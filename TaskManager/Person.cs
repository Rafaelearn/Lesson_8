namespace TaskManager
{
    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public Person()
        {

        }
        public override string ToString()
        {
            return Name; 
        }
    }
}
