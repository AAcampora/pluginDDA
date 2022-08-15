using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DDAManager : MonoBehaviour
{
    public List<DataCollector> observers = new List<DataCollector>();
    public int failing;
    public int outperforming;
    public bool isAssessing = true;
    public static event Action PlayerFail;
    public static event Action PlayerSuccess;

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
                PlayerFail?.Invoke();
                failing = 0;
            }
            else if (outperforming > observers.Count/2)
            {
                PlayerSuccess?.Invoke();
                outperforming = 0;
                Debug.Log("player is succeding!");
            }
            yield return new WaitForSeconds(1);
        }
    }
}

