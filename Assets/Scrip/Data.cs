using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Data : MonoBehaviour
{
    public TMP_Text many_items_ChojuKigan_Txet;
    public TMP_Text many_items_KenkoKigan_Txet;
    public TMP_Text many_items_SanshuNoJingi_Txet;
    int ChojuKigan;
    int KenkoKigan;
    int SanshuNoJingi;

    public void Update()
    {
        ChojuKigan = PlayerPrefs.GetInt("Choju Kigan");
        KenkoKigan = PlayerPrefs.GetInt("Kenko Kigan");
        SanshuNoJingi = PlayerPrefs.GetInt("SanshuNoJingi");
        many_items_ChojuKigan_Txet.text = ChojuKigan.ToString();
        many_items_KenkoKigan_Txet.text = KenkoKigan.ToString();
        many_items_SanshuNoJingi_Txet.text = "Sanshu No Jingi " + SanshuNoJingi.ToString() + "/3";
    }
}
