-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-06-2024 a las 16:26:26
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdsaraimagenes`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `texturas`
--

CREATE TABLE `texturas` (
  `id` int(11) NOT NULL,
  `colororigen` varchar(20) DEFAULT NULL,
  `cR_origen` int(11) DEFAULT NULL,
  `cG_origen` int(11) DEFAULT NULL,
  `cB_origen` int(11) DEFAULT NULL,
  `cR_destino` int(11) DEFAULT NULL,
  `cG_destino` int(11) DEFAULT NULL,
  `cB_destino` int(11) DEFAULT NULL,
  `colordestino` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `texturas`
--

INSERT INTO `texturas` (`id`, `colororigen`, `cR_origen`, `cG_origen`, `cB_origen`, `cR_destino`, `cG_destino`, `cB_destino`, `colordestino`) VALUES
(1, 'Rojo', 255, 51, 64, 255, 0, 0, 'Rojo Claro'),
(2, 'Blanco', 255, 255, 255, 192, 192, 192, 'Silver'),
(3, 'Negro', 0, 0, 0, 85, 79, 79, 'Negro Claro'),
(4, 'Cafe Oscuro', 49, 32, 23, 210, 105, 30, 'Chocolate'),
(5, 'Cafe Claro', 209, 133, 49, 188, 143, 143, 'Rosa Marrón'),
(6, 'Menta', 170, 207, 163, 154, 205, 50, 'Amarillo verde'),
(7, 'Verde Oscuro', 42, 90, 21, 128, 128, 0, 'Oliva'),
(8, 'Gris Oscuro', 70, 70, 70, 220, 220, 220, 'Gris Claro'),
(9, 'Blanco celeste', 224, 246, 255, 245, 222, 179, 'Color trigo'),
(10, 'Rosado piel', 187, 141, 118, 238, 130, 238, 'Violeta'),
(11, 'Blanco plomo', 240, 243, 236, 255, 235, 205, 'Almendra blanqueada'),
(12, 'Negro Gris', 28, 23, 25, 25, 25, 112, 'Azul Noche'),
(13, 'Marron oscuro', 103, 95, 83, 210, 180, 140, 'Chocolate caliente'),
(14, 'Plomo azul', 126, 149, 167, 244, 164, 96, 'Arena marrón'),
(15, 'Gris claro', 207, 198, 192, 205, 133, 63, 'Naranja oscuro'),
(16, 'Blanco oscuro', 181, 203, 216, 255, 255, 255, 'Blanco'),
(17, 'Azul Cielo', 101, 125, 149, 135, 206, 250, 'Azul cielo claro'),
(18, 'Negro oscuro', 30, 31, 38, 105, 105, 105, 'Gris Oscuro'),
(19, 'Negro opaco', 180, 164, 26, 47, 79, 79, 'Oscuro pizarra gris'),
(20, 'Semi Gris', 233, 233, 230, 128, 128, 128, 'Gris'),
(21, 'Marrón claro', 232, 186, 38, 160, 82, 45, 'Café Tierra'),
(22, 'Verde oscuro opaco', 84, 108, 84, 46, 139, 87, 'Verde mar'),
(23, 'Marrón muy claro', 117, 63, 19, 210, 180, 140, 'Marrón amarillento'),
(24, 'Marrón cálido', 134, 104, 29, 245, 222, 179, 'Trigo'),
(25, 'Verde oscuro', 28, 67, 29, 144, 238, 144, 'Verde claro'),
(26, 'Verde pasto', 143, 193, 48, 152, 251, 152, 'Verde palido'),
(27, 'Rosado opaco', 144, 144, 133, 255, 222, 173, 'Beige anaranjado'),
(28, 'Marrón oscuro', 22, 18, 16, 0, 0, 0, 'Negro'),
(29, 'Plomo claro', 177, 183, 185, 211, 211, 211, 'Gris muy claro'),
(30, 'Rosado piel', 143, 97, 85, 230, 230, 250, 'Lavanda'),
(31, 'Blanco gris', 238, 228, 209, 255, 255, 255, 'Blanco'),
(32, 'Blanco amarillento', 223, 179, 131, 255, 255, 255, 'Blanco');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `texturas`
--
ALTER TABLE `texturas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `texturas`
--
ALTER TABLE `texturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
