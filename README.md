# Service.Core

## What is it?
Service.Core is a lightweight library designed to encourage modern and clean programming practices when implementing services for your architectural solution

The main concepts outlined in this library are:

[Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0)

[Anti-Corruption layer](https://learn.microsoft.com/en-us/azure/architecture/patterns/anti-corruption-layer)

## So what does this actually do for me?
Using this library creates a consistent standard across services, be it a WebAPI, Function, or even a batch job. 
All it requires are the following steps:
1. Create a class that extends the abstract ServiceController class 
   - This is where you will put your logic to handle some sort of response
2. Create a facade that extends from the abstract Facade class 
   - This class will accept the request and perform routing to your data layer
3. Create as many implementations of the IAdapter interface as needed 
   - The adapter is your data layer! 
   - Use it to fetch data from whatever source you need
   - For *extra* clean code, use a separate model when fetching source data and translate it into your common response model
4. Apply dependency injection for the service controller, facade, and adapter(s)

**Best Practices**:
* Keep your Controllers and Facades in a separate project from your base WebAPI. This is actually a good practice, regardless of your implementation; it keeps your implementation separate from the API specifications.

* Keep your request/response models either in a sourced NuGet package, or in a separate project. This is also a really good practice. I'd highly recommend keeping them in an entirely separate solution, and use it as a NuGet package. This lets you (or other users) consume the data models directly without any overhead, and prevents "data model corruption" caused by human error trying to replicate the definition of a data model.

* Adapters should live in their own project. This is essential to the Anti-Corruption layer pattern. You don't want to mix data retrieval/source models between systems. It just creates a headache. Keep your adapters separated, and only used to fetch/transform data, and you'll be one happy camper in the future. Trust me on that.

* Keep your dependency injection in your projects specific to that project. For example, don't add DI to your main project for your implementation. Don't add DI anywhere for your adapters besides in your adapter projects. Keep things separate, and you don't end up with dependency hell, and you make sure your implementations are where they belong. See the sample project at the end of the readme as an example.

### FAQ

### I only have one source system, and only need one source system! Do I really need the facade?
Well, you're not forced to use it. If you really want to connect to your data layer directly from the controller, I can't stop you.

**However**

If you're building something out that's actually going to be used by end users, chances are, eventually, you'll need to implement a new backend. It's better to implement a facade and make your life easier now, than later.

### Wait a minute... I need a logger? Can't I inject these classes without it?
Don't be lazy, don't be too confident. Loggers are excellent. Don't fall into the fallacy of "I don't need logging, my application works fine!". If that was true (it's not), you'd be one in a quadrillion. Just inject the logger. 

For beginning, you can just inject a console logger:

`builder.Logging.AddConsole();`

`builder.Services.AddTransient<ILogger>(x => x.GetService<ILogger<Program>>());`

### Do you have a sample I can reference?
Yes! [This sample here](https://github.com/arhuelsman/SampleWebAPI) references a WebAPI example, but it can be applied to just about anything you need it for.

### Can I contribute to this project?
Feel free to fork, make a branch, whatever. I'll review anything and if I find it helpful to the core library I'll be happy to add it with note on your contribution :)
