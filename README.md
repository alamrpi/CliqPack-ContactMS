# Contact Management System API
## Prerequisites
- .NET 8 SDK: You need the .NET 8 SDK installed on your system. Download and install it from the official .NET website: https://dotnet.microsoft.com/en-us/download
- Code Editor or IDE (Optional): While not strictly necessary, using a code editor or IDE like Visual Studio or Visual Studio Code can significantly improve your development experience.

# Steps
## 01. Open your project in a terminal:
- Command Prompt (Windows): Navigate to the directory containing your project's .csproj file using the cd command
- Terminal (macOS/Linux): Use the cd command in your terminal to navigate to the project 

## 02. Restore dependencies:
Run the following command to restore any missing NuGet packages required by your project:

```bash
dotnet restore
```

## 03. Build the project:
Run the following command to build your project:

```bash
dotnet build
```
A successful build will generate the necessary output files, typically located in a bin folder within your project directory.

## 04. Run the application:
Once the build is successful, use the following command to launch your API project:
```bash
dotnet run
```
This command will start the application and typically display the base URL where your API endpoints are accessible.


# Contact Management System UI
## Prerequisites
- Node.js and npm (or yarn): Ensure you have Node.js (version 14.18 or above) and npm (bundled with Node.js) or yarn installed on your system. You can verify their versions using node -v and npm -v (or yarn -v) commands in your terminal. Download and install them from the official websites if needed:
Node.js: https://nodejs.org/en

- Code Editor (Optional): While not strictly necessary, using a code editor with React support like Visual Studio Code can enhance your development experience.

# Steps
## Install Dependencies:
```bash
npm install
```
## Start the Development Server:
```bash
npm run dev
```

This command will launch the development server, typically accessible at http://localhost:5173/ in your web browser. You should see the React app running in the browser.
