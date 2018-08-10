using RR_Models.Contracts;

namespace RR_Models
{
    public class Benutzer : Entity
    {
        public string UserName { get; set; }
        public string Passwort { get; set; }

        public virtual Person Person { get; set; }
    }
}
