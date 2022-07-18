using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Assessor : MonoBehaviour
{
    float[] dummyData = {6, 2, 3, 1, 2, 4, 6};
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StandardDeviation(dummyData));
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


}
