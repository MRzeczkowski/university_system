# University System

This is a rudimentary system for managing a University. Some features are missing like:
 - sending emails
 - choosing advisors
 - calculating GPA
 - applying for scholarships
 - thesis related stuff
 - deleting various entities that are related to many other entities
 - academic year management, right now this has to be done more by hand
 - https

## General Features

- The navigation bar on the right-hand side can be toggled.
- Login and role-based access control. Users are authenticated and authorized to access specific parts of the application based on their roles.
- Users can manage their account by clicking on their username under Account and change their password, email and phone number.

When accessing the website a user can register using their email and a password.

![](./images/unauthorized_register.png)

This will create the User but they will be locked out until an Administrative Employee configures their profile and thus assigns a specific role.
By default new Users email is flagged as verified since sending emails is not setup.

Users with configured and approved accounts can login or change their password.

![](./images/unauthorized_login.png)

## Role-Specific Features

### All Users

Each authorized user can access Enrollments tab but depending on their roles they'll be able to do different things, more below.

### Students

Students have the most limited possibilities in the system.
They can:
 - view their upcoming classes:
![](./images/student_upcoming_classes.png)
 - view courses they've enrolled to (thus view their grades):
![](./images/student_enrollments.png)
 - enroll to courses they didn't yet:
![](./images/student_enroll.png)

### Professors

Professors have permissions to modify things related to handling courses that they teach:
 - view courses:
![](./images/professor_enrollments.png)
 - grade courses for specific Students:
![](./images/professor_grade.png)
 - view class sessions:
![](./images/professor_class_sessions.png)
 - mark session attendances:
![](./images/professor_attendances.png)
 - schedule new class sessions:
![](./images/professor_new_session.png)

### Administrative Employees

Administrative Employees have most amount of permissions:
 - view enrollments:
![](./images/admin_enrollments.png)
 - withdraw enrollments of Students:
![](./images/admin_withdraw.png)
 - add, edit and remove class sessions
![](./images/admin_class_sessions.png)
 - view and setup users pending registration:
![](./images/admin_pending_users.png)
![](./images/admin_pending_user_setup.png)
 - manage user profiles:
![](./images/admin_profiles.png)
    Each table can be collapsed. User profile management is straight forward. Editing an Administrative Employee, Student or Professor profile is very simple. Users without profiles can be promoted to one the aforementioned profiles and this comes with setting specific role for the new user.
 - add and edit departments:
![](./images/admin_departments.png) 
 - add and edit class rooms:
![](./images/admin_classrooms.png)
 - add and edit courses:
![](./images/admin_courses.png)
 - add and edit course offerings:
![](./images/admin_course_offerings_.png)
 - add and delete deans:
![](./images/admin_deans_.png)
    Only Professors can become deans and when they do, in addition to their existing Professor role they get Administrative Employee privileges.

## For developers

### Database setup

This was developed with MSSQL like databases in mind, using Entity Framework, so please use `dotnet ef database update --context UniversityContext` to set everything up.

### Schema

You can view the University database schema below:
![](./images/university_db_.png)


### Initial data

When the system starts it'll seed the database with data required for the system to work correctly and when run in debug configuration some additional test data will be seeded - this is the data visible in screenshots above. All of this is done in `DataSeeder` class.