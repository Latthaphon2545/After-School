using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
    bool pickUpAllowed;
    public string NameItem;

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            if (NameItem == "ChojuKigan")
            {
                FindObjectOfType<itemCollector>().PickUpChojuKigan();
            }
            if (NameItem == "KenkoKigan")
            {
                FindObjectOfType<itemCollector>().PickUpKenkoKigan();
            }
            if (NameItem == "SanshuNoJingi")
            {
                FindObjectOfType<itemCollector>().PickUpSanshuNoJingi();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                pickUpAllowed = true;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpAllowed = false;
        }
    }
}
