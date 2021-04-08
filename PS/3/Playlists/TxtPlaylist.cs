using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PS._3.Units;

namespace PS._3
{
    public class TxtPlaylist : Playlist
    {
        public TxtPlaylist(string src) : base(src)
        {
        }

        public override void Download()
        {
            using (StreamWriter file = new StreamWriter(src))
                foreach (var song in playlist)
                    file.WriteLine($"{song.title},{song.author}");
        }

        public override void Upload()
        {
            using (StreamReader file = new StreamReader(src))
            {
                bool is_sync = sync;
                sync = false;
                string line;
                string[] parameters;
                while (true)
                {
                    line = file.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        parameters = line.Split(",");
                        Add(new Song(parameters[0], new Author(parameters[1], int.Parse(parameters[2]))));
                    }
                    else
                        break;
                }
                sync = is_sync;
            }
        }
    }
}
