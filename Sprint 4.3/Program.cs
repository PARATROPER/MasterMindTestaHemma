// Mastermind color mapping to ConsoleColor
// r = red (ConsoleColor.Red)
// o = orange (ConsoleColor.DarkYellow)
// y = yellow (ConsoleColor.Yellow)
// g = green (ConsoleColor.Green)
// b = blue (ConsoleColor.Blue)
// p = purple (ConsoleColor.Magenta)

//inmatning = Console.ReadLine.Trim().ToUpper()             VID ANVÄNDARINPUT för att undvika felmeddelande


const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:


Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.

char[] facit = RattRad(random);                             // skapar en NY char-array genom att anropa RattRad-metoden med 
foreach (char c in facit)
{
    PrintFarg(c);
    
}

Console.WriteLine("\nKLAR!");


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
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            break;

        case 'Y':
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;

        case 'G':
            Console.ForegroundColor= ConsoleColor.Green;
            break;

        case 'B':
            Console.ForegroundColor= ConsoleColor.Blue;
            break;

        case 'P':
            Console.ForegroundColor = ConsoleColor.Magenta;
            break;
    }

    Console.Write($" {farg}");  // skriver ut varje char med rätt färg + ett mellanrum mellan bokstäverna
    Console.ResetColor(); // Behövs detta eftersom vi har konstanten i metoden?.... verkar så

}








// Console.ForegroundColor = CONSOLE_FORGRUND;                 // Konstanten tillämpas i metoder: