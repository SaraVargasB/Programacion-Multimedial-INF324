<?php
include "conexion.php";

// Verificar si se ha pasado un parámetro 'id' a través de la URL
if(isset($_GET['id'])) {
    // Obtener el ID de la cuenta que se va a modificar
    $id_cuenta_modificar = $_GET['id'];

    // Verificar si se han enviado nuevos datos a través de un formulario POST
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        // Obtener los nuevos valores de la cuenta bancaria
        $tipo = $_POST['tipo'];
        $saldo = $_POST['saldo'];
        $departamento = $_POST['departamento'];

        // Ejecutar una consulta SQL para actualizar los datos de la cuenta bancaria
        $sql_actualizar_cuenta = "UPDATE cuenta SET tipo = '$tipo', saldo = $saldo, departamento = '$departamento' WHERE id = $id_cuenta_modificar";
        if(mysqli_query($con, $sql_actualizar_cuenta)) {
            echo "Los datos de la cuenta bancaria se actualizaron correctamente.";
            echo "<a href='modificar.php'> LISTA </a>";
        } else {
            echo "Error al actualizar los datos de la cuenta bancaria: " . mysqli_error($con);
        }
    }

    // Consulta para obtener los datos de la cuenta bancaria a modificar
    $sql_cuenta = "SELECT * FROM cuenta WHERE id = $id_cuenta_modificar";
    $resultado_cuenta = mysqli_query($con, $sql_cuenta);
    $cuenta = mysqli_fetch_assoc($resultado_cuenta);
}

// Consulta para obtener personas y sus cuentas bancarias (sin cambios)
$sql_personas_cuentas = "SELECT persona.id, persona.ci, persona.nombre, persona.apellido, cuenta.id AS cuenta_id, cuenta.tipo, cuenta.saldo, cuenta.departamento
        FROM persona
        INNER JOIN cuenta ON persona.id = cuenta.persona_id";
$resultado_personas_cuentas = mysqli_query($con, $sql_personas_cuentas);
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Modificación de Cuenta Bancaria</title>
</head>
<body>
    <?php if(isset($cuenta)) { ?>
        <h1>Modificación de Cuenta Bancaria</h1>
        <form action="" method="post">
            <label for="tipo">Tipo:</label>
            <select name="tipo" id="tipo" required>
                <option value="">Seleccione el tipo</option>
                <option value="cuenta de ahorros" <?php if($cuenta['tipo'] == 'cuenta de ahorros') echo 'selected'; ?>>Cuenta de ahorros</option>
                <option value="cuenta corriente" <?php if($cuenta['tipo'] == 'cuenta corriente') echo 'selected'; ?>>Cuenta corriente</option>
                <option value="cuenta de inversion" <?php if($cuenta['tipo'] == 'cuenta de inversion') echo 'selected'; ?>>Cuenta de inversión</option>
            </select><br><br>

            <label for="saldo">Saldo:</label>
            <input type="number" id="saldo" name="saldo" value="<?php echo $cuenta['saldo']; ?>"><br><br>
            
            <label for="departamento">Departamento:</label>
            <select name="departamento" id="departamento" required>
                <option value="la paz" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'la paz') echo 'selected'; ?>>La Paz</option>
                <option value="oruro" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'oruro') echo 'selected'; ?>>Oruro</option>
                <option value="potosi" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'potosi') echo 'selected'; ?>>Potosí</option>
                <option value="beni" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'beni') echo 'selected'; ?>>Beni</option>
                <option value="chuquisaca" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'chuquisaca') echo 'selected'; ?>>Chuquisaca</option>
                <option value="tarija" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'tarija') echo 'selected'; ?>>Tarija</option>
                <option value="santa cruz" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'santa cruz') echo 'selected'; ?>>Santa Cruz</option>
                <option value="cochabamba" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'cochabamba') echo 'selected'; ?>>Cochabamba</option>
                <option value="pando" <?php if(isset($cuenta['departamento']) && $cuenta['departamento'] == 'pando') echo 'selected'; ?>>Pando</option>
            </select><br><br>    

            <button type="submit">Actualizar</button>

        </form>
    <?php } else { ?>
        <h1>Lista de Cuentas Bancarias</h1>
        <a href="index.php"> MENU </a>
        <table border="1">
            <tr>
                <th>ID</th>
                <th>CI</th>
                <th>Nombre</th>
                <th>Tipo</th>
                <th>Saldo</th>
                <th>Departamento</th>
                <th>Modificar</th>
            </tr>
            <?php while ($fila = mysqli_fetch_assoc($resultado_personas_cuentas)) { ?>
                <tr>
                    <td><?php echo $fila['cuenta_id']; ?></td>
                    <td><?php echo $fila['ci']; ?></td>
                    <td><?php echo $fila['nombre'] . ' ' . $fila['apellido']; ?></td>
                    <td><?php echo $fila['tipo']; ?></td>
                    <td><?php echo $fila['saldo']; ?></td>
                    <td><?php echo $fila['departamento']; ?></td>
                    <td><a href="?id=<?php echo $fila['cuenta_id']; ?>">Modificar</a></td>
                </tr>
            <?php } ?>
        </table>
    <?php } ?>
</body>
</html>
