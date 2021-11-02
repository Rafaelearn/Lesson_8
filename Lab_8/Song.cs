using System;

namespace Lab_8
{
    class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song PrevSong { get; set; } = null; // Чтобы конструктор Song() не выдал ошибки

        public Song()
        {
            //Без данного конструктора возникнет ошибка.... Song mySong = new Song();
        }
        public Song(string name, string author) : this(name, author, null)
        {

        }
        public Song(string name, string author, Song song)
        {
            Name = name;
            Author = author;
            PrevSong = song;
        }
        public string Title()
        {
            return Name + " " + Author;
        }
        public void Dispay()
        {
            Console.WriteLine($"\"{Name}\" by {Author}");
        }
        public override bool Equals(Object obj)
        {
            Song songEqual = obj as Song;
            if (Title().Equals(songEqual.Title()))
            {
                return true;
            }
            return false;
        }

    }
}
