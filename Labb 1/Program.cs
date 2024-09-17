Console.Write("Mata in en text med siffror och bokstäver: ");
string ueserInput = Console.ReadLine();            // Här sparas texten in från användaren.

List<ulong> ColorDigits = new List<ulong>(); // Alla färgade sifferkombinationer sparas i den här listan.

for (int i = 0; i < ueserInput.Length; i++) // Går igenom strängen, ett tecken i taget.
{
    if (char.IsDigit(ueserInput[i])) // Kollar om strängens första tecken är en siffra på varje varv.
    {
        char startDigit = ueserInput[i]; // Siffran som ska eftersökas sparas här och byts ut efter varje varv.


        for (int j = i + 1; j < ueserInput.Length; j++) // Sökningen påbörjas på tecknet som kommer efter siffran som ska eftersökas.
        {

            if (ueserInput[j] == startDigit && IsValidMatch(ueserInput, i, j)) // Kollar om tecknet är den siffran som eftersöks och om sökningsresultatet är enligt kriterierna.
            {

                string subDigitsCombination = ueserInput.Substring(i, j - i + 1); // Skapar en substring av sifferkombinationen.
                ColorDigits.Add(ulong.Parse(subDigitsCombination)); // Lägger till den i listan.
                ColorPrint(ueserInput, i, j); // Sätter färg.
                break;
            }
            else if (!char.IsDigit(ueserInput[j])) // Om det inte är en siffra så avslutas loopen för att börja söka nästa tecken.
            {
                break;
            }

        }
    }
}

ulong sum = SumCalculation(ColorDigits); // Räknar ut summan av alla sifferkombinationer.
PrintSum(sum); // Skriver ut summan.

// Kontrollerar om sökningen är enligt kriterierna. (Alla tecken i sökningen mellan start och slut ska enbart vara siffror och söknings-siffran får inte förekomma där emellan.)
static bool IsValidMatch(string userInput, int start, int end) // start = index för söknings-siffran, end = slutindex för matchaande siffra.
{
    for (int i = start + 1; i < end; i++)
    {
        if (!char.IsDigit(userInput[i]) || userInput[i] == userInput[start])
        {
            return false; // False om alla tecken emellan start och slut inte är enligt kriterierna.
        }
    }
    return true; // True om kriterierna uppfylls.
}

// Skriver ut sifferkombinationerna i färg och resten utan färg beroende på om kriterierna uppfylls eller ej.
static void ColorPrint(string UserInput, int start, int end)
{
    for (int i = 0; i < UserInput.Length; i++)
    {
        if (i >= start && i <= end)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ResetColor();
        }
        Console.Write(UserInput[i]);
    }
    Console.WriteLine();
}


// Räknar ut summan av additionen på alla sifferkombinationer.
static ulong SumCalculation(List<ulong> numbers)
{
    ulong sum = 0;
    foreach (var numberCombi in numbers)
    {
        sum += numberCombi;
    }
    return sum;
}

// Skriver ut summan i färg.
static void PrintSum(ulong sum)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"Summa: {sum}");
}



