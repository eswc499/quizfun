create table Cuenta(
id int identity(1,1) constraint Cuent_pk primary key,
Nick nvarchar(30) not null unique,
Pass nvarchar(15) not null
);