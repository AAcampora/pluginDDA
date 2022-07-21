using UnityEngine;

public class Assessor : MonoBehaviour
{
    float[] dummyData = {6, 2, 3, 1};
    // Start is called before the first frame update
    void Start()
    {
        var service = new AssesorService(dummyData);

        Debug.Log(service.CalculateZScore(2));
    }
}
