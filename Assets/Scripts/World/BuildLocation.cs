using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLocation : MonoBehaviour
{
    bool builtOn = false;

    private void Start()
    {
        builtOn = false;
    }

    public void SetLocationStatus(bool state)
    {
        builtOn = state;
    }

    public bool GetLocationStatus()
    {
        return builtOn;
    }

}
