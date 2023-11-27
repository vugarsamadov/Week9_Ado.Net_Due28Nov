create database adonet

use adonet

create table Users
(
    Id int identity primary key,
    Username nvarchar(50) NOT NULL UNIQUE ,
    Name nvarchar(50) NOT NULL,
    Surname nvarchar(50) NOT NULL,
    Password nvarchar(64) NOT NULL
);

create table Blogs
(
    Id int identity primary key,
    Title nvarchar(50) NOT NULL,
    Description nvarchar(250),
    UserId int references Users(Id)
)