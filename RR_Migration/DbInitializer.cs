using RR_Common;
using RR_Models;
using System.Linq;

namespace RR_Migration
{
    public static class DbInitializer
    {
        public static void Initialize(EfCoreDbContext context, AppSettings options)
        {
            //if (!options.InMemory)
            //{
            //    try
            //    {
            //        context.Database.Migrate();
            //    }
            //    catch
            //    {

            //    }
            //}

            context.Database.EnsureCreated();

            Set_DB(context, options);
        }

        private static void Set_DB(EfCoreDbContext context, AppSettings options)
        {
            if (context.Benutzer.Any())
            {
                var temp = context.Benutzer;
                return;
            }

            var benutzer = new Benutzer()
            {
                UserName = "rr1980",
                Passwort = "12345",
            };

            var p = new Person()
            {
                Name = "Riesner",
                Vorname = "Rene",
                Adresse = new Adresse()
                {
                    Plz = "15344",
                    Ort = "Strausberg"
                }
            };

            p.Benutzer.Add(benutzer);

            context.Add(p);
            context.SaveChanges();
        }
    }
}
