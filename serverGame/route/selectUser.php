<?php
include "../dbConnection.php";

$sql = "SELECT usuarios.username, puntajes.puntaje FROM puntajes INNER JOIN usuarios ON puntajes.id_usuarios=usuarios.id_usuarios;";

$result = mysqli_query($connect, $sql);

if(mysqli_num_rows($result)>0){
    while($row = mysqli_fetch_assoc($result)){
        echo $row['usuarios.username'].": ".$row['puntajes.puntaje']." puntos;";
    }
}
?>