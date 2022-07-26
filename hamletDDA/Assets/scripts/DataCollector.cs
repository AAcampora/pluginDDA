using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    public string valueName;
    public DataSaved PData;
    public float test = 12;

    private void Start()
    {
        //PData = new DataSaved(valueName, value);
        //check if the json file exist, if it doesn't, create it immediatly
        if (!File.Exists(Application.dataPath +"/DDASaveFolder/" + valueName + ".json"))
        {   
            string json = JsonUtility.ToJson(PData);
            File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + valueName +".json", json);
        }
        else
        {
            Debug.Log("Json alredy Exists");
        }
       

        //
        //string readJSON = File.ReadAllText(Application.dataPath + "/saveData.json");
        //PlayerData loadedData = JsonUtility.FromJson<PlayerData>(readJSON);
        //Debug.Log(loadedData.health);
    }
    private class PlayerData
    {
        public float health;
    }

    IEnumerator SaveSnapShot(float valueToSave)
    {
        PData.Value.Add(valueToSave);
        string json = JsonUtility.ToJson(PData);
        File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + valueName + ".json", json);
        yield return new WaitForSeconds(5f);
    }

}
