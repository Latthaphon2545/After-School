using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sp;
    private Animator anim;
    public static player_movement Instance;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>(); 
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateAnimaionUpdate();
    }
    
    private void UpdateAnimaionUpdate()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sp.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
