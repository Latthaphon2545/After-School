using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class monster : MonoBehaviour
{
    public Transform[] point;
    public float moveSpeed;
    public int patroDestinaion;

    //public Transform PlayerTranform;
    public bool isChasing;
    public float chaseDistance;
    private Transform PlayerTranform;
    private float distan;

    public float ResetTime = 0.5f;
    private float timeHitImage = 1f;
    private bool timerIsRunning;
    public Image HitImage;
    private int life;

    Renderer rend;
    Color c;

    private void Start()
    {
        PlayerTranform = GameObject.FindWithTag("Player").transform;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    void Update()
    {
        distan = Vector2.Distance(transform.position, PlayerTranform.position);
        if (isChasing)
        {
            Vector2 direction = PlayerTranform.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, PlayerTranform.position, moveSpeed * Time.deltaTime);

            if (transform.position.x > PlayerTranform.position.x)
            {
                transform.localScale= new Vector3(1, 1, 1);
            }
            if (transform.position.x > PlayerTranform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (distan > chaseDistance)
            {
                //Debug.Log("อย่ามาเข้าใกล้ฉานนนนน");
                isChasing = false;
            }

            if (distan == chaseDistance)
            {
                //Debug.Log("อย่ามาเข้าใกล้ฉานนนนน");
                isChasing = false;
            }
        }
        else
        {
            if (distan < chaseDistance)
            {
                Debug.Log("อย่ามาเข้าใกล้ฉานนนนน");
                Hit();
                timerIsRunning = true;
                FindObjectOfType<playerLife>().Immor();
                isChasing = true;
            }

            if (transform.position.x > PlayerTranform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (transform.position.x > PlayerTranform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (patroDestinaion == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, point[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, point[0].position) < .2f)
                {
                    patroDestinaion = 1;
                }
            }

            if (patroDestinaion == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, point[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, point[1].position) < .2f)
                {
                    patroDestinaion = 0;
                }
            }
        }

        if (timerIsRunning)
        {
            if (timeHitImage > 0)
            {
                timeHitImage -= Time.deltaTime;
            }
            else
            {
                timeHitImage = 1f;
                HitImage.gameObject.SetActive(false);
                timerIsRunning = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerPrefs.GetInt("life") > 0)
        {
            Hit();
            timerIsRunning = true;
            FindObjectOfType<playerLife>().Immor();
        }
    }

    private void Hit()
    {
        HitImage.gameObject.SetActive(true);
        life = PlayerPrefs.GetInt("life");
        life--;
        int new_life = life;
        PlayerPrefs.SetInt("life", new_life);
        if (life <= 0)
        {
            Debug.Log("Game Over");
            FindObjectOfType<playerLife>().ResumeLevel();
            PlayerPrefs.DeleteAll();
            FindObjectOfType<playerLife>().Domdes();
            //PlayerPrefs.SetInt("life", 3);
        }
        else
        {
            Debug.Log("Life: " + life);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, chaseDistance);
    }
}
