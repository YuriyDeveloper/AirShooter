using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    private static string _filePath;

    public SaveSystem()
    {
        _filePath = Application.persistentDataPath + "/stats.data";
        UnityEngine.Debug.Log("DATA PATH = " + _filePath);
    }

    public void Save(StatsDataSet saveData)
    {
        try
        {
            FileStream dataStream = new FileStream(_filePath, FileMode.Create);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, saveData);
            dataStream.Close();
        }
        catch (IOException)
        {
            Debug.Log("IOException");
        }
    }

    public StatsDataSet Load()
    {
        if (File.Exists(_filePath))
        {
            FileStream dataStream = new FileStream(_filePath, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            StatsDataSet dictionary = null;
            if (dataStream.Length > 0)
            {
                dictionary = converter.Deserialize(dataStream) as StatsDataSet;
            }
            dataStream.Close();
            return dictionary;
        }
        else
        {
            Debug.LogError("Save file not found in " + _filePath);
            return null;
        }
    }
    public void Delete()
    {
        File.Delete(_filePath);
    }
}
