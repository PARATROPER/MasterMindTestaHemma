const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:
Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.




while (true)
{
    Console.WriteLine("\nHej och välkommen till spelet Mastermind:\nDu kommer kunna använda 'quit'/'fusk'/'hjälp'");
    Console.Write("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
    string gissning = Console.ReadLine().ToUpper();
    char[] gissningArray = gissning.ToCharArray();
    char[] facit = RattRad(random);

    if (gissning == "QUIT")
    {
        return;
    }
    if (gissning == "HJÄLP")
    {
        Console.WriteLine("Du kommer få hjälp snart");
        return;
    }
    if (gissning == "FUSK")
    {
        Console.WriteLine("\nRätt rad är:");
        foreach (char c in facit)
        {
            PrintFarg(c);
        }
    }

    else
    {
        Console.WriteLine("Din gissning:");
        foreach (char p in gissningArray)
        {
            PrintFarg(p);
        }

        
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

void PrintFarg(char farg)
{
    Console.ForegroundColor = CONSOLE_FORGRUND;                 // Konstanten tillämpas i metoder:

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



// Console.WriteLine("\nKLAR!");