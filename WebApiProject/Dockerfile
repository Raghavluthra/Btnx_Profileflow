# Use the official ASP.NET Core image for the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the WebApiProject.csproj file and restore dependencies
COPY ./WebApiProject/WebApiProject.csproj ./WebApiProject/
RUN dotnet restore "./WebApiProject/WebApiProject.csproj"

# Copy the rest of the project files to the container
COPY ./WebApiProject/ ./WebApiProject/
WORKDIR /src/WebApiProject

# Build the project
RUN dotnet build "WebApiProject.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "WebApiProject.csproj" -c Release -o /app/publish

# Use the base image to create the runtime environment
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApiProject.dll"]
