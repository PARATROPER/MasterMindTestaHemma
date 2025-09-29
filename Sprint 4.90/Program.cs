const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:
Console.OutputEncoding = System.Text.Encoding.UTF8;
Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // definierar variabeln plupp som en plupp till konsolen genom \u2B24


char[] facit = { 'B', 'Y', 'Y', 'B' };                    //RattRad(random);
Rad facitStruct = new Rad(facit);


Console.WriteLine("Skriv 'Q' = Quit, 'F' = Facit, 'H' = Hjälp");
Console.WriteLine("\nAnge din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");


while (true)
{

    //bool gissningRatt = true;
    Console.Write("Ange ny gissning: \t");
    string gissningInput = Console.ReadLine().ToUpper();


    if (gissningInput == "Q")
    {
        break;
    }
    else if (gissningInput == "F")
    {
        Console.Write("Facit är:");
        facitStruct.PrintRad();
        continue;
    }
    else if (gissningInput == "H")
    {
        Console.WriteLine("Skriv 'Q' = Quit, 'F' = Facit, 'H' = Hjälp");
        Console.Write("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
        continue;
    }

    //validera input
    char[] tillatna = { 'R', 'O', 'Y', 'G', 'B', 'P' };
    if (!gissningInput.All(c => tillatna.Contains(c)) || gissningInput.Length != 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nOBS OBS OBS\nAnvänd exakt 4 tillåtna tecken: R,O,Y,G,B,P \n");
        Console.ResetColor();

        continue;
    }



    //Är det här jag ska lägga en for loop som räknar upp från 1-->12?
    char[] gissningArray = gissningInput.ToCharArray();
    Rad gissningStruct = new Rad(gissningArray);


    int[] rattning = new int[4];  //En array för att lagra 0=fel färg, 1=fel plats,rätt färg, 2=rätt plats,rätt färg.
    bool[] facitBool = new bool[4]; //En array för att lagra true/false om en bokstav använts.

    for (int i = 0; i < 4; i++)
    {
        if (gissningArray[i] == facit[i])
        {
            rattning[i] = 1;
            facitBool[i] = true;
        }
    }

    for (int i = 0; i < 4; i++)
    {
        if (rattning[i] != 1)
        {
            for (int x = 0; x < 4; x++)
            {
                if (gissningArray[i] == rattning[i] && facitBool[i] == false)
                {
                    rattning[i] = 2;
                    facitBool[i] = true;
                    break;

                }
                else
                {
                    rattning[i] = 0;
                }


            }
        }

    }


    for (int i = 0; i < 4; i++)// skriv ut feedback till spelaren
    {
        switch (rattning[i])
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\u2B24Position {i + 1}: Rätt färg på rätt plats");
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\u2B24Position {i + 1}: Rätt färg men fel plats");
                break;

            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\u2B24Position {i + 1}: Fel färg");
                break;
        }
        Console.ResetColor();
    }


    if (rattning.All(x => x == 1))
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Grattis du har vunnit spelet!\n");
        facitStruct.PrintRad();
        Console.ResetColor();
        Console.WriteLine($"Den rätta raden = {facitStruct.HamtaRad()}");

        Console.WriteLine("\n\nTryck på Enter 2ggr för att avsluta spelet");
        Console.ReadKey();
        break;

    }

}


char[] RattRad(Random random)
{
    char[] colors = { 'R', 'O', 'Y', 'G', 'B', 'P' }; // En array för att definiera färgerna vi valt
    char[] facit = new char[4];

    for (int i = 0; i < facit.Length; i++)
    {
        int index = random.Next(0, colors.Length);
        facit[i] = colors[index];
    }
    return facit;
}


struct Rad          // Vi ska ha metoder i struct
{
    char[] farger;

    public Rad(char[] input)
    {

        farger = input;
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

        Console.Write("\u2B24"); // skriver ut plupp
        Console.ResetColor(); // reset color

    }

    public void PrintRad()
    {
        for (int i = 0; i < farger.Length; i++)
        {
            PrintFarg(i);
        }
        Console.WriteLine(" ");
    }

    public bool KontrolleraFarg(int position, char bokstav)
    {
        if (farger[position] == bokstav)
        {

            return true;
        }
        else
        {
            return false;

        }
    }

    /* public bool PrintAndCheckRow(Rad RattRad)
     {
         PrintRad(); //skriver ut raden med rätt färg
         if (HamtaRad() == RattRad.HamtaRad())           //Detta kan skrivas på en rad??? För en bool är antingen true eller false.
         {
             return true;
         }
         else
         {
             Console.WriteLine("Raden är fel, försök igen");
             return false;
         }

     }                          _______________ Är Överflödig nu, men sparar ________________*/

    public string HamtaRad()                //hämtar användarens input för att kunna göra en utskrift i slutet av spelet.
    {
        return new string(farger);
    }

}
