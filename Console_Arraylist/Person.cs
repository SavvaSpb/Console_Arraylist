using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Arraylist
{
    public class Person : IEquatable<Person>
    {
        public int PasportId { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? person) => person != null && person.PasportId == PasportId;

        public override int GetHashCode()
        {
            return this.PasportId;
        }
    }
}
