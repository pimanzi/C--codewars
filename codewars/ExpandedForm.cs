namespace codewars;

public class ExpandedForm
{
    public static string Expand(long num)
    {
        string numString = num.ToString();
        
        int numLength = numString.Length;
        int power = numLength - 1;
        string result = "";
        for (int i = 0 ; i < numLength ; i++)
        {
            
            double tempNumb = int.Parse(numString[i].ToString()) * Math.Pow(10, power);
            if (i == numLength - 1)
            {
                result += $"{tempNumb}";
            }
            else
            {
                result += $"{tempNumb}+";
                power--;
            }
           
        }

        List<string> resultArr = result.Split("+").Where(x => x != "0").ToList();

        return string.Join(" + ", resultArr);
    }
}