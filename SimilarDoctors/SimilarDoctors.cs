using System.Collections.Generic;

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
