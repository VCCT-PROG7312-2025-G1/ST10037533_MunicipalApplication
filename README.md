Overview
An ASP.NET Core web application called the Municipal Services Reporting Application enables users to report municipal problems like water shortages, road damage, power outages, etc. The system offers an interface for administrators to examine all submitted reports, stores reports, and supports optional file attachments.

The purpose of this application is to increase public participation and improve the implementation of municipal services.

Features
•	Submit issues with location, category, description, and optional attachments.
•	Dropdown for selecting issue categories: Sanitation, Roads, Utilities, Streetlights, Water, Other.
•	File upload functionality for supporting documents or images.
•	Validation to ensure required fields are filled.
•	View all submitted reports with details and attachments.
•	Temporary success and error messages to provide user feedback.

Technologies Used
•	ASP.NET Core MVC
•	C# language
•	Razor Pages
•	HTML5, CSS3, Bootstrap (for basic styling)
•	File upload and storage via wwwroot/Uploads

Prerequisites
•	.NET 6.0 SDK or higher
•	Visual Studio 2022
•	Web browser

Installation
1.	Clone the repository: 
https://github.com/VCCT-PROG7312-2025-G1/ST10037533_MunicipalApplication.git  
2.	Open the solution file in Visual Studio.
3.	Restore NuGet packages.
4.	Run the application (F5 in Visual Studio).
   
How to Use
1.	Navigate to the “Report an Issue” page.
2.	Fill in the required fields:
•	Location
•	Category
•	Description
3.	Optionally attach a file.
4.	Click Submit.
5.	On success, you will see a confirmation message.
6.	Navigate to All Reports to view submitted issues.
