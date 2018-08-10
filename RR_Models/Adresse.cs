using RR_Models.Contracts;
using System.Collections.Generic;

namespace RR_Models
{
    public class Adresse : Entity
    {
        public Adresse()
        {
            Personen = new HashSet<Person>();
        }

        public string Plz { get; set; }
        public string Ort { get; set; }

        public virtual ICollection<Person> Personen { get; set; }
    }
}
