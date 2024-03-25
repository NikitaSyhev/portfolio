using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NIM_Player
{
    [Serializable]
    public class Music
    {
        static private string FilePath;
        public string filePath { get; }
        public string fileName { get; }
        private string FileName = Path.GetFileName(FilePath);

        

        public Music() { }

        public Music(string filePath, string fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;

        }
    }
}
