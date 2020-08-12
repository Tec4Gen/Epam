using System;

namespace ProgramDieOrDie.Entityes
{
    public class Person : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            return new Person { FirstName = this.FirstName, LastName = this.LastName };
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
