namespace codewars;

public class DecodeRoman
{
    public static int Solution(string roman)
    {
        var symbols = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        int sum = 0;

        for (int x = 0; x < roman.Length-1; x++)
        {
           
                if (symbols[roman[x]] >= symbols[roman[x + 1]])
                {
                    sum += symbols[roman[x]];
                }
                else
                {
                    sum -= symbols[roman[x]];
                }
            
            
        }
        return sum + symbols[roman[roman.Length - 1]];
    }
}