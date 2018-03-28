using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoView : MonoBehaviour {

    public GameObject infoObj;
    public GameObject mapObj;
    public GameObject AniObj;

    public Image ani_image;
    public Image ani_info_image;

    private bool status = false;

    public void showTiger()
    {
        ani_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("tiger");
        ani_info_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("tiger_info");
        showinfo();
    }

    public void showMonkey()
    {
        ani_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("bear");
        ani_info_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("bear_info");
        showinfo();
    }

    public void showSheep()
    {
        ani_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("sheep");
        ani_info_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("sheep_info");
        showinfo();
    }

    public void showRabbit()
    {
        ani_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("rabbit");
        ani_info_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("rabbit_info");
        showinfo();
    }

    public void showPenguin()
    {
        ani_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("penguin");
        ani_info_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("penguin_info");
        showinfo();
    }

    public void showBear()
    {
        ani_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("bear");
        ani_info_image.GetComponent<Image>().sprite = Resources.Load<Sprite>("bear_info");
        showinfo();
    }

    public void HideInfo()
    {
        status = false;
        infoObj.SetActive(false);
        mapObj.SetActive(true);
        AniObj.SetActive(true);
    }

    private void showinfo()
    {
        status = true;
        infoObj.SetActive(true);
        mapObj.SetActive(false);
        AniObj.SetActive(false);
    }
}
