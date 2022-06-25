using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    public class TrainingType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }

        public TrainingType(string name, string imageSource)
        {
            Name = name;
            ImageSource = imageSource;
            Id = Guid.NewGuid();
        }

    }
}
