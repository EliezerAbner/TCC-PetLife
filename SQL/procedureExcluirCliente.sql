DELIMITER $$
CREATE PROCEDURE `excluir_cliente`
(
    IN _clienteId INT
)
BEGIN
	SET SQL_SAFE_UPDATES = 0;

   UPDATE cliente
        SET status = 0
        WHERE clienteId = _clienteId;
        
	SET SQL_SAFE_UPDATES = 1;
END;
