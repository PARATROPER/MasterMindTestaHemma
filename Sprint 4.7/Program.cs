const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:
Console.OutputEncoding = System.Text.Encoding.UTF8;
Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // definierar variabeln plupp som en plupp till konsolen genom \u2B24



char[] facit = { 'B', 'O', 'O', 'B' };   // fördefinierad rad för facit, den slumpas alltså inte av metoden RattRad.


while (true)
{
    Console.WriteLine("Skriv 'Q' = Quit, 'FACIT' = rätt svar");
    Console.Write("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
    
    string gissningInput = Console.ReadLine().ToUpper();
    Rad facitStruct = new Rad(facit);

    if (gissningInput == "Q")
    {
        break;
    }
    else if (gissningInput == "FACIT")
    {
        Console.Write("Facit är:");
        facitStruct.PrintRad();
        continue;
    }

    char[] tillatna = { 'R', 'O', 'Y', 'G', 'B', 'P' };
    if (!gissningInput.All(c => tillatna.Contains(c)) || gissningInput.Length != 4)
    {
        Console.WriteLine("Använd exakt 4 tillåtna tecken: R,O,Y,G,B,P \n");
        continue;
    }    

    char[] gissningArray = gissningInput.ToCharArray();
    Rad gissningStruct = new Rad(gissningArray);


    if (gissningStruct.KontrolleraFarg(0, facit[0]))   // om användarens input på index 0 == facits index 0 
    {

        Console.WriteLine("Din gissning är RÄTT ");
        gissningStruct.PrintRad();

    }
    else
    {
        Console.WriteLine("Din gissning är FEL");
    }
    
}


char[] RattRad(Random random)
{
    char[] colors = { 'R', 'O', 'Y', 'G', 'B', 'P' }; // En array för att definiera färgerna vi valt
    char[] randomColor = new char[4];

    for (int i = 0; i < randomColor.Length; i++)
    {
        int index = random.Next(0, colors.Length);
        randomColor[i] = colors[index];
    }
    return randomColor;
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


}
