

## I just create a repository to share my issue

The first step is : 

    docker-compose up in the root directory


After the kafka is up, start masstransit-poc.sln with VS 2019 and try to debug the API.

**1. IIS Express (or Console App mode "API")**

With "IIS Express" (or console app) startup mode : everything is ok !
Even if the host is invalid or the topic is not yet created, the API stay up and several logs are written.

And when I setup my topic, I can handle the message in my consumer : it's perfect

**But**, I don't want to use : "IIS Express" (or console app) debug mode, I want to use **Docker** and more precisely : Docker Compose integration

**2. Docker**

I just switch from "IIS Express" or "API" to "Docker", then I press play

The API start and few seconds after I got the error specify in my issue : 

    The program 'dotnet' has exited with code 0 (0x0).

without any other explanation :(

> Note :  if you comment the line
> "services.AddMassTransitHostedService();" the API will start and it
> doesn't stop, but it does nothing of course.

