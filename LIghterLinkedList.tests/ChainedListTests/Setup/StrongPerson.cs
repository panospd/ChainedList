using System;

namespace ChainedList.tests.ChainedListTests
{
    public partial class Find
    {
        public class StrongPerson : Person
        {
            public StrongPerson(int id, string name, string surname)
                :base(id, name, surname)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as StrongPerson);
            }

            private bool Equals(StrongPerson other)
            {
                return other != null && Id == other.Id;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name, Surname);
            }
        }
    }
}
