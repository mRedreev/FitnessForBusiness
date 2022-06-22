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

        public List<Bodypart> BodyParts {get; set;}

        public Equipment Equipment {get; set;}

        public Excercise(string name, string videooSource, bool? level, List<string> bodyParts, string equipment)
        {
            Name = name;
            VideoSource = videooSource;
            Level = level;
            BodyParts = new List<Bodypart>();
            foreach(var part in bodyParts)
            {
                BodyParts.Add(new Bodypart(part));
            }
            Equipment = new Equipment(equipment);
        }
        public Excercise()
        { }
        public string ShowLevel()
        {
            return functions.NameOfLevel(Level);
        }
    }
}
