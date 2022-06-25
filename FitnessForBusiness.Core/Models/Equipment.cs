using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Equipment(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

    }
}
