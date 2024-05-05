<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de Cuentas Bancarias</title>
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
    <header class="header">
        <div class="container">
            <img src="imagenes/logo.png" alt="Logo del banco" class="logo">
            <h1 class="title">Bienvenido al Banco BNB</h1>
        </div>
    </header>

    <main class="container">
        <h2 class="subtitle">Lista de Cuentas Bancarias</h2>
        <div class="account-list">
            <?php
            // Conexión a la base de datos
            $conexion = new mysqli("localhost", "root", "", "bdsara");

            // Verificar la conexión
            if ($conexion->connect_error) {
                die("Error de conexión: " . $conexion->connect_error);
            }

            // Consulta para recuperar las cuentas bancarias
            $sql = "SELECT cuenta.id, cuenta.tipo, cuenta.saldo, cuenta.departamento, persona.nombre, persona.apellido
                    FROM cuenta
                    INNER JOIN persona ON cuenta.persona_id = persona.id;";

            $result = $conexion->query($sql);

            if ($result->num_rows > 0) {
                // Mostrar cada cuenta bancaria
                while($row = $result->fetch_assoc()) {
                    echo "<div class='account'>";
                    echo "<h3>{$row['tipo']}</h3>";
                    echo "<p>Cuenta: {$row['id']}</p>";
                    echo "<p>Titular: {$row['nombre']} {$row['apellido']}</p>";
                    echo "<p>Saldo: {$row['saldo']} Bs</p>";
                    echo "<p>Departamento: {$row['departamento']}</p>";
                    echo "</div>";
                }
            } else {
                echo "<p class='no-accounts'>No se encontraron cuentas bancarias.</p>";
            }

            // Cerrar la conexión
            $conexion->close();
            ?>
        </div>
    </main>

    <footer class="footer">
        <div class="container">
            &copy; <?php echo date("Y"); ?> Realizado por Univ. Sara Abigail Vargas Blanco.
        </div>
    </footer>
</body>
</html>