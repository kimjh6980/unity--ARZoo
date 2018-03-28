using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomB : MonoBehaviour
{
    public GameObject obj;

    private bool acting = false;
    public void zoomin()
    {
        if (acting == false)
        {
            acting = true;
            if (GoogleApi.zoom > 1)
            {
                GoogleApi.zoom -= 1;
                obj.GetComponent<GoogleApi>().Startfunc();
                Debug.Log("zoom:" + GoogleApi.zoom);
            }
            acting = false;
        }
    }

    public void zoomout()
    {
        if (acting == false)
        {
            acting = true;
            if (GoogleApi.zoom < 20)
            {
                GoogleApi.zoom += 1;
                obj.GetComponent<GoogleApi>().Startfunc();
                Debug.Log("zoom:" + GoogleApi.zoom);
            }
            acting = false;
        }
    }
}
