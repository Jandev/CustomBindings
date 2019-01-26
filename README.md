# Azure Functions v2 Custom Bindings

I'll be using this repository to create and do some tests with the Azure Functions custom bindings feature.

## Hacky hacky

Using these Bindings in v2 isn't as straightforward as the documentation makes you think it is. There have been some changes in the past, so you'll have to rely on some 'old' Azure WebJobs magic in order to get them working.

In short, what you need to do is register your custom binding as a new `Extension` and making sure this is called via a `IWebJobsStartup` class.

## `local.settings.json`

Be sure to add a `local.settings.json` file before you run the application. The contents should be similar to this.

	{
	  "IsEncrypted": false,
	  "Values": {
		"AzureWebJobsStorage": "UseDevelopmentStorage=true",
		"AzureWebJobsDashboard": "UseDevelopmentStorage=true",
		"FUNCTIONS_WORKER_RUNTIME": "dotnet",
		"filepath": "D:\\Temp\\",
		"ServiceBusConnection": "Endpoint=sb://[myServiceBus].servicebus.windows.net/;SharedAccessKeyName=[NameOfAccessKey];SharedAccessKey=[AccessKey]"
	  },
	  "ConnectionStrings": {
		"SqlServerConnectionString": "Server=tcp:[server].database.windows.net,1433;Initial Catalog=[database];Persist Security Info=False;User ID=[username];Password=[password];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
	  }
	}