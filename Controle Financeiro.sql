CREATE DATABASE controle_financeiro_bd;
USE controle_financeiro_bd;

CREATE TABLE Usuario (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nome_completo VARCHAR(200) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE,
    cpf VARCHAR(50) NOT NULL UNIQUE,
    telefone VARCHAR(50) NOT NULL,
    senha VARCHAR(255) NOT NULL
);

CREATE TABLE Conta (
    id_conta INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100),
    nome_instituicao VARCHAR(150),
    tipo VARCHAR(100)NOT NULL,
    saldo_atual FLOAT NOT NULL,
    id_usuario_fk INT NOT NULL,
    FOREIGN KEY (id_usuario_fk) REFERENCES Usuario (id_usuario)
);

CREATE TABLE Categoria (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    tipo VARCHAR(100) NOT NULL
);

CREATE TABLE Movimentacao (
    id_movimentacao INT AUTO_INCREMENT PRIMARY KEY,
    valor float NOT NULL,
    data_movimentacao DATE NOT NULL,
    descricao TEXT,
    id_conta_fk INT NOT NULL,
    FOREIGN KEY (id_conta_fk) REFERENCES Conta (id_conta),
    id_categoria_fk INT NOT NULL,
    FOREIGN KEY (id_categoria_fk) REFERENCES Categoria (id_categoria)
);