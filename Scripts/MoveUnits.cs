using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnits : MonoBehaviour
{
    [SerializeField] private GameObject _panel;


    public static bool isPressed;

    public void PressMove()
    {
        TerritoryManager tManager = FindAnyObjectByType<TerritoryManager>();

        isPressed = true;
        _panel.SetActive(false);
        Time.timeScale = 1;

        // add a guard condition ro define requirementds
        if (tManager.gScript.hasBeenSetADestination == true)
        {
            tManager._MovingExistingUnits = false;

        }
        else
        {
            tManager._MovingExistingUnits = true;
        }

    }

}
