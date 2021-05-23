using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class Person
    {
        public Person(int id, string name, string surname)
           :this(name, surname)
        {
            Id = id;
        }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public int Id { get; set; }
        public string Name { get; }
        public string Surname { get; }

        public override string ToString()
        {
            return $"My name is {Name} {Surname}";
        }
    }
}
