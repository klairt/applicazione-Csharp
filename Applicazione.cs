using System;
using System.IO; //per la lettura del file 

class Program
{

    string NomeFile="Comune_Bergamo_-_Numerazione_civica.csv";

    //funzione che inserisce un nuovo indirizzo InsertDati 
    bool InsertDati(string classe, string descrizione, string numero, string subalterno, string CAP, string ISTAT, double lng, double lat)
    {
        //l'idea è quella di creare un nuovo file ogni volta che si inseriscono i dati, per poi farsì che il file originale Comune_Bergamo_-_Numerazione_civica.csv venga eliminato e il file file_copia.csv lo sostituisca
        string fileCopia="file_copia.csv";


        //try e catch funzionano come IF ELSE
        try
        {
            //apre il file originale in lettura e quello copia in scrittura
            using (StreamReader read=new StreamReader(NomeFile))
            using (StreamWriter write=new StreamWriter(fileCopia))
            {
                string line;

                //copia riga per riga il contenuto del file originale nella copia finché non raggiunge non trova null (ovvero fino all'ultima riga)
                while ((line=read.ReadLine())!=null)
                {
                    write.WriteLine(line);
                }

                //aggiunge in fondo la nuova riga con i dati inseriti dall'utente
                write.WriteLine($"{classe},{descrizione},{numero},{subalterno},{CAP},{ISTAT},{lng},{lat},");

                /*L'USO DI $ serve per evitare di scrivere una catena di variabili tutti uniti dal +
                ESEMPIO: classe+ "," + descrizione etc...
                Entrambi i modi sono uguali*/

            }

            //elimina il file originale e rinomina la copia con il nome originale
            File.Delete(NomeFile);
            File.Move(fileCopia, NomeFile);

            return true;
        }
        catch (Exception)
        {
            //se qualcosa va storto (es. file non trovato) ritorna false
            return false;
        }
    }

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

            //dato che con ReadLine legge solo stringe, con la funzione int.Parse l'input viene convertito in intero  
            scelta=int.Parse(Console.ReadLine());
            

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
                    lng=double.Parse(Console.ReadLine());
                    Console.Write("Inserire la latitudine: ");
                    lat=double.Parse(Console.ReadLine());

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
}
