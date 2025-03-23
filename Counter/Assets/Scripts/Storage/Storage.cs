using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine;

public class Storage
{
    private string filePath;
    private BinaryFormatter formatter;
    public Storage()
    {
        filePath = Application.persistentDataPath + "/GameSave.save";
        //Debug.Log(filePath);

        InitBinaryFormatter();
    }
    private void InitBinaryFormatter()
    {
        formatter = new BinaryFormatter();


        var selector = new SurrogateSelector();

        var ldSurrogate_1 = new CounterDataSerializationSurrogate();

        selector.AddSurrogate(typeof(CounterData), new StreamingContext(StreamingContextStates.All), ldSurrogate_1);

        var ldSurrogate_2 = new GameDataSerializationSurrogate();

        selector.AddSurrogate(typeof(GameData), new StreamingContext(StreamingContextStates.All), ldSurrogate_2);


        formatter.SurrogateSelector = selector;
    }
    public object Load(object saveDataByDefault)
    {

        if (!File.Exists(filePath))
        {
            if (saveDataByDefault != null)
                Save(saveDataByDefault);
            return saveDataByDefault;
        }

        var file = File.Open(filePath, FileMode.Open);
        var savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        FileStream file = File.Create(filePath);
        //Debug.Log("פאיכ סמחהאם");
        formatter.Serialize(file, saveData);
        file.Close();
    }

}
