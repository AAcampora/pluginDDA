using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Assessor : MonoBehaviour
{
    float[] dummyData = {100, 80, 40, 100, 20, 45, 67};
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(CalculateZScore(123, dummyData));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="values"></param>
   /// <returns></returns>
    float StandardDeviation(float [] values)
    {
        //calculate the distance of each variable of our collection
       var distanceValues = values.Select(c => 
       { 
            var distance = Mathf.Pow(c - values.Average(), 2);  
            return distance; 
       })
       .ToList();
        var sDeviation = Mathf.Sqrt(distanceValues.Sum(c=> c) / distanceValues.Count());
        return sDeviation;
    }

    float CalculateZScore(float valueToEvalutate, float [] collection)
    {
        return (valueToEvalutate - collection.Average()) / StandardDeviation(collection);
    }

}
