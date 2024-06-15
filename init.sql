CREATE DATABASE University;
USE University;

-- Schemas for organization
CREATE SCHEMA Students;
CREATE SCHEMA Academics;
CREATE SCHEMA Administration;

-- Common Persons table in Administration schema
CREATE TABLE Administration.Persons (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    DateOfBirth DATE,
    Address VARCHAR(255),
    Gender VARCHAR(10),
    Status VARCHAR(20),
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

-- Students table in Students schema
CREATE TABLE Students.Students (
    Id INT PRIMARY KEY,
    PersonId INT,
    EnrollmentYear INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id)
);

-- Professors table in Academics schema
CREATE TABLE Academics.Professors (
    Id INT PRIMARY KEY,
    PersonId INT,
    DepartmentId INT,
    Title VARCHAR(10),
    HireDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id),
    FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id)
);

-- Courses table in Academics schema
CREATE TABLE Academics.Courses (
    Id INT PRIMARY KEY,
    CourseName VARCHAR(100),
    DepartmentId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id)
);

-- Classrooms table in Academics schema
CREATE TABLE Academics.Classrooms (
    Id INT PRIMARY KEY,
    Building VARCHAR(50),
    RoomNumber VARCHAR(10),
    Capacity INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Students.AttendanceStatuses (
    StatusId INT PRIMARY KEY,
    StatusName VARCHAR(10)
);

INSERT INTO Students.AttendanceStatuses (StatusId, StatusName)
VALUES (1, 'Present'), (2, 'Absent'), (3, 'Excused');

-- Attendance table in Students schema
CREATE TABLE Students.Attendance (
    Id INT PRIMARY KEY,
    EnrollmentId INT,
    DateOfClass DATE,
    StatusId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (EnrollmentId) REFERENCES Students.Enrollments(Id),
    FOREIGN KEY (StatusId) REFERENCES Students.AttendanceStatuses(StatusId)
);

-- Course Offerings table in Academics schema
CREATE TABLE Academics.CourseOfferings (
    Id INT PRIMARY KEY,
    CourseId INT,
    Semester VARCHAR(10),
    Year INT,
    ProfessorId INT,
    ClassroomId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (CourseId) REFERENCES Academics.Courses(Id),
    FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id),
    FOREIGN KEY (ClassroomId) REFERENCES Academics.Classrooms(Id)
);

-- Enrollments table in Students schema
CREATE TABLE Students.Enrollments (
    Id INT PRIMARY KEY,
    StudentId INT,
    OfferingId INT,
    EnrollmentDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (StudentId) REFERENCES Students.Students(Id),
    FOREIGN KEY (OfferingId) REFERENCES Academics.CourseOfferings(Id)
);

-- Grades table in Students schema
CREATE TABLE Students.Grades (
    Id INT PRIMARY KEY,
    EnrollmentId INT,
    Grade DECIMAL(4,2),
    GradeDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (EnrollmentId) REFERENCES Students.Enrollments(Id)
);

-- Departments table in Administration schema
CREATE TABLE Administration.Departments (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Budget DECIMAL(18, 2),
    StartDate DATE,
    DeanId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (DeanId) REFERENCES Academics.Professors(Id)
);

-- Advisors table in Students schema
CREATE TABLE Students.Advisors (
    StudentId INT,
    ProfessorId INT,
    AssignmentDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (StudentId) REFERENCES Students.Students(Id),
    FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id),
    PRIMARY KEY (StudentId, ProfessorId)
);
