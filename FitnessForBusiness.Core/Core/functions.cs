using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Core
{
    public class functions
    {
        public static string NameOfLevel(bool? level)
        {
            if (level == null) return "Beginner";
            else if (level == false) return "Amateur";
            else if (level == true) return "Advanced";
            return null;
        }

        public static string NameOfGoal(bool? goal)
        {
            if (goal == null) return "Losing weight";
            else if (goal == true) return "Gaining muscels";
            else if (goal == false) return "Keeping fit";
        }
    }
}
