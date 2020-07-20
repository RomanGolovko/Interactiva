# Interactiva

The solution was implemented according to requirements. It consist the front-end (angular10), the back-end(.net core 3.1) and the relational database (sql localdb).
Back-end has low coupled layered architecture ( Presentation, Service (business logic), DataAccess, Shared).
Application use swagger as API documentation, covered with Unit tests (back-end), support containers (Docker)

## Application setup
Clone the project from this repository, open it in Visual studio, set up `WebUI` as startup project and press `F5` or use docker-compose to run application in container.

## DB setup
For creation local database copy in `Package Manager Console` type  command: `Update-Database`
or in `cmd` using `.NET Core CLI` type command: `dotnet ef database update`

## Application description
Application is basically CRUD operations fro managing pets of Interactiva employees pets. It shows a list of employees and their pets, where you can add employees with pets, update existing information, or delete employees.
