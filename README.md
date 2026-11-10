PROYECTO INTEGRADOR - DÍA 1: ANÁLISIS DEL PROBLEMA

1. Identificación del problema:
Un cine requiere digitalizar su proceso de administración de asientos para evitar errores humanos, sobreventas de boletos y conflictos de reservaciones duplicadas. El sistema debe permitir gestionar de manera ordenada los espacios de la sala.

2. Identificación de Entradas, Procesos y Salidas:
- Entradas: 
  * Opción del menú principal seleccionada por el usuario (número entero).
  * Coordenadas de fila y columna para reservar, liberar o consultar (números enteros).
- Procesos: 
  * Validación de límites de la matriz para evitar desbordamientos.
  * Verificación del estado previo del asiento (libre u ocupado).
  * Conteo automatizado de las celdas ocupadas y disponibles.
  * Cálculo matemático del porcentaje de ocupación total de la sala.
- Salidas: 
  * Representación visual actualizada de la matriz de asientos en consola ([O] / [X]).
  * Mensajes de confirmación, éxito o error en las operaciones.
  * Reporte estadístico detallado de la sala.

3. Alcance y Limitaciones:
- Alcance: Gestión lógica completa de una sala estática configurada por código mediante arreglos bidimensionales en entorno de consola.
- Limitaciones: No incluye persistencia en bases de datos externas ni pasarela de pagos en línea en esta fase.

4. Justificación de la Estructura de Datos:
Se utiliza una matriz bidimensional (bool[,]) porque mapea de forma directa e intuitiva la distribución física de una sala de cine organizada en filas y butacas, permitiendo un acceso directo a cualquier posición mediante sus coordenadas (i, j).
