# Technical Document for BTNX_ProfileFlow

## 1. Project Overview

**BTNX_ProfileFlow** is a web-based application aimed at managing user profiles. The solution is composed of two major projects:

1. **BlazorProfileApp**: A Blazor WebAssembly project that serves as the front-end. It provides users with an interactive interface to create, update, and view profiles.
2. **WebApiProject**: An ASP.NET Core Web API project that acts as the back-end, handling profile-related operations such as creating, retrieving, and updating data.

The application supports basic CRUD (Create, Read, Update) operations on profiles, enabling users to manage profile data efficiently. The front-end communicates with the back-end via HTTP requests, making it a typical client-server architecture.

### 1.1 Technology Stack

- **Blazor WebAssembly**: Provides the client-side rendering of the application.
- **ASP.NET Core Web API**: Handles server-side logic and acts as the data provider for the Blazor app.
- **C#**: Used throughout the entire stack for consistency.
- **HTTP & JSON**: Communication between the Blazor client and the API is done through HTTP requests using JSON for data exchange.
  
---

## 2. Project Structure

The project is split into two primary components with distinct responsibilities:

### 2.1 BlazorProfileApp (Client-Side)

This project is the front-end of the application and is responsible for:

- Rendering the user interface (UI)
- Handling user interactions
- Communicating with the Web API to fetch and send profile data

It follows the component-based architecture of Blazor, where each page or functionality is encapsulated in a reusable component.

Key directories:
- **Layout/**: Contains the layout and structure of the app's UI.
- **Pages/**: Includes different Blazor components (views) for creating, updating, and listing profiles.

### 2.2 WebApiProject (Server-Side)

This project is the back-end of the application and is responsible for:

- Handling HTTP requests from the BlazorProfileApp.
- Performing the business logic related to profile creation, retrieval, and updating.
- Managing data (currently using in-memory storage).

Key directories:
- **Controllers/**: Contains the `ProfileController`, which is responsible for handling HTTP requests for profile-related actions.
  


---

## 3. BlazorProfileApp

### 3.1 Structure and Layout

The **BlazorProfileApp** is the front-end interface that allows users to interact with the application. It is built using the component model of Blazor WebAssembly, which offers a rich user experience without requiring full-page reloads.

#### 3.1.1 **Main Layout**

The main layout defines the overall structure of the application. It has three key sections:

- **Left Section**: Displays introductory information about the application.
- **Middle Section**: Dynamically renders components such as the forms to create and update profiles.
- **Right Section**: Contains a grid that shows all created profiles.

The buttons in the middle section allow users to toggle between creating a new profile and updating an existing one, with the appropriate component being displayed based on the user's selection.

#### 3.1.2 **Routing**

The app uses routing to navigate between pages like `CreateProfile`, `Grid`, and `UpdateProfile`. This is done without reloading the entire page, creating a smooth and responsive user experience. The routing is managed through a central router, which maps URLs to the corresponding Blazor components.

#### 3.1.3 **Component Structure**

The key components of the BlazorProfileApp include:

- **CreateProfile Component**: A form that allows users to enter details like name, email, and phone number to create a new profile. Form validation is handled using data annotations.
  
- **UpdateProfile Component**: Allows users to fetch an existing profile based on its ID and update the details. After fetching the profile, the form is pre-filled with the profile’s data for editing.

- **Grid Component**: Displays a list of all created profiles in a tabular format. Users can toggle the visibility of this grid using a button. Data is retrieved from the API and displayed in a responsive manner.

### 3.2 HTTP Communication

The Blazor app uses an `HttpClient` to communicate with the Web API. HTTP requests are sent from the front-end to the API to:

- Retrieve the list of profiles (GET request)
- Create a new profile (POST request)
- Update an existing profile (PUT request)

The HTTP client is configured during the app initialization and uses the base URL of the API, allowing the Blazor app to send requests to the API endpoints.

### 3.3 User Interface (UI)

The UI is designed to be clean and user-friendly, with form validation to ensure correct data input. Buttons are styled for easy interaction, and sections are clearly delineated to make it easy for users to navigate between functionalities (e.g., creating, updating profiles).

---

## 4. WebApiProject

### 4.1 Structure and Role

The **WebApiProject** serves as the backend of the system. It handles all requests from the BlazorProfileApp and performs the necessary actions, such as creating new profiles or updating existing ones. The Web API is built using ASP.NET Core, which provides a robust framework for handling HTTP requests.

#### 4.1.1 **Controllers**

The **ProfileController** is responsible for managing profile-related operations. It provides several endpoints:

- **POST endpoint**: Allows the Blazor client to send profile data to create a new profile.
- **GET endpoint (by ID)**: Fetches a specific profile based on its ID.
- **GET endpoint (list)**: Retrieves a list of all created profiles.
- **PUT endpoint**: Updates an existing profile.

#### 4.1.2 **CORS Configuration**

Cross-Origin Resource Sharing (CORS) is enabled in the API to allow the Blazor client (which runs on a different port) to communicate with the API. A specific CORS policy is applied to allow the front-end to send and receive requests securely.

### 4.2 Data Management

Currently, the API uses in-memory data storage to manage profiles. All created profiles are stored in a static list within the controller, which acts as a simple data store. While this approach works for development and testing, it can be replaced with a more scalable solution like a database in future iterations.

The **PersonProfile** model represents a profile and includes fields for ID, first name, last name, email, and phone. These profiles are added, updated, and retrieved from the static list, simulating CRUD operations.

---

## 5. HTTP Communication Between Client and Server

The Blazor client and Web API interact using HTTP methods. The front-end sends HTTP requests to specific API endpoints to perform the following operations:

- **Create a profile**: The client sends a POST request to the API, including profile data in JSON format. The API processes the request and responds with the newly created profile’s ID.
  
- **Retrieve profiles**: The client sends a GET request to retrieve a list of all profiles or a specific profile by ID. The API responds with the requested data in JSON format.
  
- **Update a profile**: The client sends a PUT request with the profile’s ID and updated data. The API processes the update and responds with the updated profile.

All communication between the Blazor app and the Web API is stateless, meaning each request is independent and does not rely on previous interactions.

---

## 6. Conclusion

**BTNX_ProfileFlow** is a robust starting point for managing user profiles with a clear separation of concerns between the Blazor WebAssembly front-end and the ASP.NET Core Web API back-end. It provides a scalable architecture that can be extended with additional features like database integration, authentication, and enhanced UI functionality.
