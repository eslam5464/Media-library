using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_library
{
    class Data
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string omdbapi_key = "89e09461";
        private readonly Dictionary<string, string[]> mediaLibrary = new Dictionary<string, string[]>();
        private readonly string fileMediaName = "Media data.txt";
        private readonly string fileLocation = @Path.GetPathRoot(Environment.SystemDirectory) + @"Temp\myTV data\";
        private readonly string postersLocation = @Path.GetPathRoot(Environment.SystemDirectory) + @"Temp\myTV data\posters\";
        private string[] error = new string[2];

        internal string[] getMediaItem(string name)//method to return the array of a media name
        {
            if (mediaLibrary.ContainsKey(name))
                return mediaLibrary[name];

            else
                return new string[0];
        }

        internal Dictionary<string, string[]> getAllMediaData()//returns all the stored media data
        {
            Dictionary<string, string[]> mediaLibraryTemp = new Dictionary<string, string[]>();

            foreach (string key in mediaLibrary.Keys)
            {
                mediaLibraryTemp.Add(key.ToLower(), mediaLibrary[key]);
            }

            return mediaLibraryTemp;
        }

        internal void addMediaItem(string name, string[] data, bool save)//stores an item into the dictionary and checks if you want to save it
        {
            if (!mediaLibrary.ContainsKey(name))
            {
                mediaLibrary.Add(name, data);

                if (save)
                    saveData(name, data);
            }
        }

        internal bool checkFiles()// checks all the files that needs the data to be saved to it
        {
            if (!Directory.Exists(fileLocation))
                Directory.CreateDirectory(fileLocation);

            if (!Directory.Exists(postersLocation))
                Directory.CreateDirectory(postersLocation);

            if (!File.Exists(fileLocation + fileMediaName))
                File.Create(fileLocation + fileMediaName).Close();

            return true;
        }

        internal string[] getError()//returns the error messege that made the exception and its location
        {
            return error;
        }

        private void saveData(string Name, string[] Data)// saves the dictionary line into a txt file
        {
            if (checkFiles())
            {
                using (StreamWriter Fwrite = new StreamWriter(fileLocation + fileMediaName, true))
                {
                    Fwrite.Write(Name);

                    for (int i = 0; i < Data.Length; i++)
                        Fwrite.Write("\t" + Data[i]);

                    Fwrite.WriteLine();
                    Fwrite.Close();
                }
            }
        }

        internal void readDataFromFile()// by its name, it reads the data saved to file only once when the program loads
        {
            string[] AllsavedData, lineData, restOFdata;
            List<string> eachMediaData = new List<string>();
            using (StreamReader Fread = new StreamReader(fileLocation + fileMediaName))
            {
                AllsavedData = Fread.ReadToEnd().Split('\n');
                Array.Resize(ref AllsavedData, AllsavedData.Length - 1);
                for (int i = 0; i < AllsavedData.Length; i++)
                {
                    lineData = AllsavedData[i].Split('\t');

                    for (int j = 0; j < lineData.Length; j++)
                        eachMediaData.Add(lineData[j]);

                    string tempTXT = eachMediaData[0];
                    eachMediaData.RemoveAt(0);
                    restOFdata = eachMediaData.ToArray();
                    addMediaItem(tempTXT, restOFdata, false);
                    eachMediaData.Clear();
                }
            }
        }

        //searches the server with the specified string from the textbox
        internal async Task searchForInfo(string Name, string Link, bool Watched, string Description)
        {
            Name.Replace(" ", "+");
            try
            {
                var JsonResponse = await client.GetStringAsync(string.Format("https://www.omdbapi.com/?t={0}&y=&plot=short&r=json&apikey={1}", Name, omdbapi_key));
                try
                {
                    MediaData media = JsonConvert.DeserializeObject<MediaData>(JsonResponse);

                    if (!mediaLibrary.ContainsKey("title=" + media.Title))
                    {
                        if (media.Error == null)
                        {
                            string ratings = "[";
                            for (int i = 0; i < media.Ratings.Count; i++)
                            {
                                if (i != 0)
                                    ratings += "||";

                                JToken temp = media.Ratings[i];
                                ratings += temp["Source"] + ":";
                                ratings += temp["Value"];
                            }
                            ratings += "]";

                            string[] data = {"link=" + Link,"description=" + Description, "watched=" + Watched.ToString().ToLower(),
                            "year="+media.Year,"rated="+media.Rated,"released="+media.Released,"runtime="+media.Runtime,"genre="+media.Genre,
                            "director="+media.Director,"writer="+media.Writer,"actors="+media.Actors,"plot="+media.Plot,"language="+media.Language,
                            "country="+media.Country,"awards="+media.Awards,"poster="+media.Poster,"Ratings="+ratings,"metascore="+media.Metascore,
                            "imdbRating="+media.imdbRating,"imdbVotes="+media.imdbVotes,"imdbID="+media.imdbID,"type="+media.Type,"DVD="+media.DVD,
                            "BoxOffice="+media.BoxOffice,"production="+media.Production,"Website="+media.Website,"response="+media.Response};

                            addMediaItem("title=" + media.Title, data, true);

                            downloadImage(media.Poster, postersLocation + media.imdbID + ".jpg");

                            //openImageInWindow(postersLocation + media.imdbID + ".jpg");
                            error[0] = media.Type + " (" + media.Title + ") added sucessfully";
                            error[1] = "Attention!!...";
                        }
                        else
                        {
                            Debug.WriteLine("### Error in deserializing object => " + media.Error);
                            error[1] = "Error in deserializing object";
                            error[0] = media.Error;
                        }
                    }
                    else
                    {
                        error[1] = media.Type + " (" + media.Title + ") already exists";
                        error[0] = "Warning!!...";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("### Error in getting information => " + ex.Message);
                    error[1] = "Error in getting information";
                    error[0] = ex.Message;
                }
            }
            catch (Exception exJson)
            {
                Debug.WriteLine("### Error in connecting to server => " + exJson.Message);
                error[1] = "Error in connecting to server";
                error[0] = exJson.Message;
            }
        }

        private void downloadImage(string Link, string LocationWithPosterName)//download the poster with a specified link
        {
            if (!File.Exists(LocationWithPosterName))
                using (WebClient wclient = new WebClient())
                    wclient.DownloadFileAsync(new Uri(Link), LocationWithPosterName);
        }

        internal void openImageInWindow(string mediaName)//opens a new form with the downloaded  poster if it exists
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string tempTxt = mediaName.Split('=')[0] + "=" + textInfo.ToTitleCase(mediaName.Split('=')[1]);


            if (mediaLibrary.ContainsKey(mediaName))
            {
                string imgName = mediaLibrary[mediaName][20];

                if (File.Exists(postersLocation + imgName.Split('=')[1] + ".jpg"))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Image = Image.FromFile(postersLocation + imgName.Split('=')[1] + ".jpg");
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    Form form = new Form();
                    form.Controls.Add(pictureBox);
                    form.MaximizeBox = false;
                    form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    form.ShowDialog();
                }
            }

            if (mediaLibrary.ContainsKey(tempTxt))
            {
                string imgName = mediaLibrary[tempTxt][20];

                if (File.Exists(postersLocation + imgName.Split('=')[1] + ".jpg"))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Image = Image.FromFile(postersLocation + imgName.Split('=')[1] + ".jpg");
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    Form form = new Form();
                    form.Controls.Add(pictureBox);
                    form.MaximizeBox = false;
                    form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    form.ShowDialog();
                }
            }


        }

        internal void showImagePicBox(PictureBox SelectedPictureBox, string mediaName)// shows the downloaded poster if its downloaded at the specified picture box
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string tempTxt = mediaName.Split('=')[0] + "=" + textInfo.ToTitleCase(mediaName.Split('=')[1]);


            if (mediaLibrary.ContainsKey(mediaName))
            {
                string imgName = mediaLibrary[mediaName][20];

                if (File.Exists(postersLocation + imgName.Split('=')[1] + ".jpg"))
                    SelectedPictureBox.Image = Image.FromFile(postersLocation + imgName.Split('=')[1] + ".jpg");
            }

            if (mediaLibrary.ContainsKey(tempTxt))
            {
                string imgName = mediaLibrary[tempTxt][20];

                if (File.Exists(postersLocation + imgName.Split('=')[1] + ".jpg"))
                    SelectedPictureBox.Image = Image.FromFile(postersLocation + imgName.Split('=')[1] + ".jpg");
            }


        }

        internal int getAllDataCount()//by its name returns the number of saved keys in the dictionary
        {
            return mediaLibrary.Keys.Count;
        }

        internal string getlastAddedType()// returns the last added media type <<------ just for testing
        {
            string output = "";
            foreach (string name in mediaLibrary.Keys)
            {
                output = mediaLibrary[name][21];
            }
            return output;
        }
    }

    internal class MediaData
    {
        //the response from the get request are stored here and its place in the array are beside it

        //link description watched 3
        // year rated released runtime genre director writer actors plot 12
        //language country awards poster ratings metascore imdbRating imdbVotes imdbID Type 22
        //DVD BoxOffice Production Website Response
        public string Title { get; set; }//2
        public string Year { get; set; }//3
        public string Rated { get; set; }//4
        public string Released { get; set; }//5
        public string Runtime { get; set; }//6
        public string Genre { get; set; }//7
        public string Director { get; set; }//8
        public string Writer { get; set; }//9
        public string Actors { get; set; }//10
        public string Plot { get; set; }//11
        public string Language { get; set; }//12
        public string Country { get; set; }//13
        public string Awards { get; set; }//14
        public string Poster { get; set; }//15
        public JArray Ratings { get; set; }//16
        public string Metascore { get; set; }//17
        public string imdbRating { get; set; }//18
        public string imdbVotes { get; set; }//19
        public string imdbID { get; set; }//20
        public string Type { get; set; }//21
        public string DVD { get; set; }//22
        public string BoxOffice { get; set; }//23
        public string Production { get; set; }//24
        public string Website { get; set; }//25
        public string Response { get; set; }//26
        public string Error { get; set; }//27
    }

}
