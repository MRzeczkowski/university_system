-- Seed Addresses
INSERT INTO Administration.Addresses (Id, Street, HouseNumber, FlatNumber, City, PostalCode, Country, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 'Słoneczna', 5, 10, 'Warszawa', '00-001', 'Poland', GETDATE(), GETDATE(), 0),
(2, 'Leśna', 10, 11, 'Kraków', '30-001', 'Poland', GETDATE(), GETDATE(), 0),
(3, 'Parkowa', 15, 12, 'Wrocław', '50-001', 'Poland', GETDATE(), GETDATE(), 0),
(4, 'Ogrodowa', 20, 13, 'Poznań', '60-001', 'Poland', GETDATE(), GETDATE(), 0),
(5, 'Kwiatowa', 25, 14, 'Gdańsk', '80-001', 'Poland', GETDATE(), GETDATE(), 0);

-- Seed Persons
INSERT INTO Administration.Persons (Id, FirstName, LastName, Email, Phone, DateOfBirth, AddressId, GenderId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 'Jan', 'Kowalski', 'jan.kowalski@univ.edu', '+48123123123', '1970-01-01', 1, 1, GETDATE(), GETDATE(), 0),
(2, 'Ewa', 'Nowak', 'ewa.nowak@univ.edu', '+48234234234', '1980-05-05', 2, 2, GETDATE(), GETDATE(), 0),
(3, 'Marek', 'Zieliński', 'marek.zielinski@univ.edu', '+48345345345', '1990-09-09', 3, 1, GETDATE(), GETDATE(), 0),
(4, 'Anna', 'Wiśniewska', 'anna.wisniewska@univ.edu', '+48456456456', '1985-02-02', 4, 2, GETDATE(), GETDATE(), 0),
(5, 'Piotr', 'Wójcik', 'piotr.wojcik@univ.edu', '+48567567567', '1975-12-12', 5, 1, GETDATE(), GETDATE(), 0);

-- Seed Students
INSERT INTO Students.Students (Id, PersonId, EnrollmentYear, StatusId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 3, 2018, 1, GETDATE(), GETDATE(), 0),
(2, 4, 2019, 1, GETDATE(), GETDATE(), 0),
(3, 5, 2017, 2, GETDATE(), GETDATE(), 0);

-- Seed Departments
INSERT INTO Administration.Departments (Id, Name, Budget, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 'Computer Science', 1500000, GETDATE(), GETDATE(), 0),
(2, 'Biology', 1200000, GETDATE(), GETDATE(), 0),
(3, 'History', 800000, GETDATE(), GETDATE(), 0);

-- Seed Professors
INSERT INTO Academics.Professors (Id, PersonId, DepartmentId, TitleId, StatusId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 1, 1, 1, 1, GETDATE(), GETDATE(), 0),
(2, 2, 2, 2, 1, GETDATE(), GETDATE(), 0);

-- Seed Administrative Employees
INSERT INTO Administration.AdministrativeEmployees (EmployeeId, PersonId, DepartmentId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 2, 3, GETDATE(), GETDATE(), 0);

-- Seed Courses
INSERT INTO Academics.Courses (Id, CourseName, DepartmentId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 'Fundamentals of Programming', 1, GETDATE(), GETDATE(), 0),
(2, 'Molecular Biology', 2, GETDATE(), GETDATE(), 0),
(3, 'European History', 3, GETDATE(), GETDATE(), 0);

-- Seed Classrooms
INSERT INTO Academics.Classrooms (Id, Building, RoomNumber, Capacity, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 'Main Campus', '101', 50, GETDATE(), GETDATE(), 0),
(2, 'Science Wing', '201', 40, GETDATE(), GETDATE(), 0),
(3, 'History Annex', '301', 30, GETDATE(), GETDATE(), 0);

-- Seed Course Offerings
INSERT INTO Academics.CourseOfferings (Id, CourseId, SemesterId, Year, ProfessorId, ClassroomId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 1, 1, 2023, 1, 1, GETDATE(), GETDATE(), 0),
(2, 2, 2, 2023, 2, 2, GETDATE(), GETDATE(), 0),
(3, 3, 1, 2023, 1, 3, GETDATE(), GETDATE(), 0);

-- Seed Enrollments
INSERT INTO Students.Enrollments (Id, StudentId, OfferingId, EnrollmentDate, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 1, 1, '2023-01-15', GETDATE(), GETDATE(), 0),
(2, 2, 2, '2023-06-15', GETDATE(), GETDATE(), 0),
(3, 3, 3, '2023-01-15', GETDATE(), GETDATE(), 0);

-- Seed Attendance
INSERT INTO Students.Attendance (Id, EnrollmentId, DateOfClass, StatusId, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 1, '2023-02-01', 2, GETDATE(), GETDATE(), 0),
(2, 2, '2023-07-01', 2, GETDATE(), GETDATE(), 0),
(3, 3, '2023-02-01', 3, GETDATE(), GETDATE(), 0);

-- Seed Grades
INSERT INTO Students.Grades (Id, EnrollmentId, Points, FinalGrade, GradeDate, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 1, 75, 4.0, '2023-05-01', GETDATE(), GETDATE(), 0),
(2, 2, 85, 4.5, '2023-10-01', GETDATE(), GETDATE(), 0),
(3, 3, 55, 3.5, '2023-05-01', GETDATE(), GETDATE(), 0);

-- Seed Advisors
INSERT INTO Students.Advisors (StudentId, ProfessorId, AssignmentDate, CreatedDate, ModifiedDate, IsDeleted)
VALUES
(1, 1, '2023-01-01', GETDATE(), GETDATE(), 0),
(2, 2, '2023-06-01', GETDATE(), GETDATE(), 0),
(3, 1, '2023-01-01', GETDATE(), GETDATE(), 0);
