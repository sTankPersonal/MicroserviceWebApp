# -----------------------------------
# STEP 1: Build stage
# -----------------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy SDK & restore-related files first
COPY ../../../global.json .
COPY ../../../Directory.Packages.props .
COPY ../../../Webservice3.sln .

# Copy the rest of the repository
COPY ../../.. .

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

COPY --from=build /app/out ./

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "RecipeMicroservice.Presentation.dll"]
