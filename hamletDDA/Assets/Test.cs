using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float healthTest = 0f;
    public DataCollector collector;

    private void Start()
    {
        //StartCoroutine(collector.SaveSnapShot(healthTest, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        healthTest = Random.Range(10, 120);
    }
}
