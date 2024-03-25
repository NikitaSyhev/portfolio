using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIM_Player
{ //класс создающий двойную панель в первой форме с надписью
    public static class FormComponent
    {
        //Элементы тоже статичные чтобы к ним обращаться
        public static Label label = new Label();
        public static Panel panel = new Panel();
        public static Panel panel2 = new Panel();
        public static Button close = new Button();

        public static void AddFormPanel(this Form form, string FormNameLabel)
        {

            Color HotTrack = ColorTranslator.FromHtml("#51913a");
            Color Dark = ColorTranslator.FromHtml("#232921");

            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);

            panel2.Dock = DockStyle.Top;
            panel2.Height = 45;
            panel2.BackColor = HotTrack;

            label.Text = FormNameLabel;
            label.ForeColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            label.Font = new Font("Cambria", 14.25f, FontStyle.Italic);
            label.AutoSize = true;
            label.Location = new Point(3, 3);

            panel2.Controls.Add(label);
            form.Controls.Add(panel2);

            panel.Dock = DockStyle.Top;
            panel.Height = 25;
            panel.BackColor = Dark;

            close.Size = new Size(25, 25);
            close.Name = "bClose";
            close.Text = "X";
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
            close.Location = new Point(form.Size.Width - close.Width - 3, -2);
            close.ForeColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            close.Font = new Font("Comic Sans", 9.75f, FontStyle.Bold);

            panel.Controls.Add(close);
            form.Controls.Add(panel);
        }

    }
}
