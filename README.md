# Inventory Management Module (Practical 8)

An ASP.NET MVC 5 application demonstrating an Inventory Management Module using ADO.NET and SQL Server CRUD operations.

## Features
- List all products
- Add a product
- Edit product details
- Delete a product with confirmation
- Server-side validation for product name, category, quantity, and price
- SQL Server database access using parameterized queries

## Requirements
- Visual Studio 2022 (ASP.NET MVC 5 / .NET Framework 4.8)
- SQL Server LocalDB
- .NET Framework 4.8

## Setup
1. Open Visual Studio and create an **ASP.NET Web Application (.NET Framework)** project named `InventoryManagement`.
2. Select the **MVC** template.
3. Add the files from this repository to the matching folders. Keep the standard MVC files created by Visual Studio (`Global.asax`, `App_Start`, `Content`, `Scripts`, and the `.csproj`).
4. Run `Database/Setup.sql` in SQL Server Management Studio or Visual Studio's SQL Server Object Explorer.
5. Confirm the `InventoryDb` connection string in `Web.config` points to your LocalDB instance.
6. Build and run the project.

## Folder structure
```text
InventoryManagement/
├── Controllers/
│   └── ProductController.cs
├── Data/
│   └── ProductRepository.cs
├── Database/
│   └── Setup.sql
├── Models/
│   └── Product.cs
├── Views/
│   └── Product/
│       ├── Delete.cshtml
│       ├── Form.cshtml
│       └── Index.cshtml
├── Content/
│   └── Site.css
├── Web.config
└── README.md
```

## Database
The setup script creates the `InventoryPractical8` database and a `Products` table if they do not already exist.

## Notes
- This repository contains the application source files, not a complete Visual Studio solution file. Create the MVC 5 project in Visual Studio first, then copy these files into it.
- Do not upload passwords, private connection strings, or `bin/` and `obj/` build folders.
