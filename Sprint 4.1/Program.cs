using System.Linq;

Random random = new Random();  // skapar ett objekt av klassen Random för att senare kunna kalla på random.Next(x,y)

int [] test = { 1, 1, 1, 1, 1, 1, };


int[] arrayDiceValue = new int[6]; // skapar en int [] med 6 värdehållare

for (int i = 0; i < arrayDiceValue.Length; i++)   // Loopar igenom arrayen och tilldelar ett random tal till varje plats
{
    arrayDiceValue[i] = random.Next(1, 7);
}

Console.WriteLine(string.Join(" ", arrayDiceValue)); // skriver ut alla värden i arrayen genom att göra om int värdena i arrayen till string
Console.WriteLine(string.Join(" ", arrayDiceValue.Concat(test))); // testar lägga till två arrayer... funkar, men måste nog vara samma värdetyp




















































//for (int i = 0; i < arrayDiceValue.Length; i++)               //Detta är en loop som vi kan använda istället för metoden Join för att skriva ut 
//{                                                             //värdena i vår arrayDiceValue
//    Console.Write($"{arrayDiceValue[i]} ");
//}