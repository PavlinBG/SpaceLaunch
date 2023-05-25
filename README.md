# SpaceLaunch Repository

Welcome to the SpaceLaunch repository! This repository contains an application that helps you calculate the most appropriate day for a space shuttle launch based on weather conditions. The application takes into account the weather forecast for the first half of July and specific criteria for a successful shuttle launch.


<p align="center">
<img src="/SpaceLaunch/Screenshots/4.png" alt="Logo">
</p>

## Introduction

The purpose of this application is to assist in determining the best launch day for a space shuttle mission. It takes weather conditions into account, allowing you to make an informed decision based on the forecast.

### Console Home Screen
 
<p align="center">
  <img src="/SpaceLaunch/Screenshots/1.png" alt="Home Screen">
</p>
The application requires the following input parameters:

### Add Parameters

 
<p align="center">
  <img src="/SpaceLaunch/Screenshots/2.png" alt="Add Parameters">
</p>

- **File name**: The path to the weather forecast file on the file system.
- **Sender email address**: The email address of the sender for the launch information.
- **Password**: The password associated with the sender email address.
- **Receiver email address**: The email address of the recipient for the launch information.

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
