using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    class Excercise
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public string VideoSource {get; set;}

        public bool? Level {get; set;}

        public List<string> BodyParts {get; set;}

        public string Equipment {get; set;}

        public string Description {get; set;}
    }
}
