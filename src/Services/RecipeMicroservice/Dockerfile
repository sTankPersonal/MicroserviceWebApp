# -----------------------------------
# STEP 1: Build stage
# -----------------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy solution-level files first for caching
COPY global.json .
COPY Directory.Packages.props .
COPY MicroserviceWebApp.sln .

# Copy the microservice source code
COPY src/Services/RecipeMicroservice ./src/Services/RecipeMicroservice

WORKDIR /app/src/Services/RecipeMicroservice

# Restore dependencies
RUN dotnet restore RecipeMicroservice.Presentation/RecipeMicroservice.Presentation.csproj

# Build and publish
RUN dotnet publish RecipeMicroservice.Presentation/RecipeMicroservice.Presentation.csproj -c Release -o /app/out

# -----------------------------------
# STEP 2: Runtime stage
# -----------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/out ./

# Expose port
EXPOSE 8080

# Environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Start the application
ENTRYPOINT ["dotnet", "RecipeMicroservice.Presentation.dll"]
