CREATE database siepro;

CREATE SEQUENCE pessoa_seq;
CREATE TABLE pessoa
(
	id bigint NOT NULL DEFAULT nextval('pessoa_seq'),
	nome varchar(100) NOT NULL,
	registro varchar(25) NOT NULL,
	data_cadastro timestamp WITHout TIME ZONE DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT pk_pessoa  PRIMARY key(id)
)

CREATE TABLE pessoa_fisica
(
	id bigint NOT NULL,
	data_nascimento date,
	rg varchar(10),
	rg_expedidor varchar(50),
	rg_expedicao date,
	titulo varchar(10),
	titulo_zona varchar(5),
	titulo_secao varchar(5),	
	nome_mae varchar(50),
	nome_pai varchar(50),
	CONSTRAINT pk_pessoa_fisica  PRIMARY key(id),
	CONSTRAINT fk_pessoa_fisica_pessoa FOREIGN key(id) REFERENCES pessoa(id)
)

CREATE SEQUENCE ramo_seq;
CREATE TABLE ramo
(
	id bigint NOT NULL DEFAULT nextval('ramo_seq'),
	nome varchar(100) not null,
	CONSTRAINT pk_ramo PRIMARY key(id)
)

CREATE TABLE pessoa_juridica
(
	id bigint NOT NULL,	
	nome_fantasia varchar(100),
	CONSTRAINT pk_pessoa_juridica  PRIMARY key(id),
	CONSTRAINT fk_pessoa_juridica_pessoa FOREIGN key(id) REFERENCES pessoa(id)
)


CREATE SEQUENCE ramo_juridica_seq;
CREATE TABLE ramo_juridica
(
	id bigint NOT NULL DEFAULT nextval('ramo_juridica_seq'),
	id_pessoa_juridica bigint NOT NULL,	
	id_ramo bigint NOT NULL,
	CONSTRAINT pk_ramo_juridica  PRIMARY key(id),
	CONSTRAINT fk_ramo_juridica_pessoa FOREIGN key(id_pessoa_juridica) REFERENCES pessoa_juridica(id),
	CONSTRAINT fk_ramo_juridica_ramo FOREIGN key(id_ramo) REFERENCES ramo(id)	,
	CONSTRAINT uk_ramo_juridica UNIQUE (id_pessoa_juridica,id_ramo )
)