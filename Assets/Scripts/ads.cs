using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ads : MonoBehaviour {

    // Use this for initialization
    public void adStart()
    {
       if (Advertisement.IsReady())
        {
            Advertisement.Show ();
        }
    } 

}
