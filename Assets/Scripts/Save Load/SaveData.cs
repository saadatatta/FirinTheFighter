using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData
{
    /// <summary>
    /// Save data to a file in local storage.
    /// </summary>
    /// <param name="data">The data that need to be saved.</param>
    public static void Save(FileManager data)
    {
        if (!Directory.Exists("Saves"))
        {
            Directory.CreateDirectory("Saves");
        }

        BinaryFormatter bf = new BinaryFormatter();

        using (FileStream fs = File.Create("Saves/data.dat"))
        {
            bf.Serialize(fs,data);
            fs.Close();
        }
    }
}
