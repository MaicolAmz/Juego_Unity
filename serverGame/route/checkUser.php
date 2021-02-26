<?php
    $username = $_POST['username'];
    $password = hash("sha256", $_POST['passoword']);

    $sql = "SELECT username WHERE username = '$username' AND password = '$password'";

    $result =  mysqli_query($connect, $sql);

    if(mysqli_num_rows($result) > 0) {
        $data = array('done'=> true, 'message'=>"Bienvenido $username");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    } else {
        $data = array('done'=> false, 'message'=>"Error en el nombre de usuario o contraseña");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    }
?>