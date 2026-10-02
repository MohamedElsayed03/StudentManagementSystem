# Student Management System

A console-based Student Management System built with **C#**, **.NET 8**, **Entity Framework Core**, and **SQL Server**.

The project focuses on building a clean data-access layer with asynchronous database operations, EF Core relationships, migrations, seed data, CRUD operations, and LINQ-based queries.

## ✨ Features

### Student Management
- Add a student
- Get a student by ID
- Update student information
- Delete a student
- Search students by partial name
- Get a student together with all enrollments

### Course Management
- Add a course
- Get a course by ID
- Update course information
- Delete a course
- Optional instructor relationship

### Enrollment Management
- Add an enrollment
- Get an enrollment by composite key
- Update enrollment information
- Delete an enrollment
- Get all students enrolled in a specific course
- Get all courses for a specific student with grades
- Calculate the average grade for a course

## 🧩 Project Architecture

The application follows a simple service-based structure:

```text
Program.cs
   │
   ├── Menu
   └── Handle Methods
          │
          ├── StudentService
          ├── CourseService
          └── EnrollmentService
                    │
                    ▼
              AppDbContext
                    │
                    ▼
                SQL Server
```

The services directly use `AppDbContext`, keeping database access inside the service layer while `Program.cs` is responsible for the console UI and user interaction.

## 🗂️ Project Structure

```text
StudentManagementSystem/
│
├── Data/
│   └── AppDbContext.cs
│
├── Entities/
│   ├── Student.cs
│   ├── Course.cs
│   ├── Enrollment.cs
│   └── Instructor.cs
│
├── Service/
│   ├── StudentService.cs
│   ├── CourseService.cs
│   └── EnrollmentService.cs
│
├── Configuration/
│   ├── StudentConfiguration.cs
│   ├── CourseConfiguration.cs
│   ├── EnrollmentConfiguration.cs
│   └── InstructorConfiguration.cs
│
├── Migrations/
│
├── SeedData.cs
├── Program.cs
├── appsettings.json
└── StudentManagementSystem.csproj
```

## 🗃️ Data Model

The main entities are:

### Student
- `StudentId`
- `FullName`
- `Email`
- `DateOfBirth`
- `EnrollmentDate`

### Course
- `CourseId`
- `Title`
- `Credits`
- `Description`
- `InstructorId` (nullable)

### Enrollment
- `StudentId`
- `CourseId`
- `EnrollmentDate`
- `Grade` (nullable)

`Enrollment` connects students and courses using a composite key consisting of:

```text
(StudentId, CourseId)
```

### Instructor
- `InstructorId`
- `FullName`

A course may optionally reference an instructor.

## 🔗 Relationships

```text
Student 1 ───────── N Enrollment N ───────── 1 Course

Instructor 1 ───── N Course
```

The project uses EF Core relationship configuration for these associations.

## ⚙️ Entity Framework Core

The project uses:

- EF Core SQL Server provider
- Fluent API configurations
- EF Core migrations
- Seed data through `HasData`
- `AsNoTracking()` for read-only queries
- Async database operations such as `AddAsync`, `FirstOrDefaultAsync`, `ToListAsync`, and `SaveChangesAsync`
- `Include()` for loading related data

The `AppDbContext` applies all entity configurations from the assembly and configures SQL Server using the connection string stored in `appsettings.json`.

## 🌱 Seed Data

The project includes centralized seed data in `SeedData.cs`.

The seed data currently includes:

- 5 students
- 5 courses
- 10 enrollments
- 3 instructors

It also contains examples of nullable values such as enrollment grades and an optional course instructor.

## 🛠️ Technologies

| Technology | Version / Usage |
|---|---|
| C# | Main programming language |
| .NET | 8.0 |
| Entity Framework Core | 8.x |
| SQL Server | Database |
| LINQ | Querying |
| Git / GitHub | Version control |

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MohamedElsayed03/StudentManagementSystem.git
cd StudentManagementSystem
```

### 2. Configure SQL Server

Open:

```text
StudentManagementSystem/appsettings.json
```

and set the `constr` value to your SQL Server connection string.

Example:

```json
{
  "constr": "Server=.;Database=StudentManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Use the connection string format appropriate for your SQL Server installation.

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply EF Core migrations

Using Visual Studio Package Manager Console:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```

## 🖥️ Console Menu

The application provides a console menu for working with the system:

```text
======================================
       Student Management System
======================================

========== Student ==========
1. Add Student
2. Get Student By Id
3. Update Student
4. Delete Student
5. Search Student By Name
6. Get Student With All Enrollments

========== Course ==========
7. Add Course
8. Get Course By Id
9. Update Course
10. Delete Course

========== Enrollment ==========
11. Add Enrollment
12. Get Enrollment By Id
13. Update Enrollment
14. Delete Enrollment
15. Get Students By Course
16. Get Courses By Student
17. Get Average Grade Per Course

0. Exit
```

## 🔎 Query Examples

### Search students by partial name

```csharp
_context.Students
    .AsNoTracking()
    .Where(s => s.FullName.Contains(name))
    .ToListAsync();
```

### Get students enrolled in a course

```csharp
_context.Enrollments
    .AsNoTracking()
    .Where(e => e.CourseId == courseId)
    .Select(e => e.Student)
    .ToListAsync();
```

### Get courses and grades for a student

```csharp
_context.Enrollments
    .AsNoTracking()
    .Include(e => e.Course)
    .Where(e => e.StudentId == studentId)
    .ToListAsync();
```

### Calculate the average grade for a course

```csharp
_context.Enrollments
    .AsNoTracking()
    .Where(e => e.CourseId == courseId)
    .Select(e => e.Grade)
    .AverageAsync();
```

## 🧠 Key EF Core Concepts Demonstrated

This project is designed to practice important EF Core concepts:

- `DbContext` and `DbSet`
- Fluent API configuration
- Entity relationships
- Composite primary keys
- Foreign keys
- Optional relationships
- Cascade and restrict delete behavior
- Migrations
- Seed data
- Change tracking
- `AsNoTracking`
- Eager loading with `Include`
- Async database access
- LINQ-to-Entities
- Nullable values

## 🎯 Project Goals

The main goal of the project is to practice implementing a relational data layer using EF Core while keeping the console application simple.

It demonstrates how:

```text
C# Entities
     ↓
EF Core Configuration
     ↓
DbContext
     ↓
Migrations
     ↓
SQL Server
```

and how application code can perform CRUD and relationship-based queries asynchronously.

## 📌 Notes

- This is an educational project focused on EF Core and data access.
- The project intentionally uses services that receive `AppDbContext` directly.
- No additional repository or generic repository layer is required for the current project structure.
- Database schema changes are managed through EF Core migrations.

## 👤 Author

**Mohamed Elsayed**

GitHub:  
https://github.com/MohamedElsayed03

Repository:  
https://github.com/MohamedElsayed03/StudentManagementSystem
