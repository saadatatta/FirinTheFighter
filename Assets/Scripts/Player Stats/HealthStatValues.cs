[System.Serializable]
public static class HealthStatValues
{
    public static ushort Level1 = 0;
    public static ushort Level2 = 30;
    public static ushort Level3 = 80;

    public static ushort GetHealthStatValues(int level)
    {
        ushort value = 0;
        switch (level)
        {
            case 1:
                value = Level1;
                break;

            case 2:
                value = Level2;
                break;

            case 3:
                value = Level3;
                break;
            default:
                break;
        }
        return value;
    }

}
