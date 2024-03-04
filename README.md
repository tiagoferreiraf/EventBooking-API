# Events Booking API

The Events Booking API allows performing various operations related to event and reservation management. With it, users can create events and reservations, update and delete events, view all events, as well as create, update, and delete reservations, among other functionalities.

All routes are available in the Swagger documentation, facilitating interaction with the API. In addition, user authentication using JWT has been implemented, allowing authentication through tokens. The application features both unit and integration tests and follows the CQRS pattern. The project was developed using the .NET 8 framework.

## Getting Started

### Installation
```bash
- docker
```


## Running the Application

To run the application, follow these steps:

- Clone the project to your local environment.
- Navigate to the project's root folder, open the terminal, and run the command (`docker-compose up -d`). This command will start the database. Due to complications in the docker-compose configuration, only the database will be started. To run the API locally, you will need to start the API manually.
- Open Visual Studio and in the Package Manager Console, run the command (`Add-Migration`). This command is necessary to generate migrations that will be mapped through the mappings, subsequently creating tables in the database.
- Run the command  (`Update-Database`) to create tables in the database based on the generated migrations.
- Set the EventBooking.API as the startup project.
- Run the API and test the functionalities.

## Using the API

As mentioned earlier, the API is documented through Swagger, including authorization to insert access tokens. Below, we present a basic flow to test the API:

Register User: Register a user in the API. An access token will be returned granting access to routes that require authorization.

Login with User: Log in with the registered user to obtain an access token.

Create Event: Use the access token to create events. It is possible to create, update, delete, view a single event, or view all events.

Create Reservation: Use the access token to create reservations. Like events, it is possible to create, update, delete, view a single reservation, or view all reservations.

### Testing

The application has both integration and unit tests, located in the EventBooking.Teste project. These tests ensure the robustness and reliability of the application.

For any questions or additional needs, I am available to assist.


