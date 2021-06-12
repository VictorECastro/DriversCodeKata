# DriversCodeKata
 Code Kata Exercise for Drivers History

This project consists in 2 different projects

Web site, which is created using HTML with Javascript to consume the Rest API project
REST API project developed with ASP.NET Core 5 Web API
Instructions to deploy: Web Site

Download the website folder and create a virtual directory in IIS
Set the website directory as physical directory for virtual directory
Set default.html as default document for virtual directory
It is important that web sites open from localhost since this url is allowed in the REST API
REST API

Download RestAPI folder
Open published folder and add an application in IIS.
Set published folder as physical directory for the application.
configure in web site default.html file the url for the rest api in settings -> url (line 101) api resides in http://server/api/process
Test REST API call with postman, you can use drivers postman collection included in FilesAndPostman folder.
once the url is configured and API tested you can start using the program.
Open web site Select a text file (included in the FilesAndPostman folder) Process request and you will see the results.

REST API

Developed using ASP.NET Core 5 Web API

Models
Contains 2 models Driver and Trip, this 2 models contains the properties for each type of data that will be received by the API in the text file

Repo
Contains 2 repository files for the models, this files contains all the logic to process the received information

Controller
ProcessController, implements Upload Post method that will receive formdata from website, process the information and return the result organized as required.

CROS
REST API has CROS enabled for http://locahost then the web site should be created on the locahost as virtual directory or modify Rest API cross in Startup.cs Configuration the allowed URL.

WEB SITE
For the web site, the url (line 101) should be modified with the REST API url, and add /api/Process to consume the process controller.

Thank you.
