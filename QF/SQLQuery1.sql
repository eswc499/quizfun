
create table Pregunta(
Id int constraint preg_key primary key,
Problema nvarchar(300) not null,
Alter1 nvarchar(100) not null,
Alter2 nvarchar(100) not null,
Alter3 nvarchar(100) not null,
Respuesta nvarchar(100) not null,
CuestionarioID int constraint pregcuest_pk foreign key references Cuestionario(id)
)

