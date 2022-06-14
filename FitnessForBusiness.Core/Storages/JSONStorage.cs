using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Storages
{
    public class JSONStorage : IStorage
    {
        readonly Repository<Film> _films;
        readonly Repository<Actor> _actors;

        public JSONStorage()
        {
            _films = new Repository<Film>("films.json");
            _actors = new Repository<Actor>("actors.json");
        }


        public List<Film> GetFilms => _films.GetCollection;

        public List<Actor> GetActors => _actors.GetCollection;

        public void Save()
        {
            _films.Save();
            _actors.Save();
        }
    }
}
