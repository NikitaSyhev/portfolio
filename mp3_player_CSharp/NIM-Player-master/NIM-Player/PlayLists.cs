using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIM_Player
{

    [Serializable]
    public class PlayLists
    {

        //список плейлистов
        public List<PlayList> playlists = new List<PlayList>();

        public PlayLists() { }


        /// <summary>
        /// создаем коллекцию плейлистов
        /// </summary>
        
        public void CreatePlaylist(string name)
        {
            // Проверяем, существует ли уже плейлист с таким именем
            if (playlists.Exists(p => p.Name == name))
            {
                return;
            }

            // Если плейлист с таким именем не существует, создаем новый плейлист
            playlists.Add(new PlayList(name));
        }


        /// <summary>
        /// добавляем трек в плейлист
        /// </summary>
     
        public void AddMusicToPlaylist(string playlistName, string filePath, string filename)
        {
            PlayList playlist = playlists.Find(p => p.Name == playlistName);
            if (playlist != null)
            {
                playlist.AddMusic(filePath, filename);
            }
            else
            {
                return;
            }
        }

       
        /// <summary>
        /// вывод списка плейлистов 
        /// </summary>
       
        public List<PlayList> GetAllPlaylists()
        {
            return playlists;
        }

  
    }
}
