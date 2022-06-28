using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Models
{
    public class Training
    {
       public Guid Id { get; set;}

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

        //public List<User> Users { get; set;}

        public Training(string name, TrainingType type, bool? level, List<Excercise> excercises, double exLength, double breakLength, int circleAmount)
        {
            Name = name;
            Type = type;
            Level = level;
            Excercises = excercises;
            ExcerciseLength = exLength;
            BreakLength = breakLength;
            CircleAmount = circleAmount;
            Equipment = new List<Equipment>();
            var equipmentList = excercises
                .Select(e => e.Equipment.Name)
                .Distinct()
                .ToList();
            equipmentList = equipmentList.Distinct().ToList();

            foreach (var equipment in equipmentList)
            {
                Equipment.Add(new Equipment(equipment));
            }

            ExcerciseAmount = excercises.Count;
            Length = (ExcerciseLength + BreakLength) * ExcerciseAmount * CircleAmount - breakLength;

            var bodyparts = Excercises.Select(e => e.BodyParts.Name).ToList();
            bodyparts = bodyparts.Distinct().ToList();
            

            for (int i = 0; i < bodyparts.Count; i++)
            {
                Description = Description + bodyparts[i];
                Description = Description + ", ";
            }

            Id = Guid.NewGuid();
           // Users = new List<User>();
        }

        public Training()
        {
            Excercises = new List<Excercise>();
            Description = "";
            Equipment = new List<Equipment>();
        }

        public string ShowLevel()
        {
            return functions.NameOfLevel(Level);
        }

    }
}
