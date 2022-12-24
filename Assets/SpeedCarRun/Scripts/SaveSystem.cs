using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SavePlayer(ScoreS scored)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.kg";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(scored);

       
        // put data in file
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/score.kg";
        if(File.Exists(path))
        {
        BinaryFormatter formatter = new BinaryFormatter();        
        FileStream stream = new FileStream(path, FileMode.Open);
        // convert binary to readable form
        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();
        
        return data;
        }
        else
        {
            Debug.LogError("save file not found in : " + path);
            return null;
        }
    }


}
