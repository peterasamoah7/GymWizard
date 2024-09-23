<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<p align="center">
<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
      </ul>
      <ul>
        <li><a href="#setup">Setup & Running</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Gym Wizard is an online AI tool powered by OpenAI. The goal of this project is to demonstrate how generative AI can be used in providing quick and easy advise for beginner and experienced gym goers. 
Gym Wizard can generate a workout plan, recommend meal plans to help you meet your calorie deficit and also identify and advise on how to use gym machines and equipments.

Feature
* Workout Builder: Gym Wizard can generate tailored based on user input workout sessions with clear descriptions. 
* Mean Plan Builder: Gym Wizard can generate meal plans to help users meet their calories goals based on estimateed calories and preferred macros. 
* Machine Finder: Gym Wizard can generate benefical information on gym machine by anlysing upload image.

You can view the demo [here](https://youtu.be/suaMCUWgQpw)

You can try the live application here [Live site](https://gymwizard.azurewebsites.net)

### Built With
* [ASP.NET Core](https://dotnet.microsoft.com/)
* [OpenAI .NET library](https://github.com/openai/openai-dotnet)
* [OpenAI](https://platform.openai.com/docs/overview)


<!-- GETTING STARTED -->
## Getting Started

To run the application locally, please follow the steps below.

### Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/)
* [OpenAI Developer account](https://platform.openai.com/docs/overview)


### Setup

1. Clone the repo 
2. Create an OpenAI Developer Account at [OpenAI](https://azure.microsoft.com/) or use an existing one. 
3. Update `appsettings.json`
  ```sh
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "APIKey": "<Add your API Key here>",
  "GPTModel": "<Provide your GPT Model>"  
}
```

### Running from Visual Studio

1. From Visual Studio, press `F5`
 
<!-- USAGE EXAMPLES -->
## Usage

Please refer to the [demo](https://youtu.be/suaMCUWgQpw)

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.
