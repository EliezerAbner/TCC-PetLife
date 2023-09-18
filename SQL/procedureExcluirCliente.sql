DELIMITER $$
CREATE PROCEDURE `excluir_cliente`
(
    IN clienteId INT
)
BEGIN
    DECLARE _emailId INT;

    DELETE  
        FROM telefone
        WHERE clienteId = clienteId;

    DELETE
        FROM login
        WHERE clienteId = clienteId;

    DELETE
        FROM email
        WHERE clienteId = clienteId;

    DELETE
        FROM endereco
        WHERE clienteId =  clienteId;
        
    DELETE 
        FROM cliente 
        WHERE clienteId =  clienteId;
END;
