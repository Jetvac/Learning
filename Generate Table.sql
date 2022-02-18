-- Таблица День недели
CREATE TABLE [WeekDay]
(
	WeekDayID INT PRIMARY KEY IDENTITY (0, 1),
	WeekDayName NVARCHAR (20) NOT NULL
)

-- Таблица Пол
CREATE TABLE [Gender]
(
	GenderID INT PRIMARY KEY IDENTITY (0, 1),
	GenderName NVARCHAR (25) NOT NULL
)

-- Таблица Должность
CREATE TABLE [Post]
(
	PostID INT PRIMARY KEY IDENTITY (0, 1),
	PostName NVARCHAR (25) NOT NULL
)

-- Таблица Сотрудник
CREATE TABLE [Employee]
(
	EmployeeID INT PRIMARY KEY IDENTITY (0, 1),
	EmployeeFullname NVARCHAR (MAX) NOT NULL,
	EmployeeBirthdate DATE NOT NULL,
	EmployeePhoneNumber NVARCHAR (30) NOT NULL,
	EmployeeEmail NVARCHAR (30) NOT NULL,
	GenderID INT FOREIGN KEY REFERENCES Gender (GenderID) NOT NULL,
	PostID INT FOREIGN KEY REFERENCES Post (PostID) NOT NULL
)

-- Таблица Класс
CREATE TABLE [StudyClass]
(
	StudyClassID INT PRIMARY KEY IDENTITY (0, 1),
	StudyClassNumber NVARCHAR (5) NOT NULL,
	EmployeeID INT FOREIGN KEY REFERENCES Employee (EmployeeID) NOT NULL,
)

-- Таблица Дисциплина
CREATE TABLE [Discipline]
(
	DisciplineID INT PRIMARY KEY IDENTITY (0, 1),
	DisciplineName NVARCHAR (50) NOT NULL,
	WeeklyLoad INT
)

-- Таблица рабочий-дисциплина
CREATE TABLE [EmployeeDiscipline]
(
	EmployeeDisciplineID INT PRIMARY KEY IDENTITY (0, 1),
	EmployeeID INT FOREIGN KEY REFERENCES Employee (EmployeeID),
	DisciplineID INT FOREIGN KEY REFERENCES Discipline (DisciplineID),
)

-- Таблица Расписание
CREATE TABLE [Schedule]
(
	StudyClassID INT FOREIGN KEY REFERENCES StudyClass (StudyClassID),
	WeekDayID INT FOREIGN KEY REFERENCES WeekDay (WeekDayID),
	CONSTRAINT ScheduleID PRIMARY KEY (StudyClassID, WeekDayID)
)

-- Таблица Список дисциплин (на один день)
CREATE TABLE [ScheduleDiscipline]
(
	ScheduleDisciplineID INT PRIMARY KEY IDENTITY (0, 1),
	ScheduleID INT FOREIGN KEY REFERENCES Schedule (ScheduleID) NOT NULL,	
	DisciplineID INT FOREIGN KEY REFERENCES Discipline (DisciplineID) NOT NULL	
)