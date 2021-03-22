

## I just create a repository to share my issue

The first step is : in the root directory, execute this statement 

    docker-compose up


After the kafka is up, start masstransit-poc.sln with VS 2019 and try to debug the API.

**1. IIS Express (or Console App mode "API")** (on Windows 10)

With "IIS Express" (or console app) startup mode : everything is ok !
Even if the host is invalid or the topic is not yet created, the API stay up and several logs are written.

And when I setup my topic, I can handle the message in my consumer : it's perfect

**But**, I don't want to use : "IIS Express" (or console app) debug mode, I want to use **Docker** and more precisely : Docker Compose integration

**2. Docker** (image : mcr.microsoft.com/dotnet/core/aspnet:3.1.9-alpine3.12)

I just switch from "IIS Express" or "API" to "Docker", then I press play

The API start and few seconds after I got the error specify in my issue : 

    The program 'dotnet' has exited with code 0 (0x0).

without any other explanation :(

> Note 1 :  if you comment the line
> "services.AddMassTransitHostedService();" the API will start and it
> doesn't stop, but it does nothing of course.

> Note 2 :  I try to switch from InMemory Bus to RabbitMQ Bus, and ... same issue on Docker (and continue to work in console app mode)

