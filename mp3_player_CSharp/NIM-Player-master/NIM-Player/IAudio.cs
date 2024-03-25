using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace NIM_Player
{
    //вируальный класс, как основа для интеграции сторонних библиотек
    internal abstract class Audio
    {
        /// <summary>
        /// возвращает текущую позицию в потоке
        /// </summary>
        public virtual int trackPosition { get; set; }
        /// <summary>
        /// возвращает длинну трека после его запуска
        /// </summary>
        public virtual int FileDuration { get; set; }
        /// <summary>
        /// возвращает название трека
        /// </summary>
        public virtual string Track { get; set; }
        public Audio() { }
        /// <summary>
        ///метод для запуска проигрывателя, принимает путь к файлу
        /// </summary>
        public virtual void Play(string nameFile) {}
        /// <summary>
        ///смещает поток на передданную точку
        /// </summary>
        public virtual void TrackBar(int ValueTrackBar) { }
        /// <summary>
        ///Останавливает воспроизведение трека
        /// </summary>
        public virtual void Pause() { }

        /// <summary>
        /// Воспроизводит следующий по порядку трек плейлиста
        /// Если трек последний , то воспроизводит первый из списка
        /// </summary>
        public virtual void NextTrack() { }
        /// <summary>
        /// Принимает плейлист для проигрывания
        /// </summary>
        public virtual void CreatePlaylist(List<Music> playList){ }
        /// <summary>
        ///конвертирует длинну трека в строковое значение времени
        /// </summary>
        public virtual string TimeTrack(int LengthTrack) { return "0:0"; }
        /// <summary>
        ///меняет громкость звука на входящее значение : от 0 до 100
        /// </summary>
        public virtual void  Volume(int volume) { }
        /// <summary>
        ///закрывает плеер
        /// </summary>
        public virtual void Close() { }
    }
    //класс основанный на библиотекe WindowsMediaPlayer
    internal class PlayerWMP : Audio {

        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        private bool pausePlay = true;
        
        public override int trackPosition { get { return (int)player.controls.currentPosition; }}
        
        public override int FileDuration { get { return (int)player.controls.currentItem.duration; } }

        private List<Music> _playerPlayList;
        
        public override string Track { get { return player.currentMedia.name; } set{ } }
        private string trackPath { get; set; }
        public PlayerWMP() { }

        public override void Play(string nameFile)
        {
            if (trackPath != nameFile){
                player.URL = nameFile;
                Track = nameFile.Substring(nameFile.LastIndexOf('\\') + 1);
                trackPath = nameFile;
                player.controls.play();
                pausePlay = true;
            }
            else
                if (!pausePlay)
                {
                    player.controls.play();
                    pausePlay = true;
                }
        }
        public override void CreatePlaylist(List<Music> playList) {
            _playerPlayList = playList;
            IWMPPlaylist playlist = player.playlistCollection.newPlaylist("myplaylist");
            IWMPMedia media;
                foreach (Music file in playList)
                {
                    media = player.newMedia(file.filePath);
                    playlist.appendItem(media);
                }           
            player.currentPlaylist = playlist;
           
        }
        
        public override void Pause() {            
            if (pausePlay)
            {
                player.controls.pause();
                pausePlay = false;
            }
        }
        
        public override void TrackBar(int valueTrackBar) {
            player.controls.currentPosition = valueTrackBar;
        }
        public override string TimeTrack(int LengthTrack) {
            int m = LengthTrack / 60;
            int s = LengthTrack - m*60;
            string min = m > 10 ? m.ToString() : $"0{m}";
            string sec = s > 10 ? s.ToString() : $"0{s}";
            return $"{min}:{sec}";
        }
        public  override void Volume(int volume)
        {
            if (volume <0) player.settings.volume = 0;
            else if (volume > 100) player.settings.volume = 100;
            else player.settings.volume = volume;
            
        }
        public override void Close() {
            player.close();
        }
    }
}
