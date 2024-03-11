using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lavadora3000
{
    internal class Lavadora
    {
        //private string nombreTipoRopa;
        private int ropaKilos;
        private int tiempoLavado;
        private List<string> tiposDeRopa;
        private static int clientesAtendidos = 0;


        //Constructor 
        public Lavadora(List<string> tiposDeRopa, int ropaKilos, int tiempoLavado) {

            this.tiposDeRopa = tiposDeRopa;
            this.ropaKilos = ropaKilos;
            this.tiempoLavado = tiempoLavado;
        }

        public Lavadora() { }



        private int RopaKilos
        {
            get { return ropaKilos; }
            set { ropaKilos = value; }
        }

        private int TiempoLavado
        {
            get { return tiempoLavado; }
            set { tiempoLavado = value; }
        }

        private List<string> TiposDeRopa
        {
            get { return tiposDeRopa; }
            set { tiposDeRopa = value; }
        }

        private static int ClientesAtendidos
        {
            get { return clientesAtendidos; }
        }


        public override string ToString()
        {
            string tiposRopaString = (tiposDeRopa != null && tiposDeRopa.Any()) ? string.Join(", ", tiposDeRopa) : "Ninguno";
            return $"Ropa en kilos: {ropaKilos}, Tiempo de lavado: {tiempoLavado} minutos, Tipos de ropa: {tiposRopaString}";
        }

        private void iniciandoLavadora()
        {
            // se mostrara el mensaje caracterxcarater con un retraso entre cada letra
            //Console.ForegroundColor = ConsoleColor.Green; 
            //Console.WriteLine("Encendiendo lavadora...");
            //Console.ResetColor(); 
            SoundPlayer player = new SoundPlayer(@"C:\Users\juane\OneDrive\Desktop\sonidos\encendido.wav"); // Ruta del archivo de sonido
            player.Play();

            foreach (char letra in "Encendiendo lavadora...\n")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(letra);
                Console.ResetColor();
                Thread.Sleep(100);
            }

        }

        private void ingresoDatos()
        {
            Console.WriteLine("\n----------------------------------------------------\n");

            bool entradaValida = false;

            do
            {
                Console.WriteLine("Ingrese los kilos de ropa a lavar: ");
                string input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Por favor, ingrese un valor.");
                }
                else if (!int.TryParse(input, out ropaKilos))
                {
                    Console.WriteLine("Por favor, ingrese un valor numérico.");
                }
                else if (ropaKilos < 10 || ropaKilos > 30)
                {
                    Console.WriteLine("Ingrese los kilos correctos, MIN 10/MAX 30");
                }
                else
                {
                    entradaValida = true;
                }
            } while (!entradaValida);

        }




        //Lista para almacenar los tipos de ropa
        private List<string> listaTipoRopa()
        {

            Console.WriteLine("\n----------------------------------------------------\n");
            List<string> tiposDeRopa = new List<string>();

            Console.WriteLine("Ingrese los tipos de ropa a lavar, escriba 'fin' para terminar");

            string tipoRopa;
            do
            {
                tipoRopa = Console.ReadLine().Trim();

                if (tipoRopa.ToLower() != "fin")
                {
                    tiposDeRopa.Add(tipoRopa);
                }
            }
            while (tipoRopa.ToLower() != "fin");

            Console.WriteLine("Recomendaciones de Lavado!");
            Console.WriteLine("1. Agua fría (hasta 20 º): se recomienda para ropa de colores, algodón, lycra, sedas, prendas delicadas y telas que puedan achicarse.");
            Console.WriteLine("2 Agua tibia (entre 30 a 50º): se recomienda para jeans, camperas, ropa muy sucia o poco delicada.");
            Console.WriteLine("3. Agua caliente (entre 55 a 90º): se recomienda para toallas, sábanas o acolchados, telas blancas gruesas y cortinas de tela.");

            foreach (string tipo in tiposDeRopa)
            {
                Console.WriteLine($"Para '{tipo}', la opción de lavado recomendada es:");
                if (tipo.Contains("algodon") || tipo.Contains("lycra") || tipo.Contains("sedas") || tipo.Contains("prendas delicadas"))
                {
                    Console.WriteLine("SE RECOMIENDA: Agua fría (hasta 20 º)");
                }
                else if (tipo.Contains("jeans") || tipo.Contains("camperas") || tipo.Contains("ropa muy sucia"))
                {
                    Console.WriteLine("SE RECOMIENDA: Agua tibia (entre 30 a 50º)");
                }
                else if (tipo.Contains("toallas") || tipo.Contains("sabanas") || tipo.Contains("acolchados") || tipo.Contains("telas blancas gruesas") || tipo.Contains("cortinas de tela"))
                {
                    Console.WriteLine("SE RECOMIENDA: Agua caliente (entre 55 a 90º)");
                }
                else
                {
                    Console.WriteLine("No hay recomendación específica para este tipo de ropa.");
                }
            }

            

            return tiposDeRopa;
        }


        //Metodo llenado
        private void llenadoAgua()
        {

            SoundPlayer playerAgua = new SoundPlayer(@"C:\Users\juane\OneDrive\Desktop\sonidos\llenado.wav"); // Ruta del archivo de sonido
            playerAgua.Play();
            for (int i = 0; i < 7; i++)
            {
                

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Llenando...");
                Thread.Sleep(500);
                Console.SetCursorPosition(Console.CursorLeft - "Llenando...".Length, Console.CursorTop);
                Thread.Sleep(500);

            }
            Console.WriteLine("Llenado completado.");
            Console.ResetColor();
        }

        //Metodo lavado
        private void lavado()
        {

            Console.WriteLine("\n----------------------------------------------------\n");

            Console.WriteLine("¿La ropa está muy sucia? (SI/NO)");
            string respuestaRopaS = Console.ReadLine().ToLower();

            if (respuestaRopaS == "si")
            {
                Console.WriteLine("Ingrese el tiempo de lavado en minutos:");
                if (int.TryParse(Console.ReadLine(), out int tiempo))
                {
                    if (tiempo > 0)
                    {
                        tiempoLavado = tiempo;
                        Console.WriteLine($"Tiempo de lavado fijado en {tiempoLavado} minutos.");
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese un valor de tiempo de lavado válido (mayor que 0).");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un valor numérico para el tiempo de lavado.");
                }
            }
            else if (respuestaRopaS == "no")
            {
                tiempoLavado = 30;
                Console.WriteLine("Tiempo fijado para lavado general.");

            }
            else
            {
                Console.WriteLine("Respuesta no reconocida. Por favor, ingrese 'SI' o 'NO'.");
            }

            SoundPlayer playerLavando = new SoundPlayer(@"C:\Users\juane\OneDrive\Desktop\sonidos\lavado.wav"); // Ruta del archivo de sonido
            playerLavando.Play();
            for (int i = 0; i < 7; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Lavando...");
                Thread.Sleep(500);
                Console.SetCursorPosition(Console.CursorLeft - "Lavando...".Length, Console.CursorTop);
                Thread.Sleep(500);

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lavado Completado.");
            Console.ResetColor();

        }


        //Metodo enjuague y secado
        private void enjuagueYSecado()
        {
            SoundPlayer playerEnjuague = new SoundPlayer(@"C:\Users\juane\OneDrive\Desktop\sonidos\lavado.wav"); // Ruta del archivo de sonido
            playerEnjuague.Play();
            for (int i = 0; i < 7; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enjuagando Ropa...");
                Thread.Sleep(500);
                //Console.SetCursorPosition(Console.CursorLeft - "Enjuagando Ropa...Enjuagando Ropa...".Length, Console.CursorTop);
                Thread.Sleep(500);

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ropa Enjuagada!.");
            Console.ResetColor();

            // Preguntamos al usuario si desea secar o detener
            string respuesta="";
            bool secadoEnCurso = false; // Variable para controlar si el secado está en curso

            do
            {
                if (!secadoEnCurso)
                {
                    Console.WriteLine("Desea seguir con el proceso de secado? SI/NO ");
                    respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "si")
                    {
                        secadoEnCurso = true; // Indicamos que el secado está en curso
                        SoundPlayer playerSecado = new SoundPlayer(@"C:\Users\juane\OneDrive\Desktop\sonidos\secado.wav"); // Ruta del archivo de sonido
                        playerSecado.Play();
                        for (int i = 0; i < 7; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Secando Ropa... Secando Ropa...");
                            Thread.Sleep(500);
                            //Console.SetCursorPosition(Console.CursorLeft - "Enjuagando Ropa...Enjuagando Ropa...".Length, Console.CursorTop);
                            Thread.Sleep(500);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Secado terminado!");
                        Console.ResetColor();
                        secadoEnCurso = false; // Indicamos que el secado ha terminado
                    }
                    else if (respuesta == "no")
                    {
                        Console.WriteLine("Proceso pausado, ingrese 'R' para reanudar el proceso");
                        string reanudar = Console.ReadLine().ToLower();

                        while (reanudar != "r")
                        {
                            Console.WriteLine("Opción no válida. Por favor, ingrese 'R' para reanudar el proceso");
                            reanudar = Console.ReadLine().ToLower();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Respuesta no válida. Por favor, ingrese 'SI' o 'NO'.");
                    }
                }
                else
                {
                    // Si el secado está en curso, no solicitamos respuesta, sino que continuamos con el secado
                    for (int i = 0; i < 7; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Secando Ropa...");
                        Thread.Sleep(500);
                        Console.SetCursorPosition(Console.CursorLeft - "Secando Ropa...".Length, Console.CursorTop);
                        Thread.Sleep(500);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Secado Completado.");
                    Console.ResetColor();
                    secadoEnCurso = false; // Indicamos que el secado ha terminado
                }
            } while (respuesta != "si");


            //Sonido
            SoundPlayer playerTerminado = new SoundPlayer(@"C:\Users\juane\OneDrive\Desktop\sonidos\terminado.wav");
            playerTerminado.Play();
            foreach (char letra in "Lavado terminado...\n")
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(letra);
                Console.ResetColor();
                Thread.Sleep(100);
            }


        }

        //Metodo ciclo terminao, disponible para importar
        public static void lavadoTerminado()
        {
            bool continuar = true;
            
            // while para agregar mas lavados o finalizar
            while (continuar)
            {
                // Creamos una instancia de Lavadora
                Lavadora lavadora = new Lavadora();

                // Se llaman todos los metodos
                lavadora.iniciandoLavadora();
                lavadora.ingresoDatos();
                List<string> tiposDeRopa = lavadora.listaTipoRopa(); // Almacenamos los tipos de ropa ingresados
                lavadora.llenadoAgua();
                lavadora.lavado();
                lavadora.enjuagueYSecado();

                // Creamos una nueva instancia de Lavadora pasando los tipos de ropa ingresados como argumento al constructor
                Lavadora lavada1 = new Lavadora(tiposDeRopa, lavadora.RopaKilos, lavadora.TiempoLavado);

                // se muestran los datos para ver si se estan almacenando
                Console.WriteLine(lavada1.ToString());

                Console.WriteLine("Ingrese el nombre del cliente");
                string cliente = Console.ReadLine();
                lavada1.Facturacion(cliente);

                clientesAtendidos++;

                
                Console.WriteLine("¿Desea ingresar otro registro? (SI/NO)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta != "si")
                {
                    continuar = false;
                }

                Console.WriteLine($"Total de clientes atendidos: {ClientesAtendidos}");
            }
        }



            private void Facturacion(string nombreCliente)
        {

            Console.WriteLine("\n----------------------------------------------------\n");

            double costoPorKilo = 4000;

            
            if (tiposDeRopa.Any(tipo => tipo.Contains("color") || tipo.Contains("algodon")))
            {
                costoPorKilo *= 1.05;
            }


            double costoLavado = RopaKilos * costoPorKilo;
            double costoTotalCliente = costoLavado * 1.19;
            double gananciaDueño = costoLavado * 0.3;
            double totalDinero = costoLavado + gananciaDueño;

            // EL costo de 60min es 516.72
            double costoKwh = 516.72;
            double tiempoEnHoras = (tiempoLavado / 60.0) * costoKwh;


            Console.WriteLine($"Costo de la energía eléctrica consumida: ${tiempoEnHoras}");


            // Impresion de los resultados
            Console.WriteLine($"Nombre del cliente: {nombreCliente}");
            Console.WriteLine($"Fecha y hora del lavado: {DateTime.Now}");
            Console.WriteLine($"Costo de lavar {RopaKilos} kilos de ropa: ${costoLavado}");
            Console.WriteLine($"Tiempo de lavado: {tiempoLavado} Minutos");
            Console.WriteLine($"Costo total de lavado para el cliente (IVA incluido): ${costoTotalCliente}");
            Console.WriteLine($"Ganancia del dueño: ${gananciaDueño}");
            Console.WriteLine($"Total de dinero realizado en la operación de lavado: ${totalDinero}");
            

            Console.WriteLine();

            
        }

    }
}
