CREATE DATABASE University;
USE University;

CREATE SCHEMA Students;
CREATE SCHEMA Academics;
CREATE SCHEMA Administration;

CREATE TABLE Administration.Genders (
    Id INT PRIMARY KEY,
    Description VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Administration.Genders (Id, Description)
VALUES (1, 'Male'), (2, 'Female'), (3, 'Prefer Not to Say');

CREATE TABLE Administration.Addresses (
    Id INT PRIMARY KEY,
    Street VARCHAR(255) NOT NULL,
    HouseNumber INT NOT NULL,
    FlatNumber INT,
    City VARCHAR(100) NOT NULL,
    PostalCode VARCHAR(10) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Administration.Persons (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Phone CHAR(14) NOT NULL UNIQUE,
    DateOfBirth DATE NOT NULL,
    AddressId INT NOT NULL,
    GenderId INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Persons_Gender FOREIGN KEY (GenderId) REFERENCES Administration.Genders(Id),
    CONSTRAINT FK_Persons_Address FOREIGN KEY (AddressId) REFERENCES Administration.Addresses(Id),
    CONSTRAINT CHK_Persons_DateOfBirth CHECK (DateOfBirth <= CONVERT(DATE, GETDATE()))
);

CREATE TABLE Students.StudentStatuses (
    Id INT PRIMARY KEY,
    StatusDescription VARCHAR(50) NOT NULL
);

INSERT INTO Students.StudentStatuses (Id, StatusDescription)
VALUES (1, 'Enrolled'), (2, 'Graduated'), (3, 'Suspended'), (4, 'Withdrawn');

CREATE TABLE Students.Students (
    Id INT PRIMARY KEY,
    PersonId INT NOT NULL,
    EnrollmentYear INT NOT NULL,
    StatusId INT NOT NULL DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Students_Person FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id),
    CONSTRAINT FK_Students_Status FOREIGN KEY (StatusId) REFERENCES Students.StudentStatuses(Id)
);

CREATE TABLE Administration.Departments (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Budget DECIMAL(18, 2) NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Administration.AdministrativeEmployees (
    EmployeeId INT PRIMARY KEY,
    PersonId INT NOT NULL,
    DepartmentId INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_AdminEmployees_Person FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id),
    CONSTRAINT FK_AdminEmployees_Department FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id)
);

CREATE TABLE Academics.ProfessorStatuses (
    Id INT PRIMARY KEY,
    StatusDescription VARCHAR(50) NOT NULL
);

INSERT INTO Academics.ProfessorStatuses (Id, StatusDescription)
VALUES (1, 'Active'), (2, 'On Leave'), (3, 'Retired'), (4, 'Emeritus');

CREATE TABLE Academics.Titles (
    Id INT PRIMARY KEY,
    TitleName VARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO Academics.Titles (Id, TitleName)
VALUES (1, 'Professor'), (2, 'Associate Professor'), (3, 'Assistant Professor'), (4, 'Lecturer'), (5, 'Senior Lecturer');

CREATE TABLE Academics.Professors (
    Id INT PRIMARY KEY,
    PersonId INT NOT NULL,
    DepartmentId INT NOT NULL,
    TitleId INT NOT NULL,
    StatusId INT NOT NULL DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Professors_Person FOREIGN KEY (PersonId) REFERENCES Administration.Persons(Id),
    CONSTRAINT FK_Professors_Department FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id),
    CONSTRAINT FK_Professors_Status FOREIGN KEY (StatusId) REFERENCES Academics.ProfessorStatuses(Id),
    CONSTRAINT FK_Professors_Title FOREIGN KEY (TitleId) REFERENCES Academics.Titles(Id)
);

CREATE TABLE Administration.Deans (
    DepartmentId INT NOT NULL,
    ProfessorId INT NOT NULL,
    EffectiveDate DATE NOT NULL,
    PRIMARY KEY (DepartmentId, ProfessorId),
    CONSTRAINT FK_Deans_Department FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id),
    CONSTRAINT FK_Deans_Professor FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id)
);

CREATE TABLE Academics.Courses (
    Id INT PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Courses_Department FOREIGN KEY (DepartmentId) REFERENCES Administration.Departments(Id)
);

CREATE TABLE Academics.Classrooms (
    Id INT PRIMARY KEY,
    Building VARCHAR(50) NOT NULL,
    RoomNumber VARCHAR(10) NOT NULL,
    Capacity INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Academics.Semesters (
    Id INT PRIMARY KEY,
    Name VARCHAR(10) NOT NULL UNIQUE
);

INSERT INTO Academics.Semesters (Id, Name)
VALUES (1, 'Summer'), (2, 'Winter');

CREATE TABLE Academics.CourseOfferings (
    Id INT PRIMARY KEY,
    CourseId INT NOT NULL,
    SemesterId INT NOT NULL,
    Year INT NOT NULL,
    ProfessorId INT NOT NULL,
    ClassroomId INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_CourseOfferings_Course FOREIGN KEY (CourseId) REFERENCES Academics.Courses(Id),
    CONSTRAINT FK_CourseOfferings_Professor FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id),
    CONSTRAINT FK_CourseOfferings_Classroom FOREIGN KEY (ClassroomId) REFERENCES Academics.Classrooms(Id),
    CONSTRAINT FK_CourseOfferings_Semester FOREIGN KEY (SemesterId) REFERENCES Academics.Semesters(Id)
);

CREATE TABLE Students.Enrollments (
    Id INT PRIMARY KEY,
    StudentId INT NOT NULL,
    OfferingId INT NOT NULL,
    EnrollmentDate DATE NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Enrollments_Student FOREIGN KEY (StudentId) REFERENCES Students.Students(Id),
    CONSTRAINT FK_Enrollments_CourseOffering FOREIGN KEY (OfferingId) REFERENCES Academics.CourseOfferings(Id)
);

CREATE TABLE Students.AttendanceStatuses (
    Id INT PRIMARY KEY,
    StatusName VARCHAR(10) NOT NULL
);

INSERT INTO Students.AttendanceStatuses (Id, StatusName)
VALUES (1, 'Absent'), (2, 'Present'), (3, 'Excused');

CREATE TABLE Students.Attendance (
    Id INT PRIMARY KEY,
    EnrollmentId INT NOT NULL,
    DateOfClass DATE NOT NULL,
    StatusId INT NOT NULL DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Attendance_Enrollment FOREIGN KEY (EnrollmentId) REFERENCES Students.Enrollments(Id),
    CONSTRAINT FK_Attendance_Status FOREIGN KEY (StatusId) REFERENCES Students.AttendanceStatuses(Id)
);

CREATE TABLE Students.Grades (
    Id INT PRIMARY KEY,
    EnrollmentId INT NOT NULL,
    Points INT NOT NULL,
    FinalGrade DECIMAL(5,2) NOT NULL,
    GradeDate DATE NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Grades_Enrollment FOREIGN KEY (EnrollmentId) REFERENCES Students.Enrollments(Id),
    CONSTRAINT CHK_Grades_Grade CHECK (Grade IN (2, 3, 3.5, 4, 4.5, 5))
);

CREATE TABLE Students.Advisors (
    StudentId INT NOT NULL,
    ProfessorId INT NOT NULL,
    AssignmentDate DATE NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Advisors_Student FOREIGN KEY (StudentId) REFERENCES Students.Students(Id),
    CONSTRAINT FK_Advisors_Professor FOREIGN KEY (ProfessorId) REFERENCES Academics.Professors(Id),
    PRIMARY KEY (StudentId, ProfessorId)
);
