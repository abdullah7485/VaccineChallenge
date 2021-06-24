using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VaccineChallenge;

namespace VaccineChallengeTests
{
    [TestClass]
    public class CalculationsTests
    {
        [TestMethod]
        [DataRow(100.5, 120.5, "Center 1")]
        [DataRow(300, 140, "Center 2")]
        [DataRow(400, 150, "Center 3")]
        public void GetNearestCenter_SameCenterCordinates_ShouldReturnThatCenter(double latitude, double longitude, string centerName)
        {
            var centers = new List<VaccineCenter>() {
                new VaccineCenter() { Name = "Center 1", Latitude = "100.5", Longitude = "120.5" } ,
                new VaccineCenter() { Name = "Center 2", Latitude = "300", Longitude = "140" },
                new VaccineCenter() { Name = "Center 3", Latitude = "400", Longitude = "150" }};

            var center = Calculations.GetNearestCenter(latitude, longitude, centers);

            Assert.AreEqual(center, centerName);
        }

        [TestMethod]
        public void GetNearestCenter_SameCenterCordinates_ShouldReturnThatCenter()
        {
            var centers = new List<VaccineCenter>() {
                new VaccineCenter() { Name = "Center 1", Latitude = "100.5", Longitude = "120.5" } ,
                new VaccineCenter() { Name = "Center 2", Latitude = "200.5", Longitude = "120.5" },
                new VaccineCenter() { Name = "Center 3", Latitude = "300.5", Longitude = "120.5" }};

            var center = Calculations.GetNearestCenter(100.5, 120.5, centers);

            Assert.AreEqual(center, "Center 1");
        }

        

    }
}