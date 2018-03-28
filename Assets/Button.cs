using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject obj;

    bool status = false;

    private void Start()
    {
        //obj.SetActive(false);
    }

    public void maponoff()
    {
        if (status == false)
        {
            obj.SetActive(true);
            status = true;
            obj.GetComponent<GoogleApi>().Startfunc();
        }
        else
        {
            obj.SetActive(false);
            status = false;
            obj.GetComponent<GoogleApi>().Stopfunc();
        }
    }
}
