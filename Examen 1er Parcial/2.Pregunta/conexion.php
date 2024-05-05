<?php
$servername = "localhost";
$username = "sara";
$password = "123456";
$database = "bdsara";

// Crear conexión
$con = new mysqli($servername, $username, $password, $database);

// Verificar la conexión
if ($con->connect_error) {
    die("Conexión fallida: " . $con->connect_error);
}
?>
