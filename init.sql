CREATE DATABASE University;
USE University;

CREATE SCHEMA Students;
CREATE SCHEMA Academics;
CREATE SCHEMA Administration;

CREATE TABLE Administration.Genders (
    Id INT PRIMARY KEY,
    Description VARCHAR(50) UNIQUE
);

INSERT INTO Administration.Genders (Id, Description)
VALUES (1, 'Male'), (2, 'Female'), (3, 'Prefer Not to Say');

CREATE TABLE Administration.Persons (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Phone CHAR(14) UNIQUE,
    DateOfBirth DATE,
    Address VARCHAR(255),
    GenderId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Persons_Gender FOREIGN KEY (GenderId) REFERENCES Administration.Genders(Id)
);

CREATE TABLE Students.StudentStatuses (
    Id INT PRIMARY KEY,
    StatusDescription VARCHAR(50)
);

INSERT INTO Students.StudentStatuses (Id, StatusDescription)
VALUES (1, 'Enrolled'), (2, 'Graduated'), (3, 'Suspended'), (4, 'Withdrawn');

CREATE TABLE Students.Students (
    Id INT PRIMARY KEY,
    PersonId INT,
    EnrollmentYear INT,
    StatusId INT DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Students_Person FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id),
    CONSTRAINT FK_Students_Status FOREIGN KEY (StatusId) REFERENCES Students.StudentStatuses(Id)
);

CREATE TABLE Academics.ProfessorStatuses (
    Id INT PRIMARY KEY,
    StatusDescription VARCHAR(50)
);

INSERT INTO Academics.ProfessorStatuses (Id, StatusDescription)
VALUES (1, 'Active'), (2, 'On Leave'), (3, 'Retired'), (4, 'Emeritus');

CREATE TABLE Academics.Professors (
    Id INT PRIMARY KEY,
    PersonId INT,
    DepartmentId INT,
    Title VARCHAR(10),
    StatusId INT DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Professors_Person FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id),
    CONSTRAINT FK_Professors_Department FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id),
    CONSTRAINT FK_Professors_Status FOREIGN KEY (StatusId) REFERENCES Academics.ProfessorStatuses(Id)
);

CREATE TABLE Academics.Courses (
    Id INT PRIMARY KEY,
    CourseName VARCHAR(100),
    DepartmentId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Courses_Department FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id)
);

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

CREATE TABLE Students.Attendance (
    Id INT PRIMARY KEY,
    EnrollmentId INT,
    DateOfClass DATE,
    StatusId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Attendance_Enrollment FOREIGN KEY (EnrollmentId) REFERENCES Students.Enrollments(Id),
    CONSTRAINT FK_Attendance_Status FOREIGN KEY (StatusId) REFERENCES Students.AttendanceStatuses(StatusId)
);

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
    CONSTRAINT FK_CourseOfferings_Course FOREIGN KEY (CourseId) REFERENCES Academics.Courses(Id),
    CONSTRAINT FK_CourseOfferings_Professor FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id),
    CONSTRAINT FK_CourseOfferings_Classroom FOREIGN KEY (ClassroomId) REFERENCES Academics.Classrooms(Id)
);

CREATE TABLE Students.Enrollments (
    Id INT PRIMARY KEY,
    StudentId INT,
    OfferingId INT,
    EnrollmentDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Enrollments_Student FOREIGN KEY (StudentId) REFERENCES Students.Students(Id),
    CONSTRAINT FK_Enrollments_CourseOffering FOREIGN KEY (OfferingId) REFERENCES Academics.CourseOfferings(Id)
);

CREATE TABLE Students.Grades (
    Id INT PRIMARY KEY,
    EnrollmentId INT,
    Grade DECIMAL(5,2),
    GradeDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Grades_Enrollment FOREIGN KEY (EnrollmentId) REFERENCES Students.Enrollments(Id)
);

CREATE TABLE Administration.Departments (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Budget DECIMAL(18, 2),
    DeanId INT,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Departments_Dean FOREIGN KEY (DeanId) REFERENCES Academics.Professors(Id)
);

CREATE TABLE Students.Advisors (
    StudentId INT,
    ProfessorId INT,
    AssignmentDate DATE,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Advisors_Student FOREIGN KEY (StudentId) REFERENCES Students.Students(Id),
    CONSTRAINT FK_Advisors_Professor FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id),
    PRIMARY KEY (StudentId, ProfessorId)
);
