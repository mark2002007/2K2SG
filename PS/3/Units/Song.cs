using System;
using System.Collections.Generic;
using System.Text;
using PS._3.Units;

namespace PS._3
{
    public class Song
    {
        public string title { get; protected set; }
        public Author author { get; protected set; }

        public Song(string title, Author author)
        {
            this.title = title;
            this.author = author;
        }

        public override string ToString() => $"Title : {title}\nAuthor ::\n{author}";
    }
}
