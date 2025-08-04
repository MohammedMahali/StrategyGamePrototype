using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public GameObject Background;
    public GameObject SpeakerIcon;

    private void Start()
    {
        Background.SetActive(false);
        SpeakerIcon.SetActive(false);
        
    }


    public void DisplayInstructions()
    {
        if(Background.activeSelf == false)
        {
            Background.SetActive(true);
            SpeakerIcon.SetActive(true);
        }

        else
        {
            Background.SetActive(false);
            SpeakerIcon.SetActive(false);
        }
    }

}
