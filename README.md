# ☕ Coffee Shop Mobile App

## Project Summary

**Feawos Coffee Shop Mobile App** is a cross-platform mobile application built with .NET MAUI that provides a seamless coffee ordering experience. The app allows users to browse coffee menu items, place orders, and manage their coffee shop experience on both iOS and Android devices.

## 🎯 Features

- **Cross-Platform Support**: Built to run on iOS and Android platforms
- **User-Friendly Interface**: Intuitive XAML-based UI for smooth navigation
- **Menu Management**: Browse and explore coffee shop offerings
- **Order Management**: Easy order placement and tracking
- **Shell Navigation**: Modern app shell architecture for navigation

## 🛠️ Tech Stack

| Technology | Purpose |
|-----------|---------|
| **C#** | Primary programming language |
| **.NET MAUI** | Cross-platform mobile framework (UI & Logic) |
| **XAML** | UI markup language for interface design |
| **Visual Studio 2022+** | Development IDE |
| **.NET 8+** | Runtime framework |

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- **Visual Studio 2022** (Community, Professional, or Enterprise)
  - Install the **.NET MAUI** workload
- **.NET 8 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- **Git** for version control ([Download](https://git-scm.com))

### Optional (for platform-specific development)
- **Xcode 15+** - For iOS development on macOS
- **Android SDK 34+** - For Android emulator/device testing
- **Android Studio** - For Android development (optional)

## 📖 How to Clone and Run

### 1. Clone the Repository

```bash
git clone https://github.com/Feawos/Coffe-Shop-Mobile-App.git
cd Coffe-Shop-Mobile-App
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Build the Project

```bash
dotnet build
```

### 4. Run the Application

#### Run on Windows (Debug)
```bash
dotnet build -f net8.0-windows
dotnet run -f net8.0-windows
```

#### Run on Android (Emulator)
```bash
dotnet build -f net8.0-android
dotnet run -f net8.0-android
```

#### Run on iOS (Simulator - macOS only)
```bash
dotnet build -f net8.0-ios
dotnet run -f net8.0-ios
```

### 5. Open in Visual Studio

1. Open `FeawosCoffeeApp.sln` in Visual Studio 2022
2. Select your target platform from the Solution Platforms dropdown
3. Click the **Run** button or press **F5**

## 📁 Project Structure

```
Coffe-Shop-Mobile-App/
├── App.xaml                 # Application entry point styling
├── App.xaml.cs             # Application code-behind
├── AppShell.xaml           # Navigation shell definition
├── AppShell.xaml.cs        # Shell code-behind
├── MauiProgram.cs          # MAUI configuration and services
├── FeawosCoffeeApp.csproj  # Project file
├── FeawosCoffeeApp.sln     # Solution file
│
├── Model/                  # Data models
├── View/                   # XAML views/pages
├── ViewModel/              # MVVM ViewModels
├── Services/               # Business logic & API services
├── Platforms/              # Platform-specific code
├── Properties/             # Project properties
├── Resources/              # Images, strings, styles, fonts
└── README.md              # This file
```

## 🏗️ Architecture

The project follows the **MVVM (Model-View-ViewModel)** architectural pattern:

- **Model**: Data models representing coffee items, orders, and user information
- **View**: XAML pages and controls for the user interface
- **ViewModel**: Business logic and state management
- **Services**: Core functionality including API communication and data management

## 🚀 Building for Release

### Android APK
```bash
dotnet publish -f net8.0-android -c Release
```

### iOS App
```bash
dotnet publish -f net8.0-ios -c Release
```

### Windows App
```bash
dotnet publish -f net8.0-windows -c Release
```

## 🐛 Troubleshooting

### Common Issues

**Issue**: MAUI workload not found
```bash
dotnet workload restore
```

**Issue**: NuGet package restore fails
```bash
dotnet nuget locals all --clear
dotnet restore
```

**Issue**: Build fails on specific platform
- Ensure the target framework is installed: `dotnet workload list`
- Check platform-specific SDKs are up to date

## 📚 Useful Resources

- [Microsoft MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [XAML Documentation](https://learn.microsoft.com/en-us/dotnet/maui/xaml/)
- [MVVM Pattern Guide](https://learn.microsoft.com/en-us/dotnet/maui/architecture/mvvm)

## 📝 License

This project is open source. Check the repository for license details.

## 👤 Author

**Feawos** - [GitHub Profile](https://github.com/Feawos)

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

## 📧 Support

For issues, questions, or suggestions, please open an [issue](https://github.com/Feawos/Coffe-Shop-Mobile-App/issues) on GitHub.

---

**Last Updated**: May 2025  
**Status**: Active Development
