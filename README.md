# ToDoList Web API

This is an ASP.NET Core Web API project for a simple task management application.

## Project Description

This project allows users to organize their daily tasks, create new tasks, update existing tasks, and delete them when necessary. Additionally, it is protected by user authentication and authorization, which means only authorized users can access the API.

## Technologies Used

- **ASP.NET Core**: The project is built using ASP.NET Core, a cross-platform framework for building modern, cloud-based, and internet-connected applications.

- **Entity Framework Core**: Entity Framework Core is used as the Object-Relational Mapping (ORM) framework for database interactions.

- **JWT Authentication**: JSON Web Tokens (JWT) are used for user authentication and securing API endpoints.

- **Swagger**: Swagger is integrated into the project for API documentation and testing.

- **SQL Server**: The database is powered by SQL Server, a relational database management system.

- **Git and GitHub**: Git is used for version control, and the project is hosted on GitHub for collaboration and code sharing.

## Features
- Selecting a date from the calendar
- Add a new task
- Mark a task as completed/incomplete
- Task prioritization
- Edit a task
- Delete a single task
- Delete completed tasks
- Delete all tasks

## How to use

You can create, update, delete, and list your tasks using the API. You can also authenticate by registering or logging in as a user.
## Getting Started

Below, you can find the basic steps on how to get started with this project in your local development environment.

1. Clone this repository to your local machine:

    ```bash          
    git clone https://github.com/kmlcncyln/ToDoList.git
    ```

2. Update the database connection string in the appsettings.json file:

   ```bash
   "ConnectionStrings": {
    "DefaultConnection": "your-connection-string-here"}

3. Navigate to the project folder and create the necessary database tables by running the following command:

   ```bash
    dotnet ef database update
    ```

4. Start the project:

    ```bash
    dotnet run
    ```

    
