using MediaPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NIM_Player
{
    public partial class FormInterface2 : Form
    {
        public bool down = false, //проверяет, пристыковано ли окно к нижней границе
           left = false,  //проверяет, пристыковано ли окно к левой границе
           top = false,   //проверяет, пристыковано ли окно к верхней границе
           right = false; //проверяет, пристыковано ли окно к правой границе
        public double leftlength, toplength;  //переменные нужны для вычисления смещения второго окна по отношен
        FormInterface1 form1;
        public FormInterface2()
        {

            InitializeComponent();
            if (File.Exists("data.dat")) {
                PlayLists = Serializator.Deserialize<List<PlayLists>>("data.dat");
            }
            FormComponent.panel.MouseDown += new MouseEventHandler(PanelMove_MouseDown);
            FormComponent.panel.MouseMove += new MouseEventHandler(PanelMove_MouseMove);
            FormComponent.panel.MouseUp += new MouseEventHandler(PanelMove_MouseUp);
            FormComponent.panel2.MouseDown += new MouseEventHandler(PanelMove_MouseDown);
            FormComponent.panel2.MouseMove += new MouseEventHandler(PanelMove_MouseMove);
            FormComponent.panel2.MouseUp += new MouseEventHandler(PanelMove_MouseUp);
            FormComponent.close.Click += Close_Click;
            RefreshPlaylistComboBox();
            //this.FormBorderStyle = FormBorderStyle.None;

        }
        private void labelClose_Click(object sender, EventArgs e)
        {
            Serializator.Serialize("data.dat", PlayLists);
            Application.Exit();
        }
        private void FormInterface2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(700, 100);
        }

        private void FormInterface2_LocationChanged(object sender, EventArgs e)
        {
            FormInterface1 form1 = this.Owner as FormInterface1;
            //Стыковка с нижней границей главного окна
            //Проверяем условия попадания верхней границы данного окна в пределы нижней границы главного окна
            if ((this.Top < form1.Top + form1.Height + 20) && (this.Top > form1.Top + form1.Height - 20))
            {
                //Собственно стыковка
                this.Top = form1.Top + form1.Height;
                //Запоминаем смещение левой границы данного окна и левой границы главного окна (условие ввел для фиксации переменной, чтобы больше не изменять ее во время сеанса текущей стыковки)
                if (!form1.down) form1.leftlength = this.Left - form1.Left;
                //Говорим главному окну, что произошла стыковка
                form1.down = true;
            }
            else form1.down = false;

            //Соответственно поступаем с остальными границами
            //Стыковка с верхней границей главного окна
            if ((this.Top + this.Height < form1.Top + 20) && (this.Top + this.Height > form1.Top - 20))
            {
                this.Top = form1.Top - this.Height;
                if (!form1.top) form1.leftlength = this.Left - form1.Left;
                form1.top = true;
            }
            else form1.top = false;

            //Стыковка с левой границей главного окна
            if ((this.Left + this.Width < form1.Left + 20) && (this.Left + this.Width > form1.Left - 20))
            {
                this.Left = form1.Left - this.Width;
                if (!form1.left) form1.toplength = this.Top - form1.Top;
                form1.left = true;
            }
            else form1.left = false;

            //Стыковка с правой границей главного окна
            if ((this.Left < form1.Left + form1.Width + 20) && (this.Left > form1.Left + form1.Width - 20))
            {
                this.Left = form1.Left + form1.Width;
                if (!form1.right) form1.toplength = this.Top - form1.Top;
                form1.right = true;
            }
            else form1.right = false;
        }


        //================================================Перетаскивание формы при отсутствии BorderStyle=====================================\\
        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect,
                                                          int nTopRect,
                                                          int nRightRect,
                                                          int nBottomRect,
                                                          int nWidthEllipse,
                                                          int nHeightEllipse);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        private bool Drag;
        private int MouseX;
        private int MouseY;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);



        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }



        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
            this.Opacity = 0.5;
        }
        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
                this.Opacity = 0.5;
            }
        }
        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; this.Opacity = 1; }

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //код по плейлистам Никиты

        //управление плейлистам
        PlayLists PlayLists = new PlayLists();

        //переменная для присвоедния пути выбранного музыкального файла
        static string filePath = string.Empty;
        static string fileName = string.Empty;
        Music music = new Music(filePath, fileName); // создали пустой объект класс Music

        //объект класса
        private PlayList playList = new PlayList("Пусто"); // создали объект плейлист

        private void btn_OpenMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMusic = new OpenFileDialog()
            {
                Filter = "MP3|*.mp3", //можем выбирать только mp3 файлы
                Multiselect = false, // можем выбирать только 1 трек
            };
            if (openMusic.ShowDialog() == DialogResult.OK)
            {
                //присвоили путь к выбранному файлу

                filePath = openMusic.FileName;
                fileName = Path.GetFileName(filePath);

                music = new Music(filePath, fileName); //инициализировали объект класс
                filePath = music.filePath;
                fileName = music.fileName;
                listBoxTrack.Items.Add(music);//передали объект класса Music
                //lb_playNow.Text = music.fileName;М: куда передадим инфу о песне? есть лейбл на 1 форме показывает текущую песню
            }

        }
      
       

        //метод обновляет комбобокс с плейлистами + добавляет новые в комбобокс
        private void RefreshPlaylistComboBox()
        {
            // Очищаем выпадающий список
            comboBoxlistSelection.Items.Clear();

            // Получаем список всех плейлистов
            List<PlayList> playlists = PlayLists.GetAllPlaylists();

            // Добавляем уникальные плейлисты в выпадающий список
            foreach (var playlist in playlists)
            {
                if (!comboBoxlistSelection.Items.Contains(playlist.Name))
                {
                    comboBoxlistSelection.Items.Add(playlist.Name);

                }
            }
        }


        PlayList selectedPlaylist;
        //отображает музыку из плейлиста
        void ShowAllMusicInPlayList()
        {
            // Очищаем поле отображения песен
            listBoxTrack.Items.Clear();

            // Получаем имя выбранного плейлиста из ComboBox
            string selectedPlaylistName = comboBoxlistSelection.SelectedItem?.ToString();

            // Если ничего не выбрано, выходим из метода
            if (string.IsNullOrEmpty(selectedPlaylistName))
            {
                return;
            }


            // Находим выбранный плейлист
            //GetAllPlaylists - список всех плейлистов
            //FirstOrDefault - возвращает первый элемент из условия p => p.Name == selectedPlaylistName
            selectedPlaylist = PlayLists.GetAllPlaylists().FirstOrDefault(p => p.Name == selectedPlaylistName);
            Program.f1.CreateplayListPlayer(selectedPlaylist.GetMusics()); // Илья разбирается
            // Если плейлист найден, отображаем его песни в ЛИСТ БОКС
            if (selectedPlaylist != null)
            {
                foreach (var music in selectedPlaylist.GetMusics())
                {

                    //добавляем музыку в листбокс
                    listBoxTrack.Items.Add(music);
                }
            }
        }

        private void cb_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAllMusicInPlayList();
        }

        private void listBoxTrack_DoubleClick(object sender, EventArgs e)
        {
            Music music = listBoxTrack.SelectedItem as Music;
            string path = music.filePath;
            Program.f1.playtrack(path);
        }
        /// <summary>
        /// добавления трека в плейлист
        /// </summary>

        private void btn_addToPlayList_Click(object sender, EventArgs e)
        {
            string playListName = textBoxListName.Text;

            //сохранили выбранную музыку в список List<Music> selectedSongs
            List<Music> selectedSongs = new List<Music>();
            foreach (var selectedItem in listBoxTrack.Items)
            {
                Music selectedMusic = (Music)selectedItem;
                selectedSongs.Add(selectedMusic);
            }
            // Проверяем, существует ли уже плейлист с таким именем
            //метод FirstOrDefault - ищет первый элемент, удовлетворяющий условию p => p.Name == playListName ( равно ли имя плейлиста переданному )
            //если плейлист найден - добавляем трек, если нет - возвращает null
            PlayList playlist = PlayLists.GetAllPlaylists().FirstOrDefault(p => p.Name == playListName);
            if (playListName == String.Empty) // если мы не назвали плейлист выходит сообщение
            {
                MessageBox.Show("Назовите плейлист!");
            }
            else if (playlist == null)
            {
                // Создаем новый плейлист, если плейлист с таким именем не существует
                PlayLists.CreatePlaylist(playListName); //создали список плейлистов
                RefreshPlaylistComboBox(); // Обновляем выпадающий список плейлистов
            }
            else
            {
                // Проверяем, содержит ли плейлист уже выбранную музыку
                //метод Any проверяет условия лямбды ( если переданный путь к файлу уже существует в плейлисте или нет)
                foreach (var item in selectedSongs)
                {
                    if (playlist.GetMusics().Any(m => m.filePath == item.filePath))
                    {
                        MessageBox.Show($"{item.fileName} уже добавлен в плейлист {playListName}");
                    }
                }
            }
            //добавление выбранной музыки в плейлист
            foreach (var item in selectedSongs)
            {
                PlayLists.AddMusicToPlaylist(playListName, item.filePath, item.fileName);
            }

            // Очищаем поле ввода названия плейлиста
            textBoxListName.Clear();

        }
       
        /// <summary>
        /// метод удаления трека из плейлиста
        /// </summary>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //проверка на то, что выбран трек в листбокс
            if (listBoxTrack.SelectedItem != null)
            {
                Music selectedMusic = (Music)listBoxTrack.SelectedItem;

                listBoxTrack.Items.Remove(selectedMusic);
                //пробегаем по коллекции и удаляем выбранную музыку
                foreach (var item in PlayLists.GetAllPlaylists())
                {

                    if (item.Name == comboBoxlistSelection.Text)
                    {
                        item.RemoveMusic(selectedMusic.filePath);
                    }

                }
            }
            //сообщение, если треу не выбран
            else
            {
                MessageBox.Show("Выберите трек для удаления");
            }
        }

    }

}



