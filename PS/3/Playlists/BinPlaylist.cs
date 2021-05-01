using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PS._3.Units;

namespace PS._3
{
    public class BinPlaylist : Playlist
    {
        public BinPlaylist(string src) : base(src)
        {
        }

        public override void Download()
        {
            using var file = new BinaryWriter(File.Open(src, FileMode.Create));
            foreach (var song in playlist)
                file.Write($"{song.title}@{song.author.name}@{song.author.age}");
        }

        public override void Upload()
        {
            using var file = new BinaryReader(File.Open(src, FileMode.Open));
            bool is_sync = sync;
            sync = false;

            while (file.PeekChar() > -1)
            {
                var parameters = file.ReadString().Split("@");
                Add(new Song(parameters[0], new Author(parameters[1], int.Parse(parameters[2]))));
            }

            sync = is_sync;
        }
    }
}
