# IndustrialTaskZoo
This project represents a simplified backend system for managing a Zoo Garden.
It is implemented using .NET Core WebAPI and demonstrates domain modeling, REST API design, in-memory persistence, unit testing, and optional database support.

The Zoo Garden domain contains:

A collection of animals:
-Food stock shared by all animals
-Different animal types with unique eating rules
-Persistence layer that supports In-Memory and Database modes

All animals eat the same type of food, but the amount varies by type:
-Carnivores eat 3x the standard amount
-Herbivores eat 1/2 of the standard amount
-Giraffes (although herbivores) eat exactly the standard amount

The application uses In-Memory storage by default, but supports switching to a database-backed persistence layer via configuration.
