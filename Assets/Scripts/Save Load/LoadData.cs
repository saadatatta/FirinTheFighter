using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LoadData
{
    /// <summary>
    /// Load data from a local file to game.
    /// </summary>
    /// <returns>The data stored in strongly typed format.</returns>
    public static FileManager Load()
    {
        if (!Directory.Exists("Saves") &&!File.Exists("Saves/data.dat"))
        {
            return new FileManager(new SerializablePlayerStats(
                new AttackStat(), 
                new HealthStat(), 
                new ExperienceStat()),
                new LevelState(1, 1, 1));
        }

        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = File.Open("Saves/data.dat", FileMode.Open))
        {
            FileManager fm = bf.Deserialize(fs) as FileManager;
            fs.Close();
            return fm;
        }
    }
}
