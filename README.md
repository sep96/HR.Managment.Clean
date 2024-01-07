# ASP.NET Core - SOLID and Clean Architecture Project

This project is designed and structured following the principles of SOLID and Clean Architecture in ASP.NET Core.

## Overview

The project aims to demonstrate a robust, maintainable, and scalable architecture by adhering to SOLID principles and Clean Architecture practices. It separates concerns into distinct layers to promote code maintainability, testability, and flexibility.

## Features

- **SOLID Principles Implementation**: The codebase is structured to adhere to SOLID principles, promoting a clean, understandable, and maintainable codebase.
- **Clean Architecture**: Follows the Clean Architecture design pattern to maintain separation of concerns, keeping the codebase independent of external concerns like frameworks and databases.
- **Layered Structure**: Divides the application into layers - Presentation, Application, Domain, and Infrastructure - ensuring a clear separation of concerns.
- **Dependency Injection**: Utilizes ASP.NET Core's built-in dependency injection for loose coupling and easy testing of components.
- **Unit Testing**: Encourages and demonstrates unit testing practices to ensure the reliability and correctness of the codebase.

## Project Structure

- **src/**: Contains the main source code of the application.
  - **Presentation/**: Handles HTTP requests, contains controllers, and deals with user inputs and outputs.
  - **Application/**: Contains application-specific business logic, use cases, and application services.
  - **Domain/**: Defines the core domain entities, interfaces, and business logic.
  - **Infrastructure/**: Deals with external concerns like database access, third-party integrations, etc.
- **tests/**: Houses unit tests for different layers/modules of the application.

## Getting Started

To get started with this project, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/your-project.git
