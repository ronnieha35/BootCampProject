using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp_OOP
{
    public class VideoPlayer
    {
        private readonly List<IPlayable> _videoList; // Contiene los videos cargados
        private int _currentIndex; // Índice del video actual
        private bool _isPlaying; // Estado de reproducción
        private string _collectionName; // Nombre de la colección de videos

        public IPlayable CurrentVideo
        {
            get
            {
                if (_videoList.Any() && _currentIndex >= 0 && _currentIndex < _videoList.Count)
                {
                    return _videoList[_currentIndex];
                }
                return null;
            }
        }

        public VideoPlayer()
        {
            _videoList = new List<IPlayable>();
            _currentIndex = -1;
            _isPlaying = false;
            _collectionName = "No Collection Loaded";
        }

        public void LoadVideos(IEnumerable<IPlayable> videos, string name)
        {
            if (videos == null)
                throw new ArgumentNullException(nameof(videos));

            Stop();
            _videoList.Clear();
        }

        private void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
