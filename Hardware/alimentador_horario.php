<?php

include 'conexao.php';

$disp = $_GET['disp'];

if ($disp== '')
{
    echo ">_<";
}
else
{
    $sql = "SELECT DATE_FORMAT(horario, '%H:%i') AS h, qtdeDespejarRacao AS qtdeR, qtdeDespejarAgua AS qtdeA FROM alimentadorHorarios WHERE identificador= '$disp' AND horario=DATE_FORMAT(CURTIME(), '%H:%i')";

    $select = mysqli_query($conn, $sql);

    if(mysqli_num_rows($select) > 0)
    {
        while($result = mysqli_fetch_assoc($select))
        {
            echo $result["h"];
            echo "-";
            echo $result["qtdeR"];
            echo "-";
            echo $result["qtdeA"];
        }
        return $dadoObtido;
    }
    else
    {
        echo 'sem dados';
    }

    mysqli_close($conn);
}
?>