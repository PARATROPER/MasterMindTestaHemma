using System.Linq;

Random random = new Random();  // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y) pch ha som input till RattRad.

char[] facit = RattRad(random);  // skapar en NY char-array genom att anropa RattRad-metoden med 
Console.WriteLine(string.Join(" ", facit)); // skriver ut alla värden i arrayen genom att göra om int värdena i arrayen till string



//int[] arrayDiceValue = new int[6]; // skapar en int [] med 6 värdehållare
//for (int i = 0; i < arrayDiceValue.Length; i++)   // Loopar igenom arrayen och tilldelar ett random tal till varje plats
//{
//    arrayDiceValue[i] = random.Next(1, 7);
//}

//Console.WriteLine(string.Join(" ", arrayDiceValue)); // skriver ut alla värden i arrayen genom att göra om int värdena i arrayen till string



char [] RattRad(Random random)  // Metod som skapar en rad med 4 värden utifrån angivna chars. 
{
    char[] colors = { 'R', 'O', 'Y', 'G', 'B', 'P' }; // En array för att definiera färgerna vi valt
    char[] randomColor = new char[4];                 // arrayen där de slumpade värdena lagras

    for (int i = 0; i < randomColor.Length; i++)
    {
       int index = random.Next(0, colors.Length);   // Skapar en variabel index som får ett värde mellan 0-5. Men man kan bara köra colos.Length
       randomColor[i] = colors[index];              // Sätter randomColor[i] = colors[index] som då översätter till Char från colors
    }
    return randomColor;
}




















































//for (int i = 0; i < arrayDiceValue.Length; i++)               //Detta är en loop som vi kan använda istället för metoden Join för att skriva ut 
//{                                                             //värdena i vår arrayDiceValue
//    Console.Write($"{arrayDiceValue[i]} ");
//}