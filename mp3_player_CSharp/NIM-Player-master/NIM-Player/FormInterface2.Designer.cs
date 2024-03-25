namespace NIM_Player
{
    partial class FormInterface2
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
            this.gradientPanel1 = new NIM_Player.GradientPanel();
            this.labelListSelection = new System.Windows.Forms.Label();
            this.labelListName = new System.Windows.Forms.Label();
            this.comboBoxlistSelection = new System.Windows.Forms.ComboBox();
            this.textBoxListName = new System.Windows.Forms.TextBox();
            this.buttonSaveList = new NIM_Player.ButtonPro();
            this.buttonDelete = new NIM_Player.ButtonPro();
            this.buttonAdd = new NIM_Player.ButtonPro();
            this.listBoxTrack = new System.Windows.Forms.ListBox();
            this.labelClose = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorBottom = System.Drawing.Color.DarkGreen;
            this.gradientPanel1.ColorTop = System.Drawing.Color.Black;
            this.gradientPanel1.Controls.Add(this.labelListSelection);
            this.gradientPanel1.Controls.Add(this.labelListName);
            this.gradientPanel1.Controls.Add(this.comboBoxlistSelection);
            this.gradientPanel1.Controls.Add(this.textBoxListName);
            this.gradientPanel1.Controls.Add(this.buttonSaveList);
            this.gradientPanel1.Controls.Add(this.buttonDelete);
            this.gradientPanel1.Controls.Add(this.buttonAdd);
            this.gradientPanel1.Controls.Add(this.listBoxTrack);
            this.gradientPanel1.Controls.Add(this.labelClose);
            this.gradientPanel1.Location = new System.Drawing.Point(-3, -3);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(567, 631);
            this.gradientPanel1.TabIndex = 0;
            // 
            // labelListSelection
            // 
            this.labelListSelection.AutoSize = true;
            this.labelListSelection.BackColor = System.Drawing.Color.Black;
            this.labelListSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelListSelection.ForeColor = System.Drawing.Color.Chartreuse;
            this.labelListSelection.Location = new System.Drawing.Point(296, 57);
            this.labelListSelection.Name = "labelListSelection";
            this.labelListSelection.Size = new System.Drawing.Size(164, 20);
            this.labelListSelection.TabIndex = 7;
            this.labelListSelection.Text = "выберите плейлист ";
            // 
            // labelListName
            // 
            this.labelListName.AutoSize = true;
            this.labelListName.BackColor = System.Drawing.Color.Black;
            this.labelListName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelListName.ForeColor = System.Drawing.Color.Chartreuse;
            this.labelListName.Location = new System.Drawing.Point(48, 57);
            this.labelListName.Name = "labelListName";
            this.labelListName.Size = new System.Drawing.Size(216, 18);
            this.labelListName.TabIndex = 6;
            this.labelListName.Text = "введите название плейлиста";
            // 
            // comboBoxlistSelection
            // 
            this.comboBoxlistSelection.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.comboBoxlistSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxlistSelection.ForeColor = System.Drawing.Color.Black;
            this.comboBoxlistSelection.FormattingEnabled = true;
            this.comboBoxlistSelection.ItemHeight = 29;
            this.comboBoxlistSelection.Location = new System.Drawing.Point(290, 83);
            this.comboBoxlistSelection.Name = "comboBoxlistSelection";
            this.comboBoxlistSelection.Size = new System.Drawing.Size(224, 37);
            this.comboBoxlistSelection.TabIndex = 5;
            this.comboBoxlistSelection.SelectedIndexChanged += new System.EventHandler(this.cb_List_SelectedIndexChanged);
            // 
            // textBoxListName
            // 
            this.textBoxListName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBoxListName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxListName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxListName.Location = new System.Drawing.Point(52, 83);
            this.textBoxListName.Multiline = true;
            this.textBoxListName.Name = "textBoxListName";
            this.textBoxListName.Size = new System.Drawing.Size(225, 49);
            this.textBoxListName.TabIndex = 4;
            // 
            // buttonSaveList
            // 
            this.buttonSaveList.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonSaveList.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.buttonSaveList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSaveList.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonSaveList.BorderRadius = 20;
            this.buttonSaveList.BorderSize = 0;
            this.buttonSaveList.FlatAppearance.BorderSize = 0;
            this.buttonSaveList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveList.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveList.ForeColor = System.Drawing.Color.White;
            this.buttonSaveList.Location = new System.Drawing.Point(363, 537);
            this.buttonSaveList.Name = "buttonSaveList";
            this.buttonSaveList.Size = new System.Drawing.Size(160, 49);
            this.buttonSaveList.TabIndex = 3;
            this.buttonSaveList.Text = "сохранить плейлист";
            this.buttonSaveList.TextColor = System.Drawing.Color.White;
            this.buttonSaveList.UseVisualStyleBackColor = false;
            this.buttonSaveList.Click += new System.EventHandler(this.btn_addToPlayList_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonDelete.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.buttonDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonDelete.BorderRadius = 20;
            this.buttonDelete.BorderSize = 0;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(210, 537);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(146, 49);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "удалить трек";
            this.buttonDelete.TextColor = System.Drawing.Color.White;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonAdd.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.buttonAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonAdd.BorderRadius = 20;
            this.buttonAdd.BorderSize = 0;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(51, 537);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(152, 49);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "добавить трек";
            this.buttonAdd.TextColor = System.Drawing.Color.White;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.btn_OpenMusic_Click);
            // 
            // listBoxTrack
            // 
            this.listBoxTrack.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.listBoxTrack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxTrack.DisplayMember = "music.fileName";
            this.listBoxTrack.FormattingEnabled = true;
            this.listBoxTrack.ItemHeight = 20;
            this.listBoxTrack.Location = new System.Drawing.Point(52, 166);
            this.listBoxTrack.Name = "listBoxTrack";
            this.listBoxTrack.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTrack.Size = new System.Drawing.Size(462, 340);
            this.listBoxTrack.TabIndex = 2;
            this.listBoxTrack.ValueMember = "music.filePath";
            this.listBoxTrack.DoubleClick += new System.EventHandler(this.listBoxTrack_DoubleClick);
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClose.Location = new System.Drawing.Point(530, 9);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(30, 29);
            this.labelClose.TabIndex = 0;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // FormInterface2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 625);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(562, 625);
            this.MinimumSize = new System.Drawing.Size(562, 625);
            this.Name = "FormInterface2";
            this.Text = "FormInterface2";
            this.Load += new System.EventHandler(this.FormInterface2_Load);
            this.LocationChanged += new System.EventHandler(this.FormInterface2_LocationChanged);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label labelClose;
        private ButtonPro buttonDelete;
        private ButtonPro buttonAdd;
        private System.Windows.Forms.ListBox listBoxTrack;
        private ButtonPro buttonSaveList;
        private System.Windows.Forms.ComboBox comboBoxlistSelection;
        private System.Windows.Forms.TextBox textBoxListName;
        private System.Windows.Forms.Label labelListSelection;
        private System.Windows.Forms.Label labelListName;
    }
}