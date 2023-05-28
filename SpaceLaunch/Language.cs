namespace Space
{
    class Language
    {


        public static string GetLocalizedString(string key)
        {
            // Localization resources
            Dictionary<string, Dictionary<string, string>> resources = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "en-US",
                    new Dictionary<string, string>
                    {
                        { "UI_ASCII_ART", @"
                        
                    " },
                        { "UI_PanelText1", "SPACE" },
                        { "UI_PanelText2", "CONTROL CENTRE" },
                        { "UI_PanelText3", "Before we launch, please provide the following data:" },
                        { "UI_PanelText4", "1. File Path CSV file" },
                        { "UI_PanelText5", "2. Sender Email With OutLook" },
                        { "UI_PanelText6", "3. Email Password" },
                        { "UI_PanelText7", "4. Receiver email address" },
                        { "UI_PanelText8", "Code for the Stars" },

                        { "UI_FilePathPrompt", "Enter the file path of the CSV data:" },
                        { "UI_SenderEmailPrompt", "Enter your email address:" },
                        { "UI_PasswordPrompt", "Enter your email password:" },
                        { "UI_ReceiverEmailPrompt", "Enter the receiver's email address:" },
                        { "UI_InitializationMessage", "Initializing the space mission control centre..." },
                        { "UI_WeatherReportTitle", "WEATHER REPORT" },
                        { "UI_AppropriateLaunchDay", "An appropriate launch day has been found:" },
                        { "UI_NoAppropriateLaunchDay", "No appropriate launch day has been found." },
                        { "UI_Day", "Day" },
                        { "UI_Temperature", "Temperature" },
                        { "UI_Wind", "Wind (m/s)" },
                        { "UI_Humidity", "Humidity (%)" },
                        { "UI_Precipitation", "Precipitation (%)" },
                        { "UI_Lightning", "Lightning" },
                        { "UI_Clouds", "Clouds" },
                        { "UI_Yes", "Yes" },
                        { "UI_Cumulus", "Cumulus" },
                        { "UI_Nimbus", "Nimbus" },
                        { "UI_MostAppropriateLaunchDay", "Most Appropriate Launch Day:" },
                        { "UI_ReportName", "Report Name" },
                        { "UI_Average", "Average" },
                        { "UI_MaxValue", "Maximum Value" },
                        { "UI_MinValue", "Minimum Value" },
                        { "UI_MedianValue", "Median Value" },
                        { "UI_ErrorReadingCSV", "Error reading the CSV file" },
                        { "UI_ErrorWritingCSV", "Error writing to the CSV file" },
                        { "UI_EmailSubject", "Space Mission Weather Report" },
                        { "UI_EmailBody", "Please find attached the weather report for the space mission." },
                        { "UI_EmailSent", "Email sent successfully!" },
                        { "UI_EmailSendingError", "Error sending the email" }
                    }
                },{
        "de-DE",
        new Dictionary<string, string>
        {
            { "UI_ASCII_ART", @"
 
                                         
        " },
            { "UI_PanelText1", "ESPACE" },
            { "UI_PanelText2", "CENTRE DE CONTRÔLE" },
            { "UI_PanelText3", "Avant le lancement, veuillez fournir les données suivantes :" },
            { "UI_PanelText4", "1. Chemin du fichier CSV" },
            { "UI_PanelText5", "2. Adresse e-mail de l'expéditeur avec Outlook" },
            { "UI_PanelText6", "3. Mot de passe de l'e-mail" },
            { "UI_PanelText7", "4. Adresse e-mail du destinataire" },
            { "UI_PanelText8", "Code pour les étoiles" },
            { "UI_FilePathPrompt", "Geben Sie den Dateipfad der CSV-Daten ein:" },
            { "UI_SenderEmailPrompt", "Geben Sie Ihre E-Mail-Adresse ein:" },
            { "UI_PasswordPrompt", "Geben Sie Ihr E-Mail-Passwort ein:" },
            { "UI_ReceiverEmailPrompt", "Geben Sie die E-Mail-Adresse des Empfängers ein:" },
            { "UI_InitializationMessage", "Initialisiere das Raumfahrtkontrollzentrum..." },
            { "UI_WeatherReportTitle", "WETTERBERICHT" },
            { "UI_AppropriateLaunchDay", "Ein geeigneter Starttag wurde gefunden:" },
            { "UI_NoAppropriateLaunchDay", "Es wurde kein geeigneter Starttag gefunden." },
            { "UI_Day", "Tag" },
            { "UI_Temperature", "Temperatur" },
            { "UI_Wind", "Wind (m/s)" },
            { "UI_Humidity", "Luftfeuchtigkeit (%)" },
            { "UI_Precipitation", "Niederschlag (%)" },
            { "UI_Lightning", "Blitze" },
            { "UI_Clouds", "Wolken" },
            { "UI_Yes", "Ja" },
            { "UI_Cumulus", "Cumulus" },
            { "UI_Nimbus", "Nimbus" },
            { "UI_MostAppropriateLaunchDay", "Bestgeeigneter Starttag:" },
            { "UI_ReportName", "Berichtsname" },
            { "UI_Average", "Durchschnitt" },
            { "UI_MaxValue", "Maximaler Wert" },
            { "UI_MinValue", "Minimaler Wert" },
            { "UI_MedianValue", "Mittlerer Wert" },
            { "UI_ErrorReadingCSV", "Fehler beim Lesen der CSV-Datei" },
            { "UI_ErrorWritingCSV", "Fehler beim Schreiben in die CSV-Datei" },
            { "UI_EmailSubject", "Wetterbericht für die Raummission" },
            { "UI_EmailBody", "Im Anhang finden Sie den Wetterbericht für die Raummission." },
            { "UI_EmailSent", "E-Mail erfolgreich gesendet!" },
            { "UI_EmailSendingError", "Fehler beim Senden der E-Mail" }
         }
     },

                {
                    "fr-FR",
                    new Dictionary<string, string>
                    {
                        { "UI_ASCII_ART", @"
 
                                             
                    " },
                        { "UI_PanelText1", "ESPACE" },
                        { "UI_PanelText2", "CENTRE DE CONTRÔLE" },
                        { "UI_PanelText3", "Avant le lancement, veuillez fournir les données suivantes :" },
                        { "UI_PanelText4", "1. Chemin du fichier CSV" },
                        { "UI_PanelText5", "2. Adresse e-mail de l'expéditeur avec Outlook" },
                        { "UI_PanelText6", "3. Mot de passe de l'e-mail" },
                        { "UI_PanelText7", "4. Adresse e-mail du destinataire" },
                        { "UI_PanelText8", "Code pour les étoiles" },
                        { "UI_FilePathPrompt", "Entrez le chemin d'accès du fichier CSV :" },
                        { "UI_SenderEmailPrompt", "Entrez votre adresse e-mail :" },
                        { "UI_PasswordPrompt", "Entrez votre mot de passe e-mail :" },
                        { "UI_ReceiverEmailPrompt", "Entrez l'adresse e-mail du destinataire :" },
                        { "UI_InitializationMessage", "Initialisation du centre de contrôle de la mission spatiale..." },
                        { "UI_WeatherReportTitle", "RAPPORT MÉTÉOROLOGIQUE" },
                        { "UI_AppropriateLaunchDay", "Un jour de lancement approprié a été trouvé :" },
                        { "UI_NoAppropriateLaunchDay", "Aucun jour de lancement approprié n'a été trouvé." },
                        { "UI_Day", "Jour" },
                        { "UI_Temperature", "Température" },
                        { "UI_Wind", "Vent (m/s)" },
                        { "UI_Humidity", "Humidité (%)" },
                        { "UI_Precipitation", "Précipitation (%)" },
                        { "UI_Lightning", "Éclairs" },
                        { "UI_Clouds", "Nuages" },
                        { "UI_Yes", "Oui" },
                        { "UI_Cumulus", "Cumulus" },
                        { "UI_Nimbus", "Nimbus" },
                        { "UI_MostAppropriateLaunchDay", "Jour de lancement le plus approprié :" },
                        { "UI_ReportName", "Nom du rapport" },
                        { "UI_Average", "Moyenne" },
                        { "UI_MaxValue", "Valeur maximale" },
                        { "UI_MinValue", "Valeur minimale" },
                        { "UI_MedianValue", "Valeur médiane" },
                        { "UI_ErrorReadingCSV", "Erreur lors de la lecture du fichier CSV" },
                        { "UI_ErrorWritingCSV", "Erreur lors de l'écriture dans le fichier CSV" },
                        { "UI_EmailSubject", "Rapport météorologique de la mission spatiale" },
                        { "UI_EmailBody", "Veuillez trouver ci-joint le rapport météorologique de la mission spatiale." },
                        { "UI_EmailSent", "E-mail envoyé avec succès !" },
                        { "UI_EmailSendingError", "Erreur lors de l'envoi de l'e-mail" }
                    }
                }
            };

            string cultureName = Thread.CurrentThread.CurrentCulture.Name;

            if (resources.ContainsKey(cultureName) && resources[cultureName].ContainsKey(key))
            {
                return resources[cultureName][key];
            }
            else
            {
                // Fallback to English
                return resources["en-US"][key];
            }
        }

    }
}

