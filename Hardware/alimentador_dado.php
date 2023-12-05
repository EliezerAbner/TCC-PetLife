<?php
include 'conexao.php';

$qtdConsumidaAgua = $_GET['qtdConsumAgua'];
$qtdConsumidaRacao = $_GET['qtdConsumRacao'];
$disp = $_GET['disp'];

if($qtdConsumidaAgua=='' || $qtdConsumidaRacao=='' || $disp=='')
{
    echo ">_<";
}
else
{
    $sql = "INSERT INTO alimentadorDadosRecolhidos (horaRecolhida, qtdConsumidaAgua, qtdConsumidaRacao, identificador) VALUES (NOW(), $qtdConsumidaAgua, $qtdConsumidaRacao, '$disp')";

    if(mysqli_query($conn, $sql))
    {
        echo "Dados cadastrados :)";
    }
    else
    {
        echo "Error: " . $sql . "<br>" . mysqli_error($conn);
    }

    mysqli_close($conn);
}
?>