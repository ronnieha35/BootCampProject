using System;

namespace MusicPlayerApp_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Console Media Player!");
            Console.WriteLine("Demonstrating OOP Concepts...");
            Console.WriteLine("Choose player : music / video");
            Console.Write("> ");

            string option = Console.ReadLine()?.ToLower();

            //Instancia Compartida para ambos tipos
            List <IPlayable> playlist;

            if (option == "music")
            {
                playlist = new List<IPlayable>()
                {
                    new Song("Bohemian Rhapsody", "Queen", "A Night at the Opera", TimeSpan.FromMinutes(5.9)),
                    new Song("Stairway to Heaven", "Led Zeppelin", "Led Zeppelin IV", TimeSpan.FromMinutes(8.0)),
                    new Song("Hotel California", "Eagles", "Hotel California", TimeSpan.FromMinutes(6.5)),
                    new AudioBook("The Hobbit", "J.R.R. Tolkien", "Rob Inglis", TimeSpan.FromHours(11.1))
                };
            }
            else if (option == "video")
            {
                playlist = new List<IPlayable>()
                {
                     new Video("shawshank redemption", "Frank Darabont", TimeSpan.FromMinutes(222), "1080p"),
                     new Video("Interstellar", "Christopher Nolan", TimeSpan.FromMinutes(169), "4K"),
                     new Video("The Matrix", "Wachowskis Brothers", TimeSpan.FromMinutes(136), "1080p"),
                     new Video("El Pianista", "Roman Polanski", TimeSpan.FromMinutes(230), "1080p"),
                     new Video("Oppenheimer", "Christopher Nolan", TimeSpan.FromMinutes(300), "8K"),
                };
            }
            else
            {
                Console.WriteLine("Invalid Option. ");
                return;
            }

            //Usar el mismo reproductor
            var player = new MusicPlayer();
            player.LoadPlaylist(playlist, option.ToUpper());

            string command;

            do
            {
                Console.WriteLine("\nCommands: play, stop, next, prev, info, list, exit");
                Console.Write("> ");
                command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "play": 
                        player.Play(); 
                        break;
                    case "stop": 
                        player.Stop(); 
                        break;
                    case "next": 
                        player.Next(); 
                        break;
                    case "prev": 
                        player.Previous(); 
                        break;
                    case "info": 
                        player.DisplayCurrentItemInfo(); 
                        break;
                    case "list": 
                        player.DisplayPlaylist(); 
                        break;
                    case "exit": 
                        Console.WriteLine("👋 Goodbye!"); 
                        break;
                    default: 
                        Console.WriteLine("⚠️ Unknown command."); 
                        break;
                }
            } while (command != "exit");


        }
    }
}
