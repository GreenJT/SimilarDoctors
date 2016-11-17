using System;
using System.Collections.Generic;
using System.Device.Location;

namespace SimilarDoctors
{
    public class Doctor
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Specialty { get; set; }
        public String Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float ReviewScore { get; set; }

        /// <summary>
        /// Custom comparer that compares by Doctor's specialty, shortest distance from similar doctor, and lastly review score.
        /// </summary>
        public class SortBySpecLocScore : IComparer<Doctor>
        {
            private Doctor doctor;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="doctor">The doctor that similarities will be drawn upon.</param>
            public SortBySpecLocScore(Doctor doctor)
            {
                this.doctor = doctor;
            }

            public int Compare(Doctor x, Doctor y)
            {
                //Determine if they have the same Specialty and that it matches the doctor that 
                //we're drawing similarity to.
                if (x.Specialty != doctor.Specialty) return 1;
                if (y.Specialty != doctor.Specialty) return -1;

                //determine the distance x and y doctors are from the comparison doctor
                var xDistance = GetDistance(x.Latitude, x.Longitude);
                var yDistance = GetDistance(y.Latitude, y.Longitude);

                //if the two doctors being compared are both less than 3 miles from the comparison the distance will be
                //considered negligible and treated similarly to being equal.
                if((xDistance <= 5000) && (yDistance <= 5000) || (xDistance == yDistance))
                {
                    //In such case the distances from the comparison doctor are equal sort by ReviewScore
                    if(x.ReviewScore > y.ReviewScore)
                    {
                        return -1;
                    }
                    else if(x.ReviewScore < y.ReviewScore)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }

                //closer by doctor closer to the comparison doctor.
                if(xDistance < yDistance)
                {
                    return -1;
                }

                return 1;
            }

            /// <summary>
            /// Calculates the from the class doctor and the one beng compared to
            /// </summary>
            /// <param name="latitude">Latitude component of the current doctor.</param>
            /// <param name="longitude">Longitude component of the current doctor.</param>
            /// <returns></returns>
            private double GetDistance(double latitude, double longitude)
            {
                var docCoordinate = new GeoCoordinate(doctor.Latitude, doctor.Longitude);
                var distance = docCoordinate.GetDistanceTo(new GeoCoordinate(latitude, longitude));

                return distance;
            }

        }
    }
}
