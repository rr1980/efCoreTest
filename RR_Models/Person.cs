using RR_Models.Contracts;
using System.Collections.Generic;

namespace RR_Models
{

    public class Person : Entity
    {
        public Person()
        {
            Benutzer = new HashSet<Benutzer>();
        }

        public string Name { get; set; }
        public string Vorname { get; set; }

        public virtual Adresse Adresse { get; set; }
        public virtual ICollection<Benutzer> Benutzer { get; set; }
    }
}
