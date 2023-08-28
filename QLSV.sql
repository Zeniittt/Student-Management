CREATE TABLE [dbo].[Login] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [username] NVARCHAR (10) NULL,
    [password] NVARCHAR (10) NULL,
    [email]    NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[RegisterAccount] (
	[verify] bit default(0),
	[role] NVARCHAR(20),
	[id] NVARCHAR(20),
	[fname] NVARCHAR(20),
	[lname] NVARCHAR(20),
    [username] NVARCHAR (20) PRIMARY KEY ,
    [password] NVARCHAR (10) NULL,
    [email]    NVARCHAR (50) NULL,
	[image] image,
);

CREATE TABLE Student
(
	id nvarchar(20) PRIMARY KEY not null,
    fname nvarchar(10),
    lname nvarchar(50),
	email nvarchar(50),
	major nvarchar(20),
	faculty nvarchar(50),
	selectedCourse nvarchar(100),
	bdate date,
	gender nvarchar(10),
	phone nvarchar(10),
	hometown nvarchar(10),
	address nvarchar(10),
	picture image,
	[username] NVARCHAR (10) NULL,
    [password] NVARCHAR (10) NULL,
)
Create TABLE Course
(
	id int PRIMARY KEY not null,
	semester nvarchar(20),
    lable nvarchar(50),
	idTeacher nvarchar(20),
	room nvarchar(20),
	dayOfCourse nvarchar(20),
	lesson nvarchar(20),
	timeOfCourse nvarchar(20),
    period int,
	description nvarchar(50),
)

CREATE TABLE Score
(
	studentID nvarchar(20)not null,
	courseID int,
    score float,
	description text,
	result	NVARCHAR(50)
)

CREATE TABLE Major
(
	id int PRIMARY KEY not null,
	major nvarchar(30)
)

CREATE TABLE Faculty
(
	id int IDENTITY(1,1) PRIMARY KEY not null,
	idHumanResourse nvarchar(20),
	faculty nvarchar(30)
)

CREATE TABLE Gender
(
	id int PRIMARY KEY not null,
	gender nvarchar(30)
)

CREATE TABLE Hometown
(
	id int PRIMARY KEY not null,
	hometown nvarchar(30)
)

CREATE TABLE Semester
(
	id int PRIMARY KEY not null,
	semester nvarchar(3)
)

CREATE TABLE CourseStudent
(
	studentID nvarchar(20),
	fname nvarchar(20),
	lname nvarchar(20),
	courseID int,
    courseName nvarchar(50),
	semester nvarchar(3),
	room nvarchar(20),
	dayOfCourse nvarchar(20),
	lesson nvarchar(20),
	timeOfCourse nvarchar(20),

	FOREIGN KEY (studentID)
	REFERENCES Student (id),
	FOREIGN KEY (courseID)
	REFERENCES Course (id)
)

CREATE TABLE CourseTeacher
(
	teacherID nvarchar(20),
	fname nvarchar(20),
	lname nvarchar(20),
	courseID int,
    courseName nvarchar(50),
	semester nvarchar(3),

	FOREIGN KEY (teacherID)
	REFERENCES Teacher (id),
	FOREIGN KEY (courseID)
	REFERENCES Course (id)
)

CREATE TABLE Teacher
(
	id nvarchar(20) PRIMARY KEY,
	idHumanResourse nvarchar(20),
    fname nvarchar(20),
    lname nvarchar(20),
	faculty_id int,
	phone nvarchar(20),
	address nvarchar(50),
	username nvarchar(20),
	password nvarchar(20),
	email nvarchar(50),
	picture image,
)

CREATE TABLE HumanResourse
(
	id nvarchar(20) PRIMARY KEY,
    fname nvarchar(20),
    lname nvarchar(20),
	username nvarchar(20),
	password nvarchar(20),
	email nvarchar(50),
	picture image,
)

CREATE TABLE Notification
(
	idTeacher nvarchar(20),
	idCourse int,
	time datetime,
    title nvarchar(75),
    description nvarchar(200),
)

select * from Notification
drop table Notification

CREATE TABLE Room
(
	id int PRIMARY KEY not null,
	room nvarchar(30)
)

select * from Room
drop table Room
insert into Room values(1, 'A5-103')
insert into Room values(2, 'A5-304') 

CREATE TABLE Day
(
	id int PRIMARY KEY not null,
	day nvarchar(30)
)

select * from Day
drop table Day
insert into Day values(1, 'Monday')
insert into Day values(2, 'Tuesday') 
insert into Day values(3, 'Wednesday') 
insert into Day values(4, 'Thursday') 
insert into Day values(5, 'Friday') 
insert into Day values(6, 'Saturday') 

CREATE TABLE Lesson
(
	id int PRIMARY KEY not null,
	lesson nvarchar(30)
)

select * from Lesson
drop table Lesson
insert into Lesson values(1, '1-5')
insert into Lesson values(2, '7-10') 

CREATE TABLE TimeTableOfStudent
(
	idStudent nvarchar(20),
	semester nvarchar(3),
	courseName nvarchar(50),
	teacher nvarchar(30),
	room nvarchar(20),
	dayOfCourse nvarchar(20),
	lesson nvarchar(20),
	timeOfCourse nvarchar(20),
)

select * from TimeTableOfStudent
drop table TimeTableOfStudent
SELECT courseName, teacher, room, dayOfCourse, lesson, timeOfCourse FROM TimeTableOfStudent where idStudent = '20110016STU' and semester = 'HK2'


select * from Student
drop table Student
update Student set selectedCourse=''  where id = '20110016'
update Student set selectedCourse=''  where id = '20142178'
update Student set username='huy', password = 'huy'  where id = '20142178STU'
update Student set username='anh', password = 'anh'  where id = '20112306STU'
Select * from Student where selectedCourse = ''
SELECT id, fname, lname, major, faculty FROM Student
delete from Student where id = '20110016'

select * from Login
drop table 
delete from Login where email = 'khaidai@gmail.com'
delete from Login where email = '20110016@student.hcmute.edu.vn'

select * from RegisterAccount
drop table RegisterAccount
delete from RegisterAccount where email = '20110016@student.hcmute.edu.vn'
delete from RegisterAccount where email = 'tinnqd2002@gmail.com'

select * from Teacher
SELECT * FROM Teacher WHERE id = '4TEA'
UPDATE Teacher SET username = 'thinh', password = 'thinh' WHERE id = '3TEA'
UPDATE Teacher SET username = 'van', password = 'van' WHERE id = '4TEA'
drop table Teacher
SELECT Teacher.id, Teacher.fname, Teacher.lname, Faculty.faculty, Teacher.phone, Teacher.email, Teacher.address, Teacher.picture FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id WHERE Teacher.idHumanResourse = '1HRE'

select * from HumanResourse
drop table HumanResourse
delete from HumanResourse where email = 'niemhr@gmail.com'
update HumanResourse SET id = '2HRE' where fname = 'Niem'


select * from Course
SELECT * FROM Course where semester = 'HK2'
drop table Course

select * from Score
select courseID from Score where studentID = '20142178STU'
drop table Score

select * from Major
drop table Major
insert into Major values(1, 'Software Engineering')
insert into Major values(2, 'Information System') 
insert into Major values(3, 'Networking')
insert into Major values(4, 'IT')

select * from Faculty
drop table Faculty
insert into Faculty values(1, 'Information Technology')
insert into Faculty values(2, 'Mechanical')
insert into Faculty values(3, 'Electric')
delete from Faculty where idHumanResourse = '2HREHRE'

select * from Gender
drop table Gender
insert into Gender values(1, 'Male')
insert into Gender values(2, 'Female')

select * from Hometown
drop table Hometown
insert into Hometown values(1, 'An Giang')
insert into Hometown values(2, 'Dong Thap')
insert into Hometown values(3, 'Tien Giang')
insert into Hometown values(4, 'TPHCM')
insert into Hometown values(5, 'Long An')
insert into Hometown values(6, 'Dong Nai')
insert into Hometown values(7, 'Ha Noi')

select * from Semester
drop table Semester
insert into Semester values(1, 'HK1')
insert into Semester values(2, 'HK2')

Select * from CourseStudent
drop table CourseStudent
SELECT id FROM Course WHERE lable='Machine Learning'

Select * from CourseTeacher
drop table CourseTeacher
SELECT id FROM Course WHERE lable='Machine Learning'

SELECT selectedCourse FROM Student where id = '20142178'


SELECT Score.studentID, Student.fname, Student.lname, Score.courseID, Course.lable, Score.score FROM Student INNER JOIN score on Student.id = Score.studentID INNER JOIN course on Score.courseID = Course.id

SELECT Score.studentID, Student.fname, Student.lname, Score.courseID, Course.lable  FROM Student INNER JOIN score on Student.id = Score.studentID INNER JOIN course on Score.courseID = Course.id

SELECT CourseStudent.studentID, CourseStudent.fname, CourseStudent.lname, Student.bdate  FROM Student INNER JOIN CourseStudent on Student.id = CourseStudent.studentID WHERE courseName='OOP'

SELECT Teacher.id, Teacher.fname, Teacher.lname, Faculty.faculty, Teacher.phone, Teacher.email, Teacher.address, Teacher.picture FROM Teacher INNER JOIN Faculty ON Teacher.faculty_id = Faculty.id WHERE Faculty.faculty = 'Information Technology'

select * from Student where concat(fname, address, null, null) like '%V%' 
select * from Student where major = 'IT' and faculty = null

CREATE TRIGGER AutoCalculateResult
ON Score
AFTER INSERT
AS
BEGIN
    UPDATE Score
    SET result = 
        CASE 
            WHEN Score.score < 3 THEN 'Kem'
            WHEN Score.score >= 3 AND Score.score < 5 THEN 'Yeu'
            WHEN Score.score >= 5 AND Score.score < 6 THEN 'Trung Binh'
            WHEN Score.score >= 6 AND Score.score < 8 THEN 'Kha'
            ELSE 'Gioi' 
        END
    FROM inserted
    WHERE Score.studentId = inserted.studentId and Score.courseId = inserted.courseId
END

SELECT COUNT(*) FROM Score INNER JOIN Course ON courseID = id WHERE result = 'Gioi' AND lable = 'Networking Essential' GROUP BY Course.lable