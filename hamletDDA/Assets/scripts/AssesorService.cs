using System.Linq;
using UnityEngine;

public class AssesorService
{
    public AssesorService(float[] data)
    {
        Data = data;
    }

    public float[] Data { get; }

    // <summary>
    /// 
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public float StandardDeviation(float[] values)
    {
        //calculate the distance of each variable of our collection
        var distanceValues = values.Select(c =>
        {
            var distance = Mathf.Pow(c - values.Average(), 2);
            return distance;
        })
        .ToList();
        var sDeviation = Mathf.Sqrt(distanceValues.Sum(c => c) / distanceValues.Count());
        return (Mathf.Round(sDeviation*100))/100;
    }

    public float CalculateZScore(float valueToEvalutate)
    {
        var result = (valueToEvalutate - Data.Average()) / StandardDeviation(Data);
        return (Mathf.Round(result * 100)) / 100; ;
    }
}
