
[System.Serializable]
public static class HealthStatNames
{
    public static string Level1 = "Fragile";
    public static string Level2 = "Weak";
    public static string Level3 = "Normal";

    public static string GetHealthLevelName(int level)
    {
        string name = "";
        switch (level)
        {
            case 1:
                name = Level1;
                break;

            case 2:
                name = Level2;
                break;

            case 3:
                name = Level3;
                break;
            default:
                break;
        }
        return name;
    }
}
