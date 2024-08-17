This is an e-commerce dashboard application built using Angular for the front end and ASP.NET Core Web API for the back end. The dashboard provides a comprehensive interface for managing and analyzing e-commerce data.

preview : https://www.youtube.com/watch?v=88DErhA8Oj4

## Features

- **User Management**: Admins can manage user accounts, roles, and permissions.
- **Product Management**: Add, update, delete, and view products with detailed information.
- **Order Management**: View and manage customer orders and their statuses.
- **Sales Analytics**: Generate and view sales reports and analytics.
- **Inventory Tracking**: Monitor and manage inventory levels and stock alerts.

## Technologies

- **Frontend**: Angular
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server
- **Authentication**: JWT ( under development )

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8)
- [Node.js](https://nodejs.org/) (version 16.2)
- [Angular CLI](https://angular.io/cli) (version 14.0)

## Installation

### Backend

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/ecommerce-dashboard.git
    ```
2. Navigate to the backend directory:
    ```bash
    cd ecommerce-dashboard/backend
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```
4. Run the application:
    ```bash
    dotnet run
    ```

### Frontend

1. Navigate to the frontend directory:
    ```bash
    cd ecommerce-dashboard/frontend
    ```
2. Install dependencies:
    ```bash
    npm install
    ```
3. Run the application:
    ```bash
    ng serve
    ```

## Configuration

- Configure your database connection string in `appsettings.json` for the ASP.NET Core Web API.


## Usage

Once both the backend and frontend applications are running, navigate to `http://localhost:4200` to access the dashboard.
