using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class StandardDeviationTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void StandardDeviation()
        {
            var service = new AssesorService(new float[] { 6, 2, 3, 1 });

            Assert.AreEqual(1.870f, service.StandardDeviation(service.Data));
        }
    }

    public class CalculateZScoreTest
    {
        [Test]
        public void CalculateZScore()
        {
            var service = new AssesorService(new float[] { 6, 2, 3, 1 });
            Assert.AreEqual(-0.53f, service.CalculateZScore(2));
        }
    }
}
