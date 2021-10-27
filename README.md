# WhoIsMorePopular - Akka.NET
Akka.Net is an open source, distributed computing framework built by Petabridge. It allows you to create scalable, resilient, concurrent, event-driven applications using the actor model. 

![](https://i.ibb.co/9YqwTwK/Capture.png)


**The goal of this project is to understand how the actor model works with Akka.NET through a simple application.**

## WhoIsMorePopular.Common
This project has util methods for the application (they don't matter).

## WhoIsMorePopular.Server
It is a console application that runs as a server with Akka remote. This project only has a Program class that starts the server and a .hocon file with the server settings.

## WhoIsMorePopular.WebApp
I have tried to keep the structure of this project as simple as possible to focus on the actor model.

- In the **Services** folder, there are the extension methods to inject the Akka services and search providers that the project has.

- In the **Providers** folder, there is the implementation of the search providers and the delegate for the instantiation of the actor that manages the searches.

- In the **Page** folder, there are the default files created by the application template (they don't matter).

- In the **Messages** folder, there are the types of messages that can interact with the actors. The messages are records since they must be immutable throughout the actors.

- In the **Controller** folder, there is only one controller, it exposes a single endpoint that invokes the actor that manages the searches.

- In the **ClientApp** folder, there is a React application, it is not part of the goal of this project so I did not put much effort into it.

- In the **Actors** folder, there are the actors. They are the most important part of this application.

When the **Controller** endpoint is invoked, it calls the **SearchManagerActor**, this actor has only one responsibility: receive the request and delegate it to the next actor in the hierarchy: **SearchCoordinatorActor**.

When the SearchCoordinatorActor actor is created, it creates a **SearchActor** actor for each search provider it receives. SearchActor actors only know a specific search provider and perform all searches with this provider and then return the search results to SearchCoordinatorActor.

When the SearchCoordinatorActor actor receives the result of all the SearchActors, it calculates the result of the searches and returns it to the controller.

The flow is something like this:

![](https://i.ibb.co/n7hyLwx/Flowchart.jpg)

