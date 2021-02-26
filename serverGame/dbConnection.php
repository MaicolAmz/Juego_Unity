<?php
    $servername = "b8omtxlpyesfnxdtk7a0-mysql.services.clever-cloud.com";
    $database = "b8omtxlpyesfnxdtk7a0";
    $username = "un82qksuqjyzhzxm";
    $password = "nkWQ4RKr9ZCCC8S50y5q";

    $connect = new mysqli
        (
            $servername,
            $username,
            $password,
            $database
        );

    if ($connect->connect_errno) {
        die("La conexión a fallado");
    }
?>