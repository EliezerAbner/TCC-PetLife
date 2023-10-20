DELIMITER $$
CREATE PROCEDURE `login`
(
    IN _email VARCHAR(100),
    IN _senha VARCHAR(200),
    OUT loginAutorizado BOOLEAN,
    OUT _clienteId INT
)
BEGIN
    DECLARE _emailId INT;

    IF EXISTS (SELECT email FROM email WHERE email = _email) THEN
    
        SELECT emailId INTO _emailId FROM email WHERE email = _email;
        
        IF EXISTS (SELECT loginId FROM login WHERE emailId=_emailId AND senha=_senha ) THEN
            SET loginAutorizado = TRUE;
            
            SELECT clienteId 
				INTO _clienteId
                FROM login
                WHERE emailId=_emailId 
                AND senha=_senha;
        ELSE
            SET loginAutorizado = FALSE;
        END IF;   
    ELSE
        SET loginAutorizado = FALSE;
    END IF;
END;