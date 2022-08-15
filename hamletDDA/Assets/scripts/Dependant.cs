using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependant : MonoBehaviour
{
    public float valueToChange;
    public float ammountToSubtract;
    private void Start()
    {
        DDAManager.PlayerFail += AdjustVariableFail;
        DDAManager.PlayerSuccess += AdjustVariableSuccess;
    }
    private void AdjustVariableFail()
    {
        valueToChange += ammountToSubtract;
    }

    private void AdjustVariableSuccess()
    {
        valueToChange -= ammountToSubtract;
    }

    private void OnDisable()
    {
        DDAManager.PlayerFail -= AdjustVariableFail;
        DDAManager.PlayerSuccess -= AdjustVariableSuccess;
    }
}
