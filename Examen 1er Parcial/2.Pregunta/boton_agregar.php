<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de Cuentas Bancarias</title>
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
    <main class="container">
        <h2 class="subtitle">Lista de Cuentas Bancarias</h2>
        <div class="account-list">
<body>
    Agregar Persona y Cuenta Bancaria <br>
    <form action="agregar.php" method="post">
        <label for="ci">CI:</label>
        <input type="text" id="ci" name="ci" required><br><br>
        <label for="nombre">Nombre:</label>
        <input type="text" id="nombre" name="nombre" required><br><br>
        <label for="apellido">Apellido:</label>
        <input type="text" id="apellido" name="apellido" required><br><br>
        <label for="edad">Edad:</label>
        <input type="number" id="edad" name="edad" required><br><br>
        <label for="direccion">Dirección:</label>
        <input type="text" id="direccion" name="direccion" required><br><br>
        <label for="psw">Contraseña:</label>
        <input type="password" id="psw" name="psw" required><br><br>
        <label for="rol_id">Rol:</label>
        <select name="rol_id" id="rol_id" required>
            <option value="">Seleccione un rol</option>
            <option value="1">Admin</option>
            <option value="2">Director Bancario</option>
            <option value="3">Cliente</option>
        </select><br><br>

        <label for="tipo">Tipo:</label>
        <select name="tipo" id="tipo" required>
            <option value="">Seleccione el tipo</option>
            <option value="cuenta de ahorros">cuenta de ahorros</option>
            <option value="cuenta corriente">cuenta corriente</option>
            <option value="cuenta de inversion">cuenta de inversion</option>
        </select><br><br>

        <label for="saldo">Saldo:</label>
        <input type="number" id="saldo" name="saldo" required><br><br>

        <label for="departamento">Departamento:</label>
         <select name="departamento" id="departamento" required>

            <option value="la paz">la paz</option>
            <option value="oruro">oruro</option>
            <option value="potosi">potosi</option>
            <option value="beni">beni</option>
            <option value="chuquisaca">chuquisaca</option>
            <option value="tarija">tarija</option>
            <option value="santa cruz">santa cruz</option>
            <option value="cochabamba">cochabamba</option>
            <option value="pando">pando</option>

        </select><br><br>    
        <button type="submit">Agregar</button>
        <button onclick="window.location.href='index.php'">Menu</button>

    </form>

       </div>
    </main>
</body>
</html>