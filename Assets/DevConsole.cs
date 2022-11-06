using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevConsole : MonoBehaviour
{
    public Toggle devToggle;
    public GameObject console;

    public void ChangeDevConsoleVisibility()
    {
        if (devToggle.isOn)
        {
            console.SetActive(true);
        } else
        {
            console.SetActive(false);
        }
    }
}