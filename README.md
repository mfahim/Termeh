Termeh
======
   This is an effort to build a single page application (SPA) using Microsoft technologies from a different angle. In this project two different suite of technologies glued together for building LOB apps. One of the latest Microsoft technologies in building REST services has been used (WEB API) and on the Client-Side one of the most common Javascript frameworks (AngularJS). 

## Server-Side Tools
  *	Asp.Net WEB API
  *	Entity Framework 
  *	StructureMap

## Client-Side Tools
  *	AngularJS
  *	Semantic UI

## Project Structure
  *	Termeh.API (WEB API)
  *	Termeh.Web (AngularJS)

## How to:
### Configuration and Compilation
#### Termeh.API(Server-side)
  - Change Database >connection string in Termeh.API/Web.Config to your desired computer settings
  - Build the solution to install NuGet packages ( this will restore all required packages)
  - Termeh.API is running under IIS Express.

##### Termeh.Web(Client-side)
  - Please ensure that Termeh.API is up and running.
  - Change the url address of ‘apiurl’ in Termeh.Web/Scripts/config.js to your ‘Termeh.API’ running url in order to connect to WEB API server.
  - Please make sure Javascript files listed in Termeh.Web/index.html have correct paths.
  - Run the solution.

## Available Features
  - REST API with MS Web API 
  - Implement Command/Query pattern by ShortBus
  - Role Based Security
  - Using very well documented, easy css classes by Semantic-ui 
  - Asp.net Identity Framework has been overridden by using integer as primary key for 'Users' Table.
