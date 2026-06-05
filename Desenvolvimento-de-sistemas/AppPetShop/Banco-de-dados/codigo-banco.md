create DATABASE if not EXISTS petshop_db;
use petshop_db;
CREATE TABLE if not exists tb_tutor(
	cpf_tutor char(11) not null unique,
    nome_tutor varchar(80) not null,
    celular_tutor char(11) not null unique,
    email_tutor varchar(80) not null unique,
    PRIMARY KEY(cpf_tutor)
)engine="InnoDB";

insert into tb_tutor(cpf_tutor, nome_tutor, celular_tutor, email_tutor) values 
("07845179913", "Valter Tertuliano", "16994030287", "valtertert@gmail.com"),
("56123460854", "Felipe Rodrigo", "11977818235", "felipereidelas@gmail.com"),
("58225745906", "Lucas Braz", "11944517587", "lucasubraz@gmail.com");

create table if not exists tb_pet(
	cod_pet int not null AUTO_INCREMENT,
    cpf_tutor char(11) not null,
    nascimento_pet date,
    genero_pet enum("M", "F") not null,
    raca_pet varchar(30) not null,
    foto_pet blob,
    nome_pet varchar(30) not null,
    especie_pet varchar(30) not null,
    PRIMARY key (cod_pet),
    FOREIGN key (cpf_tutor) REFERENCES tb_tutor(cpf_tutor)
) engine="InnoDB";

insert into tb_pet(cpf_tutor, nascimento_pet, genero_pet, raca_pet, nome_pet, especie_pet) values 
("07845179913", '2025-10-13', "M", "vira-lata", "caramelo", "cachorro"),
("56123460854", "2024-02-21", "M", "yorkshire", "paçoca", "cachorro"),
("58225745906", "2015-07-30", "F", "poddle", "veinha", "cachorro");


create table if not exists tb_servicos(
	cod_pet int not null,
    tipo_servico enum("banho", "tosa") not null,
    data_servico date not null,
    -- valor mais caro poposto 5000,00
    valor_servico numeric(6,2) not null,
    FOREIGN key(cod_pet) REFERENCES tb_pet(cod_pet)
) engine="InnoDB";

insert into tb_servicos(cod_pet, tipo_servico, data_servico, valor_servico) values 
(01, "banho", "2026-06-01", 20.50),
(02,"tosa","2025-05-31",54.99),
(03, "banho", "2026-01-25", 115.70);

create table if not exists tb_consulta(
	cod_pet int not null,
    data_consulta date not null,
    prescricao_consulta text not null,
    FOREIGN key(cod_pet) REFERENCES tb_pet(cod_pet)
) engine="InnoDB";

insert into tb_consulta(cod_pet, data_consulta, prescricao_consulta) VALUES
(01, "2026-06-01", "Cachorro com excesso de gostosura igual o tutor"),
(02, "2019-11-24","Sacrificado"),
(03, "2024-08-23", "Excesso de velhice, ronca demais, cataratas, dedao direito menor");
