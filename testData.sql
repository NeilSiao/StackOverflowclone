create database StackOverflowDatabase;

use StackOverflowDatabase

create table Categories(
CategoryID int primary key identity(1,1),
CategoryName nvarchar(max)
);

create table Users(
	UserID int primary key identity(1,1),
	Email nvarchar(max),
	PasswordHash nvarchar(max),
	Name nvarchar(max),
	Mobile nvarchar(max),
	IsAdmin bit default(0)
)

create table Questions(
QuestionID int primary key identity(1,1),
QuestionName nvarchar(max),
QuestionDateTime datetime,
UserID int references Users(UserID) on delete cascade,
CategoryID int references Categories(CategoryID) on delete cascade,
VotesCount int,
AnswersCount int,
ViewsCount int
)
sp_rename 'Questions.AnswerCount', 'AnswersCount', 'COLUMN';

create table Answers(
AnswerID int primary key identity(1,1),
AnswerText nvarchar(max),
AnswerDateTime datetime,
UserID int references Users(UserID) on delete cascade,
QuestionID int,
VotesCount int
)
 /**references Questions(QuestionID) on delete cascade*
ALTER TABLE [dbo].Answers  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([QuestionID])
ON DELETE cascade

ALTER TABLE [dbo].[States]  WITH CHECK ADD  CONSTRAINT [FK_States_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
ON UPDATE CASCADE*/

Create table Votes(
VoteID int primary key identity(1,1),
UserID int references [Users](UserID) on delete cascade,
AnswerID int , --references Answers(AnswerID) on delete cascade,
VoteValue int
)


insert into Users (Email, PasswordHash, Name, Mobile, IsAdmin) values ('admin@gmail.com', 
'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Admin', '000000000', 1);

insert into Users (Email, PasswordHash, Name, Mobile, IsAdmin) values('test@gmail.com', 'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae', 'Test', '000000000', 0);



insert into Categories values ('HTML') , ('CSS'), ('JavScript')


QuestionID int primary key identity(1,1),
QuestionName nvarchar(max),
QuestionDateTime datetime,
UserID int references Users(UserID) on delete cascade,
CategoryID int references Categories(CategoryID) on delete cascade,
VotesCount int,
AnswerCount int,
ViewsCount int

insert into Questions (QuestionName, QuestionDateTime,UserID,CategoryID,VotesCount,AnswerCount,ViewsCount) 
values ('How to display icon in the browser titlebar using HTML', '2018-08-02 10:03 am', 2,1,0,0,0);

insert into Questions values ('How to set background image', '2018-08-02 10:03 am', 2,2,0,0,0);
