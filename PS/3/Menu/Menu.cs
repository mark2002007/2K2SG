using System;
using PS._3.Units;

namespace PS._3.Menu
{
    public enum PlaylistTypes
    {
        Txt,
        Bin
    }
    public class Menu
    {
        private PlaylistTypes playlistType { get; set; }
        private string pointer { get; set; }
        public int pPos { get; set; }
        public string listInd { get; set; }
        public string title { get; set; }

        private readonly Playlist playlist;

        public Menu(PlaylistTypes playlistType, string title = "Menu", string list_ind = "ORDERED", string pointer = "<")
        {
            this.title = title;
            this.listInd = list_ind;
            this.pointer = pointer;
            this.playlistType = playlistType;

            switch (playlistType)
            {
                case PlaylistTypes.Txt:
                    playlist = new TxtPlaylist(@"C:\Programs\MyPrograms\C#\Canvas (Cshp dnet core)\PS\3\Data\Songs.txt");
                    break;
                case PlaylistTypes.Bin:
                    playlist = new BinPlaylist(@"C:\Programs\MyPrograms\C#\Canvas (Cshp dnet core)\PS\3\Data\Songs.dat");
                    break;
            }
        }

        public void AddSong()
        {
            Console.Clear(); Console.WriteLine("\tAdd new song");
            Console.Write("title: "); string title = Console.ReadLine();
            Console.Write("author \nName : "); string auth_name = Console.ReadLine();
            Console.Write("age : "); string auth_age = Console.ReadLine();
            playlist.Add(new Song(title, new Author(auth_name, int.Parse(auth_age))));
        }

        public void RemoveSong()
        {
            Console.Clear();
            Console.Write("Song to remove (number) : "); int pos = int.Parse(Console.ReadLine());
            playlist.Remove(pos - 1);
        }

        public void ShowMenu()
        {
            bool exit = false;
            int rowN = 5, pPos = 1;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\t{title}");
                for (int i = 0; i < rowN; i++)
                {
                    if (listInd == "ORDERED") Console.Write($"{i + 1}. ");
                    else if (listInd == "UNORDERED") Console.Write("*");
                    switch (i + 1)
                    {
                        case 1:
                            Console.Write("{0,-10}", "Add");
                            break;

                        case 2:
                            Console.Write("{0,-10}", "Remove");
                            break;

                        case 3:
                            Console.Write("{0,-10}", "Show");
                            break;

                        case 4:
                            Console.Write("{0,-10}", "Settings");
                            break;

                        case 5:
                            Console.Write("{0,-10}", "Exit");
                            break;
                    }

                    if (i + 1 == pPos) Console.Write($" {pointer}");
                    Console.WriteLine();
                }

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (1 < pPos) pPos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pPos < rowN) pPos++;
                        break;

                    case ConsoleKey.E:
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (pPos)
                        {
                            case 1:
                                ShowAdd();

                                break;

                            case 2:
                                ShowRemove();

                                break;

                            case 3:
                                ShowShow();

                                break;

                            case 4:
                                ShowSettings();

                                break;

                            case 5:
                                exit = true;
                                break;
                        }
                        break;
                }
            }
        }

        public void ShowAdd()
        {
            bool exit = false;
            int rowN = 2, pPos = 1;
            ConsoleKey user_input;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\tAdd");
                for (int i = 0; i < rowN; i++)
                {
                    if (listInd == "ORDERED") Console.Write($"{i + 1}. ");
                    else if (listInd == "UNORDERED") Console.Write("*");

                    switch (i + 1)
                    {
                        case 1:
                            Console.Write("{0,-10}", "Song");
                            break;

                        case 2:
                            Console.Write("{0,-10}", "Exit");
                            break;
                    }

                    if (i + 1 == pPos) Console.Write($" {pointer}");
                    Console.WriteLine();
                }

                user_input = Console.ReadKey().Key;
                switch (user_input)
                {
                    case ConsoleKey.UpArrow:
                        if (1 < pPos) pPos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pPos < rowN) pPos++;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (pPos)
                        {
                            case 1:
                                AddSong();
                                break;

                            case 2:
                                exit = true;
                                break;
                        }

                        break;
                }
            }
        }

        public void ShowRemove()
        {
            bool exit = false;
            int rowN = 2, pPos = 1;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\tRemove");
                for (int i = 0; i < rowN; i++)
                {
                    if (listInd == "ORDERED") Console.Write($"{i + 1}. ");
                    else if (listInd == "UNORDERED") Console.Write("*");

                    switch (i + 1)
                    {
                        case 1:
                            Console.Write("{0,-10}", "Song");
                            break;

                        case 2:
                            Console.Write("{0,-10}", "Exit");
                            break;
                    }

                    if (i + 1 == pPos) Console.Write($" {pointer}");
                    Console.WriteLine();
                }

                var user_input = Console.ReadKey().Key;
                switch (user_input)
                {
                    case ConsoleKey.UpArrow:
                        if (1 < pPos) pPos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pPos < rowN) pPos++;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (pPos)
                        {
                            case 1:
                                RemoveSong();
                                break;

                            case 2:
                                exit = true;
                                break;
                        }

                        break;
                }
            }
        }

        public void ShowShow()
        {
            bool exit = false;
            int rowN = 2, pPos = 1;
            ConsoleKey user_input;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\tShow");
                for (int i = 0; i < rowN; i++)
                {
                    if (listInd == "ORDERED") Console.Write($"{i + 1}. ");
                    else if (listInd == "UNORDERED") Console.Write("*");

                    switch (i + 1)
                    {
                        case 1:
                            Console.Write("{0,-10}", "Songs");
                            break;

                        case 2:
                            Console.Write("{0,-10}", "Exit");
                            break;
                    }

                    if (i + 1 == pPos) Console.Write($" {pointer}");
                    Console.WriteLine();
                }

                user_input = Console.ReadKey().Key;
                switch (user_input)
                {
                    case ConsoleKey.UpArrow:
                        if (1 < pPos) pPos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pPos < rowN) pPos++;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (pPos)
                        {
                            case 1:
                                Console.WriteLine(playlist);
                                break;

                            case 2:
                                exit = true;
                                break;
                        }
                        if (!exit) Console.ReadKey();
                        break;
                }
            }
        }

        public void ShowSettings()
        {
            bool exit = false;
            int rowN = 4, pPos = 1;
            ConsoleKey user_input;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\tSettings");
                for (int i = 0; i < rowN; i++)
                {
                    if (listInd == "ORDERED") Console.Write($"{i + 1}. ");
                    else if (listInd == "UNORDERED") Console.Write("*");

                    switch (i + 1)
                    {
                        case 1:
                            Console.Write("{0,-20}", "Change title");
                            break;

                        case 2:
                            Console.Write("{0,-20}", "Change indexation");
                            break;

                        case 3:
                            Console.Write("{0,-20}", "Change pointer");
                            break;

                        case 4:
                            Console.Write("{0,-20}", "Exit");
                            break;
                    }

                    if (i + 1 == pPos) Console.Write($" {pointer}");
                    Console.WriteLine();
                }

                user_input = Console.ReadKey().Key;
                switch (user_input)
                {
                    case ConsoleKey.UpArrow:
                        if (1 < pPos) pPos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pPos < rowN) pPos++;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (pPos)
                        {
                            case 1:
                                ChangeTitle();

                                break;

                            case 2:
                                ChangeIndexation();

                                break;

                            case 3:
                                ChangePointer();

                                break;

                            case 4:
                                exit = true;
                                break;
                        }
                        break;
                }
            }
        }

        public void ChangeTitle()
        {
            Console.Clear();
            Console.Write("Enter title : ");
            title = Console.ReadLine();
        }

        public void ChangeIndexation()
        {
            Console.Clear();
            Console.Write("Enter indexation type : ");
            listInd = Console.ReadLine();
        }

        public void ChangePointer()
        {
            Console.Clear();
            Console.Write("Enter pointer : ");
            pointer = Console.ReadLine();
        }
    }
}