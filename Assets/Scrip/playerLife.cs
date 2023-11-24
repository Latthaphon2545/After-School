using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class playerLife : MonoBehaviour
{
    int life;
    public float set = 5f;

    Renderer rend;
	Color c;

    
    // Start is called before the first frame update
    void Start () 
    {
		rend = GetComponent<Renderer> ();
		c = rend.material.color;
        PlayerPrefs.SetInt("life", 3);
    }


    public void ResumeLevel()
    {
        SceneManager.LoadScene("GameOver");
        Destroy(this.gameObject);
        PlayerPrefs.DeleteAll();
    }

    public void UseChojuKigan()
    {
        life = PlayerPrefs.GetInt("life");
        life++;
        int new_life = life;
        PlayerPrefs.SetInt("life", new_life);
    }

    public void UseKinunJosho()
    {
        StartCoroutine("UseKen");
    }


    IEnumerator UseKen()
	{
		Physics2D.IgnoreLayerCollision (3, 8, true);
		c.a = 0.5f;
		rend.material.color = c;
		yield return new WaitForSeconds (3f);
		Physics2D.IgnoreLayerCollision (3, 8, false);
		c.a = 1f;
		rend.material.color = c;
	}

    public void Use_Loker()
    {
        Physics2D.IgnoreLayerCollision (3, 8, true);
		c.a = 0.5f;
		rend.material.color = c;
        GetComponent<player_movement>().enabled = false;
        //gameObject.SetActive(false);
    }

    public void Unuse_Loker()
    {
        StartCoroutine("UseLoker");
        GetComponent<player_movement>().enabled = true;
    }

    IEnumerator UseLoker()
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(3, 8, false);
        c.a = 1f;
        rend.material.color = c;
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(3, 8, false);
        c.a = 1f;
        rend.material.color = c;
    }

    public void Immor()
    {
        StartCoroutine("GetInvulnerable");
    }

    public void Domdes()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
