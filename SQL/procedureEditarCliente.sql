DELIMITER $$
CREATE PROCEDURE `editar_cliente`
(
	IN clienteId INT,
    IN nome VARCHAR(50),
	IN dataNascimento DATE,
	IN email VARCHAR(50),
    IN senha VARCHAR(200),
	IN rua VARCHAR(50),
	IN numero INT,
	IN cep VARCHAR(50),
	IN cidade VARCHAR(50),
	IN estado VARCHAR(50),
	IN telefone VARCHAR(50) 
)
BEGIN
    DECLARE _cidadeId INT;
    DECLARE _emailId INT;
    
    UPDATE cliente
        SET nome = nome, dataNascimento = dataNascimento
        WHERE clienteId = clienteId;

    UPDATE email
        SET email = email
        WHERE clienteId = clienteId;
        
	SELECT emailId
		INTO _emailId
        FROM email
        WHERE email = email;

    UPDATE telefone
        SET telefone = telefone
        WHERE clienteId = clienteId;

    UPDATE login
        SET senha = senha
        WHERE clienteId = clienteId
        AND emailId = _emailId;

    IF NOT EXISTS (SELECT nomeCidade FROM cidade WHERE nomeCidade = cidade)
        THEN INSERT INTO cidade (estadoId, nomeCidade) VALUES (estado, cidade);
    END IF;

    SELECT cidadeId
        INTO _cidadeId
        FROM cidade
        WHERE nomeCidade = cidade;

    UPDATE endereco
        SET cidadeId = _cidadeId, rua = rua, numero = numero, cep = cep
        WHERE clienteId = clienteId;
END;