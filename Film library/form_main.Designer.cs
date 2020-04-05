namespace Film_library
{
    partial class form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.tabgroup_main = new System.Windows.Forms.TabControl();
            this.tab_main = new System.Windows.Forms.TabPage();
            this.listbx_main_selectedinfo = new System.Windows.Forms.ListBox();
            this.listbx_main_searchResults = new System.Windows.Forms.ListBox();
            this.btn_main_search = new System.Windows.Forms.Button();
            this.tb_main_search = new System.Windows.Forms.TextBox();
            this.progbar_searching = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_searchBy = new System.Windows.Forms.ComboBox();
            this.pic_main_searchedPoster = new System.Windows.Forms.PictureBox();
            this.tab_edit = new System.Windows.Forms.TabPage();
            this.tab_save = new System.Windows.Forms.TabPage();
            this.pic_save_loadingAnimation = new System.Windows.Forms.PictureBox();
            this.tb_save_description = new System.Windows.Forms.TextBox();
            this.lbl_save_description = new System.Windows.Forms.Label();
            this.btn_save_add = new System.Windows.Forms.Button();
            this.lbl_save_link = new System.Windows.Forms.Label();
            this.tb_save_link = new System.Windows.Forms.TextBox();
            this.chkbx_save_watched = new System.Windows.Forms.CheckBox();
            this.tb_save_name = new System.Windows.Forms.TextBox();
            this.lbl_save_name = new System.Windows.Forms.Label();
            this.tabgroup_main.SuspendLayout();
            this.tab_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_main_searchedPoster)).BeginInit();
            this.tab_save.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_save_loadingAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabgroup_main
            // 
            this.tabgroup_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabgroup_main.Controls.Add(this.tab_main);
            this.tabgroup_main.Controls.Add(this.tab_edit);
            this.tabgroup_main.Controls.Add(this.tab_save);
            this.tabgroup_main.Location = new System.Drawing.Point(9, 0);
            this.tabgroup_main.Margin = new System.Windows.Forms.Padding(10);
            this.tabgroup_main.Name = "tabgroup_main";
            this.tabgroup_main.SelectedIndex = 0;
            this.tabgroup_main.Size = new System.Drawing.Size(499, 312);
            this.tabgroup_main.TabIndex = 0;
            // 
            // tab_main
            // 
            this.tab_main.Controls.Add(this.listbx_main_selectedinfo);
            this.tab_main.Controls.Add(this.listbx_main_searchResults);
            this.tab_main.Controls.Add(this.btn_main_search);
            this.tab_main.Controls.Add(this.tb_main_search);
            this.tab_main.Controls.Add(this.progbar_searching);
            this.tab_main.Controls.Add(this.label2);
            this.tab_main.Controls.Add(this.cbx_searchBy);
            this.tab_main.Controls.Add(this.pic_main_searchedPoster);
            this.tab_main.Location = new System.Drawing.Point(4, 22);
            this.tab_main.Name = "tab_main";
            this.tab_main.Size = new System.Drawing.Size(491, 286);
            this.tab_main.TabIndex = 2;
            this.tab_main.Text = "Main";
            this.tab_main.UseVisualStyleBackColor = true;
            // 
            // listbx_main_selectedinfo
            // 
            this.listbx_main_selectedinfo.FormattingEnabled = true;
            this.listbx_main_selectedinfo.Location = new System.Drawing.Point(260, 153);
            this.listbx_main_selectedinfo.Name = "listbx_main_selectedinfo";
            this.listbx_main_selectedinfo.Size = new System.Drawing.Size(228, 134);
            this.listbx_main_selectedinfo.TabIndex = 7;
            this.listbx_main_selectedinfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listbx_main_selectedinfo_MouseDoubleClick);
            // 
            // listbx_main_searchResults
            // 
            this.listbx_main_searchResults.FormattingEnabled = true;
            this.listbx_main_searchResults.Location = new System.Drawing.Point(3, 153);
            this.listbx_main_searchResults.Name = "listbx_main_searchResults";
            this.listbx_main_searchResults.Size = new System.Drawing.Size(251, 134);
            this.listbx_main_searchResults.Sorted = true;
            this.listbx_main_searchResults.TabIndex = 6;
            this.listbx_main_searchResults.SelectedIndexChanged += new System.EventHandler(this.listbx_main_searchResults_SelectedIndexChanged);
            // 
            // btn_main_search
            // 
            this.btn_main_search.Location = new System.Drawing.Point(106, 121);
            this.btn_main_search.Name = "btn_main_search";
            this.btn_main_search.Size = new System.Drawing.Size(75, 23);
            this.btn_main_search.TabIndex = 5;
            this.btn_main_search.Text = "Search";
            this.btn_main_search.UseVisualStyleBackColor = true;
            this.btn_main_search.Click += new System.EventHandler(this.btn_main_search_Click);
            // 
            // tb_main_search
            // 
            this.tb_main_search.Location = new System.Drawing.Point(14, 35);
            this.tb_main_search.Name = "tb_main_search";
            this.tb_main_search.Size = new System.Drawing.Size(240, 20);
            this.tb_main_search.TabIndex = 4;
            // 
            // progbar_searching
            // 
            this.progbar_searching.Location = new System.Drawing.Point(14, 82);
            this.progbar_searching.MarqueeAnimationSpeed = 50;
            this.progbar_searching.Name = "progbar_searching";
            this.progbar_searching.Size = new System.Drawing.Size(364, 23);
            this.progbar_searching.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progbar_searching.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search by:";
            // 
            // cbx_searchBy
            // 
            this.cbx_searchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_searchBy.FormattingEnabled = true;
            this.cbx_searchBy.Items.AddRange(new object[] {
            "ID of imdb",
            "Name",
            "year"});
            this.cbx_searchBy.Location = new System.Drawing.Point(260, 35);
            this.cbx_searchBy.Name = "cbx_searchBy";
            this.cbx_searchBy.Size = new System.Drawing.Size(109, 21);
            this.cbx_searchBy.TabIndex = 1;
            // 
            // pic_main_searchedPoster
            // 
            this.pic_main_searchedPoster.Location = new System.Drawing.Point(386, 5);
            this.pic_main_searchedPoster.Margin = new System.Windows.Forms.Padding(5);
            this.pic_main_searchedPoster.Name = "pic_main_searchedPoster";
            this.pic_main_searchedPoster.Size = new System.Drawing.Size(100, 100);
            this.pic_main_searchedPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_main_searchedPoster.TabIndex = 0;
            this.pic_main_searchedPoster.TabStop = false;
            this.pic_main_searchedPoster.Click += new System.EventHandler(this.pic_main_searchedPoster_Click);
            this.pic_main_searchedPoster.MouseEnter += new System.EventHandler(this.pic_main_searchedPoster_MouseEnter);
            // 
            // tab_edit
            // 
            this.tab_edit.Location = new System.Drawing.Point(4, 22);
            this.tab_edit.Name = "tab_edit";
            this.tab_edit.Padding = new System.Windows.Forms.Padding(3);
            this.tab_edit.Size = new System.Drawing.Size(491, 286);
            this.tab_edit.TabIndex = 1;
            this.tab_edit.Text = "Edit";
            this.tab_edit.UseVisualStyleBackColor = true;
            // 
            // tab_save
            // 
            this.tab_save.Controls.Add(this.pic_save_loadingAnimation);
            this.tab_save.Controls.Add(this.tb_save_description);
            this.tab_save.Controls.Add(this.lbl_save_description);
            this.tab_save.Controls.Add(this.btn_save_add);
            this.tab_save.Controls.Add(this.lbl_save_link);
            this.tab_save.Controls.Add(this.tb_save_link);
            this.tab_save.Controls.Add(this.chkbx_save_watched);
            this.tab_save.Controls.Add(this.tb_save_name);
            this.tab_save.Controls.Add(this.lbl_save_name);
            this.tab_save.Location = new System.Drawing.Point(4, 22);
            this.tab_save.Name = "tab_save";
            this.tab_save.Padding = new System.Windows.Forms.Padding(3);
            this.tab_save.Size = new System.Drawing.Size(491, 286);
            this.tab_save.TabIndex = 0;
            this.tab_save.Text = "Save";
            this.tab_save.UseVisualStyleBackColor = true;
            // 
            // pic_save_loadingAnimation
            // 
            this.pic_save_loadingAnimation.Image = ((System.Drawing.Image)(resources.GetObject("pic_save_loadingAnimation.Image")));
            this.pic_save_loadingAnimation.Location = new System.Drawing.Point(386, 202);
            this.pic_save_loadingAnimation.Name = "pic_save_loadingAnimation";
            this.pic_save_loadingAnimation.Size = new System.Drawing.Size(75, 75);
            this.pic_save_loadingAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_save_loadingAnimation.TabIndex = 13;
            this.pic_save_loadingAnimation.TabStop = false;
            this.pic_save_loadingAnimation.Visible = false;
            // 
            // tb_save_description
            // 
            this.tb_save_description.Location = new System.Drawing.Point(75, 112);
            this.tb_save_description.Multiline = true;
            this.tb_save_description.Name = "tb_save_description";
            this.tb_save_description.Size = new System.Drawing.Size(400, 61);
            this.tb_save_description.TabIndex = 12;
            // 
            // lbl_save_description
            // 
            this.lbl_save_description.AutoSize = true;
            this.lbl_save_description.Location = new System.Drawing.Point(6, 115);
            this.lbl_save_description.Name = "lbl_save_description";
            this.lbl_save_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_save_description.TabIndex = 11;
            this.lbl_save_description.Text = "Description:";
            // 
            // btn_save_add
            // 
            this.btn_save_add.Location = new System.Drawing.Point(221, 247);
            this.btn_save_add.Name = "btn_save_add";
            this.btn_save_add.Size = new System.Drawing.Size(75, 23);
            this.btn_save_add.TabIndex = 7;
            this.btn_save_add.Text = "Add";
            this.btn_save_add.UseVisualStyleBackColor = true;
            this.btn_save_add.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_save_link
            // 
            this.lbl_save_link.AutoSize = true;
            this.lbl_save_link.Location = new System.Drawing.Point(6, 70);
            this.lbl_save_link.Name = "lbl_save_link";
            this.lbl_save_link.Size = new System.Drawing.Size(30, 13);
            this.lbl_save_link.TabIndex = 6;
            this.lbl_save_link.Text = "Link:";
            // 
            // tb_save_link
            // 
            this.tb_save_link.Location = new System.Drawing.Point(75, 67);
            this.tb_save_link.Name = "tb_save_link";
            this.tb_save_link.Size = new System.Drawing.Size(400, 20);
            this.tb_save_link.TabIndex = 5;
            // 
            // chkbx_save_watched
            // 
            this.chkbx_save_watched.AutoSize = true;
            this.chkbx_save_watched.Location = new System.Drawing.Point(405, 19);
            this.chkbx_save_watched.Name = "chkbx_save_watched";
            this.chkbx_save_watched.Size = new System.Drawing.Size(70, 17);
            this.chkbx_save_watched.TabIndex = 4;
            this.chkbx_save_watched.Text = "Watched";
            this.chkbx_save_watched.UseVisualStyleBackColor = true;
            // 
            // tb_save_name
            // 
            this.tb_save_name.Location = new System.Drawing.Point(75, 17);
            this.tb_save_name.Name = "tb_save_name";
            this.tb_save_name.Size = new System.Drawing.Size(324, 20);
            this.tb_save_name.TabIndex = 3;
            // 
            // lbl_save_name
            // 
            this.lbl_save_name.AutoSize = true;
            this.lbl_save_name.Location = new System.Drawing.Point(6, 20);
            this.lbl_save_name.Name = "lbl_save_name";
            this.lbl_save_name.Size = new System.Drawing.Size(41, 13);
            this.lbl_save_name.TabIndex = 2;
            this.lbl_save_name.Text = "Name: ";
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(517, 321);
            this.Controls.Add(this.tabgroup_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_main";
            this.Text = "Film library";
            this.Load += new System.EventHandler(this.form_main_Load);
            this.tabgroup_main.ResumeLayout(false);
            this.tab_main.ResumeLayout(false);
            this.tab_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_main_searchedPoster)).EndInit();
            this.tab_save.ResumeLayout(false);
            this.tab_save.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_save_loadingAnimation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabgroup_main;
        private System.Windows.Forms.TabPage tab_save;
        private System.Windows.Forms.TextBox tb_save_name;
        private System.Windows.Forms.Label lbl_save_name;
        private System.Windows.Forms.TabPage tab_edit;
        private System.Windows.Forms.CheckBox chkbx_save_watched;
        private System.Windows.Forms.Button btn_save_add;
        private System.Windows.Forms.Label lbl_save_link;
        private System.Windows.Forms.TextBox tb_save_link;
        private System.Windows.Forms.TextBox tb_save_description;
        private System.Windows.Forms.Label lbl_save_description;
        private System.Windows.Forms.TabPage tab_main;
        private System.Windows.Forms.PictureBox pic_save_loadingAnimation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_searchBy;
        private System.Windows.Forms.PictureBox pic_main_searchedPoster;
        private System.Windows.Forms.ProgressBar progbar_searching;
        private System.Windows.Forms.TextBox tb_main_search;
        private System.Windows.Forms.Button btn_main_search;
        private System.Windows.Forms.ListBox listbx_main_searchResults;
        private System.Windows.Forms.ListBox listbx_main_selectedinfo;
    }
}

