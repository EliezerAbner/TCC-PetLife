DELIMITER $$
CREATE PROCEDURE `login`
(
    IN clienteId INT,
    IN email VARCHAR(100),
    IN senha VARCHAR(200),
    OUT loginAutorizado BOOLEAN
)
BEGIN
    DECLARE _emailId INT;

    IF EXISTS (SELECT nome FROM cliente WHERE clienteId=clienteId) THEN
        
        SELECT emailId INTO _emailId FROM email WHERE clienteId = clienteId;

        IF EXISTS (SELECT loginId FROM login WHERE emailId=_emailId AND senha=senha ) THEN
            SET loginAutorizado = TRUE;
        ELSE
            SET loginAutorizado = FALSE;
        END IF;   
    ELSE
        SET loginAutorizado = FALSE;
    END IF;
END;