using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSTest : MonoBehaviour {

    public Text coordinates = null;

    private void Update()
    {
        string latValue = GPS.Instance.latitude.ToString();
        string lonValue = GPS.Instance.longitude.ToString();
        coordinates.text = "Lat:" + latValue.Substring(0, 7) + "\nLon: " + lonValue.Substring(0,7);
        //coordinates.text = "Lat:" + GPS.Instance.latitude.ToString() + "\nLon: " + GPS.Instance.longitude.ToString();
    }
}
