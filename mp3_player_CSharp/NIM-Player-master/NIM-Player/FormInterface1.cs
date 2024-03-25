using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIM_Player
{
    public partial class FormInterface1 : Form
    {
        public bool down = false, //проверяет, пристыковано ли окно к нижней границе
           left = false,  //проверяет, пристыковано ли окно к левой границе
           top = false,   //проверяет, пристыковано ли окно к верхней границе
           right = false; //проверяет, пристыковано ли окно к правой границе
        public double leftlength, toplength;  //переменные нужны для вычисления смещения второго окна по отношению к главному

        FormInterface2 form2;//Создаем объект второго окна
        //Создание класса PlayerWMP через вируальный класс Audio
        Audio player = new PlayerWMP();
        public FormInterface1()
        {
            Program.f1 = this;
            InitializeComponent();
            form2 = new FormInterface2();
            form2.Owner = this;
            form2.Show();

            this.FormBorderStyle = FormBorderStyle.None;//убираем бордер
            this.AddFormPanel("NIM Player");
            FormComponent.panel.MouseDown += new MouseEventHandler(PanelMove_MouseDown);
            FormComponent.panel.MouseMove += new MouseEventHandler(PanelMove_MouseMove);
            FormComponent.panel.MouseUp += new MouseEventHandler(PanelMove_MouseUp);
            FormComponent.panel2.MouseDown += new MouseEventHandler(PanelMove_MouseDown);
            FormComponent.panel2.MouseMove += new MouseEventHandler(PanelMove_MouseMove);
            FormComponent.panel2.MouseUp += new MouseEventHandler(PanelMove_MouseUp);
            FormComponent.close.Click += Close_Click;
        }
        private void FormInterface1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(180, 100);
        }
        private void FormInterface1_LocationChanged(object sender, EventArgs e)
        {
            //Стыковка с нижней границей главного окна
            if (down)
            {
                //Второе окно оставляем у нижней границы главного окна путем смещения координаты верхней границы на значение высоты главного окна
                form2.Top = this.Top + this.Height;
                //А левую границу второго окна смещаем относительно левой границы главного на величину leftlength, установленную в момент стыковки
                form2.Left = (int)this.Left + (int)leftlength;
            }

            //Соответственно поступаем и при стыковке с другими границами
            //Стыковка с верхней границей главного окна
            if (top)
            {
                form2.Top = this.Top - form2.Height;
                form2.Left = (int)this.Left + (int)leftlength;
            }

            //Стыковка с левой границей главного окна
            if (left)
            {
                form2.Left = this.Left - form2.Width;
                form2.Top = (int)this.Top + (int)toplength;
            }

            //Стыковка с правой границей главного окна
            if (right)
            {
                form2.Left = this.Left + this.Width;
                form2.Top = (int)this.Top + (int)toplength;
            }
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
        //код Ильи для проигрывания музыки

        string path = string.Empty;
        public void b_play_Click(object sender, EventArgs e)
        {
            if (path != string.Empty)
            {
                playtrack(path);
            }
        }
        public void playtrack(string filepath) {
            if (File.Exists(filepath))
            {
                player.Play(filepath);
                path = filepath;
                labelTrack.Text = player.Track;
                timer1.Start();
            }
            else {
                MessageBox.Show("Файла не существует");
            }
        }


        private void b_pause_Click(object sender, EventArgs e)
        {
            player.Pause();
            timer1.Stop();
        }
        public void CreateplayListPlayer(List<Music> pl) {
            if (pl.Count > 0)
            {
                player.CreatePlaylist(pl);
                timer1.Start();
            }
        }

        private void FormInterface1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            player.Close();
        }

        private void GTrackBar_Scroll(object sender, ScrollEventArgs e)
        {
            player.TrackBar(GTrackBar.Value);
        }

        //======== коментарий для команды===========
        // без timera обновление времени и трек бара невозможно, для кооректной работы
        // предлогаю принять без изменений данный метод
        public void timer1_Tick(object sender, EventArgs e)
        {
            //задаем длинну трекбара (вне этого метода , данное приравнивание будет возвращать 0)
            GTrackBar.MaxValue = (int)player.FileDuration;
            //выводим полное время трека для отображения пользователю
            labelTotal.Text = player.TimeTrack(GTrackBar.MaxValue);
            //меняем каждую секунду значения трек бара для отображения пользователю
            GTrackBar.Value = player.trackPosition;
            //выводим прошедшее время трека для отображения пользователю
            labelRemainder.Text = player.TimeTrack(GTrackBar.Value);
            labelTrack.Text =player.Track;
        }
        //установка параметров громкости
        private void tbar_volume_Scroll(object sender, ScrollEventArgs e)
        {
            player.Volume(gTrackBarVolume.Value);
        }


    }
}

