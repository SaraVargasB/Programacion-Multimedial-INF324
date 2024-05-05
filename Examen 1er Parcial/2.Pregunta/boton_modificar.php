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
        <ul>
            <?php while ($fila = mysqli_fetch_assoc($resultado_personas_cuentas)) { ?>
                <li>
                    <strong>ID:</strong> <?php echo $fila['cuenta_id']; ?>,
                    <strong>CI:</strong> <?php echo $fila['ci']; ?>,
                    <strong>Nombre:</strong> <?php echo $fila['nombre']; ?> <?php echo $fila['apellido']; ?>,
                    <strong>Tipo:</strong> <?php echo $fila['tipo']; ?>,
                    <strong>Saldo:</strong> <?php echo $fila['saldo']; ?>,
                    <strong>Departamento:</strong> <?php echo $fila['departamento']; ?>, <!-- Nuevo campo -->
                    <a href="?id=<?php echo $fila['cuenta_id']; ?>">Modificar</a>
                </li>
            <?php } ?>
        </ul>
    <?php } ?>
</body>
</html>
