using UnityEngine;

public class Test : MonoBehaviour
{
    [Range(0.0f, 120f)]
    public float healthTest;
    public DataCollector collector;
    public float minRange;
    public float maxRange;

    // Update is called once per frame
    void Update()
    {
        //healthTest = Random.Range(minRange, maxRange);
        collector.valueToSave = healthTest;
    }
}
