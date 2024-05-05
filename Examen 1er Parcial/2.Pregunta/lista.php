<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Operaciones ABC</title>
    
</head>
<body>
    <a href='lista.php'>ACTUALIZAR</a>
     <a href='index.php'>MENU</a>
    <?php
    // Incluir archivo de conexión a la base de datos
    include "conexion.php";

    // Consulta SQL para obtener personas y sus cuentas bancarias
    $sql = "SELECT persona.id, persona.ci, persona.nombre, persona.apellido, cuenta.id AS cuenta_id, cuenta.tipo, cuenta.saldo
            FROM persona
            INNER JOIN cuenta ON persona.id = cuenta.persona_id";

    // Ejecutar la consulta
    $resultado = mysqli_query($con, $sql);
    ?>
    <div class="table-container">
        <table border="1px">
            <h1>Lista</h1>
            <tr>
                <td>ID</td>
                <td>CI</td>
                <td>Nombre</td>
                <td>Apellido</td>
                <td>ID Cuenta</td>
                <td>Tipo</td>
                <td>Saldo</td>
                <td>OPERACIONES</td>
            </tr>
            <?php
            // Iterar sobre los resultados de la consulta
            while ($fila = mysqli_fetch_array($resultado)) {
                echo "<tr>";
                echo "<td>".$fila['id']."</td>";
                echo "<td>".$fila['ci']."</td>";
                echo "<td>".$fila['nombre']."</td>";
                echo "<td>".$fila['apellido']."</td>";
                echo "<td>".$fila['cuenta_id']."</td>"; // Cambiado a cuenta_id
                echo "<td>".$fila['tipo']."</td>"; // Cambiado a tipo
                echo "<td>".$fila['saldo']."</td>"; // Cambiado a saldo
                // Generar enlace para eliminar cuenta bancaria
                echo "<td><a href='eliminar.php?id=".$fila['cuenta_id']."'>Eliminar</a></td>";
                echo "</tr>";    
            }
            ?>
        </table>
    </div>
</body>
</html>
