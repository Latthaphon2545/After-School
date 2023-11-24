using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    bool dooeAllowed;
    public TextMeshProUGUI doorText;

    private void Start()
    {
        doorText.gameObject.SetActive(false);
    }
    void Update()
    {
        if (dooeAllowed && Input.GetKeyDown(KeyCode.W))
        {
                if (FindObjectOfType<itemCollector>().items_SanshuNoJingi == 3)
                {
                    SceneManager.LoadScene("win");
                    Destroy(this.gameObject);
                    PlayerPrefs.DeleteAll();
                }
                else
                {

                    Debug.Log("เก็บไม่ครบจ้า ไปหาเก็บมา่อน");
                }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorText.gameObject.SetActive(true);
            dooeAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorText.gameObject.SetActive(false);
            dooeAllowed = false;
        }
    }
}
