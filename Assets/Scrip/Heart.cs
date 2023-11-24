using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int numOfHeart;

    public Image[] hearts;
    public Sprite fullheart;


    void Update()
    {
        numOfHeart = PlayerPrefs.GetInt("life");
        for (int i = 0; i < hearts.Length; i++)
            if(i < numOfHeart)
            {   
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
    }
}
