# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY ./BtnxProfileApp/BtnxProfileApp.csproj ./BtnxProfileApp/
RUN dotnet restore "./BtnxProfileApp/BtnxProfileApp.csproj"

# Copy the rest of the application code and build the app
COPY ./BtnxProfileApp/ ./BtnxProfileApp/
WORKDIR /app/BtnxProfileApp
RUN dotnet publish BtnxProfileApp.csproj -c Release -o /app/publish

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Debug step: Check if the .dll is in the runtime container
RUN ls -la /app

# Debug step: Add a shell sleep to keep the container running for manual inspection
CMD ["sleep", "3600"]

# Entry point to run the application
ENTRYPOINT ["dotnet", "BtnxProfileApp.dll"]
