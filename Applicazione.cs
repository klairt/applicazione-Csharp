using System;

class Program
{   
    //dichiarazione main
    static void main()
    {
        int scelta;

        do
        {
            //struttura a menù
            Console.WriteLine("1 - Inserimento di un nuovo record");
            Console.WriteLine("2 - Visualizzazione dei file");
            Console.WriteLine("3 - Modifica di un record");
            Console.WriteLine("4 - Cancellazione di un record");
            Console.WriteLine();
            Console.Write("Scegliere una funzione: ");

            //dato che con ReadLine legge solo stringe, con la funzione int.Parse l'input viene convertito in intero  
            scelta = int.Parse(Console.ReadLine());
            

            switch (scelta)
            {
                case 1:
                    // Inserimento
                    break;

                case 2:
                    // Visualizzazione
                    break;

                case 3:
                    // Modifica
                    break;

                case 4:
                    // Cancellazione
                    break;

                default:
                    Console.WriteLine("\nOpzione non valida.\n");
                    break;
            }

        } while (scelta != 0);
    }
}
