## Task6

-- 6.1

CREATE DATABASE SweeftTasksDB;
GO
USE SweeftTasksDB;
GO

CREATE TABLE Teacher (
    TeacherId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    Subject NVARCHAR(50)
);

CREATE TABLE Pupil (
    PupilId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    Class NVARCHAR(20)
);

CREATE TABLE TeacherPupil (
    TeacherId INT NOT NULL,
    PupilId INT NOT NULL,
    PRIMARY KEY (TeacherId, PupilId),
    FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
    FOREIGN KEY (PupilId) REFERENCES Pupil(PupilId)
);

--6.2

SELECT t.TeacherId, t.FirstName, t.LastName, t.Subject
FROM Teacher t
JOIN TeacherPupil tp ON t.TeacherId = tp.TeacherId
JOIN Pupil p ON tp.PupilId = p.PupilId
WHERE p.FirstName = 'გიორგი';
