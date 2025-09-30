const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå enligt Dag.
// test push vid 12:10
Console.OutputEncoding = System.Text.Encoding.UTF8; // Behövs för att kunna skriva ut pluppar (Unicode-symboler)
Random random = new Random();   // Skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // Möjliggör utskrivt av en plupp i konsollen.

// char[] facit = { 'R', 'R', 'B', 'P' }; OM JAG VILL HA EN FÖRDEFINIERAD RAD.
char[] facit = RattRad(random);  // Skapa en array och slumpa värden för färger, facit som spelaren ska gissa.

Rad facitStruct = new Rad(facit);    // Gör om char arrayen till ett Rad-objekt(Instans?) för att kunna använda metoderna.
Rad[] allaGissningar = new Rad[12];  // Array med plats för alla 12 potentiella gissningar

Console.WriteLine("___  ___          _                      _           _ \r\n|  \\/  |         | |                    (_)         | |\r\n| .  . | __ _ ___| |_ ___ _ __ _ __ ___  _ _ __   __| |\r\n| |\\/| |/ _` / __| __/ _ \\ '__| '_ ` _ \\| | '_ \\ / _` |\r\n| |  | | (_| \\__ \\ ||  __/ |  | | | | | | | | | | (_| |\r\n\\_|  |_/\\__,_|___/\\__\\___|_|  |_| |_| |_|_|_| |_|\\__,_|\r\n                                                       \r\n                                                       ");
Console.WriteLine("Skriv 'Q' = Quit, 'F' = Facit, 'H' = Hjälp");
Console.WriteLine("\nAnge din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");

bool SpeletKor = true;   // Bestämmer om spelet körs eller ska avslutas
int antalForsok = 0;     // Räknare för antal gissningar användaren gjort

while (SpeletKor == true)
{
    string gissningInput = Console.ReadLine().ToUpper();    //Läser in användarens gissning och gör om till VERSALER.

    if (gissningInput == "Q")
    {
        break;
    } //Q = avbryter speler
    else if (gissningInput == "F")
    {
        Console.Write("Facit är:");
        facitStruct.PrintRad();
        continue;
    } // F = Visar facit
    else if (gissningInput == "H")
    {
        Console.WriteLine("Skriv 'Q' = Quit, 'F' = Facit, 'H' = Hjälp");
        Console.Write("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
        continue;
    } // H för att få se hjälp-alternativen


    char[] tillatna = { 'R', 'O', 'Y', 'G', 'B', 'P' };
    if (!gissningInput.All(c => tillatna.Contains(c)) || gissningInput.Length != 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("OBS OBS OBS\nAnvänd exakt 4 tillåtna tecken: R,O,Y,G,B,P");
        Console.ResetColor();
        continue;
    } //validerar input till R,O,Y,G,B,P & max 4 tecken

    // Gör om gissningen till en Rad och lagrar den i historiken --> OBSOBSOBS
    char[] gissningArray = gissningInput.ToCharArray();  // Gör om string gissningInput till en char-array
    Rad gissningStruct = new Rad(gissningArray);    // Skapar ny instans av.....??? OBS_OBS_OBS_ Hur formulerar jag detta?
    allaGissningar[antalForsok] = gissningStruct;
    antalForsok++;      //Ökar räknaren för varje gissning 

    int[] rattning = gissningStruct.KontrolleraRad(facitStruct); //Rättar Raden mot facit och får tillbaka int-array med resultat.
    Console.Clear();
    Console.WriteLine($"Försök {antalForsok}/12 - R,O,Y,G,B,P"); //Skriver ut vilket försök användern är på

    for (int i = 0; i < antalForsok; i++)
    {
        allaGissningar[i].PrintAllaGissningarPlusFeedback(facitStruct);
        Console.WriteLine(); // radbrytning mellan gissningarna
    } //Skriver ut alla föregående gissningar + feedback om rätt plats/färg

    if (rattning.All(x => x == 1))
    {
        Console.Clear();
        Console.WriteLine("___  ___          _                      _           _ \r\n|  \\/  |         | |                    (_)         | |\r\n| .  . | __ _ ___| |_ ___ _ __ _ __ ___  _ _ __   __| |\r\n| |\\/| |/ _` / __| __/ _ \\ '__| '_ ` _ \\| | '_ \\ / _` |\r\n| |  | | (_| \\__ \\ ||  __/ |  | | | | | | | | | | (_| |\r\n\\_|  |_/\\__,_|___/\\__\\___|_|  |_| |_| |_|_|_| |_|\\__,_|\r\n                                                       \r\n                                                       ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Grattis du har vunnit spelet!\n");
        facitStruct.PrintRad();
        Console.ResetColor();
        Console.WriteLine($"\nDen rätta raden = {facitStruct.HamtaRad()}");

        Console.WriteLine("\n\nTryck på Enter 2ggr för att avsluta spelet");
        Console.ReadKey();//Använder .ALL-metoden istället för att loopa igenom array och kolla om alla värden är 1.
        break;
    }// Om alla pluppar är rätt (alla = 1) --> spelaren vinner

    if (antalForsok == 12)
    {
        SpeletKor = false;
        Console.Clear();
        Console.WriteLine("Du har förlorat spelet, maxantal gissningar uppnått");
        Console.Write("Rätt rad va: ");
        facitStruct.PrintRad();
        Console.WriteLine("\nTryck på Enter 2ggr för att avsluta spelet! ");
        Console.ReadKey();
        break;
    } //Om användaren når 12 gissninar utan att vinna avbryts spelet och en förlusttext skrivs ut

}



char[] RattRad(Random random)
{
    char[] colors = { 'R', 'O', 'Y', 'G', 'B', 'P' }; // En array för att definiera spelets färger.
    char[] facit = new char[4];

    for (int i = 0; i < facit.Length; i++)
    {
        int index = random.Next(0, colors.Length);
        facit[i] = colors[index];
    }
    return facit;
} //Slumpar fram en rad till facit med 4 färger.


struct Rad     // Struct för att representera en rad i spelet (en gissning eller facit) // "Vi ska ha metoder i struct"
{
    char[] farger;

    public Rad(char[] input)
    {

        farger = input;    // Tar emot en array och sparar lokalt i structen
    }



    public void PrintFarg(int position)
    {

        char bokstav = farger[position];

        switch (bokstav)
        {
            case 'R':
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case 'O':
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;

            case 'Y':
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case 'G':
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case 'B':
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

            case 'P':
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
        }

        Console.Write("\u2B24 "); // skriver ut plupp
        Console.ResetColor(); // reset color

    } //Skriver ut plupp i rätt färg kopplat till ROYGBP

    public void PrintRad()
    {
        for (int i = 0; i < farger.Length; i++)
        {
            PrintFarg(i);
        }
        //Console.WriteLine(" ");
    }  // Skriver ut en hel rad... 

    public string HamtaRad()
    {
        return new string(farger);
    } // returnerar en string av facit-raden, för utskrift.

    public void PrintAllaGissningarPlusFeedback(Rad facit)
    {
        int[] rattning = KontrolleraRad(facit);

        PrintRad();
        Console.Write(" --> ");

        int antalRoda = 0;
        int antalVita = 0;

        foreach (int item in rattning)
        {
            if (item == 1)
            {
                antalRoda++;
            }
            else if (item == 2)
            {
                antalVita++;
            }
        }

        for (int i = 0; i < antalVita; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('\u2B24');
            Console.ResetColor();
        }
        for (int i = 0; i < antalRoda; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('\u2B24');
            Console.ResetColor();
        }
    }

    public int[] KontrolleraRad(Rad facit)
    {
        int[] rattning = new int[4];  //En array för att lagra 0=fel färg, 1=fel plats, rätt färg, 2=rätt plats, rätt färg.
        bool[] facitBool = new bool[4]; //True = använd, False = ej använd
        for (int i = 0; i < 4; i++)
        {
            if (farger[i] == facit.farger[i])
            {
                rattning[i] = 1;
                facitBool[i] = true;
            }
        }// Loopar igenom för att se om rätt färg är på rätt plats.

        for (int i = 0; i < rattning.Length; i++)
        {
            if (rattning[i] != 1) // Hoppa över om färgen redan var rätt på rätt plats i tidigare forloop.
            {

                for (int x = 0; x < rattning.Length; x++)
                {
                    if (farger[i] == facit.farger[x] && facitBool[x] == false)  //OBS
                    {
                        rattning[i] = 2;
                        facitBool[x] = true; //Kollar på om just den platsen i facit har blivit matchad. Chatten
                        break;
                    }
                }
            }

        }// Loopar igenom en andra gång för att lagra true/false om en bokstav använts.
        return rattning;
    }  // Returnerar en array som beskriver rättningen (0 = fel färg, 1 = rätt plats, 2 = rätt färg fel plats)
       // Metod för att kunna kontrollera/rätta raden gentemot facit. 
    public void PrintFargText(char farg)   // Vill använda för att färga bokstäverna till respektiva färg i slutet av spelet.
    {

        switch (farg)
        {
            case 'R':
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case 'O':
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;

            case 'Y':
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case 'G':
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case 'B':
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

            case 'P':
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
        }

        Console.Write($" {farg}");  // skriver ut varje char med rätt färg + ett mellanrum mellan bokstäverna
        Console.ResetColor(); // Behövs detta eftersom vi har konstanten i metoden?.... verkar så

    }
}




