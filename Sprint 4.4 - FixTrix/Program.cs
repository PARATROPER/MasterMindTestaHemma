const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:


Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.

char[] facit = RattRad(random);                             // skapar en NY char-array genom att anropa RattRad-metoden med 
foreach (char c in facit)
{
    PrintFarg(c);

}



string gissning = TaInput();                                        //OBS OBS OBS - Jag vill begränsa valen till ROYGBP
char[] gissningArray = gissning.ToCharArray();                      //OBS OBS OBS - Jag vill ha en loop som håller igång programmet
                                                                    //OBS OBS OBS - Jag vill undersöka om jag kan ändra min metod TaInput()
                                                                    //... till att också göra om arrayen och använda printFarg. Går det?
foreach (char p in gissningArray)
{
    PrintFarg(p);
}

//En EGEN metod för att ta in input från användaren. KUL! :D 

string TaInput()
{

    while (true)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P");
        string gissning = Console.ReadLine().ToUpper();
        if (gissning.Length == 4)
        {
            return (gissning);
        }
        else
        {
            Console.WriteLine("Du har angivit fel format");

        }
    }
}
//Console.WriteLine(" ");
//Console.WriteLine("Ange din färggissning, välj mellan R,O,Y,G,B,P");
//string gissning = Console.ReadLine();

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