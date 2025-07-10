# 🖊️ Blog Platform - Frontend 🖊️

A modern, responsive blog platform frontend built with ASP.NET Core Razor Pages. This application provides a beautiful interface for displaying blog articles fetched from a REST API backend.

![Blog Platform - Frontend Preview](https://github.com/logan-tolbert/dev-space/blob/main/demos/blogapp-preview.gif)

**⚠️ Important**: This frontend application requires the [BlogAPI backend](https://github.com/logan-tolbert/Asp.Net-BlogApi) to function properly. Both applications have been deployed to Azure for cloud development.

## 📋 Table of Contents

- [Features](#-features)
- [Technology Stack](#️-technology-stack)
- [Project Structure](#-project-structure)
- [Related Projects](#-related-projects)
- [Getting Started](#-getting-started)
- [Configuration](#-configuration)
- [API Integration](#-api-integration)
- [Contributing](#-contributing)
- [License](#-license)

## ✨ Features

- **Modern UI/UX**: Clean, responsive design with beautiful typography and smooth animations
- **Article Display**: Browse and view blog articles with rich content formatting
- **Tag System**: Explore articles by tags and topics
- **Responsive Design**: Optimized for desktop, tablet, and mobile devices
- **API Integration**: Seamlessly connects to a backend API for content management
- **Performance**: Fast loading with efficient data fetching and caching
- **Cloud Deployment**: Both frontend and backend deployed on Azure

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 9.0
- **UI Framework**: Razor Pages
- **Styling**: Custom CSS with modern design system
- **HTTP Client**: Built-in HttpClient for API communication
- **JSON Handling**: System.Text.Json for data serialization
- **Typography**: Google Fonts (Inter + Playfair Display)

## 📁 Project Structure

```pt
App.Web/                    # Main web application
    │   ├── Models/                 # Data models
    │   │   └── ArticleViewModel.cs # Article data structure
    │   ├── Pages/                  # Razor Pages
    │   │   ├── Index.cshtml       # Homepage
    │   │   ├── Articles.cshtml    # Articles listing
    │   │   └── Shared/            # Layout and partials
    │   ├── Services/               # Business logic
    │   │   ├── IBlogApiService.cs # API service interface
    │   │   └── BlogApiService.cs  # API service implementation
    │   ├── wwwroot/               # Static assets
    │   │   ├── css/               # Stylesheets
    │   │   └── js/                # JavaScript files
    │   └── Program.cs             # Application entry point
    └── README.md                  # This file
```

## 🔗 Related Projects

### Backend API

This frontend application requires the [BlogAPI backend](https://github.com/logan-tolbert/Asp.Net-BlogApi) to function. The backend provides:

- REST API endpoints for article management
- Database operations and data persistence
- Authentication and authorization (if implemented)
- Content management capabilities

### Cloud Deployment

Both the frontend and backend applications have been deployed to Azure for cloud development and production use.

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code
- Access to the [BlogAPI backend](https://github.com/logan-tolbert/Asp.Net-BlogApi)

### Local Development Setup

1. **Clone both repositories**

   ```bash
   # Clone the frontend (this repository)
   git clone <repository-url>
   cd RazorBlog

   # Clone the backend
   git clone https://github.com/logan-tolbert/Asp.Net-BlogApi
   ```

2. **Configure the API endpoint**
   Edit `App.Web/appsettings.json` and update the `BlogApi:BaseUrl` to point to your backend API:

   ```json
   {
     "BlogApi": {
       "BaseUrl": "https://localhost:7038"
     }
   }
   ```

3. **Start the backend API first**

   ```bash
   cd ../Asp.Net-BlogApi
   dotnet run
   ```

4. **Start the frontend application**

   ```bash
   cd ../RazorBlog/App.Web
   dotnet run
   ```

5. **Access the application**
   Open your browser and navigate to `https://localhost:5001` (or the URL shown in the console)

## 🔧 Configuration

### API Configuration

The application connects to a backend API for article data. Configure the API endpoint in `appsettings.json`:

```json
{
  "BlogApi": {
    "BaseUrl": "https://your-api-url.com"
  }
}
```

### Environment-Specific Settings

- **Development**: Uses `appsettings.Development.json` for local development settings
- **Production**: Uses `appsettings.json` for production configuration

## 📖 API Integration

The application integrates with a REST API that provides the following endpoints:

- `GET /api/v0/articles` - Fetch paginated articles
- `GET /api/v0/articles/{id}` - Fetch specific article
- `GET /api/v0/articles/tags` - Fetch available tags

### Azure Deployment

Both the frontend and backend applications have been deployed to Azure for cloud development and production use. The applications are configured to work together in the Azure environment.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## **Happy Blogging! 📝✨**
