DELIMITER $$
CREATE PROCEDURE `editar_cliente`
(
	IN _clienteId INT,
    IN _nome VARCHAR(50),
	IN _dataNascimento DATE,
	IN _email VARCHAR(50),
    IN _senha VARCHAR(200),
	IN _rua VARCHAR(50),
	IN _numero INT,
	IN _cep VARCHAR(50),
	IN cidade VARCHAR(50),
	IN estado VARCHAR(50),
	IN _telefone VARCHAR(50) 
)
BEGIN
    DECLARE _cidadeId INT;
    DECLARE _emailId INT;
    
    SET SQL_SAFE_UPDATES = 0;
    
    UPDATE cliente
        SET nome = _nome, dataNascimento = _dataNascimento
        WHERE clienteId = _clienteId;

    UPDATE email
        SET email = _email
        WHERE clienteId = _clienteId;
        
	SELECT emailId
		INTO _emailId
        FROM email
        WHERE email = _email
        AND clienteId = _clienteId;

    UPDATE telefone
        SET telefone = _telefone
        WHERE clienteId = _clienteId;

    UPDATE login
        SET senha = _senha
        WHERE clienteId = _clienteId
        AND emailId = _emailId;

    IF NOT EXISTS (SELECT nomeCidade FROM cidade WHERE nomeCidade = cidade)
        THEN INSERT INTO cidade (estadoId, nomeCidade) VALUES (estado, cidade);
    END IF;

    SELECT cidadeId
        INTO _cidadeId
        FROM cidade
        WHERE nomeCidade = cidade;

    UPDATE endereco
        SET cidadeId = _cidadeId, rua = _rua, numero = _numero, cep = _cep
        WHERE clienteId = _clienteId;

    SET SQL_SAFE_UPDATES = 1;
END;