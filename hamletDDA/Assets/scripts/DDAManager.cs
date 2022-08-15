using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAManager : MonoBehaviour
{
    public List<DataCollector> observers = new List<DataCollector>();
    public int failing;
    public int outperforming;
    public bool isAssessing = true;

    private void Start()
    {
        StartCoroutine(AssessPerformance());
    }


    private IEnumerator AssessPerformance()
    {
        while (isAssessing)
        {
            outperforming = 0;
            failing = 0;
            foreach (var observer in observers)
            {
                if (observer.skill == DataCollector.skillAssesment.UNDERPERFROMING)
                {
                    failing++;
                }
                else if (observer.skill == DataCollector.skillAssesment.OUTPERFORMING)
                {
                    outperforming++;
                }
            }

            if (failing > observers.Count/2)
            {
                Debug.Log("player is failing");
            }
            else if (outperforming > observers.Count/2)
            {
                Debug.Log("player is succeding!");
            }
            yield return new WaitForSeconds(1);
        }
    }
}

