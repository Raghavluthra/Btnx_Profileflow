# BTNX_ProfileFlow

**BTNX_ProfileFlow** is a web-based profile management system that allows users to create, update, and view profiles. The solution is structured into two major components: a **Blazor WebAssembly front-end** and an **ASP.NET Core Web API back-end**. This architecture allows for seamless communication between the client-side and server-side components, providing a smooth user experience for managing profile data over in-memory storage.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [File Structure](#file-structure)
- [Future Enhancements](#future-enhancements)


---

## Project Overview

BTNX_ProfileFlow is a simple, scalable web application designed to demonstrate a typical client-server architecture using Blazor WebAssembly and ASP.NET Core Web API. The Blazor front-end allows users to interact with the profile data, while the back-end API manages profile **Creation**, **Retrieval**, and **Updates**.

### Front-End:
- **Blazor WebAssembly** is used to build the front-end, offering a modern, interactive, and responsive user interface.
- Users can create new profiles, update existing ones, and view a list of all profiles.

### Back-End:
- **ASP.NET Core Web API** handles the business logic and data management. The API provides endpoints for profile-related operations such as creating, updating, and fetching profile data.
- The back-end uses in-memory data storage for simplicity, but it can be extended to work with a database.

---

## Features

- **Create Profiles**: Users can create a new profile by entering details like first name, last name, email, and phone number.
- **Update Profiles**: Existing profiles can be updated by fetching them using a profile ID.
- **View Profiles**: A list of all created profiles is displayed in a grid, showing key details such as profile ID, name, and email.


---

## Technologies Used

- **Blazor WebAssembly**: A framework for building interactive web UIs using C# instead of JavaScript.
- **ASP.NET Core Web API**: A powerful and flexible back-end framework for building RESTful APIs.
- **C#**: The primary programming language used for both the front-end and back-end.
- **HTTP & JSON**: Used for communication between the Blazor client and the Web API.

---

## Installation

### Prerequisites

To run the project locally, ensure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
- [Git](https://git-scm.com/): For cloning the repository.
- [Visual Studio](https://visualstudio.microsoft.com/) or another compatible IDE for running and debugging the projects.

### Steps to Clone the Repository

Clone the repository to your local machine using Git:

```bash
git clone https://github.com/Raghavluthra/Btnx_Profileflow
cd BTNX_ProfileFlow
```


### Building and Running

1. **Build the Solution**: Open the solution in your IDE and run both the **BlazorProfileApp** (client) and **WebApiProject** (server) projects on different terminals.
2. **Run the Web API Project**: Start the Web API project to host the back-end on `localhost:5031`.
```bash
## TERMINAL 1
# Run this from the BTNX_ProfileFlow directory
cd WebApiProject && dotnet run
```
3. **Run the Blazor WebAssembly App**: Start the Blazor client app, which will be served on `localhost:5057`.
```bash
## TERMINAL 2
# Run this from the BTNX_ProfileFlow directory
cd BtnxProfileApp && dotnet run BtnxProfileApp.csproj
```

Once both projects are running, the front-end will communicate with the back-end API to manage profile data.

---

## Usage

1. **Home Page**: After starting the Blazor app, you will land on the home page. It includes options to create or update profiles.
2. **Create a Profile**: Click the "Create Profile" button to open the form. After filling in the required information (First Name, Last Name, Email, Phone), submit the form to create a new profile.
3. **Update a Profile**: To update a profile, click on the "Update Profile" button, enter the profile ID to fetch the existing data, modify the profile details, and submit the changes.
4. **View Profiles**: The right section of the app displays all created profiles in a grid format. You can view all profiles by clicking the "View Profiles" button.

---

## File Structure

The project is divided into two main parts: **BlazorProfileApp** (client-side) and **WebApiProject** (server-side).

```
BTNX_ProfileFlow/
│
├── BtnxProfileApp/           # Blazor WebAssembly Project (Client-Side)
│   ├── wwwroot/                # Static assets like CSS, images, etc.
│   ├── Layout/                 # Main layout and shared components for the app
│   ├── Pages/                  # Blazor pages for Create, Update, and View Profiles
│   ├── Program.cs              # Configures the Blazor WebAssembly project
│   └── App.razor               # Routing and main entry point for the Blazor app
│
├── WebApiProject/              # ASP.NET Core Web API Project (Server-Side)
│   ├── Controllers/            # ProfileController for handling profile-related API requests
│   └── Program.cs              # Configures the Web API and CORS settings

```

### Key Components:
- **BlazorProfileApp**: Contains the front-end logic, pages, and components for user interaction.
- **WebApiProject**: Provides the RESTful API for managing profiles, including endpoints for creating, retrieving, and updating profile data.

---

## Future Enhancements

1. **Database Integration**: Replace the current in-memory data storage with a persistent database such as SQL Server or PostgreSQL for better data management.
2. **Authentication and Authorization**: Implement user authentication (e.g., OAuth or JWT) to secure profile management and restrict access to certain actions.
3. **Pagination**: Add pagination to the profile grid for better performance when dealing with a large number of profiles.
4. **Search and Filtering**: Enable users to search and filter profiles within the grid for quicker access to specific profiles.
5. **Improved Error Handling**: Enhance error handling on both the front-end and back-end to provide more detailed feedback to the users.

