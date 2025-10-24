# -----------------------------------
# STEP 1: Build stage
# -----------------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solution and restore dependencies
COPY ../../.. .
WORKDIR /app/src/Services/RecipeMicroservice

# Restore dependencies
RUN dotnet restore RecipeMicroservice.Presentation/RecipeMicroservice.Presentation.csproj

# Build and publish
RUN dotnet publish RecipeMicroservice.Presentation/RecipeMicroservice.Presentation.csproj -c Release -o /app/out

# -----------------------------------
# STEP 2: Runtime stage
# -----------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published files
COPY --from=build /app/out ./

# Expose port (Render expects port 8080 by default)
EXPOSE 8080

# Set environment variables for ASP.NET
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Start app
ENTRYPOINT ["dotnet", "RecipeMicroservice.Presentation.dll"]
