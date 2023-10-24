# Order Apps
This solution is developed to demonstrate the usage of Azure Functions with Http and Service Bus Queue Triggers along with developing ASP.NET Core Web API with Entity Framework Code First approach, The solution consists of three application:
- Send Order Function App
- Receive Order Function App
- Order Web API

# Functional Flow
As shown in the diagram, client who wishes to create a new order, posts a order request to Send Order Function which (Http Trigger). Send Order function will publoish the order message to a Azure Service Bus Queue. Another function named Receive Order (Service Bus Trigger) will receive the order message and calls Order API. Order API finally saves the order in SQL Server database.

![image](https://github.com/nehapardeshi/order-apps/assets/53896012/1304feee-3b10-4cb0-81b5-d553f76b1306)


# Getting Started
## Add your files

- [ ] [Create](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#create-a-file) or [upload](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#upload-a-file) files
- [ ] [Add files using the command line](https://docs.gitlab.com/ee/gitlab-basics/add-file.html#add-a-file-using-the-command-line) or push an existing Git repository with the following command:

```
cd existing_repo
git remote add origin https://gitlab.com/nehapardeshi/order-apps.git
git branch -M main
git push -uf origin main
```

## Setup Order API Project
- Ensure to have connection string of SQL Server where new orders database can be created
- Clone repo and open order-apps.sln solution file
- Update ConnectionStrings.SqlConnection value in the appsettings.json file
- Build the solution
- Open package manage console and run Update-Database
- Run the Web API and swagger UI will open
- 
  
## Azure Service Bus Setup
Create an Azure Service Bus namespace in your Azure portal.

Create a queue named "orders" on the Service Bus to send and receive messages related to orders.


## Testing and Documentation

Run Order API Unit Tests


# Future Scope
Authentication and Authorization
-Necessary authentication and authorization mechanisms in place for your API to interact with GitHub and Azure Service Bus. 
This may involve generating tokens or using OAuth2 for GitHub and Azure Managed Identity or Shared Access Signature (SAS) tokens for Azure Service Bus.
