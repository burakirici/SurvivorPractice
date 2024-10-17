Survivor Web API
This application is a Web API for managing competitors and categories in a Survivor competition. There is a one-to-many relationship between categories and competitors: one category can have multiple competitors, but each competitor belongs to only one category. The API provides CRUD (Create, Read, Update, Delete) operations for managing this relationship.

Technologies Used
.NET Core
Entity Framework Core (EF Core)
Swagger (for API documentation)
Postman (for API testing)
Project Structure
BaseEntity.cs: A base class for all entities, containing common properties like Id.
Competitor.cs: Represents the competitors table.
Category.cs: Represents the categories table.
CompetitorController.cs: Manages CRUD operations for competitors.
CategoryController.cs: Manages CRUD operations for categories.
