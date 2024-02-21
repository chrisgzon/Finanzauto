IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Students] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    [Name] nvarchar(250) NOT NULL,
    [Identification] nvarchar(50) NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Teachers] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    [Name] nvarchar(250) NOT NULL,
    [Birtdhay] datetime2 NOT NULL,
    CONSTRAINT [PK_Teachers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Courses] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    [TeacherID] int NOT NULL,
    [Name] nvarchar(250) NOT NULL,
    [Description] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Courses_Teachers_TeacherID] FOREIGN KEY ([TeacherID]) REFERENCES [Teachers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Califications] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    [StudentID] int NOT NULL,
    [CourseID] int NOT NULL,
    [Note] decimal(4,2) NOT NULL,
    CONSTRAINT [PK_Califications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Califications_Courses_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Califications_Students_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Students] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [StudentCourse] (
    [CourseID] int NOT NULL,
    [StudentID] int NOT NULL,
    CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([CourseID], [StudentID]),
    CONSTRAINT [FK_StudentCourse_Courses_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentCourse_Students_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Students] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Califications_CourseID] ON [Califications] ([CourseID]);
GO

CREATE INDEX [IX_Califications_StudentID] ON [Califications] ([StudentID]);
GO

CREATE INDEX [IX_Courses_TeacherID] ON [Courses] ([TeacherID]);
GO

CREATE INDEX [IX_StudentCourse_StudentID] ON [StudentCourse] ([StudentID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240221184459_initialMigration', N'6.0.27');
GO

COMMIT;
GO