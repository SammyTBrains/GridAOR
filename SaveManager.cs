using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager 
{
    public static void Save(DataManager.TileData[] tD)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        bf.Serialize(file, tD);
        file.Close();
    }

    public static DataManager.TileData[] Load()
    {
        if (SaveExists())
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                DataManager.TileData[] td = (DataManager.TileData[])bf.Deserialize(file);
                file.Close();

                return td;
            }
            catch (SerializationException)
            {
                Debug.LogError("Failed to load file");
                //Try again
            }
        }

        return null;
    }

    private static bool SaveExists()
    {
        return File.Exists(GetFullPath());
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + "TileData.txt";
    }
}
