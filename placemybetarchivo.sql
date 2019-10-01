-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-10-2019 a las 23:15:09
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybetarchivo`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuestas`
--

CREATE TABLE `apuestas` (
  `ID` int(15) NOT NULL,
  `tipo` varchar(25) DEFAULT NULL,
  `cuota` decimal(8,2) DEFAULT NULL,
  `apostado` decimal(8,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `apuestas`
--

INSERT INTO `apuestas` (`ID`, `tipo`, `cuota`, `apostado`) VALUES
(1, 'goles', '2.15', '10.36'),
(2, 'goles', '1.36', '5.23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE `cuentas` (
  `tarjeta` int(16) NOT NULL,
  `saldo` int(25) DEFAULT NULL,
  `banco` varchar(25) DEFAULT NULL,
  `correo_usuario` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cuentas`
--

INSERT INTO `cuentas` (`tarjeta`, `saldo`, `banco`, `correo_usuario`) VALUES
(63216545, 50, 'la caixa', 'algo2@gmail.com'),
(451210232, 200, 'sabadell', 'algo@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE `eventos` (
  `ID` int(15) NOT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `equipoLocal` varchar(25) DEFAULT NULL,
  `equipoVisitante` varchar(25) DEFAULT NULL,
  `ID_mercado` int(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`ID`, `fecha`, `hora`, `equipoLocal`, `equipoVisitante`, `ID_mercado`) VALUES
(1, '2019-10-09', '20:15:00', 'valencia', 'madrid', 1),
(2, '2019-10-16', '15:00:00', 'madrid', 'valencia', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercado`
--

CREATE TABLE `mercado` (
  `ID` int(16) NOT NULL,
  `tipo` varchar(25) DEFAULT NULL,
  `cuotaOver` decimal(8,2) DEFAULT NULL,
  `cuotaUnder` decimal(8,2) DEFAULT NULL,
  `apostadoOver` decimal(8,2) DEFAULT NULL,
  `apostadoUnder` decimal(8,2) DEFAULT NULL,
  `ID_apuesta` int(16) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `mercado`
--

INSERT INTO `mercado` (`ID`, `tipo`, `cuotaOver`, `cuotaUnder`, `apostadoOver`, `apostadoUnder`, `ID_apuesta`) VALUES
(1, 'goles', '2.12', '5.36', '4.20', '0.00', 1),
(2, 'goles', '4.23', '7.50', '0.00', '4.25', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `correo` varchar(25) NOT NULL,
  `edad` int(3) DEFAULT NULL,
  `nombre` varchar(25) DEFAULT NULL,
  `apellido` varchar(25) DEFAULT NULL,
  `ID_apuestas` int(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`correo`, `edad`, `nombre`, `apellido`, `ID_apuestas`) VALUES
('algo2@gmail.com', 25, 'pepe', 'tum', 2),
('algo@gmail.com', 23, 'juanito', 'san', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD PRIMARY KEY (`tarjeta`),
  ADD KEY `correo_usuario` (`correo_usuario`);

--
-- Indices de la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_mercado` (`ID_mercado`);

--
-- Indices de la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_apuesta` (`ID_apuesta`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`correo`),
  ADD KEY `ID_apuestas` (`ID_apuestas`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  MODIFY `ID` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `ID` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `mercado`
--
ALTER TABLE `mercado`
  MODIFY `ID` int(16) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `cuentas_fk1` FOREIGN KEY (`correo_usuario`) REFERENCES `usuarios` (`correo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD CONSTRAINT `eventos_fk1` FOREIGN KEY (`ID_mercado`) REFERENCES `mercado` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD CONSTRAINT `mercado_fk1` FOREIGN KEY (`ID_apuesta`) REFERENCES `apuestas` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_fk1` FOREIGN KEY (`ID_apuestas`) REFERENCES `apuestas` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
