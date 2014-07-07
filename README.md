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
  - Implement [Command/Query Objects] (http://msdn.microsoft.com/en-us/library/jj554200.aspx) 
  - Leverage Mediator pattern([ShortBus](https://github.com/mhinze/ShortBus)) to promotes loose coupling 
  - Role Based Security
  - Using very well documented, easy css classes by [Semantic-ui] (http://semantic-ui.com/)
  - [Asp.net Identity Framework](http://www.asp.net/identity) has been overridden by using integer as primary key for 'Users' Table.
  - TypeaHead.js for populating proposed items (better searching experience)
  
  
### Command/Query Objects
In this application all of our read actions as a parameter take a query which implements:

```
public interface IQuery<out TResponse> { }
```
	
Within the action the query is passed to a bus which locates a handler and returns a view model. 
So our API controllers now look something like this:

```
public class ShowJobsQuery : IQuery<IList<JobView>>
{
}
public IHttpActionResult Get()
{
  var model = Mediator.Request(new ShowJobsQuery());
  return Ok(model.Data);
}
```		
	
Effectively just passing queries to our mediator and returning the result.
	
Our command actions take a command which implements:
	
```
public class EditJobCommand : ICommand
{
  public int Id { get; set; }
  public decimal JobNumber { get; set; }
}
		
public IHttpActionResult Put(int id, EditJobCommand jobViewModel)
{
  var response = Mediator.Send(jobViewModel);

  if (response.HasException())
   return InternalServerError(BuildUserFriendlyMessage(response));

  return Ok(jobViewModel);
}
```	
	
Note : There's no need for any manual hand-wirings, as far as any Ioc tool( e.g. Structuremap) can take care of it simply by:
```
scan.AddAllTypesOf(typeof(IQueryHandler<,>));
scan.AddAllTypesOf(typeof(ICommandHandler<>));
```		 