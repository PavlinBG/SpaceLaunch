# SpaceLaunch Repository

Welcome to the SpaceLaunch repository!  This repository contains an application that helps you calculate the most appropriate day for a space shuttle launch based on weather conditions.  


<p align="center">
<img src="/SpaceLaunch/Screenshots/4.png" alt="Logo">
</p>

## Home
 

 
<p align="center">
  <img src="/SpaceLaunch/Screenshots/5.png" alt="Home Screen">
</p>
The application provides user-friendly experience, with multilingual UI (English & German & French) with the ability to change the language.

### Add Parameters

 
<p align="center">
  <img src="/SpaceLaunch/Screenshots/6.png" alt="Add Parameters">
</p>

- **File name**: The path to the weather forecast file on the file system.
- **Sender email address**: The email address of the sender for the launch information.
- **Password**: The password associated with the sender email address.
- **Receiver email address**: The email address of the recipient for the launch information.

### Reading the CSV File Path
<p align="center">
  <img src="/SpaceLaunch/Screenshots/7.png" alt="Reading the CSV File Path">
</p>
The type of the accepted input file for the weather forecast (filename parameter) is CSV and has the following structure:

- Day/Parameter; 
- Temperature (C);
- Wind (m/s);
- Humidity (%);
- Precipitation (%);
- Lightning;
- Clouds;

### Calculate the most appropriate date
The criteria for the weather conditions for a space shuttle launch is as
follows:
- Temperature between 2 and 31 degrees Celsius;
- Wind speed no more than 10m/s (the lower the better);
- Humidity less than 60% (the lower the better);
- No precipitation;
- No lightings;
- No cumulus or nimbus clouds.


### Create and Send CSV
 
<p align="center">
  <img src="/SpaceLaunch/Screenshots/3.png" alt="Create and Send CSV">
</p>

After processing the weather forecast, the application will determine the most appropriate launch date and generate a CSV file containing the relevant details. It will then send an email with the launch information to the specified recipient using Outlook.

## Setup

To set up and use the SpaceLaunch application, follow these steps:

Clone the repository to your local machine using the following command:
   ```
   git clone https://github.com/PavlinBG/SpaceLaunch.git
   ```

Necessary configuration settings in the application code:
   - Replace `SENDER_EMAIL` with the sender's email address.
   - Replace `SENDER_PASSWORD` with the sender's email password.
   - Replace `RECEIVER_EMAIL` with the recipient's email address.

 
The application will process the weather forecast, calculate the best launch date, generate a CSV file, and send an email with the launch information to the recipient.

## Error Handling

The SpaceLaunch application implements error handling to provide a smooth user experience. In case of any issues, the application will display user-friendly error messages instead of unhandled errors and printed call stacks.

For example, if the specified file is not found, the application will show a message like "File not found" instead of displaying a technical error traceback.

## 📬 Feedback
Thank you for viewing my project!<br/>
If you have any questions, comments or you come across some bugs, please contact me through the contact info in my profile.<br/>
Any feedback is highly appreciated! 🙂
