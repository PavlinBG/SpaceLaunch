using System.Net;
using System.Net.Mail;


namespace Space
{

    class ShuttleLaunchCalculator
    {
        public void Run(string filePath, string senderEmail, string password, string receiverEmail)
        {
            string[] dataArray = ErrorHandling.ReadCsvFile(filePath);
            Dictionary<string, List<string>> dataDictionary = ParseArrayData(dataArray);

            List<double> temperatureValues = new List<double>();
            List<double> windValues = new List<double>();
            List<double> humidityValues = new List<double>();
            List<double> precipitationValues = new List<double>();
            List<double> lightningValues = new List<double>();

            for (int dayIndex = 0; dayIndex < dataDictionary["Day/Parameter"].Count; dayIndex++)
            {
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
                Console.WriteLine(Language.GetLocalizedString("UI_AppropriateLaunchDay"));
                PrintWeatherData(dataDictionary, appropriateDayIndex);

                //Add the most appropriate launch day to the WeatherReport.csv
                AddWeatherData(reportData, dataDictionary, appropriateDayIndex);
            }
            else
            {
                reportData.Add(Language.GetLocalizedString("UI_NoAppropriateLaunchDay"));
                Console.WriteLine(Language.GetLocalizedString("UI_NoAppropriateLaunchDay"));
            }

            AddToWeatherReport(reportData, "Temperature", temperatureValues);
            AddToWeatherReport(reportData, "Wind", windValues);
            AddToWeatherReport(reportData, "Humidity", humidityValues);
            AddToWeatherReport(reportData, "Precipitation", precipitationValues);

            string reportFileName = GetWeatherReportPath();
            ErrorHandling.WriteToCsvFile(reportFileName, reportData.ToArray());

            SendEmail(senderEmail, password, receiverEmail);

            Console.WriteLine("Press any key to exit.");       // to do maybe
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

        static void PrintWeatherData(Dictionary<string, List<string>> dataDictionary, int dayIndex)
        {
            Console.WriteLine($"{Language.GetLocalizedString("UI_Day")}: {dataDictionary["Day/Parameter"][dayIndex]}");
            Console.WriteLine($"{Language.GetLocalizedString("UI_Temperature")}: {dataDictionary["Temperature"][dayIndex]}");
            Console.WriteLine($"{Language.GetLocalizedString("UI_Wind")}: {dataDictionary["Wind (m/s)"][dayIndex]}");
            Console.WriteLine($"{Language.GetLocalizedString("UI_Humidity")}: {dataDictionary["Humidity (%)"][dayIndex]}");
            Console.WriteLine($"{Language.GetLocalizedString("UI_Precipitation")}: {dataDictionary["Precipitation (%)"][dayIndex]}");
            Console.WriteLine($"{Language.GetLocalizedString("UI_Lightning")}: {dataDictionary["Lightning"][dayIndex]}");
            Console.WriteLine($"{Language.GetLocalizedString("UI_Clouds")}: {dataDictionary["Clouds"][dayIndex]}");
        }

        static double GetDoubleValue(string value)
        {
            return double.TryParse(value, out double result) ? result : double.NaN;
        }

        static double CalculateMedian(List<double> values)
        {
            List<double> sortedValues = values.OrderBy(x => x).ToList();
            int count = sortedValues.Count;

            return count % 2 == 0
                ? (sortedValues[count / 2 - 1] + sortedValues[count / 2]) / 2
                : sortedValues[count / 2];
        }

        static int GetAppropriateLaunchDayIndex(Dictionary<string, List<string>> dataDictionary, List<double> temperatureValues, List<double> windValues, List<double> humidityValues, List<double> precipitationValues, List<double> lightningValues)
        {
            for (int dayIndex = 0; dayIndex < dataDictionary["Day/Parameter"].Count; dayIndex++)
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
                    && !hasLightning.Contains(Language.GetLocalizedString("UI_Yes"))
                    && !clouds.Contains(Language.GetLocalizedString("UI_Cumulus"))
                    && !clouds.Contains(Language.GetLocalizedString("UI_Nimbus")))
                {
                    return dayIndex++;
                }
            }

            return -1;
        }
        static void AddWeatherData(List<string> reportData, Dictionary<string, List<string>> dataDictionary, int dayIndex)
        {
            reportData.Add(Language.GetLocalizedString("UI_MostAppropriateLaunchDay"));
            reportData.Add($"{Language.GetLocalizedString("UI_Day")}: {dataDictionary["Day/Parameter"][dayIndex]}");
            reportData.Add($"{Language.GetLocalizedString("UI_Temperature")}: {dataDictionary["Temperature"][dayIndex]}");
            reportData.Add($"{Language.GetLocalizedString("UI_Wind")}: {dataDictionary["Wind (m/s)"][dayIndex]}");
            reportData.Add($"{Language.GetLocalizedString("UI_Humidity")}: {dataDictionary["Humidity (%)"][dayIndex]}");
            reportData.Add($"{Language.GetLocalizedString("UI_Precipitation")}: {dataDictionary["Precipitation (%)"][dayIndex]}");
            reportData.Add($"{Language.GetLocalizedString("UI_Lightning")}: {dataDictionary["Lightning"][dayIndex]}");
            reportData.Add($"{Language.GetLocalizedString("UI_Clouds")}: {dataDictionary["Clouds"][dayIndex]}");
            reportData.Add("");
        }

        static void AddToWeatherReport(List<string> reportData, string reportName, List<double> values)
        {
            double average = values.Average();
            double max = values.Max();
            double min = values.Min();
            double median = CalculateMedian(values);

            reportData.Add($"{Language.GetLocalizedString("UI_ReportName")}: {reportName}");
            reportData.Add($"{Language.GetLocalizedString("UI_Average")}: {average:F2}");
            reportData.Add($"{Language.GetLocalizedString("UI_MaxValue")}: {max:F2}");
            reportData.Add($"{Language.GetLocalizedString("UI_MinValue")}: {min:F2}");
            reportData.Add($"{Language.GetLocalizedString("UI_MedianValue")}: {median:F2}");
            reportData.Add("");
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
                mail.Subject = Language.GetLocalizedString("UI_EmailSubject");
                mail.Body = Language.GetLocalizedString("UI_EmailBody");

                // Create an attachment
                Attachment attachment = new Attachment(GetWeatherReportPath());

                // Add the attachment to the email
                mail.Attachments.Add(attachment);

                // Configure the SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(senderEmail, password);

                // Send the email
                smtpClient.Send(mail);

                Console.WriteLine(Language.GetLocalizedString("UI_EmailSent"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Language.GetLocalizedString("UI_EmailSendingError")}: {e.Message}");
            }
        }

    }
}