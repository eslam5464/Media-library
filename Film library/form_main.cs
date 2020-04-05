using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Film_library
{
    public partial class form_main : Form
    {

        private static Data data = new Data();
        private Dictionary<string, string[]> mediaLibrary = data.getAllMediaData();
        private string mainImageName = "";
        //private int selectedItemIndexInLibrary = -1;

        public form_main()
        {
            InitializeComponent();
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            startloading();

            await data.searchForInfo(tb_save_name.Text, tb_save_link.Text, chkbx_save_watched.Checked, tb_save_description.Text);

            string[] error = data.getError();

            if (error[1] == "Attention!!...")
                MessageBox.Show(error[0], error[1], MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show(error[0], error[1], MessageBoxButtons.OK, MessageBoxIcon.Warning);

            endloading();
        }

        private void startloading()
        {
            if (!pic_save_loadingAnimation.Visible)
                pic_save_loadingAnimation.Visible = true;
        }

        private void endloading()
        {
            if (pic_save_loadingAnimation.Visible)
                pic_save_loadingAnimation.Visible = false;
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            data.checkFiles();
            data.readDataFromFile();
            progbar_searching.Maximum = data.getAllDataCount();
        }

        private void btn_main_search_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            mediaLibrary = data.getAllMediaData();

            progbar_searching.Maximum = mediaLibrary.Keys.Count;
            progbar_searching.Value = 0;

            foreach (string txt in mediaLibrary.Keys)
            {
                temp.Add(txt.Split('=')[1].ToLower());
            }
            string[] allKeys = temp.ToArray();

            if (cbx_searchBy.SelectedIndex != -1 && cbx_searchBy.SelectedItem.ToString() == "Name")
            {
                listbx_main_searchResults.Items.Clear();
                for (int i = 0; i < mediaLibrary.Keys.Count; i++)
                {
                    if (allKeys[i].IndexOf(tb_main_search.Text.ToLower()) > -1 && !listbx_main_searchResults.Items.Contains(allKeys[i]))
                    {
                        listbx_main_searchResults.Items.Add(allKeys[i]);
                    }

                    if (progbar_searching.Value < progbar_searching.Maximum && i != 0)
                        progbar_searching.Value = Convert.ToInt32(mediaLibrary.Keys.Count / i);
                }
            }
        }

        private void listbx_main_searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbx_main_searchResults.SelectedIndex != -1)
            {
                string selectedItem = listbx_main_searchResults.SelectedItem.ToString();
                if (mediaLibrary.ContainsKey("title=" + selectedItem))
                {
                    listbx_main_selectedinfo.Items.Clear();
                    string[] allData = mediaLibrary["title=" + selectedItem];
                    data.showImagePicBox(pic_main_searchedPoster, "title=" + selectedItem);
                    mainImageName = "title=" + selectedItem;

                    foreach (string item in allData)
                    {
                        listbx_main_selectedinfo.Items.Add(item.Split('=')[0] + " = " + item.Split('=')[1]);
                    }
                }
            }
        }

        private void listbx_main_selectedinfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listbx_main_selectedinfo.SelectedIndex > -1)
            {
                string[] txt = listbx_main_selectedinfo.SelectedItem.ToString().Split('=');

                if (txt.Length > 1)
                    Clipboard.SetText(txt[1]);
            }
        }

        private void pic_main_searchedPoster_MouseEnter(object sender, EventArgs e)
        {
            if (pic_main_searchedPoster.Image != null)
            {
                pic_main_searchedPoster.Cursor = Cursors.Hand;
            }
        }

        private void pic_main_searchedPoster_Click(object sender, EventArgs e)
        {
            if (pic_main_searchedPoster.Image != null)
            {
                data.openImageInWindow(mainImageName);
            }
        }
    }
}
