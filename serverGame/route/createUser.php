<?php
    include "../dbConnection.php";

    $username = $_POST['username'];
    $password = hash("sha256", $_POST['password']);

    $sql = "SELECT username FROM usuarios WHERE username='$username'";
    $result =  mysqli_query($connect, $sql);

    if(mysqli_num_rows($result) > 0) {
        $data = array('done'=> false, 'message'=>"Error nombre de usuario ya existe");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    } else {
        if( $username != "" && $password != "") {
            $sql = "INSERT INTO usuarios SET username = '$username', password = '$password'";
            mysqli_query($connect, $sql);
            $data = array('done'=> true, 'message'=>"Usuario creado con exito");
            Header('Content-Type: application/json');
            echo json_encode($data);
            exit();
        } else {
            $data = array('done'=> false, 'message'=>"Todos los campos son requeridos");
            Header('Content-Type: application/json');
            echo json_encode($data);
            exit();
        }
    }
?>