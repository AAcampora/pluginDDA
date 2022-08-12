using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class DataCollector : MonoBehaviour
{
    [SerializeField]
    PlayerData data;
    [Header("File Settings")]
    public float valueToSave;
    public string valueName;
    [Header("Entries Settings")]
    public int maximumEntryNumber = 20;
    public float entryCooldown = 5f;
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
        StartCoroutine(SaveSnapShot(entryCooldown));
    }

    //save a snapshot of the value everyonce in a while
    private IEnumerator SaveSnapShot(float secondsToWait = 5f)
    {
        while (isChecking)
        {
            data.entries.Add(valueToSave);
            //check size of the list, remove the older measurement;
            if (data.entries.Count > maximumEntryNumber)
            {
                data.entries.RemoveAt(0);
            }
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
