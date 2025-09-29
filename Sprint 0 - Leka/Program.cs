using System.Reflection;

const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå
Console.OutputEncoding = System.Text.Encoding.UTF8; // Behövs för att kunna skriva ut pluppar
Random random = new Random();   // Skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // Möjliggör utskrivt av en plupp i konsollen.


char[] facit = RattRad(random);      // Skapa en array och slumpa värden. 
Rad facitStruct = new Rad(facit);    // Vad gör denna egentligen?

Rad[] allaGissningar = new Rad[12];  //Skapa en array med plats för alla 12 potentiella gissningar


Console.WriteLine("Skriv 'Q' = Quit, 'F' = Facit, 'H' = Hjälp");
Console.WriteLine("\nAnge din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");

bool SpeletKor = true;
int antalForsok = 0;

while (SpeletKor == true)
{
    string gissningInput = Console.ReadLine().ToUpper();

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
        Console.WriteLine("\nOBS OBS OBS\nAnvänd exakt 4 tillåtna tecken: R,O,Y,G,B,P \n");
        Console.ResetColor();
        continue;
    } //validerar input till ROYGBP & max 4 tecken


    char[] gissningArray = gissningInput.ToCharArray();  // Gör om gissningInput från en string till en array
    Rad gissningStruct = new Rad(gissningArray);    // Skapar ny instans av.....??? OBS_OBS_OBS_ Hur formulerar jag detta?
    allaGissningar[antalForsok] = gissningStruct;
    antalForsok++;

    int[] rattning = new int[4];  //En array för att lagra 0=fel färg, 1=fel plats, rätt färg, 2=rätt plats, rätt färg.
    bool[] facitBool = new bool[4]; //True = använd, False = ej använd

    for (int i = 0; i < 4; i++)
    {
        if (gissningArray[i] == facit[i])
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
                if (gissningArray[i] == facit[x] && facitBool[x] == false)  //OBS
                {
                    rattning[i] = 2;
                    facitBool[x] = true; //Kollar om på om just den platsen i facit har blivit matchad. Chatten
                    break;
                }
                else  //Överflödigt?
                {
                    rattning[i] = 0;
                }
            }
        }

    } //Loopar igenom en andra gång för att lagra true/false om en bokstav använts.

    Console.WriteLine("\nAnge ny gissning: \t");
    antalForsok++;   //räkna upp efter varje giltig gissning
    Console.Write($"Försök {antalForsok}/12 ");
    gissningStruct.PrintRad();
    Console.Write(" --> ");



    for (int i = 0; i < rattning.Length; i++)
    {
        switch (rattning[i])
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Red; //Rätt färg på rätt plats
                Console.Write("\u2B24");
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\u2B24"); //Rätt färg men fel plats
                break;

            default:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\u2B24"); //Finns inte eller är redan konsumerad
                break;
        }
        Console.ResetColor();
    }// skriv ut feedback till spelaren

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
    }//Använder .ALL-metoden istället för att loopa igenom array och kolla om alla värden är 1.

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
    } //Om användaren når 12 gissninar avbryts spelet och en förlusttext skrivs ut

    //}

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
//Slumpar fram en rätt rad till facit.


struct Rad          // "Vi ska ha metoder i struct"
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

    } //Skriver ut plupp i rätt färg kopplat till ROYGBP

    public void PrintRad()
    {
        for (int i = 0; i < farger.Length; i++)
        {
            PrintFarg(i);
        }
        //Console.WriteLine(" ");
    }  // Skriver ut en Rad... Kan jag återanvända den för att skriva ut gissningarna? Kan jag spara dom i någon array eller typ matris?

    public string HamtaRad()                //hämtar användarens input för att kunna göra en utskrift i slutet av spelet.
    {
        return new string(farger);
    }


    //public void PrintAllaGissningarPlusFeedback(Rad facit)
    //{
    //    int[] rattning = new int[4];  //En array för att lagra 0=fel färg, 1=fel plats, rätt färg, 2=rätt plats, rätt färg.
    //    bool[] facitBool = new bool[4]; //True = använd, False = ej använd


    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (farger[i] == facit.farger[i])
    //        {
    //            rattning[i] = 1;
    //            facitBool[i] = true;
    //        }
    //    }// Loopar igenom för att se om rätt färg är på rätt plats.

    //    for (int i = 0; i < rattning.Length; i++)
    //    {
    //        if (rattning[i] != 1) // Hoppa över om färgen redan var rätt på rätt plats i tidigare forloop.
    //        {

    //            for (int x = 0; x < rattning.Length; x++)
    //            {
    //                if (farger[i] == facit.farger[x] && facitBool[x] == false)  //OBS
    //                {
    //                    rattning[i] = 2;
    //                    facitBool[x] = true; //Kollar om på om just den platsen i facit har blivit matchad. Chatten
    //                    break;
    //                }
    //                else  //Överflödigt?
    //                {
    //                    rattning[i] = 0;
    //                }
    //            }
    //        }

    //    }// Loopar igenom en andra gång för att lagra true/false om en bokstav använts.

    //    PrintRad();
    //    Console.Write(" --> ");

    //    for (int i = 0; i < rattning.Length; i++)
    //    {
    //        switch (rattning[i])
    //        {
    //            case 1:
    //                Console.ForegroundColor = ConsoleColor.Red; //Rätt färg på rätt plats
    //                Console.Write("\u2B24");
    //                break;

    //            case 2:
    //                Console.ForegroundColor = ConsoleColor.White;
    //                Console.Write("\u2B24"); //Rätt färg men fel plats
    //                break;

    //            default:
    //                Console.ForegroundColor = ConsoleColor.DarkGray;
    //                Console.Write("\u2B24"); //Finns inte eller är redan konsumerad
    //                break;
    //        }
    //        Console.ResetColor();
    //    }// skriv ut feedback till spelaren
    //}

}
