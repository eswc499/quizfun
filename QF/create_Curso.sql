create table curso(
id int IDENTITY(1,1) constraint cr_pk primary key,
namec nvarchar(30) not null unique
)