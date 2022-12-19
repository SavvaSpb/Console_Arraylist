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

        //public string FirstName { get; set; }

        //public string SurName { get; set; }
        

        public override bool Equals(object? obj)
        {

            return Equals(obj as Person);


            //bool result = obj is Person person && person.GetHashCode() == GetHashCode();
            //return result;



            //if (obj is Person person) 
            //    return PasportId == person.PasportId;
            //return false;
             
        }

        public bool Equals(Person? person) => person != null && person.PasportId == PasportId;


        public override int GetHashCode()
        {
            return this.PasportId;
        }
    }
}
