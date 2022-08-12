using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class DataCollector : MonoBehaviour
{
    [SerializeField]
    PlayerData data;
    [Header("Settings")]
    public float valueToSave;
    public string valueName;
    public bool isChecking;
    private void Start()
    {
        string saveAdress = Application.dataPath + "/DDASaveFolder/" + valueName + ".json";
        data = new PlayerData();
        //check if the json file exist, if it doesn't, create it immediatly
        if (!File.Exists(saveAdress))
        {   
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(saveAdress, json);
        }
        else
        {
            string json = File.ReadAllText(saveAdress);
            data = JsonUtility.FromJson<PlayerData>(json);
        }
        StartCoroutine(SaveSnapShot(1));
    }

    private IEnumerator SaveSnapShot(float secondsToWait = 5f)
    {
        
        while (isChecking)
        {
            data.entries.Add(valueToSave);
            string output = JsonUtility.ToJson(data);
            Debug.Log(output);
            File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + valueName + ".json", output);
            yield return new WaitForSeconds(secondsToWait);
        }  
    }

    [System.Serializable]
    private class PlayerData
    {
        public List<float> entries = new List<float>();
    }
}
