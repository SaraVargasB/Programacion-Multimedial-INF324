<?php
include "conexion.php";

// Verificar si se ha pasado un parámetro 'id' a través de la URL
if(isset($_GET['id'])) {
    // Obtener el ID de la cuenta que se va a eliminar
    $id_cuenta_eliminar = $_GET['id'];

    // Eliminar registros de transaccion relacionados con la cuenta a eliminar como cuenta origen
    $sql_eliminar_transacciones_origen = "DELETE FROM transaccion WHERE cuenta_origen_id = $id_cuenta_eliminar";
    mysqli_query($con, $sql_eliminar_transacciones_origen);

    // Eliminar registros de transaccion relacionados con la cuenta a eliminar como cuenta destino
    $sql_eliminar_transacciones_destino = "DELETE FROM transaccion WHERE cuenta_destino_id = $id_cuenta_eliminar";
    mysqli_query($con, $sql_eliminar_transacciones_destino);

    // Luego, eliminar la cuenta bancaria
    $sql_eliminar_cuenta = "DELETE FROM cuenta WHERE id = $id_cuenta_eliminar";
    if(mysqli_query($con, $sql_eliminar_cuenta)) {
        echo "La cuenta bancaria se eliminó exitosamente.";
         echo "<a href='lista.php'>LISTA</a>";
    } else {
        echo "Error al eliminar la cuenta bancaria: " . mysqli_error($con);
    }
}

// Consulta para obtener personas y sus cuentas bancarias (sin cambios)
$sql = "SELECT persona.id, persona.ci, persona.nombre, persona.apellido, cuenta.id AS cuenta_id, cuenta.tipo, cuenta.saldo
        FROM persona
        INNER JOIN cuenta ON persona.id = cuenta.persona_id";
$resultado = mysqli_query($con, $sql);
?>
