using System;
using System.IO; //per la lettura del file 

class Program
{


    //dichiarazione main
    static void Main()
    {
        //dichiarazione variabili
        int scelta;

        do
        {


            //struttura a menù
            Console.WriteLine("1 - Inserimento di un nuovo record\n2 - Visualizzazione dei file\n3 - Modifica di un record\n4 - Cancellazione di un record\n");
            Console.Write("Scegliere una funzione: ");

            //dato che con ReadLine legge solo stringe, con la funzione Covert l'input viene convertito in intero  
            //COVERT UTILIZZATI: Covert.ToInt32, Convert.ToDouble, Convert.ToString
            scelta= Convert.ToInt32(Console.ReadLine()); 
            

            switch (scelta)
            {
                case 0:
                    // Ferma programma
                    break;
                case 1:

                    //variabili
                    string classe, descrizione, numero, subalterno, CAP, ISTAT;
                    double lng, lat;

                    // Inserimento
                    Console.Write("\nInserire la classe: ");
                    classe=Console.ReadLine();
                    Console.Write("Inserire la descrizione: ");
                    descrizione=Console.ReadLine();
                    Console.Write("Inserire il numero: ");
                    numero=Console.ReadLine();
                    Console.Write("Inserire il subalterno: ");
                    subalterno=Console.ReadLine();
                    Console.Write("Inserire il CAP: ");
                    CAP=Console.ReadLine();
                    Console.Write("Inserire il ISTAT: ");
                    ISTAT=Console.ReadLine();
                    Console.Write("Inserire la longitudine: ");
                    lng=Convert.ToDouble(Console.ReadLine());
                    Console.Write("Inserire la latitudine: ");
                    lat=Convert.ToDouble(Console.ReadLine());

                    //variabile che controlla se l'inserimento è andato a buon fine
                    bool esito=InsertDati(classe, descrizione, numero, subalterno, CAP, ISTAT, lng, lat);

                    if(!esito)
                    {
                        Console.WriteLine("\nErrore nell'apertura del file.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nI dati sono stati inseriti correttamente!\n");
                    }

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

        } while (scelta!=0);
    }   


//FUNZIONI
    
//INSERTDATI
//funzione che inserisce un nuovo indirizzo
    static bool InsertDati(string classe, string descrizione, string numero, string subalterno, string CAP, string ISTAT, double lng, double lat)
    {
        //l'idea è quella di creare un nuovo file ogni volta che si inseriscono i dati, per poi farsì che il file originale Comune_Bergamo_-_Numerazione_civica.csv venga eliminato e il file file_copia.csv lo sostituisca
        
        // IF FILE NON ESISTE, RITORNA FALSO, ELSE ESEGUE I COMANDI
        if(File.Exists("Comune_Bergamo_-_Numerazione_civica.csv")==false)
        {
            //se il file non esiste ritorna false
            return false;
        }else
        {
            //apre il file originale in lettura e quello copia in scrittura
            StreamReader lettura=new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
            StreamWriter scrittura=new StreamWriter("file_copia.csv");
            {
                string riga;

                //copia riga per riga il contenuto del file originale nella copia finché non raggiunge non trova null (ovvero fino all'ultima riga)
                while ((riga=lettura.ReadLine())!=null)
                {
                    scrittura.WriteLine(riga);
                }

                //aggiunge in fondo la nuova riga con i dati inseriti dall'utente
                scrittura.WriteLine($"{classe},{descrizione},{numero},{subalterno},{CAP},{ISTAT},{lng},{lat},");

                /*L'USO DI $ serve per evitare di scrivere una catena di variabili tutti uniti dal +
                ESEMPIO: classe+ "," + descrizione etc...
                Entrambi i modi sono uguali*/

            }

            //elimina il file originale e rinomina la copia con il nome originale
            File.Delete("Comune_Bergamo_-_Numerazione_civica.csv");
            File.Move("file_copia.csv", "Comune_Bergamo_-_Numerazione_civica.csv");

            return true;
        }
    }

}
