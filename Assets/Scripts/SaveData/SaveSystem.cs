using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SaveGame(GameData gameData) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/spaceman.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(gameData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadGame() {
        string path = Application.persistentDataPath + "/spaceman.data";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        } else {
            Debug.Log("Save file not found in: " + path);
            return null; 
        }
    }
}
