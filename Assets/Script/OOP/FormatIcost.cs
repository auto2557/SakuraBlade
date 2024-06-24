using UnityEngine;

public class FormatIcost : UI
{
    public string FormatNumber(double number)
    {
        if (number >= 1000000000)
        {
            return (number / 1000000000D).ToString("0.##") + "b";
        }
        else if (number >= 1000000)
        {
            return (number / 1000000D).ToString("0.##") + "m";
        }
        else if (number >= 1000)
        {
            return (number / 1000D).ToString("0.##") + "k";
        }
        else
        {
            return number.ToString("0");
        }
    }
}
