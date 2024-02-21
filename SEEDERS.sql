-- Seed for Students table
INSERT INTO [Students] ([Created], [LastModified], [Name], [Identification], [Birthdate])
VALUES 
    (GETDATE(), GETDATE(), 'John Doe', '12345', '2000-01-01'),
    (GETDATE(), GETDATE(), 'Jane Doe', '67890', '1999-05-15')
    -- Add more rows as needed

-- Seed for Teachers table
INSERT INTO [Teachers] ([Created], [LastModified], [Name], [Birtdhay])
VALUES 
    (GETDATE(), GETDATE(), 'Professor Smith', '1975-08-20'),
    (GETDATE(), GETDATE(), 'Dr. Johnson', '1980-03-10')
    -- Add more rows as needed

-- Seed for Courses table
INSERT INTO [Courses] ([Created],  [LastModified], [TeacherID], [Name], [Description])
VALUES 
    (GETDATE(), GETDATE(), 1, 'Math 101', 'Introduction to Mathematics'),
    (GETDATE(), GETDATE(), 2, 'Physics 201', 'Advanced Physics')
    -- Add more rows as needed

-- Seed for Califications table
INSERT INTO [Califications] ([Created], [LastModified], [StudentID], [CourseID], [Note])
VALUES 
    (GETDATE(), GETDATE(), 1, 1, 90.5),
    (GETDATE(), GETDATE(), 2, 2, 85.0)
    -- Add more rows as needed

-- Seed for StudentCourse table
INSERT INTO [StudentCourse] ([CourseID], [StudentID])
VALUES 
    (1, 1),
    (2, 2)
