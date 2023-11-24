using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class Locker : MonoBehaviour
{
    bool pickUpAllowed;
    public TextMeshProUGUI PickUpText;
    public bool bol_a = false;

    private void Start()
    {
        PickUpText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.W))
        {
            // Debug.Log("InteractLocker");
            bol_a = true;
            UseLoker();
        }

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.S) && bol_a)
        {
            // Debug.Log("InteractLocker");
            bol_a = false;
            UnuseLoker();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    public void UseLoker()
    {
        Debug.Log("UseLoker");
        PickUpText.GetComponent<TextMeshProUGUI>().text = "s to exit";
        FindObjectOfType<playerLife>().Use_Loker();
    }

    public void UnuseLoker()
    {
        Debug.Log("UnuseLoker");
        PickUpText.GetComponent<TextMeshProUGUI>().text = "w to enter";
        FindObjectOfType<playerLife>().Unuse_Loker();
    }
}
