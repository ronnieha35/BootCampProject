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

            StopVideo();
            _videoList.Clear();
            _videoList.AddRange(videos);
            _collectionName = string.IsNullOrWhiteSpace(name) ? "Unnamed Collection" : name;
            _currentIndex = _videoList.Any() ? 0 : 1;
            _isPlaying = false;

            Console.WriteLine($"\n📼 Loaded '{_collectionName}' with {_videoList.Count} videos.");
            if (CurrentVideo != null)
            {
                Console.WriteLine($"   Ready to play: {CurrentVideo.Title}");
            }
        }
        private void Play()
        {
            if (CurrentVideo == null)
            {
                Console.WriteLine("Cannot play. No videos loaded or selected.");
                _isPlaying = false;
                return;
            }

            _isPlaying = true;
            CurrentVideo.Play(); // Polimorfismo
        }
        private void StopVideo()
        {
            if (_isPlaying)
            {
                Console.WriteLine("\n⏹️ Video playback stopped.");
                _isPlaying = false;
            }
        }

        private void NextVideo()
        {
            if (!_videoList.Any()) return;

            if (_currentIndex < _videoList.Count - 1)
            {
                _currentIndex++;
                Console.WriteLine($"\n⏭️ Next video: {_videoList[_currentIndex].Title}");
                if (_isPlaying)
                    Play();
                else
                    _videoList[_currentIndex].DisplayDetails();
            }
            else
            {
                Console.WriteLine("\n🚫 End of video list.");
                StopVideo();
                _currentIndex = _videoList.Count - 1;
            }
        }
        private void PreviusVideo()
        {
            if (!_videoList.Any()) return;

            if (_currentIndex > 0)
            {
                _currentIndex--;
                Console.WriteLine($"\n⏮️ Previous video: {_videoList[_currentIndex].Title}");
                if (_isPlaying)
                    Play();
                else
                    _videoList[_currentIndex].DisplayDetails();
            }
            else
            {
                Console.WriteLine("\n🚫 At the beginning of the video list.");
                if (_isPlaying) Play();
                else if (CurrentVideo != null) CurrentVideo.DisplayDetails();
            }
        }
        public void DisplayCurrentVideoInfo()
        {
            if (CurrentVideo != null)
            {
                Console.WriteLine($"\nℹ️ Current Video ({_currentIndex + 1}/{_videoList.Count}) in '{_collectionName}':");
                CurrentVideo.DisplayDetails();
            }
            else
            {
                Console.WriteLine("\nℹ️ No video currently selected.");
            }
        }

        public void DisplayVideoList()
        {
            Console.WriteLine($"\n--- Video Collection: {_collectionName} ---");
            if (!_videoList.Any())
            {
                Console.WriteLine(" (Empty)");
                return;
            }

            for (int i = 0; i < _videoList.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {_videoList[i]} {(i == _currentIndex ? "<- Current" : "")}");
            }

            Console.WriteLine("-------------------------------------------");
        }
    }
}
