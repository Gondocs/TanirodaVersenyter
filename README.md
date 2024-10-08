# Taniroda Versenytér

## Overview

TBA

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [npm](https://www.npmjs.com/get-npm)
- [Entity Framework Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## Setup and Installation

### Backend (ASP.NET Core)

1. **Install the necessary NuGet package:**

   ```bash
   dotnet add package Microsoft.IdentityModel.Tokens
   ```

2. **Install the Entity Framework Core CLI tool:**

   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. **Add a new migration:**

   ```bash
   dotnet ef migrations add InitialCreate
   ```

4. **Update the database with the new migration:**

   ```bash
   dotnet ef database update
   ```

5. **Run the backend project:**

   ```bash
   dotnet watch run
   ```

### Frontend (Node.js)

1. **Install the necessary npm packages:**

   ```bash
   npm install
   ```

2. **Start the frontend project:**

   ```bash
   npm start
   ```

## Development

For development purposes, ensure both the backend and frontend are running:

- The backend is typically accessible at `http://localhost:5163`.
- The frontend is typically accessible at `http://localhost:3000`.

## Contributing

If you want to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a Pull Request.

## License

Include licensing information here, if applicable.

## Contact

For any inquiries, please contact gondocs.robert@gmail.com
