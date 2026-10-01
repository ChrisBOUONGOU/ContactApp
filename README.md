# Contact Application

A contact management application inspired by the concepts and exercises presented in the book *Head First C#*. This project reimagines the original learning experience using modern development technologies and practices with **C#**, **.NET 10.0**, **Windows Forms**, and **Entity Framework Core**.

## 📋 About the Project

This application was created as a practical C# learning project to explore how a desktop application can interact with a database and manage real-world data.

The project focuses on building a simple and functional contact management system where users can create, view, update, and delete contacts.

The original concepts from *Head First C#* have been adapted to a more modern **.NET 10.0** development environment.

## ✨ Features

* Add new contacts
* Display contacts in a `DataGridView`
* Select and view contact information
* Edit existing contacts
* Delete contacts
* Input validation
* Database persistence
* Automatic database creation using Entity Framework Core
* SQL Server LocalDB support

## 🛠️ Technologies

* **C#**
* **.NET 10.0**
* **Windows Forms**
* **Entity Framework Core 10**
* **SQL Server LocalDB**
* **Visual Studio 2026**


## 🚀 Getting Started

### Prerequisites

Before running the application, make sure you have:

* Visual Studio 2026
* .NET 10 SDK
* SQL Server LocalDB
* .NET 10-compatible Entity Framework Core packages

### Installation

Clone the repository:

```bash
git clone https://github.com/your-username/ContactApp.git
```

Open the project in Visual Studio.

Restore the NuGet packages:

```bash
dotnet restore
```

Create the database:

```powershell
Add-Migration InitialCreate
Update-Database
```

Then run the application from Visual Studio with:

```text
F5
```

## 🎯 Learning Objectives

This project helped me practice:

* Object-oriented programming with C#
* Windows Forms development
* Database integration
* Entity Framework Core
* CRUD operations
* LINQ queries
* Entity Framework migrations
* Event-driven programming
* Data binding
* Basic application architecture

## 📚 Inspiration

This project is inspired by the learning material and programming concepts presented in:

> *Head First C#*

The application is an independent implementation created for learning purposes and is not affiliated with or endorsed by the authors or publisher of the book.

## 🔮 Future Improvements

Possible future improvements include:

* Contact search
* Sorting and filtering
* Contact categories
* Profile pictures
* Email validation
* Phone number validation
* Improved user interface
* Export contacts to CSV
* Import contacts from CSV
* Additional database features


