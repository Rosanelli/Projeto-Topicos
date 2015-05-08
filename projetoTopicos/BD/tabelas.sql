create table USUARIO
(
	ID int identity,
	nome varchar(35),
	usuario varchar(35),
	senha varchar(32),
	tipo varchar(25),
	
	CONSTRAINT PK_usuario primary key (usuario),
	CONSTRAINT FK_tipo foreign key (tipo) references TIPO_USUARIO(descricao)
)


CREATE TABLE TIPO_USUARIO
(
	ID int identity,
	descricao varchar(25),
	
	CONSTRAINT PK_descricao primary key(descricao)
)	

CREATE TABLE CLIENTE
(
   ID int identity,
   nome varchar(50),
   telefone varchar(25),
   sexo varchar(10),
   
   CONSTRAINT PK_id primary key(ID),
   CONSTRAINT UK_nome unique(nome)
)

