DELIMITER $$
CREATE PROCEDURE `novo_cliente`
(
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
	DECLARE _clienteId INT;
    DECLARE _emailId INT;
    DECLARE _cidadeId INT;
    
    INSERT 
		INTO cliente (nome, dataNascimento) 
        VALUES (nome, dataNascimento);
        
    SELECT MAX(clienteId) 
		INTO _clienteId 
        FROM cliente;
    
    INSERT 
		INTO email (clienteId, email)
        VALUES (_clienteId, email);
	
    SELECT MAX(emailId)
		INTO _emailId
        FROM email;
        
	INSERT
		INTO login (clienteId, emailId, senha)
        VALUES (_clienteId, _emailId, senha);
        
	INSERT
		INTO telefone (clienteId, telefone)
        VALUES (_clienteId, telefone);
        
	IF NOT EXISTS ( SELECT nomeCidade FROM cidade WHERE nomeCidade = cidade )
		THEN INSERT INTO cidade (estadoId, nomeCidade) VALUES (estado, cidade);
	END IF;
        
    SELECT MAX(cidadeId)
		INTO _cidadeId
        FROM cidade;
        
	INSERT
		INTO endereco (clienteId, cidadeId, rua, numero, cep)
        VALUES (_clienteId, _cidadeId, rua, numero, cep);
    
END;
