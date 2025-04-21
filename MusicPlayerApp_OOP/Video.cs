using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp_OOP
{
    public class Video : MediaItem
    {
        public string Director { get; private set; }
        public string Resolution { get; private set; }

        // Implementación de la propiedad abstracta CreatorInfo
        public override string CreatorInfo => Director;

        public Video(string title, string director, TimeSpan duration, string resolution)
            : base(title, duration)
        {
            if (string.IsNullOrWhiteSpace(director))
                throw new ArgumentNullException(nameof(director), "Director cannot be empty.");

            Director = director;
            Resolution = resolution ?? "Unknown Resolution";
        }

        public override void Play()
        {
            Console.WriteLine($"\n🎬 Playing Video: {Title} directed by {Director}");
            Console.WriteLine($"   Duration: {Duration:hh\\:mm\\:ss}, Resolution: {Resolution}");
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails(); // Muestra título, creador y duración
            Console.WriteLine($"  Resolution: {Resolution}");
        }

        public override string ToString()
        {
            return $"{Title} - {Director} ({Duration:hh\\:mm\\:ss}, {Resolution})";
        }

        //public string Title { get; }
        //public string CreatorInfo { get; } // e.g., Director
        //public TimeSpan Duration { get; }
        //public string Resolution { get; }

        //public Video(string title, string director, TimeSpan duration, string resolution)
        //{
        //    Title = title;
        //    CreatorInfo = director;
        //    Duration = duration;
        //    Resolution = resolution;
        //}

        //public void DisplayDetails()
        //{
        //    Console.WriteLine($"🎥 Title: {Title}");
        //    Console.WriteLine($"   Director: {CreatorInfo}");
        //    Console.WriteLine($"   Duration: {Duration}");
        //    Console.WriteLine($"   Resolution: {Resolution}");
        //}

        //public void Play()
        //{
        //    Console.WriteLine($"\n🎬 Playing video: '{Title}' by {CreatorInfo} [{Duration} - {Resolution}]");
        //}

        //public override string ToString() => $"{Title} by {CreatorInfo}";
    }
}
