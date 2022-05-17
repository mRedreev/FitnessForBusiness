using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    class Training
    {
        public int Id { get; set;}

        public string Name { get; set;}

        public bool? Type { get; set;}

        public bool? Level { get; set;}

        public string VideoSource { get; set;}

        public List<Excercise> Excercises { get; set;}

        public List<string> Equipment { get; set;}

        public int Length { get; set;}

        public 
    }
}
