using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    public string valueName;
    private void Start()
    {

        if(!File.Exists(Application.dataPath +"/DDASaveFolder/" + valueName + ".json"))
        {
            PlayerData PData = new PlayerData();
            PData.health = 80;
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

    IEnumerator SaveSnapShot()
    {

        yield return new WaitForSeconds(5f);
    }
}
