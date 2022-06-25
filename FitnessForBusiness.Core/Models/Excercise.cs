using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    public class Excercise
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public string VideoSource {get; set;}

        public bool? Level {get; set;}

        public Bodypart BodyParts {get; set;}

        public Equipment Equipment {get; set;}

        public Excercise(string name, string videooSource, bool? level, Bodypart bodyParts, string equipment)
        {
            Name = name;
            VideoSource = videooSource;
            Level = level;
            BodyParts = bodyParts;
            Equipment = new Equipment(equipment);
        }
        public Excercise()
        {

        }
        public string ShowLevel()
        {
            return functions.NameOfLevel(Level);
        }
    }
}
