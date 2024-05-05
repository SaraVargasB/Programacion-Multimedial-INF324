<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Datos Recibidos</title>
</head>
<body>
    <h1>Datos Recibidos:</h1>
    <?php
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $nombre = $_POST["nombre"];
        $edad = $_POST["edad"];
        echo "<p>Nombre: $nombre</p>";
        echo "<p>Edad: $edad</p>";
    }
    ?>
</body>
</html>
