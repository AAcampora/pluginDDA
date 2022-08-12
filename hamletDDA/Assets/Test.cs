using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float healthTest = 0f;
    public DataCollector collector;

    // Update is called once per frame
    void Update()
    {
        healthTest = Random.Range(10, 120);
        collector.valueToSave = healthTest;
    }
}
