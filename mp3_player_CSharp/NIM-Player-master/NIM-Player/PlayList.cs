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
    public class PlayList
    {

        public string Name { get; set; } // имя плейлиста

        public PlayList() { }
        public PlayList(string name)
        {
            Name = name;
        }

        // создали список, куда будем помещать песни -
        public List<Music> playList = new List<Music>();


        /// <summary>
        /// добавляет музыку в плейлист
        /// </summary>
        
        public void AddMusic(string filePath, string filename)
        {
            if (!playList.Exists(m => m.filePath == filePath))
            {
                playList.Add(new Music(filePath, filename));
            }
        }

     

        /// <summary>
        /// возвращает список треков
        /// </summary>
      
        public List<Music> GetMusics() // для отображения всей музыки
        {
            return playList;
        }

        /// <summary>
        /// удаляем музыку из плейлиста
        /// </summary>
     
        public void RemoveMusic(string filePath)
        {
            Music musicToRemove = playList.Find(m => m.filePath == filePath);
            if (musicToRemove != null)
            {
                playList.Remove(musicToRemove);
            }
        }
    }
}
