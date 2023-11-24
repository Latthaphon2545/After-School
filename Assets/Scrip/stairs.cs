using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;


public class stairs : MonoBehaviour
{
    bool pickUpAllowed;
    public TextMeshProUGUI stairsText;

    private void Start()
    {
        stairsText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.W) && SceneManager.GetActiveScene().buildIndex != 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("ขึ้น");
        }

        if (pickUpAllowed &&  Input.GetKeyDown(KeyCode.S) && SceneManager.GetActiveScene().buildIndex != 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("ลง");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stairsText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stairsText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
}

