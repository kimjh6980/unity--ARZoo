using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GoogleApi : MonoBehaviour
{
    public RawImage img;
    string url;
    public double lat, lon;
    //public string lat, lon;
    LocationInfo li;
    public static int zoom = 15;
    public int mapWidth = 1000;
    public int mapHeight = 880;
    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;

    private float updatecount = 0;

    string markerS = "&markers=color:blue%7Clabel:A%7C";    // 동물들 위치 찍을 마커 값 (파란색에 A)
    //
    //----여기는 학교위치로 찍었던거
    /*
    double[] markerP1 = {35.139838, 126.933776};
    double[] markerP2 = { 35.140320, 126.934281 };
    double[] markerP3 = { 35.139531, 126.934281 };
    */
    //

    double[] markerP1 = { 35.223005, 126.890240 };  // 열대조류관
    double[] markerP2 = { 35.223093, 126.889682 };  // 큰물새장
    double[] markerP3 = { 35.223995, 126.888363 };  // 호랑이사
    double[] markerP4 = { 35.224556, 126.888373 };  // 식물원
    double[] markerP5 = { 35.223119, 126.888105 };  // 사자사
    double[] markerP6 = { 35.222190, 126.887311 };  // 원숭이사
    double[] markerP7 = { 35.220411, 126.890637 };  // 하마사
    double[] markerP8 = { 35.220586, 126.891442 };  // 코끼리, 기린사
    double[] markerP9 = { 35.222181, 126.889886 };  // 해양동물사


    IEnumerator Map()
    {
        //lat = Input.location.lastData.latitude;
        //lon = Input.location.lastData.longitude;
        lat = GPS.Instance.latitude;
        lon = GPS.Instance.longitude;
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=" + "35.139838" + "," + "126.933776";    //학교
        //url = "https://maps.googleapis.com/maps/api/staticmap?center=" + "35.223430" + "," + "126.888856";    //동물원
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon;                     //현위치
        url +=    "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected;    // 지도 셋팅
        url += "&markers=color:red%7Clabel:M%7C";   // 내위치 빨간색 글자 M
        url += lat + "," + lon; // 내위치
        url += markerS + markerP1[0] + "," + markerP1[1];   // 위치1 마커
        url += markerS + markerP2[0] + "," + markerP2[1];   // 위치2 마커
        url += markerS + markerP3[0] + "," + markerP3[1];   // 위치3 마커
        url += markerS + markerP4[0] + "," + markerP4[1];   // 위치4 마커
        url += markerS + markerP5[0] + "," + markerP5[1];   // 위치5 마커
        url += markerS + markerP6[0] + "," + markerP6[1];   // 위치6 마커
        url += markerS + markerP7[0] + "," + markerP7[1];   // 위치7 마커
        url += markerS + markerP8[0] + "," + markerP8[1];   // 위치8 마커
        url += markerS + markerP9[0] + "," + markerP9[1];   // 위치9 마커

        // url += "&key=AIzaSyBbiIcZ44YfYaAsuA0ao-3C0KQpnEESPX0";    // 키값
        url += "&key=AIzaSyBdVMjoKgVYS955AkFlgRer25QR1ljLEY0";          
        //  url += "AIzaSyCsnlx2ywGJhvIkOnoVsOyo-i3UZBlwpus";      // 비상용 서브키값
        /*
        // 인용했던 값의 원코드
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + "40.702147,-74.015794"+
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyCsnlx2ywGJhvIkOnoVsOyo-i3UZBlwpus";
            */
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();
    }
    // Use this for initialization
    void Start()
    {
        //img = gameObject.GetComponent<RawImage>();    // 위에서 그냥 퍼블릭으로 해서 오브젝트 드래그로 줘버림
        // 실제 가있는 상황이 아니여서 일단 임의로
        lat = Input.location.lastData.latitude;
        lon = Input.location.lastData.longitude;
        StartCoroutine(Map());
    }

    public void Startfunc()
    {   // 줌 값 바뀔때마다 확인하기 위해
        // 실제 가있는 상황이 아니여서 일단 임의로
        lat = Input.location.lastData.latitude;
        lon = Input.location.lastData.longitude;
        StartCoroutine(Map());
    }

    public void Stopfunc()
    {   // 지도 껏는데 위치 볼 필요 없자나
        StopCoroutine(Map());
    }

    // Update is called once per frame
    void Update()
    {   // 지속적 위치갱신을 위해 2초 단위
        updatecount += Time.deltaTime;
        if(updatecount >= 2)
        {
            updatecount = 0;
            StartCoroutine(Map());
        }

    }
}