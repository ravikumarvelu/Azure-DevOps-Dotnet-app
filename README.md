# ASP.NET Core Web Application

A modern ASP.NET Core 8.0 web application built with Razor Pages.

## Features

- ASP.NET Core 8.0
- Razor Pages
- Health Checks
- Enhanced Logging
- Development and Production configurations
- Responsive Bootstrap UI

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### 1. Clone the repository

```bash
git clone <repository-url>
cd asp-webapp
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Build the project

```bash
dotnet build
```

### 4. Run the application

```bash
dotnet run --project asp-webapp
```

The application will be available at:
- HTTPS: `https://localhost:7000`
- HTTP: `http://localhost:5000`

## Project Structure

```
asp-webapp/
├── asp-webapp/                 # Main application project
│   ├── Pages/                  # Razor Pages
│   ├── wwwroot/               # Static files (CSS, JS, images)
│   ├── Properties/            # Launch settings
│   ├── Program.cs             # Application entry point
│   ├── appsettings.json       # Production configuration
│   └── appsettings.Development.json # Development configuration
├── AspWebApp.sln              # Solution file
└── README.md                  # This file
```

## Development

### Running in Development Mode

The application uses different configurations for development and production environments:

- **Development**: Detailed error pages, debug logging
- **Production**: Custom error pages, optimized logging

### Health Checks

The application includes health checks available at `/health` endpoint.

### Configuration

Configuration is managed through:
- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development overrides
- Environment variables
- Command line arguments

## Deployment

### Prerequisites for Deployment

1. Ensure all tests pass
2. Update configuration for target environment
3. Build in Release mode:

```bash
dotnet publish -c Release -o ./publish
```

### Docker (Optional)

To containerize the application, create a `Dockerfile`:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["asp-webapp/asp-webapp.csproj", "asp-webapp/"]
RUN dotnet restore "asp-webapp/asp-webapp.csproj"
COPY . .
WORKDIR "/src/asp-webapp"
RUN dotnet build "asp-webapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asp-webapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asp-webapp.dll"]
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
