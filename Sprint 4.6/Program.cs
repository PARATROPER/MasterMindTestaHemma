const ConsoleColor CONSOLE_FORGRUND = ConsoleColor.Black;   // Deklareras som konstant i övergripande nivå:
Console.OutputEncoding = System.Text.Encoding.UTF8;
Random random = new Random();   // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) och ha som input till RattRad.
char plupp = '\u2B24';          // definierar variabeln plupp som en plupp till konsolen genom \u2B24




Console.Write("Ange din färggissning, 4 tecken, välj mellan R,O,Y,G,B,P. \t");
string gissningInput = Console.ReadLine().ToUpper();
char[] gissningArray = gissningInput.ToCharArray();
Rad gissning = new Rad(gissningArray);
Console.WriteLine("Din gissning: ");
gissning.PrintRad();


char[] facit = RattRad(random);
Rad facitStruct = new Rad(facit);
Console.WriteLine("Facit är: ");
facitStruct.PrintRad();



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

}





