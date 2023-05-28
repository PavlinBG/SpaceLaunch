using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Collections.Generic;

namespace LaunchTests
{
    public class Tests
    {
        [Test]
        public void CalculateMedian_WithOddNumberOfValues_ReturnsCorrectResult()
        {
            // Arrange
            var values = new List<double> { 1, 2, 3, 4, 5 };

            // Act
            var result = Program.CalculateMedian(values);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void ReadPassword_InputValidPassword_ReturnsPassword()
        {
            // Arrange
            string password = "testpassword";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (var sr = new StringReader($"{password}{Environment.NewLine}"))
                {
                    Console.SetIn(sr);

                    Program.Main(null);
                }

                string consoleOutput = sw.ToString().Trim();

                // Assert
                Assert.IsTrue(consoleOutput.Contains(password));
            }
        }

        [Test]
        public void GetAppropriateLaunchDayIndex_WithValidData_ReturnsAppropriateDayIndex()
        {
            // Arrange
            var dataDictionary = new Dictionary<string, List<string>>
            {
                { "DayParameter", new List<string> { "1", "2", "3" } },
                { "Temperature", new List<string> { "10", "20", "30" } },
                { "Wind (m/s)", new List<string> { "5", "8", "12" } },
                { "Humidity (%)", new List<string> { "40", "50", "60" } },
                { "Precipitation (%)", new List<string> { "0", "0", "0" } },
                { "Lightning", new List<string> { "No", "No", "No" } },
                { "Clouds", new List<string> { "Cloud1", "Cloud2", "Cloud3" } }
            };

            var temperatureValues = new List<double> { 10, 20, 30 };
            var windValues = new List<double> { 5, 8, 12 };
            var humidityValues = new List<double> { 40, 50, 60 };
            var precipitationValues = new List<double> { 0, 0, 0 };
            var lightningValues = new List<double> { 0, 0, 0 };

            // Act
            var result = Program.GetAppropriateLaunchDayIndex(dataDictionary, temperatureValues, windValues, humidityValues, precipitationValues, lightningValues);

            // Assert
            Assert.AreEqual(1, result);
        }
    }


         
    }
}