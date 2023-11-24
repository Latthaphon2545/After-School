using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{
    bool pickUpAllowed;
    public string NameItem;
    public GameObject PausedHint;

    void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        //if (pickUpAllowed)
        //{
        //    //Destroy(gameObject);
        //    if (NameItem == "Hint")
        //    {
        //        PausedHint.SetActive(true);
        //    }

        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //pickUpAllowed = true;
            PausedHint.SetActive(true);
            Debug.Log("1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //pickUpAllowed = false;
            Debug.Log("2");
            PausedHint.SetActive(false);
            //PausedHint.SetActive(false);
        }
    }
}
