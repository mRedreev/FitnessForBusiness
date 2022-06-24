using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    public class Training
    {
        public int Id { get; set;}

        public string Name { get; set;}

        public TrainingType Type { get; set;}

        public bool? Level { get; set;}

        public List<Excercise> Excercises { get; set;}

        public List<Equipment> Equipment { get; set;}

        public double ExcerciseLength { get; set;}

        public int ExcerciseAmount { get; set;}
        
        public double BreakLength { get; set;}

        public int CircleAmount { get; set;}

        public double Length { get; set;}
        public string Description { get; set;}

        public List<User> Users { get; set;}

        public Training(string name, string type, bool? level, List<Excercise> excercises, double exLength, double breakLength, int circleAmount)
        {
            Name = name;
            Type = type;
            Level = level;
            Excercises = excercises;
            ExcerciseLength = exLength;
            BreakLength = breakLength;
            CircleAmount = circleAmount;
            Equipment = new List<Equipment>();
            Equipment = excercises
                .Select(e => e.Equipment)
                .Distinct()
                .ToList();
            if (Equipment.Count > 1)
            {
                foreach (var e in Equipment)
                {
                    if (e.Name == "")
                        Equipment.Remove(e);
                }
            }

            ExcerciseAmount = excercises.Count;
            Length = (ExcerciseLength + BreakLength) * ExcerciseAmount * CircleAmount - breakLength;
            var bodyparts = new List<string>();
            foreach (var e in Excercises)
            {
                foreach (var bodypart in e.BodyParts)
                {
                    bodyparts.Add(bodypart.Name);
                }
            }

            for (int i = 0; i < bodyparts.Count - 1; i++)
            {
                Description = Description + bodyparts[i];
                Description = Description + ", ";
            }
            Users = new List<User>();
        }

        public Training()
        {

        }

        public string ShowLevel()
        {
            return functions.NameOfLevel(Level);
        }

    }
}
