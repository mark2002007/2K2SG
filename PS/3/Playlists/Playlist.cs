using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PS._3
{
    public abstract class Playlist
    {
        protected List<Song> playlist { get; set; }
        protected string src { get; set; }
        protected bool sync { get; set; }

        protected Playlist(string src, bool sync = true)
        {
            playlist = new List<Song>();
            this.src = src;
            this.sync = sync;
            Upload();
        }
        public void Add(Song song)
        {
            playlist.Add(song);
            if(sync)
                Download();
        }
        public void Remove(int ind)
        {
            playlist.RemoveAt(ind);
            if (sync)
                Download();
        }

        public override string ToString()
        {
            string str = string.Empty;
            for (int i = 0; i < playlist.Count; i++)
                str += $"{i + 1}\n{playlist[i]}\n";
            return str;
        }

        public abstract void Download();

        public abstract void Upload();

    }
}
