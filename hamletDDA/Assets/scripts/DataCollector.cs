using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class DataCollector : MonoBehaviour
{
    [Header("Data flow")]
    [SerializeField]
    [Tooltip("The flow of data observed, here we can check our data list as it gets saved by our data collector.")]
    PlayerData data;
    AssesorService calculator;

    [Header("File Settings")]
    [Tooltip("The data that is beign observed, here we can see what the Data Collector is seeing at the moment.")]
    public float valueToSave;
    [Tooltip("The name of the file the observations for our value are going to be saved to.")]
    public string fileName = "default";

    [Header("Entries Settings")]
    [Tooltip("The maximum ammount of observations that are saved in the file before dumping older observations.")]
    public int MaximumEntries = 20;
    [Tooltip("How much time the Data Collector will wait before making another observation.")]
    public float entryCooldown = 5f;
    private bool isChecking = true;

    [Header("Calculation Settings")]
    [Tooltip("How much time the Data Collector will take before calculating the zScores.")]
    public float calculationCooldown = 10f;
    [Tooltip("this value details the treshold of how far the data checked has to be in the negative in order to" +
        "assess the player as Underpreforming.")]
    public float negativeDeviation = -1.5f;
    [Tooltip("this value details the treshold of how far the data checked has to be in the positive in order to" +
    "assess the player as Outpreforming.")]
    public float postiveDeviation = 1.5f;

    public enum skillAssesment {UNDERPERFROMING, NOMINAL, OUTPERFORMING};

    [Header("Current Skill Assesment")]
    [Tooltip("This is the current final assesment that the Data Collector has made on the Player's performance.")]
    public skillAssesment currentSkillAssement = skillAssesment.NOMINAL;

    private void Start()
    {
        //Save the data collector datapath in order to store our observations
        string saveAdress = Application.dataPath + "/DDASaveFolder/" + fileName + ".json";
        data = new PlayerData();

        //check if the json file exist, if it doesn't, create it immediatly
        if (!File.Exists(saveAdress))
        {   
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(saveAdress, json);
        }
        //if the files exsits, grab the json and serialize the data
        else
        {
            string json = File.ReadAllText(saveAdress);
            data = JsonUtility.FromJson<PlayerData>(json);
        }

        //after getting our json file, we save a observation every once in a while
        StartCoroutine(SaveSnapShot());

        //after reaching a minimun size of the entries, we calculate the zScore of the list of Values
        if (data.entries.Count >= MaximumEntries)
        {
            StartCoroutine(CalculateResult());
        }
    }

    private IEnumerator CalculateResult()
    {
        while (isChecking)
        {
            calculator = new AssesorService(data.entries.ToArray());
            var result = calculator.CalculateZScore(data.entries[data.entries.Count - 1]);
            //if player is strandard deviation away in the negative, he's currently doing worse than it's current behaviour 
            if (result < negativeDeviation)
            {
                currentSkillAssement = skillAssesment.UNDERPERFROMING;
            }
            //if the player is currently 1 standard deviation in the postive, means is doing better than we expect
            else if (result > postiveDeviation)
            {
                currentSkillAssement = skillAssesment.OUTPERFORMING;
            }
            //if the player is withing a standard deviation, he's performing normally.
            else
            {
                currentSkillAssement = skillAssesment.NOMINAL;
            }
            yield return new WaitForSeconds(calculationCooldown);
        }
    }

    //save a snapshot of the value everyonce in a while
    private IEnumerator SaveSnapShot()
    {
        while (isChecking)
        {
            data.entries.Add(valueToSave);
            //check size of the list, remove the older measurement;
            if (data.entries.Count > MaximumEntries)
            {
                data.entries.RemoveAt(0);
            }

            //save the updated list to the json file
            string output = JsonUtility.ToJson(data);
            File.WriteAllText(Application.dataPath + "/DDASaveFolder/" + fileName + ".json", output);
            yield return new WaitForSeconds(entryCooldown);
        }  
    }

    //custom class used to serialize our entries as a json file
    [System.Serializable]
    private class PlayerData
    {
        public List<float> entries = new List<float>();
    }
}
