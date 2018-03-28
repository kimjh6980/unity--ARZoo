using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public double latitude, longitude;
    internal static object location;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has noe enabled GPS");
            yield break;
        }
        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        //latitude = 35.223430;
        //longitude = 126.888856;

        yield break;
    }
    public void Update()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        //latitude = 35.223430;
        //longitude = 126.888856;
    }

    public static implicit operator float(GPS v)
    {
        throw new NotImplementedException();
    }
}