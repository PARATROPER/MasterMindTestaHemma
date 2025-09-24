const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:
Console.OutputEncoding = System.Text.Encoding.UTF8;
Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // definierar variabeln plupp som en plupp till konsolen genom \u2B24


//TEST - pushade kod 2025-09-24 kl 22:47

char[] facit = RattRad(random);
Console.WriteLine("Skriv 'Q' = Quit, 'F' = Facit, 'H' = Hjälp");
Console.WriteLine("\nAnge din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
while (true)
{
    bool gissningRatt = true;
    Console.Write("Ange ny gissning: \t");

    string gissningInput = Console.ReadLine().ToUpper();
    Rad facitStruct = new Rad(facit);

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

    char[] tillatna = { 'R', 'O', 'Y', 'G', 'B', 'P' };
    if (!gissningInput.All(c => tillatna.Contains(c)) || gissningInput.Length != 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nOBS OBS OBS\nAnvänd exakt 4 tillåtna tecken: R,O,Y,G,B,P \n");
        Console.ResetColor();
        continue;
    }

    char[] gissningArray = gissningInput.ToCharArray();
    Rad gissningStruct = new Rad(gissningArray);

    for (int i = 0; i < gissningArray.Length; i++)              //Går igenom gissningarray och kontrollerar färg gentemot facitStruct
    {
        if (facitStruct.KontrolleraFarg(i, gissningArray[i]))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rätt på plats {i + 1}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Fel på plats {i + 1}");
            Console.ResetColor();
            gissningRatt = false;
        }
    }
    if (gissningRatt)
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

    public string HamtaRad()                //hämtar användarens input för att kunna göra en utskrift i slutet av spelet.
    {
        return new string(farger);
    }

}
