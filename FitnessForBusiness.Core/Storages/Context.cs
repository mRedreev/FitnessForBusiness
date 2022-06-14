using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Storages
{
    public class Context : DbContext, IStorage
    {
        public DbSet<Film> Films { get; set; }

        public DbSet<Actor> Actors { get; set; }



        public List<Actor> GetActors => Actors.ToList();

        public List<Film> GetFilms => Films.ToList();



        public Context() : base("DBConnection")
        {

        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
