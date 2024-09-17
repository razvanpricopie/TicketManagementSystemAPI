This repository represents the backend application of a System ticketing management type application.

The application was created as a final project for the dissertation.

The repository for the frontend application of this project can be found on my profile under the name "ticket-management-system"

The application contains all the basic functionalities of this type of application:
- role based functionalities
- dashboard for managing events, categories and orders
- jwt auth and registration
- card payment - using the Stripe API
- like/dislike event

The architecture used for modeling the application is Clean Architecture.

Technologies used:
- C# with ASP.NET Core
- Entity Framework Core
- MediatR
- AutoMapper
- SQL Server
- Stripe.NET

The application also contains an AI component for personalized event recommendations, integrating OpenAI's GPT3 Turbo API.
The code for the integration of the AI ​​component can be found on the branch called "integrare-gpt".
