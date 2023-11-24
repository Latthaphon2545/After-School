using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour
{
    //List of items picked up
    public int items_ChojuKigan =0;
    public int items_KenkoKigan =0;
    public int items_SanshuNoJingi = 0;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Use_Item_ChojuKigan();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Use_Item_KenkoKigan();
        }
    }

    public void PickUpChojuKigan()
    {
        items_ChojuKigan += 1;
        Debug.Log("Choju Kigan : " + items_ChojuKigan);
        PlayerPrefs.SetInt("Choju Kigan", items_ChojuKigan);
    }

    public void PickUpKenkoKigan()
    {
        items_KenkoKigan += 1;
        Debug.Log("Kenko Kigan :" + items_KenkoKigan);
        PlayerPrefs.SetInt("Kenko Kigan", items_KenkoKigan);
    }
    
    public void Use_Item_ChojuKigan()
    {
        int new_items_ChojuKigan = PlayerPrefs.GetInt("Choju Kigan");
        if (new_items_ChojuKigan > 0)
        {
            new_items_ChojuKigan -= 1;
            items_ChojuKigan = new_items_ChojuKigan;
            PlayerPrefs.SetInt("Choju Kigan", new_items_ChojuKigan);
            Debug.Log(items_ChojuKigan);
            FindObjectOfType<playerLife>().UseChojuKigan();
        }
        else if (items_ChojuKigan == 0)
        {
            Debug.Log("หมดแล้วอีดอกใช้ไรเยอะแยะ");
        }
    }

    public void Use_Item_KenkoKigan()
    {
        int new_items_KenkoKigan = PlayerPrefs.GetInt("Kenko Kigan");
        if (new_items_KenkoKigan > 0)
        {
            new_items_KenkoKigan -= 1; ;
            items_KenkoKigan = new_items_KenkoKigan;
            PlayerPrefs.SetInt("Kenko Kigan", new_items_KenkoKigan);
            Debug.Log(items_KenkoKigan);
            FindObjectOfType<playerLife>().UseKinunJosho();
        }
        else if (items_KenkoKigan == 0)
        {
            Debug.Log("หมดแล้วอีดอกใช้ไรเยอะแยะ");
        }
    }


    public void PickUpSanshuNoJingi()
    {
        items_SanshuNoJingi += 1;
        Debug.Log("SanshuNoJingi :" + items_SanshuNoJingi);
        PlayerPrefs.SetInt("SanshuNoJingi", items_SanshuNoJingi);
    }
}

