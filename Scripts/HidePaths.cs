using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePaths : MonoBehaviour
{
    public Renderer r;
    private void Start()
    {
        r.enabled = false;
    }


}
