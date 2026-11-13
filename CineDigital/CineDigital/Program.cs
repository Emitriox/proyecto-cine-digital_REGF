using System;

class Program
{
    // Dimensiones de la sala del cine (5 filas x 6 columnas)
    const int FILAS = 5;
    const int COLUMNAS = 6;

    // Matriz bidimensional: false = Libre ('O'), true = Ocupado ('X')
    static bool[,] asientos = new bool[FILAS, COLUMNAS];

    static void Main(string[] args)
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("   SISTEMA DE ADMINISTRACIÓN DE CINE     ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Mostrar matriz de asientos");
            Console.WriteLine("2. Reservar asiento");
            Console.WriteLine("3. Liberar asiento");
            Console.WriteLine("4. Consultar disponibilidad individual (Día 5)");
            Console.WriteLine("5. Ver estadísticas y ocupación (Día 6)");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MostrarAsientos();
                        break;
                    case 2:
                        ReservarAsiento();
                        break;
                    case 3:
                        LiberarAsiento();
                        break;
                    case 4:
                        ConsultarDisponibilidadIndividual(); // Integrado del Día 5
                        break;
                    case 5:
                        MostrarEstadisticas(); // Integrado del Día 6
                        break;
                    case 6:
                        Console.WriteLine("\n¡Gracias por utilizar el sistema!");
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada no numérica.");
            }

            if (opcion != 6)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }

    // ==========================================
    // MÓDULO DE CAPTURA Y VISUALIZACIÓN (Día 4)
    // ==========================================
    static void MostrarAsientos()
    {
        Console.WriteLine("\n--- MAPA DE LA SALA DE CINE ---");
        Console.WriteLine("Leyenda: [O] Libre  |  [X] Ocupado\n");

        Console.Write("   ");
        for (int j = 0; j < COLUMNAS; j++)
        {
            Console.Write($" C{j + 1} ");
        }
        Console.WriteLine();

        for (int i = 0; i < FILAS; i++)
        {
            Console.Write($"F{i + 1} ");
            for (int j = 0; j < COLUMNAS; j++)
            {
                Console.Write(asientos[i, j] ? " [X] " : " [O] ");
            }
            Console.WriteLine();
        }
    }

    static void ReservarAsiento()
    {
        MostrarAsientos();
        Console.WriteLine("\n--- RESERVAR ASIENTO ---");
        int f = LeerEntero("Ingrese la fila (1 a " + FILAS + "): ") - 1;
        int c = LeerEntero("Ingrese la columna (1 a " + COLUMNAS + "): ") - 1;

        if (ValidarCoordenadas(f, c))
        {
            if (!asientos[f, c])
            {
                asientos[f, c] = true;
                Console.WriteLine($"\n[Éxito] Asiento Fila {f + 1}, Columna {c + 1} reservado.");
            }
            else
            {
                Console.WriteLine($"\n[Aviso] El asiento Fila {f + 1}, Columna {c + 1} ya está OCUPADO.");
            }
        }
        else
        {
            Console.WriteLine("\n[Error] Coordenadas fuera de rango.");
        }
    }

    static void LiberarAsiento()
    {
        MostrarAsientos();
        Console.WriteLine("\n--- LIBERAR ASIENTO ---");
        int f = LeerEntero("Ingrese la fila (1 a " + FILAS + "): ") - 1;
        int c = LeerEntero("Ingrese la columna (1 a " + COLUMNAS + "): ") - 1;

        if (ValidarCoordenadas(f, c))
        {
            if (asientos[f, c])
            {
                asientos[f, c] = false;
                Console.WriteLine($"\n[Éxito] Asiento Fila {f + 1}, Columna {c + 1} liberado.");
            }
            else
            {
                Console.WriteLine($"\n[Aviso] El asiento ya estaba LIBRE.");
            }
        }
        else
        {
            Console.WriteLine("\n[Error] Coordenadas fuera de rango.");
        }
    }

    // ==========================================
    // MÓDULO DE CONSULTAS (Día 5)
    // ==========================================
    static void ConsultarDisponibilidadIndividual()
    {
        Console.WriteLine("\n--- CONSULTAR DISPONIBILIDAD ---");
        int f = LeerEntero("Ingrese la fila (1 a " + FILAS + "): ") - 1;
        int c = LeerEntero("Ingrese la columna (1 a " + COLUMNAS + "): ") - 1;

        if (ValidarCoordenadas(f, c))
        {
            if (asientos[f, c])
            {
                Console.WriteLine($"\nEl asiento Fila {f + 1}, Columna {c + 1} está: OCUPADO [X]");
            }
            else
            {
                Console.WriteLine($"\nEl asiento Fila {f + 1}, Columna {c + 1} está: DISPONIBLE [O]");
            }
        }
        else
        {
            Console.WriteLine("\n[Error] Coordenadas fuera de rango.");
        }
    }

    // ==========================================
    // MÓDULO DE ESTADÍSTICAS (Día 6)
    // ==========================================
    static void MostrarEstadisticas()
    {
        int totalAsientos = FILAS * COLUMNAS;
        int ocupados = 0;

        for (int i = 0; i < FILAS; i++)
        {
            for (int j = 0; j < COLUMNAS; j++)
            {
                if (asientos[i, j])
                {
                    ocupados++;
                }
            }
        }

        int disponibles = totalAsientos - ocupados;
        double porcentajeOcupacion = ((double)ocupados / totalAsientos) * 100;

        Console.WriteLine("\n--- ESTADÍSTICAS DE LA SALA ---");
        Console.WriteLine($"* Total de asientos: {totalAsientos}");
        Console.WriteLine($"* Asientos ocupados: {ocupados}");
        Console.WriteLine($"* Asientos disponibles: {disponibles}");
        Console.WriteLine($"* Porcentaje de ocupación: {porcentajeOcupacion:F2}%");
    }

    // ==========================================
    // MÉTODOS AUXILIARES Y VALIDACIONES
    // ==========================================
    static bool ValidarCoordenadas(int f, int c)
    {
        return f >= 0 && f < FILAS && c >= 0 && c < COLUMNAS;
    }

    static int LeerEntero(string mensaje)
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                return numero;
            }
            Console.WriteLine("[Error] Entrada inválida. Ingrese un número entero.");
        }
    }
}