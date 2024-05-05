<?php
include 'conexion.php';

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $ci = $_POST['ci'];
    $nombre = $_POST['nombre'];
    $apellido = $_POST['apellido'];
    $edad = $_POST['edad'];
    $direccion = $_POST['direccion'];
    $psw = $_POST['psw'];
    $rol_id = $_POST['rol_id'];
    $tipo = $_POST['tipo'];  // Agregar la variable para el tipo de cuenta
    $saldo = $_POST['saldo'];
    $departamento = $_POST['departamento'];  // Agregar la variable para el departamento

    // Insertar datos de la persona
    $sql_persona = "INSERT INTO persona (ci, nombre, apellido, edad, direccion, psw, rol_id) VALUES ('$ci', '$nombre', '$apellido', $edad, '$direccion', '$psw', $rol_id)";
    mysqli_query($con, $sql_persona);

    // Obtener el ID de la persona insertada
    $persona_id = mysqli_insert_id($con);

    // Insertar cuenta bancaria asociada a la persona
    $sql_cuenta = "INSERT INTO cuenta (tipo, saldo, departamento, persona_id) VALUES ('$tipo', $saldo, '$departamento', $persona_id)";
    mysqli_query($con, $sql_cuenta);

    echo "Persona y cuenta bancaria agregadas correctamente.";
    echo "<a href='lista.php'>LISTA</a>";

}
?>
