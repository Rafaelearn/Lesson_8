namespace TaskManager
{
    abstract class Person
    {
        public string Name { get; protected set; }
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
        abstract public void Display();
    }

}
