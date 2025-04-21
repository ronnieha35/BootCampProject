using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp_OOP
{
    public class Song : MediaItem
    {
        // Specific properties for a Song
        public string Artist { get; private set; }
        public string Album { get; private set; }

        /// <summary>
        /// Provides the implementation for the abstract CreatorInfo property from MediaItem.
        /// </summary>
        public override string CreatorInfo => Artist; // For a song, the creator is the Artist

        /// <summary>
        /// Constructor for the Song class.
        /// It calls the base class (MediaItem) constructor using 'base(...)'.
        /// </summary>
        /// <param name="title">Title of the song.</param>
        /// <param name="artist">Artist of the song.</param>
        /// <param name="album">Album the song belongs to.</param>
        /// <param name="duration">Duration of the song.</param>
        public Song(string title, string artist, string album, TimeSpan duration)
            : base(title, duration) // Call the base class constructor first
        {
            // Encapsulation: Internal data is protected. We use properties with private setters
            // or provide data via the constructor. Input validation happens here or in base class.
            if (string.IsNullOrWhiteSpace(artist))
                throw new ArgumentNullException(nameof(artist), "Artist cannot be empty.");

            Artist = artist;
            Album = album ?? "Unknown Album"; // Operador ternario: condition ?? value if true : value if false
        }

        /// <summary>
        /// OOP Concept: Polymorphism (Method Overriding).
        /// Provides the specific implementation for the 'abstract Play' method
        /// defined in the base MediaItem class.
        /// </summary>
        public override void Play()
        {
            // Simulate playing the song
            Console.WriteLine($"\n▶️ Playing Song: {Title} by {Artist}");
            Console.WriteLine($"   Album: {Album}, Duration: {Duration:mm\\:ss}");
        }

        /// <summary>
        /// OOP Concept: Polymorphism (Method Overriding).
        /// This method 'overrides' the 'virtual DisplayDetails' method from the base 'MediaItem' class.
        /// It first calls the base implementation and then adds song-specific details.
        /// </summary>
        public override void DisplayDetails()
        {
            base.DisplayDetails(); // Call the base class method first to display common info
            Console.WriteLine($"  Album: {Album}"); // Add song-specific info
        }

        /// <summary>
        /// Override ToString for simpler representation when needed.
        /// </summary>
        /// <returns>Formatted string representation of the song.</returns>
        public override string ToString()
        {
            return $"{Title} - {Artist} ({Duration:mm\\:ss})";
        }

    }
}
