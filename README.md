# Web2_Projekat

This is a school project for Web course in Faculty of Technical Sciences - University of Novi Sad.

Authors:

- [Student 1](https://github.com/SrdjanStankov/Web2_Projekat/wiki/Student-1): [Danilo Novaković](https://github.com/DaniloNovakovic)
- [Student 2](https://github.com/SrdjanStankov/Web2_Projekat/wiki/Student-2): [Srđan Stankov](https://github.com/SrdjanStankov)

## Getting Started

### Prerequisites

You will need the following tools:

- [Visual Studio 2017-2019](https://www.visualstudio.com/downloads/)
- [.NET Core SDK 3.1](https://www.microsoft.com/net/download/dotnet-core/3.1)
- [NPM](https://nodejs.org/en/)

### Setup

Follow these steps to get your development environment set up:

  1. Clone the repository
  1. Go to `PUSGS_Project/ClientApp` directory and run: `npm install`
  1. Build solution in Visual Studio (2017 or 2019)
  1. Start Application with `PUSGS_Project` set as your StartUp Project

### Configuration

Due to possible security difficulties of sending email to gmail from `localhost` during development, [additional steps](https://support.google.com/accounts/answer/185833) are required to make sure you get email service working.

For this reason we have added properties which you can modify in `PUSGS_Project/appsettings.json` as explained below.

```json
"ApplicationSettings": {
  /* used for jwt authorization */
  "JWT_Secret": "...", 

  /* used when creating redirect href link in email */
  "Client_URL": "http://localhost:4200",

  /* if true user can't login until he verifies email */
  "RequireEmailVerification": true,

  /* your email */
  "NetworkCredentialUsername": "...@gmail.com",

  /* password generated when you link gmail with local machine (2-step-verification) */
  "NetworkCredentialPassword": "...",

  /* if true all emails will be redirected to your email (great for development) */
  "RedirectEmailToCredentialUsername": true,

  /* client host (smtp.gmail.com for gmail) */
  "SmtpClientHost": "smtp.gmail.com",

  /* port for your smtp client (ex. 587 or 25) */
  "SmtpClientPort": 587,

  /* if true reservation invites/accept notifications will be sent via email */
  "SendEmailNotifications": true
}
```

## Doc

Project specification (currently only available in Serbian language) can be found [here](./doc/specifikacija.md) (or [here](./doc/specifikacija2.pdf) (pdf))
