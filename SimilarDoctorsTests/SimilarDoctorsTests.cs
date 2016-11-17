using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimilarDoctors.Tests
{
    [TestClass]
    public class SimilarDoctorsTests
    {

        [TestMethod]
        public void CompareSameDoctorsReturnsZero()
        {
            var zero = 0;
            var comparisonDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.7490555,
                Longitude = -122.4388654
            };
            var doctorA = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var doctorB = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var comparer = new Doctor.SortBySpecLocScore(comparisonDoctor);

            var result = comparer.Compare(doctorA, doctorB);

            Assert.AreEqual(result, zero);

        }

        [TestMethod]
        public void CompareDoctorsWithinThreeMilesReturnsZero()
        {
            var zero = 0;
            var comparisonDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.7490555,
                Longitude = -122.4388654
            };
            var doctorA = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var doctorB = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.7404203,
                Longitude = -122.4239622
            };
            var comparer = new Doctor.SortBySpecLocScore(comparisonDoctor);

            var result = comparer.Compare(doctorA, doctorB);

            Assert.AreEqual(result, zero);
        }

        [TestMethod]
        public void CompareDoctorACloserReturnsNegOne()
        {
            var negativeOne = -1;
            var comparisonDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.7490555,
                Longitude = -122.4388654
            };
            var closeDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var farDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.7919406,
                Longitude = -122.299005
            };
            var comparer = new Doctor.SortBySpecLocScore(comparisonDoctor);

            var result = comparer.Compare(closeDoctor, farDoctor);

            Assert.AreEqual(result, negativeOne);
        }

        [TestMethod]
        public void CompareDoctorAFurtherReturnsOne()
        {
            var one = 1;
            var comparisonDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.7490555,
                Longitude = -122.4388654
            };
            var closeDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.753251,
                Longitude = -122.299005
            };
            var farDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 4.3f,
                Latitude = 37.7919406,
                Longitude = -122.4556713
            };
            var comparer = new Doctor.SortBySpecLocScore(comparisonDoctor);

            var result = comparer.Compare(closeDoctor, farDoctor);

            Assert.AreEqual(result, one);
        }

        [TestMethod]
        public void CompareDoctorAHigherReviewScoreReturnsNegOne()
        {
            var negativeOne = -1;
            var comparisonDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.7490555,
                Longitude = -122.4388654
            };
            var doctorA = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 5.0f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var doctorB = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var comparer = new Doctor.SortBySpecLocScore(comparisonDoctor);

            var result = comparer.Compare(doctorA, doctorB);

            Assert.AreEqual(result, negativeOne);
        }

        [TestMethod]
        public void CompareDoctorALowerReviewScoreReturnsOne()
        {
            var one = 1;
            var comparisonDoctor = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 3.0f,
                Latitude = 37.7490555,
                Longitude = -122.4388654
            };
            var doctorA = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 0.0f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var doctorB = new Doctor
            {
                Specialty = "PT",
                ReviewScore = 5.0f,
                Latitude = 37.753251,
                Longitude = -122.4556713
            };
            var comparer = new Doctor.SortBySpecLocScore(comparisonDoctor);

            var result = comparer.Compare(doctorA, doctorB);

            Assert.AreEqual(result, one);
        }

        [TestMethod]
        public void GetPrioritizedListEqualOrder()
        {
            var docList = new List<Doctor>();
            var expectedList = new List<Doctor>();
            var comparisonDoctor = new Doctor{ ID = 0, Specialty = "PT", ReviewScore = 3.0f, Latitude = 37.7490555, Longitude = -122.4388654};
            var closeDiffSpec = new Doctor { ID = 5, Specialty = "MD", ReviewScore = 3.0f, Latitude = 37.7429942, Longitude = -122.441026 };
            var closeLowReview = new Doctor { ID = 2, Specialty = "PT", ReviewScore = 1.0f, Latitude = 37.7429942, Longitude = -122.441026 };
            var closeHighReview = new Doctor { ID = 1, Specialty = "PT", ReviewScore = 5.0f, Latitude = 37.7432998, Longitude = -122.4407481 };
            var farLowReviewDiffSpec = new Doctor { ID = 6, Specialty = "OS", ReviewScore = 1.0f, Latitude = 37.7642166, Longitude = -122.3601974 };
            var farLowReviewSameSpec = new Doctor { ID = 4, Specialty = "PT", ReviewScore = 0.0f, Latitude = 37.7642166, Longitude = -122.3601974 };
            var farHighReviewSameSpec = new Doctor { ID = 3, Specialty = "PT", ReviewScore = 5.0f, Latitude = 37.7642166, Longitude = -122.3601974 };

            expectedList.Add(closeHighReview);
            expectedList.Add(closeLowReview);
            expectedList.Add(farHighReviewSameSpec);
            expectedList.Add(farLowReviewSameSpec);
            expectedList.Add(closeDiffSpec);
            expectedList.Add(farLowReviewDiffSpec);

            docList.Add(closeDiffSpec);
            docList.Add(farLowReviewDiffSpec);
            docList.Add(closeLowReview);
            docList.Add(closeHighReview);
            docList.Add(farHighReviewSameSpec);
            docList.Add(farLowReviewSameSpec);

            var sortedList = (List<Doctor>)SimilarDoctors.GetPrioritizedList(comparisonDoctor, docList);

            CollectionAssert.AreEqual(sortedList, expectedList);
        }

    }
}
