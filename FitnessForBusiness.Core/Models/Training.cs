using FitnessForBusiness.Core.Core;
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

        public string Type { get; set;}

        public bool? Level { get; set;}

        public List<Excercise> Excercises { get; set;}

        public List<string> Equipment { get; set;}

        public int ExcerciseLength { get; set;}

        public int ExcerciseAmount { get; set;}
        
        public int BreakLength { get; set;}

        public int CircleAmount { get; set;}

        public int Length { get; set;}
        public string Description { get; set;}

        public Training(string name, string type, bool? level, List<Excercise> excercises, int exLength, int breakLength, int circleAmount)
        {
            Name = name;
            Type = type;
            Level = level;
            Excercises = excercises;
            ExcerciseLength = exLength;
            BreakLength = breakLength;
            CircleAmount = circleAmount;
            Equipment = new List<string>();
            Equipment = excercises
                .Select(e => e.Equipment)
                .Distinct()
                .ToList();
            ExcerciseAmount = excercises.Count;
            Length = (ExcerciseLength + BreakLength) * ExcerciseAmount * CircleAmount - breakLength;
            Description = Description;
        }

        public string ShowLevel()
        {
            return functions.NameOfLevel(Level);
        }

    }
}
