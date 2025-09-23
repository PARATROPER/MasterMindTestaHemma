const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:
Console.OutputEncoding = System.Text.Encoding.UTF8;
Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // definierar variabeln plupp som en plupp till konsolen genom \u2B24




Console.Write("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
string gissning = Console.ReadLine().ToUpper();
char[] gissningArray = gissning.ToCharArray();
char[] facit = RattRad(random);                             // skapar en NY char-array genom att anropa RattRad-metoden med 

Console.WriteLine("Din gissning:");
foreach (char p in gissningArray)
{
    PrintFarg(p);
}

Console.WriteLine("\nRätt rad är:");
foreach (char c in facit)
{
    PrintFarg(c);
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
 
    Console.Write($" {plupp}");  // skriver ut varje char med rätt färg + ett mellanrum mellan bokstäverna
    Console.ResetColor(); // Behövs detta eftersom vi har konstanten i metoden?.... verkar så

}




struct Rad          // Vi ska ha metoder i struct
{

}




