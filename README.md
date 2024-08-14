I am developing a JobSearch website utilizing C# and REST API, built with an Onion architecture. This architecture is composed of three primary layers:

Core Layer: Contains the core Application and Domain entities.
Infrastructure Layer: Manages data access and external service integrations.
Presentation Layer: Handles the user interface and interaction with the API.

Technologies Used:
Database: MS SQL Server
Technology: Squares technology
Data Transfer: DTOs (Data Transfer Objects) are used to transfer data from the database to the view.
Exception Handling: Implemented with Middleware to capture and manage exceptions across the application.
Validation: Applied to ensure data integrity and accuracy.
AutoMapper: Utilized to map objects between different layers.
Authentication: Token-based authentication for user login and registration.
UnitOfWork Pattern: Employed to manage transactions and maintain consistency.

Features and Practices:
Onion Architecture: Ensures separation of concerns and improves the maintainability and testability of the application.
DTOs: Used to map data between the database and the view, promoting a clean separation between data and presentation.
Exception Handling Middleware: Provides a centralized mechanism for managing and logging exceptions.
AutoMapper: Streamlines the process of object-to-object mapping, reducing boilerplate code.
Token-Based Authentication: Secures user access and manages authentication through tokens.
UnitOfWork Pattern: Manages database transactions and ensures consistency across multiple operations.
This project combines modern software design principles and practices to build a robust and scalable job search platform.
