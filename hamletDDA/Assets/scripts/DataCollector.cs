using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    private void Start()
    {
        PlayerData PData = new PlayerData();
        PData.health = 80;
        string json = JsonUtility.ToJson(PData);

        File.WriteAllText(Application.dataPath + "/saveData.json", json);
        string readJSON = File.ReadAllText(Application.dataPath + "/saveData.json");
        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(loadedData.health);
    }
    private class PlayerData
    {
        public float health;
    }
}
