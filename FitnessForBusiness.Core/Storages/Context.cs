using FitnessForBusiness.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Storages
{
    public class Context : DbContext, IStorage
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Training> Trainings { get; set; }



        public List<User> GetUsers => Users.ToList();

        public List<Training> GetTrainings => Trainings.ToList();



        public Context() : base("DBConnection")
        {

        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
