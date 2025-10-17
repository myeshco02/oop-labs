// Write required code.

// Data - do not change it in code!
using System.Security.Cryptography;

string[] names = {
    "Mickey Mouse", "Minnie Mouse", "Donald Duck", "Goofy", "Pluto", "Daisy Duck", "Simba", "Nala",
    "Timon", "Pumbaa", "Mufasa", "Ariel", "Flounder", "Sebastian", "Ursula", "Belle", "Beast", "Gaston",
    "Cinderella", "Prince Charming", "Aurora", "Maleficent", "Rapunzel", "Flynn Rider", "Elsa", "Anna",
    "Olaf", "Moana", "Maui", "Hercules"
};


// Print all array elements, *perLine* elements per one line
// After all elements except last one should be ", " - also on the end of lines.
// After last element should be ".".
void PrintGroups(string[] t, int perLine)
{

    for (int i = 0; i < t.Length; i++) //iterate through all elements: we've got counter. Break condition is length of array. Incrementing counter by one (we go thruevery element)
    {
        Console.Write(t[i]);

        if (i == t.Length - 1) //last element check
        {
            Console.WriteLine("."); //end with dot
        }
        else if ((i + 1) % perLine == 0) //then for other elements check modulo `perline` if equals zero we go to the next line using WriteLine
        {
            Console.WriteLine(",");
        }
        else //otherwise just separate with comma and space using `Write`
        {
            Console.Write(", ");
        }
    }

}


// Print all array elements in *perLine* columns.
// Each column must have given *width* (number of chars).
// Columns should be separated by "| ".
// If element is too long it should be trimmed.

void PrintColumns(string[] t, int perLine, int width)
{

    for (int i = 0; i < t.Length; i++) //same as before - iterate through all elements 
    {
        string item = t[i];

        if (item.Length > width) //check if element is longer than width
        {
            item = item.Substring(0, width); //trim element to fit width

            /*
            Substring - METODA KLASY string
            zwraca nowy string będący podłańcuchem łańcucha wywołującego metodę.
            Metoda ta przyjmuje dwa argumenty: indeks początkowy (od którego zaczyna się podłańcuch) oraz długość podłańcucha.
            Skoro chcemy od początku to indeks początkowy to 0, a długość max to width.
            */
        }

        Console.Write(item.PadRight(width)); 

        /*
        PadRight - METODA KLASY STRING
        The PadRight method returns a new string that right-aligns the characters in this instance by padding them on the right with spaces or a specified Unicode character, for a specified total length.
        Można wybrać jaki znak ma być użyty do wypełnienia (domyślnie spacja) oraz jaka ma być docelowa długość łańcucha.
        Używamy po to, żeby wizualnie wyrównać kolumny - każdy element zajmie tyle samo miejsca (szerokość kolumny).
        */

        if ((i + 1) % perLine == 0) //check if we reached the end of a line
        {
            Console.WriteLine(); //go to the next line
        }
        else //otherwise separate columns with "| "
        {
            Console.Write("| ");
        }
    }

}


// Test how your functions work. 
// You can temprary comment some lines not needed for current testing.


Console.WriteLine("\nPrintGroups(names, 3):\n");
PrintGroups(names, 3);
/*
Mickey Mouse, Minnie Mouse, Donald Duck,
Goofy, Pluto, Daisy Duck,
Simba, Nala, Timon,
Pumbaa, Mufasa, Ariel,
Flounder, Sebastian, Ursula,
Belle, Beast, Gaston,
Cinderella, Prince Charming, Aurora,
Maleficent, Rapunzel, Flynn Rider,
Elsa, Anna, Olaf,
Moana, Maui, Hercules.
*/

Console.WriteLine("\nPrintGroups(names, 5):\n");
PrintGroups(names, 5);
/*
Mickey Mouse, Minnie Mouse, Donald Duck, Goofy, Pluto,
Daisy Duck, Simba, Nala, Timon, Pumbaa,
Mufasa, Ariel, Flounder, Sebastian, Ursula,
Belle, Beast, Gaston, Cinderella, Prince Charming,
Aurora, Maleficent, Rapunzel, Flynn Rider, Elsa,
Anna, Olaf, Moana, Maui, Hercules. 
*/

Console.WriteLine("\nPrintGroups(names, 7):\n");
PrintGroups(names, 7);
/*
Mickey Mouse, Minnie Mouse, Donald Duck, Goofy, Pluto, Daisy Duck, Simba,
Nala, Timon, Pumbaa, Mufasa, Ariel, Flounder, Sebastian,
Ursula, Belle, Beast, Gaston, Cinderella, Prince Charming, Aurora,
Maleficent, Rapunzel, Flynn Rider, Elsa, Anna, Olaf, Moana,
Maui, Hercules.
*/

// For width = 40 don't worry if result will be wrapped due to screen width.
Console.WriteLine("\nPrintGroups(names, 40):\n");
PrintGroups(names, 40);
/*
Mickey Mouse, Minnie Mouse, Donald Duck, Goofy, Pluto, Daisy Duck, Simba, Nala, Timon, Pumbaa, Mufasa, Ariel, Flounder,
Sebastian, Ursula, Belle, Beast, Gaston, Cinderella, Prince Charming, Aurora, Maleficent, Rapunzel, Flynn Rider, Elsa, A
nna, Olaf, Moana, Maui, Hercules.
*/

Console.WriteLine("\n\nPrintColumns(names, 4, 17):\n");
PrintColumns(names, 4, 17);
/*
Mickey Mouse     | Minnie Mouse     | Donald Duck      | Goofy
Pluto            | Daisy Duck       | Simba            | Nala
Timon            | Pumbaa           | Mufasa           | Ariel
Flounder         | Sebastian        | Ursula           | Belle
Beast            | Gaston           | Cinderella       | Prince Charming
Aurora           | Maleficent       | Rapunzel         | Flynn Rider
Elsa             | Anna             | Olaf             | Moana
Maui             | Hercules         |
*/

Console.WriteLine("\n\nPrintColumns(names, 5, 15):\n");
PrintColumns(names, 5, 15);
/*
Mickey Mouse   | Minnie Mouse   | Donald Duck    | Goofy          | Pluto
Daisy Duck     | Simba          | Nala           | Timon          | Pumbaa
Mufasa         | Ariel          | Flounder       | Sebastian      | Ursula
Belle          | Beast          | Gaston         | Cinderella     | Prince Charming
Aurora         | Maleficent     | Rapunzel       | Flynn Rider    | Elsa
Anna           | Olaf           | Moana          | Maui           | Hercules
*/

Console.WriteLine("\n\nPrintColumns(names, 8, 10):\n"); //w funkcji i przykładzie jest 8, ale w stringu 'nagłówku' było 7 - poprawiłem na 8 (zgodnie z poniższym przykładowym outputem)
PrintColumns(names, 8, 10);
/*
Mickey Mou| Minnie Mou| Donald Duc| Goofy     | Pluto     | Daisy Duck| Simba     | Nala
Timon     | Pumbaa    | Mufasa    | Ariel     | Flounder  | Sebastian | Ursula    | Belle
Beast     | Gaston    | Cinderella| Prince Cha| Aurora    | Maleficent| Rapunzel  | Flynn Ride
Elsa      | Anna      | Olaf      | Moana     | Maui      | Hercules  |
*/