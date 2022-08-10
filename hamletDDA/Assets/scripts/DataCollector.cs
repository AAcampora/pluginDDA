using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    public string valueName;
    [SerializeField]
    PlayerData data;

    public bool isChecking;
    private void Start()
    {
        data = new PlayerData();
        //check if the json file exist, if it doesn't, create it immediatly
        if (!File.Exists(Application.dataPath +"/DDASaveFolder/" + valueName + ".json"))
        {   
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + valueName +".json", json);
        }
        else
        {
            Debug.Log("Json alredy Exists");
        }
        StartCoroutine(SaveSnapShot(420, 1));
    }

    private class PlayerData
    {
       public List<float> entries = new List<float>();
    }

    public IEnumerator SaveSnapShot(float valueToSave, float secondsToWait = 5f)
    {
        while (isChecking)
        {
            data.entries.Add(valueToSave);
            //string json = JsonUtility.ToJson(entries.ToArray());
            //File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + valueName + ".json", json);
            string output = JsonUtility.ToJson(data);
            Debug.Log(output);
            File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + valueName + ".json", output);
            yield return new WaitForSeconds(1f);
        }  
    }

}
