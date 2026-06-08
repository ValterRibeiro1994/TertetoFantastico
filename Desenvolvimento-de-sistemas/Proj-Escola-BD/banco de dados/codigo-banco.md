create database escola;
use escola;

create table alunos(
	Matricula_Alu int not null PRIMARY key,
    Nome_Alu varchar(80) not null,
    Email_Alu varchar(80) not null unique,
    Nasc_Alu date not null,
    CPF_Alu char(11) not null unique,
    NomeFoto_Alu varchar(80) not null,
    Foto_Alu blob not null
)engine="InnoDB";

create table mensalidade(
    Id_Mens autoincrement not null,
	Matricula_Alu int not null,
    DtPag_Mens date not null,
    VlPag_Mens double not null,
    Juros_Mens double not null,
    Desconto_Mens double not null,
    foreign key(Matricula_Alu) references alunos(Matricula_Alu)
)ENGINE="InnoDb";

