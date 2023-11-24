using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warpgete : MonoBehaviour
{
    private bool is1 = false;
    public string nameScene;
    public TextMeshProUGUI PickUpText;

    private void Start()
    {
        PickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            if(is1)
            {
                SceneManager.LoadScene(nameScene);
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUpText.gameObject.SetActive(true);
            is1 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUpText.gameObject.SetActive(false);
            is1 = false;
        }
    }
}
