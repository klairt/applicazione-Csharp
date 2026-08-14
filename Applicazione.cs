using System;
using System.IO; //per la lettura del file
using System.Globalization; //per la conversione corretta dei numeri decimali. ESEMPIO: se noi scriviamo 23,400 il programma lo legge come 23400. Con questa libreria, evitiamo questo problema

//classe che rappresenta un singolo record del file CSV
class NumCivica
{
    public string classe;
    public string descrizione;
    public string numero;
    public string subalterno;
    public string CAP;
    public string ISTAT;
    public double lng;
    public double lat;
}

class Program
{
    //dichiarazione main
    static void Main()
    {
        //dichiarazione variabili
        int scelta;

        //array che conterrà i dati caricati dal file 
        NumCivica[] dati=new NumCivica[1000];
        for (int i=0;i<dati.Length;i++)
        {
            dati[i]=new NumCivica();
        }

        //tiene traccia di quante righe sono state effettivamente caricate dal file
        int righeCaricate = 0;

        do
        {
            //struttura a menù
            Console.WriteLine("1 - Inserimento di un nuovo record\n2 - Visualizzazione dei file\n3 - Modifica di un record\n4 - Cancellazione di un record\n");
            Console.Write("Scegliere una funzione: ");

            //dato che con ReadLine legge solo stringe, con la funzione Covert l'input viene convertito in intero
            //COVERT UTILIZZATI: Covert.ToInt32, Convert.ToDouble, Convert.ToString
            scelta = Convert.ToInt32(Console.ReadLine());

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

                    if (!esito)
                    {
                        Console.WriteLine("\nErrore nell'apertura del file.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nI dati sono stati inseriti correttamente!\n");
                    }

                    break;

                case 2:
                    // Caricamento + Visualizzazione

                    /*

                    */
                    if (CaricaDati(dati, dati.Length, out righeCaricate))
                    {
                        Console.WriteLine($"\nDati caricati: {righeCaricate} righe\n");
                        Console.WriteLine(VisualizzaDati(dati, righeCaricate));
                    }
                    else
                    {
                        Console.WriteLine("\nErrore nell'apertura del file.\n");
                    }
                    break;

                case 3:
                    // Modifica

                    /*FUNZIONAMENTO
                    1) Chiedo all'utente la descrizione e il numero civico da cercare
                    2) Richiamo la funzione Search che mi restituisce la posizione
                    3) Se la posizione è -1, stampo "Elemento non trovato"
                    4) Altrimenti chiedo all'utente i nuovi dati da inserire
                    5) Richiamo la funzione UpdateDati che riscrive il file con i dati modificati
                    6) Se l'esito è true, stampo "Modifica effettuata con successo", altrimenti stampo "Errore nella modifica"
                    */


                    Console.Write("\nInserire descrizione da cercare: ");
                    string d=Console.ReadLine();
                    Console.Write("Inserire il numero civico da modificare: ");
                    string n=Console.ReadLine();
                    int posizione=Search(d, n);
 
                    if (posizione==-1)
                    {
                        Console.WriteLine("\nElemento non trovato.\n");
                    }
                    else
                    {
                    
                        string classe1, descrizione1, numero1, subalterno1, CAP1, ISTAT1;
                        double lng1, lat1;
 
                        Console.Write("\nInserire nuova classe: ");
                        classe1 = Console.ReadLine();
                        Console.Write("Inserire la nuova descrizione: ");
                        descrizione1 = Console.ReadLine();
                        Console.Write("Inserire il nuovo numero: ");
                        numero1 = Console.ReadLine();
                        Console.Write("Inserire il nuovo subalterno: ");
                        subalterno1 = Console.ReadLine();
                        Console.Write("Inserire il nuovo CAP: ");
                        CAP1 = Console.ReadLine();
                        Console.Write("Inserire il nuovo ISTAT: ");
                        ISTAT1 = Console.ReadLine();
                        Console.Write("Inserire la nuova longitudine: ");
                        lng1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Inserire la nuova latitudine: ");
                        lat1 = Convert.ToDouble(Console.ReadLine());
 
                        
                        bool esito1=UpdateDati(posizione, classe1, descrizione1, numero1, subalterno1, CAP1, ISTAT1, lng1, lat1);
 
                        if (esito1)
                        {
                            Console.WriteLine("\nModifica effettuata con successo!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nErrore nella modifica.\n");
                        }
                    }
                    break;

                   case 4:
                    // Cancellazione
 
                    /*FUNZIONAMENTO
                    1) Chiedo all'utente la descrizione e il numero civico da cercare
                    2) Richiamo la funzione Search che mi restituisce la posizione
                    3) Se la posizione è -1, stampo "Elemento non trovato"
                    4) Altrimenti richiamo DeleteDati che riscrive il file senza quella riga
                    5) Se l'esito è true, stampo "Cancellazione avvenuta", altrimenti stampo "Errore nella cancellazione"
                    */
 
                    Console.Write("\nInserire descrizione da cercare: ");
                    string d2=Console.ReadLine();
                    Console.Write("Inserire il numero civico da cancellare: ");
                    string n2=Console.ReadLine();
                    int posizione2=Search(d2, n2);
 
                    if (posizione2==-1)
                    {
                        Console.WriteLine("\nElemento non trovato.\n");
                    }
                    else
                    {
                        bool esito2=DeleteDati(posizione2);
 
                        if (esito2)
                        {
                            Console.WriteLine("\nCancellazione avvenuta con successo!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nErrore nella cancellazione.\n");
                        }
                    }
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
        if (File.Exists("Comune_Bergamo_-_Numerazione_civica.csv") == false)
        {
            //se il file non esiste ritorna false
            return false;
        }
        else
        {
            //apre il file originale in lettura e quello copia in scrittura
            StreamReader lettura = new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
            StreamWriter scrittura = new StreamWriter("file_copia.csv");
            {
                string riga;

                //copia riga per riga il contenuto del file originale nella copia finché non trova null (ovvero fino all'ultima riga)
                while ((riga = lettura.ReadLine()) != null)
                {
                    scrittura.WriteLine(riga);
                }

                //aggiunge in fondo la nuova riga con i dati inseriti dall'utente
                scrittura.WriteLine($"{classe},{descrizione},{numero},{subalterno},{CAP},{ISTAT},{lng},{lat}");

                /*L'USO DI $ serve per evitare di scrivere una catena di variabili tutti uniti dal +
                ESEMPIO: classe+ "," + descrizione etc...
                Entrambi i modi sono uguali*/
            }

            //chiude esplicitamente i file prima di eliminare/rinominare
            lettura.Close();
            scrittura.Close();

            //elimina il file originale e rinomina la copia con il nome originale
            File.Delete("Comune_Bergamo_-_Numerazione_civica.csv");
            File.Move("file_copia.csv", "Comune_Bergamo_-_Numerazione_civica.csv");

            return true;
        }
    }

    //CARICADATI
    //funzione che carica i dati dal file CSV nell'array v
    //righeTot è la dimensione massima dell'array, righeCaricate (out) è quante righe sono state lette davvero per evotare che vengano stampate righe vuote
    static bool CaricaDati(NumCivica[] v, int righeTot, out int righeCaricate)
    {
        righeCaricate = 0;

        //se il file non esiste ritorna false
        if (!File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
        {
            return false;
        }

        StreamReader lettura = new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");

        //salta la riga di intestazione, come getline(leggi, riga) in C++
        lettura.ReadLine();

        int i = 0;
        string riga;

        //legge finché ci sono righe disponibili e non si supera la dimensione dell'array
        while (i<righeTot && (riga = lettura.ReadLine())!=null)
        {
            //se la riga è vuota la saltiamo (es. riga vuota finale nel file)
            if (riga.Trim() == "")
            {
                continue;
            }

            //divide la riga nei singoli campi separati da virgola nel file csv
            string[] campi = riga.Split(',');

            v[i].classe=campi[0];
            v[i].descrizione=campi[1];
            v[i].numero=campi[2];
            v[i].subalterno=campi[3];
            v[i].CAP=campi[4];
            v[i].ISTAT=campi[5];

            //InvariantCulture assicura che il punto venga sempre letto come separatore decimale e non intero
            v[i].lng=Convert.ToDouble(campi[6], CultureInfo.InvariantCulture);
            v[i].lat=Convert.ToDouble(campi[7], CultureInfo.InvariantCulture);

            i++;
        }

        righeCaricate=i;
        lettura.Close();
        return true;
    }

    //VISUALIZZADATI
    //funzione che costruisce la stringa con tutti i dati da mostrare a video
    static string VisualizzaDati(NumCivica[] v, int righeCaricate)
    {
        //STRUTTRA MOLTO SIMILE A C++
        string s = "";
        for (int i = 0; i < righeCaricate; i++)
        {
            s+=v[i].classe + "\t";
            s+=v[i].descrizione + "\t";
            s+=v[i].numero + "\t";
            s+=v[i].subalterno + "\t";
            s+=v[i].CAP + "\t";
            s+=v[i].ISTAT + "\t";
            s+=v[i].lng + "\t";
            s+=v[i].lat + "\n";
        }
        return s;
    }

     //SEARCH
    //funzione che cerca un record nel file CSV in base alla descrizione e al numero
    static int Search(string descrizione, string numero)
    {
        //se il file non esiste non posso cercare niente
        if (!File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
        {
            return -1;
        }
 
        StreamReader lettura=new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
 
        //salto la riga di intestazione
        lettura.ReadLine();
 
        string line;
        int i=0;
 
        //leggo tutte le righe fino alla fine del file
        while ((line=lettura.ReadLine()) != null)
        {
            string[] campi = line.Split(',');
            string desc = campi[1];
            string num = campi[2];
 
            //controllo che corrispondano a quello che sto cercando
            if (desc == descrizione && num == numero)
            {
                lettura.Close();
                //restituisco la posizione (0 = prima riga di dati dopo l'intestazione)
                return i;
            }
 
            i++;
        }
 
        lettura.Close();
        //se non trovo nulla restituisco -1
        return -1;
    }
 
    //UpdateDati
    //funzione che modifica i dati di un record esistente
    static bool UpdateDati(int posizione, string classe, string descrizione, string numero, string subalterno, string CAP, string ISTAT, double lng, double lat)
    {
        if (!File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
        {
            return false;
        }
 
        //Molto simile a InsertDati, ma invece di aggiungere una riga in fondo, sostituisce la riga alla posizione specificata
        StreamReader lettura=new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
        StreamWriter scrittura=new StreamWriter("file_copia.csv");
 
    
        string line = lettura.ReadLine();
        scrittura.WriteLine(line);
 
        int i=0;
 
        //leggo tutte le righe fino alla fine del file
        while ((line=lettura.ReadLine())!=null)
        {
            if (i == posizione)
            {
                //quando trovo la riga da modificare, scrivo quella nuova al suo posto
                scrittura.WriteLine($"{classe},{descrizione},{numero},{subalterno},{CAP},{ISTAT},{lng},{lat}");
            }
            else
            {
                
                scrittura.WriteLine(line);
            }
 
            i++;
        }
 
        lettura.Close();
        scrittura.Close();
 
        //elimino il file originale e rinomino la copia con il nome originale
        File.Delete("Comune_Bergamo_-_Numerazione_civica.csv");
        File.Move("file_copia.csv", "Comune_Bergamo_-_Numerazione_civica.csv");
 
        return true;
    }


    //DeleteDati
    //funzione che elimina il record alla posizione indicata
    static bool DeleteDati(int posizione)
    {
        if (!File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
        {
            return false;
        }
 
        //Molto simile a UpdateDati, ma invece di sostituire la riga trovata, la salto (non la riscrivo)
        StreamReader lettura=new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
        StreamWriter scrittura=new StreamWriter("file_copia.csv");
 
        //salto/riscrivo l'intestazione
        string line = lettura.ReadLine();
        scrittura.WriteLine(line);
 
        int i=0;
 
        //leggo tutte le righe fino alla fine del file
        while ((line=lettura.ReadLine())!=null)
        {
            //finché non trovo la riga da eliminare la copio, quella da eliminare la salto e basta
            if (i!=posizione)
            {
                scrittura.WriteLine(line);
            }
 
            i++;
        }
 
        lettura.Close();
        scrittura.Close();
 
        //elimino il file originale e rinomino la copia con il nome originale
        File.Delete("Comune_Bergamo_-_Numerazione_civica.csv");
        File.Move("file_copia.csv", "Comune_Bergamo_-_Numerazione_civica.csv");
 
        return true;
    }
 
}
