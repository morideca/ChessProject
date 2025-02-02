using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSave
{
    private readonly string jsonPath;

    public DataSave()
    {
        jsonPath = Path.Combine(Application.persistentDataPath, "FormationData.json");
    }

    public void SaveData()
    {
        var formationData = ServiceLocator.GetInstance().FormationData;
        var json = JsonUtility.ToJson(formationData);
        File.WriteAllText(jsonPath, json);
    }

    public void LoadFormation()
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            ServiceLocator.GetInstance().FormationData = JsonUtility.FromJson<FormationData>(json);
        }
        else
        {
            Debug.Log("нема джсуна");
            ServiceLocator.GetInstance().FormationData = new();
        }
    }
}
