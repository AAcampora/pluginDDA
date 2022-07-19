using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DDAManager : MonoBehaviour
{
    Dictionary<string, float> Inspectors = new Dictionary<string, float>();

    public void AddInspector(string name, float value)
    {
        Inspectors.Add(name, value);
    }
}

