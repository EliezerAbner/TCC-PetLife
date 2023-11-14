<?php

include 'conexao.php';

$lat = $_GET['lat'];
$lon = $_GET['lon'];
$disp = $_GET['disp'];

if ($lat==''|| $lon== ''|| $disp== '')
{
      echo "Campos não preenchidos";
}
else
{
      $sql = "INSERT INTO rastreadorDados (identificador, dataRecolhida, latitude, longitude) VALUES ('$disp', 'NOW()', '$lat', '$lon')";
      
      if (mysqli_query($conn, $sql)) {
            echo "dados cadastrados";
      } else {
            echo "Error: " . $sql . "<br>" . mysqli_error($conn);
      }

      mysqli_close($conn);
}
      
?>