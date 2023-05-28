using System;
using System.Globalization;

namespace Space
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
            Console.WriteLine(@" 
                        *        *                      ___                
  *       *                                       |     | |
        *                               *        / \    | |
                           *                    |---|===|-|
                                                |---|   | |
                                           *   /     \  | |
                                              |       | | |
                                              |       |=| |
                                              |       | | |
                                              |_______| |_|
                                               |@| |@|  | |
________________________________________________________|_|_ ");

            Console.WriteLine();
            Console.WriteLine("Select language:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. German");
            Console.WriteLine("3. French");
            Console.Write("Enter your choice: ");

            int languageChoice;
            while (!int.TryParse(Console.ReadLine(), out languageChoice) || languageChoice < 1 || languageChoice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter 1 for English, 2 for German, or 3 for French.");
                Console.Write("Enter your choice: ");
            }

            Console.WriteLine("Clearing the screen!");
            Console.Clear();

            string cultureName;
            switch (languageChoice)
            {
                case 2:
                    cultureName = "de-DE";
                    break;
                case 3:
                    cultureName = "fr-FR";
                    break;
                default:
                    cultureName = "en-US";
                    break;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);


            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("                    " + Language.GetLocalizedString("UI_PanelText1"));//SPACE
            Console.WriteLine();
            Console.Write("                " + Language.GetLocalizedString("UI_PanelText2")); //CONTROL CENTRE  
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine();

            Console.Write(Language.GetLocalizedString("UI_PanelText3")); //Before we launch, please provide the following data:
            Console.WriteLine();
            Console.Write(Language.GetLocalizedString("UI_PanelText4"));  //1. File Path CSV file
            Console.WriteLine();
            Console.Write(Language.GetLocalizedString("UI_PanelText5"));  //2. Sender Email (OutLook)
            Console.WriteLine();
            Console.Write(Language.GetLocalizedString("UI_PanelText6"));  //3. Sender Email (OutLook)
            Console.WriteLine();
            Console.Write(Language.GetLocalizedString("UI_PanelText7")); //4.  Email Recovery
            Console.WriteLine();


            Console.WriteLine("============================================");

            // Get input parameters from the user
            Console.Write(Language.GetLocalizedString("UI_FilePathPrompt"));
            string filePath = Console.ReadLine();

            Console.WriteLine();

            Console.Write(Language.GetLocalizedString("UI_SenderEmailPrompt"));
            string senderEmail = Console.ReadLine();

            Console.Write(Language.GetLocalizedString("UI_PasswordPrompt"));
            string password = Console.ReadLine();

            Console.WriteLine();

            Console.Write(Language.GetLocalizedString("UI_ReceiverEmailPrompt"));
            string receiverEmail = Console.ReadLine();
            Console.WriteLine(@"                  
                       -    :D  !
                   .'.
                   |o|
                  .'o'.
                  |.-.|
                  '   '
                   ( )
                    )
                   ( )

               ____
          .-' p 8o `-.
       .-'8888P'Y.`Y[ ' `-.
     ,']88888b.J8oo_      '`.
   ,' ,88888888888          Y`.
  / 8888888888P            Y8\
 / Y8888888P'             ]88\
:     `Y88'   P              `888:
:       Y8.oP '- >            Y88:
|           Yb  __             `'|
:             'd8888bo.          :
:             d88888888ooo.      ;
 \            Y88888888888P /
  \            `Y88888888P /
   `.            d88888P'    ,'
     `.          888PP'    ,'
       `-.d8P'    ,-' -    -
          `-. _ __   ,.-'
       ");


            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.Write("                    " + Language.GetLocalizedString("UI_PanelText1"));   //SPACE
            Console.WriteLine();
            Console.Write("                " + Language.GetLocalizedString("UI_PanelText8"));  //Code for the Stars!
            Console.WriteLine();
            Console.WriteLine("============================================");

            Console.WriteLine();
            Console.WriteLine(Language.GetLocalizedString("UI_InitializationMessage"));

            ShuttleLaunchCalculator calculator = new ShuttleLaunchCalculator();
            calculator.Run(filePath, senderEmail, password, receiverEmail);

            Console.ReadLine();




        }

        static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }


    }
}