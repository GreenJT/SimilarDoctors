using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarDoctors
{
    public class SimilarDoctors
    {
        public static IList<Doctor> GetPrioritizedList(Doctor comparisonDoctor, List<Doctor> doctorList)
        {
            doctorList.Sort(new Doctor.SortBySpecLocScore(comparisonDoctor));
            return doctorList;
        }

    }
}
