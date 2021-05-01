using System;
using System.Collections.Generic;
using System.Text;

namespace PS._3.Units
{
    public class Author
    {
        public string name { get; protected set; }
        public int age { get; protected set; }
        public Author(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public override string ToString() => $"name : {name}\nAge : {age}";
    }
}
