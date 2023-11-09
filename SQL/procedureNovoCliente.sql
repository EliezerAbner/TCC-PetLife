CREATE DEFINER=`xaolin`@`%` PROCEDURE `novo_cliente`
(
	IN `_nome` VARCHAR(50), 
	IN `_dataNascimento` DATE, 
	IN `_email` VARCHAR(50), 
	IN `_senha` VARCHAR(300), 
	IN `rua` VARCHAR(50), 
	IN `numero` INT, 
	IN `cep` VARCHAR(50), 
	IN `cidade` VARCHAR(50), 
	IN `estado` VARCHAR(50), 
	IN `_telefone` VARCHAR(50)
)
BEGIN
	DECLARE _clienteId INT;
    DECLARE _emailId INT;
    DECLARE _cidadeId INT;
    
    -- cliente
    
    IF EXISTS (SELECT * FROM cliente WHERE nome = _nome AND status = 0)
		THEN UPDATE cliente
			SET status = 1
            WHERE nome = _nome;
            
            SELECT clienteId
            INTO _clienteId
            FROM cliente
            WHERE nome = _nome;
	ELSE
		INSERT 
		INTO cliente (nome, dataNascimento, status) 
		VALUES (_nome, _dataNascimento, 1);
            
		SELECT MAX(clienteId) 
		INTO _clienteId 
		FROM cliente;
	END IF;
    
    -- email
        
	IF EXISTS (SELECT * FROM email WHERE email = _email AND status = 0)
		THEN UPDATE email
			SET status = 1
            WHERE email = _email;
            
            SELECT emailId
            INTO _emailId
            FROM email
            WHERE email = _email;
	ELSE
		INSERT 
		INTO email (clienteId, email, status)
		VALUES (_clienteId);
    
		SELECT MAX(emailId)
		INTO _emailId
		FROM email;
	END IF;
	
    -- login
        
	IF EXISTS (SELECT * FROM login WHERE clienteId = _clienteId AND emailId = _emailId AND status = 0)
		THEN UPDATE login
			SET status = 1, senha = _senha
            WHERE clienteId = _clienteId 
			AND emailId = _emailId;
	ELSE
		INSERT 
        INTO login (clienteId, status, emailId, senha)
        VALUES (_clienteId, 1, _emailId, _senha);
	END IF;
        
	-- telefone
	
    IF EXISTS (SELECT * FROM telefone WHERE telefone = _telefone AND status = 0)
		THEN UPDATE telefone
			SET status = 1
            WHERE telefone = _telefone;
	ELSE
		INSERT
        INTO telefone (clienteId, status, telefone)
        VALUES (_clienteId, 1, _telefone);
	END IF;
        
	-- cidade
    
	IF NOT EXISTS ( SELECT nomeCidade FROM cidade WHERE nomeCidade = cidade )
		THEN INSERT INTO cidade (estadoId, nomeCidade) VALUES (estado, cidade);
	END IF;
        
    SELECT cidadeId
		INTO _cidadeId
        FROM cidade
		WHERE nomeCidade = cidade;
        
	INSERT
		INTO endereco (clienteId, cidadeId, rua, numero, cep)
        VALUES (_clienteId, _cidadeId, rua, numero, cep);
    
END