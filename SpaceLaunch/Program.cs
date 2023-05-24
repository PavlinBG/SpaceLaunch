using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("         WELCOME TO THE SPACE MISSION");
            Console.WriteLine("                CONTROL CENTRE");
            Console.WriteLine("============================================");
            Console.WriteLine();

            Console.WriteLine("                    /\\");
            Console.WriteLine("                   /  \\");
            Console.WriteLine("                  /    \\");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                  |    |");
            Console.WriteLine("                 /|    |\\");
            Console.WriteLine("                / |    | \\");
            Console.WriteLine("               /  |    |  \\");
            Console.WriteLine("              /___\\   /___ \\");
            Console.WriteLine();
            Console.WriteLine("                   SPACE");
            Console.WriteLine("            Code for the Stars!");
            Console.WriteLine("============================================");


            // Get input parameters from the user
            Console.Write("Enter the path to the file on the file system: ");
            string filePath = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Enter the Sender email address: ");
            string senderEmail = Console.ReadLine();

            Console.Write("Enter the Password: ");
            string password = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Enter the Receiver email address: ");
            string receiverEmail = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine("Initializing the SPACE Shuttle Launch Calculation...");

            string fileName = filePath;
            string[] dataArray = ReadCsvFile(fileName);

            // Parse the array data into a dictionary
            Dictionary<string, List<string>> dataDictionary = ParseArrayData(dataArray);

            // Get the input value


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Weather Report:");
            Console.WriteLine();

            List<double> temperatureValues = new List<double>();
            List<double> windValues = new List<double>();
            List<double> humidityValues = new List<double>();
            List<double> precipitationValues = new List<double>();
            List<double> lightningValues = new List<double>();

            List<string> weatherReportData = new List<string>();

            // Iterate over each day in the "DayParameter" list
            for (int dayIndex = 0; dayIndex < dataDictionary["DayParameter"].Count; dayIndex++)
            {
                // Collect data for reports
                temperatureValues.Add(GetDoubleValue(dataDictionary["Temperature"][dayIndex]));
                windValues.Add(GetDoubleValue(dataDictionary["Wind (m/s)"][dayIndex]));
                humidityValues.Add(GetDoubleValue(dataDictionary["Humidity (%)"][dayIndex]));
                precipitationValues.Add(GetDoubleValue(dataDictionary["Precipitation (%)"][dayIndex]));

                string lightningValue = dataDictionary["Lightning"][dayIndex];
                int hasLightning = (lightningValue.ToLower() == "true") ? 1 : 0;
                lightningValues.Add(hasLightning);
            }

            int appropriateDayIndex = GetAppropriateLaunchDayIndex(dataDictionary, temperatureValues, windValues, humidityValues, precipitationValues, lightningValues);

            List<string> reportData = new List<string>();



            // Add the most appropriate launch day information to the report
            if (appropriateDayIndex != -1)
            {
                Console.WriteLine("The most appropriate launch day:");
                PrintWeatherData(dataDictionary, appropriateDayIndex);


                //Add the most appropriate launch day to the WeatherReport.csv
                AddWeatherData(reportData, dataDictionary, appropriateDayIndex);

            }
            else
            {
                reportData.Add("No appropriate launch day found.");
                Console.WriteLine("No appropriate launch day found.");
            }

            // Generate weather reports

            AddToWeatherReport(reportData, "Temperature", temperatureValues);

            AddToWeatherReport(reportData, "Wind", windValues);

            AddToWeatherReport(reportData, "Humidity", humidityValues);

            AddToWeatherReport(reportData, "Precipitation", precipitationValues);



            // Write the weather report data to the CSV file
            string reportFileName = GetWeatherReportPath();
            WriteToCsvFile(reportFileName, reportData);


            // Send the email with the attachment
            SendEmail(senderEmail, password, receiverEmail);


            static void PrintWeatherData(Dictionary<string, List<string>> dataDictionary, int dayIndex)
            {
                Console.WriteLine($"Day: {dataDictionary["DayParameter"][dayIndex]}");
                Console.WriteLine($"Temperature (C): {dataDictionary["Temperature"][dayIndex]}");
                Console.WriteLine($"Wind (m/s): {dataDictionary["Wind (m/s)"][dayIndex]}");
                Console.WriteLine($"Humidity (%): {dataDictionary["Humidity (%)"][dayIndex]}");
                Console.WriteLine($"Precipitation (%): {dataDictionary["Precipitation (%)"][dayIndex]}");
                Console.WriteLine($"Lightning: {dataDictionary["Lightning"][dayIndex]}");
                Console.WriteLine($"Clouds: {dataDictionary["Clouds"][dayIndex]}");
            }





            static double GetDoubleValue(string value)
            {
                if (double.TryParse(value, out double result))
                {
                    return result;
                }
                else
                {
                    return double.NaN;
                }
            }

            static double CalculateMedian(List<double> values)
            {
                List<double> sortedValues = values.OrderBy(x => x).ToList();
                int count = sortedValues.Count;

                if (count % 2 == 0)
                {
                    int index1 = count / 2 - 1;
                    int index2 = count / 2;
                    return (sortedValues[index1] + sortedValues[index2]) / 2;
                }
                else
                {
                    int index = count / 2;
                    return sortedValues[index];
                }
            }

            static int GetAppropriateLaunchDayIndex(Dictionary<string, List<string>> dataDictionary, List<double> temperatureValues, List<double> windValues, List<double> humidityValues, List<double> precipitationValues, List<double> lightningValues)
            {
                for (int dayIndex = 0; dayIndex < dataDictionary["DayParameter"].Count; dayIndex++)
                {
                    double temperature = temperatureValues[dayIndex];
                    double wind = windValues[dayIndex];
                    double humidity = humidityValues[dayIndex];
                    double precipitation = precipitationValues[dayIndex];


                    string hasLightning = dataDictionary["Lightning"][dayIndex];
                    string clouds = dataDictionary["Clouds"][dayIndex];

                    if (temperature >= 2 && temperature <= 31
                        && wind <= 10
                        && humidity < 60
                        && precipitation == 0
                        && !hasLightning.Contains("Yes")
                        && !clouds.Contains("Cumulus")
                        && !clouds.Contains("Nimbus"))
                    {
                        return dayIndex++;
                    }
                }

                return -1;
            }


            static Dictionary<string, List<string>> ParseArrayData(string[] dataArray)
            {
                Dictionary<string, List<string>> dataDictionary = new Dictionary<string, List<string>>();

                foreach (string dataRow in dataArray)
                {
                    string[] rowValues = dataRow.Split(';');
                    string key = rowValues[0];

                    if (!dataDictionary.ContainsKey(key))
                    {
                        dataDictionary[key] = new List<string>();
                    }

                    for (int i = 1; i < rowValues.Length; i++)
                    {
                        dataDictionary[key].Add(rowValues[i]);
                    }
                }

                return dataDictionary;
            }


            static void AddWeatherData(List<string> reportData, Dictionary<string, List<string>> dataDictionary, int dayIndex)
            {
                reportData.Add("The most appropriate launch day:");
                reportData.Add($"Day: {dataDictionary["DayParameter"][dayIndex]}");
                reportData.Add($"Temperature (C): {dataDictionary["Temperature"][dayIndex]}");
                reportData.Add($"Wind (m/s): {dataDictionary["Wind (m/s)"][dayIndex]}");
                reportData.Add($"Humidity (%): {dataDictionary["Humidity (%)"][dayIndex]}");
                reportData.Add($"Precipitation (%): {dataDictionary["Precipitation (%)"][dayIndex]}");
                reportData.Add($"Lightning: {dataDictionary["Lightning"][dayIndex]}");
                reportData.Add($"Clouds: {dataDictionary["Clouds"][dayIndex]}");
                reportData.Add("");


            }



            static void AddToWeatherReport(List<string> reportData, string reportName, List<double> values)
            {

                double average = values.Average();
                double max = values.Max();
                double min = values.Min();
                double median = CalculateMedian(values);


                reportData.Add($"Report Name: {reportName}");
                reportData.Add($"Average: {average:F2}");
                reportData.Add($"Max value: {max:F2}");
                reportData.Add($"Min value: {min:F2}");
                reportData.Add($"Median value: {median:F2}");
                reportData.Add("");

            }




            static string[] ReadCsvFile(string fileName)
            {
                try
                {
                    return File.ReadAllLines(fileName);
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error reading the CSV file: {e.Message}");
                    return new string[0];
                }
            }

            static void WriteToCsvFile(string fileName, List<string> data)
            {
                try
                {
                    File.WriteAllLines(fileName, data);
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error writing to the CSV file: {e.Message}");
                }
            }




            static string GetWeatherReportPath()
            {
                string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                string currentDir = System.IO.Path.GetDirectoryName(strExeFilePath);

                return $"{currentDir}/WeatherReport.csv";
            }


            static void SendEmail(string senderEmail, string password, string receiverEmail)
            {
                try
                {
                    // Create a new MailMessage object
                    MailMessage mail = new MailMessage();

                    // Set the sender and receiver email addresses
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(receiverEmail);

                    // Set the email subject and body
                    mail.Subject = "Proposed Launch Date and CSV File";
                    mail.Body = "Please find the proposed launch date and the newly generated CSV file attached.";


                    // Create an attachment
                    Attachment attachment = new Attachment(GetWeatherReportPath());

                    // Add the attachment to the email
                    mail.Attachments.Add(attachment);

                    // Configure the SMTP client
                    SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, password);
                    smtpClient.EnableSsl = true;

                    // Send the email
                    smtpClient.Send(mail);

                    // Clean up resources
                    attachment.Dispose();
                    mail.Dispose();

                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while sending the email: " + ex.Message);
                }
            }

        }

    }
}
