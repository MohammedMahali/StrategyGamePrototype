using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitMenu()
    {
        TerritoryManager tManager = FindAnyObjectByType<TerritoryManager>();
        if (panel != null)
        {
            TerritoryManager.isSelected = false;
            tManager.gScript = null;
            panel.SetActive(false);
            Time.timeScale = 1;
            tManager._MovingExistingUnits = false;
        }
    }
}
