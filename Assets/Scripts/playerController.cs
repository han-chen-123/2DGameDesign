using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Collider2D coll;

    public Animator anim;
    public Transform groundCheck;
    public LayerMask ground;
    public float speed, jumpForce;
    private float horizontalMove;

    public bool isGround, isJump, isDashing, isTouchCoffee;
    public int coffee;
    public int finalNum;
    public Text CoffeeNum;

    bool jumpPressed;
    int jumpCount;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount >0)
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate() 
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        GroundMovement();
        Jump();
        SwitchAnim();

        if (isTouchCoffee)
        {
            coffee++;
            CoffeeNum.text = coffee.ToString();
            isTouchCoffee = false;
            finalNum = coffee;
        }
    }

    void GroundMovement() 
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }

    }

    void Jump()
    {
        if (isGround)
        {
            jumpCount = 1;
            isJump = false;
        }
        if (jumpPressed && jumpCount < 2 && coll.IsTouchingLayers(ground))
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
            anim.SetBool("jumping", true);
        }
        /*else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }*/
    }
    void SwitchAnim()
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.0f)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (isGround)
        {
            anim.SetBool("falling", false);
            anim.SetBool("Idle", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coffee")
        {
            isTouchCoffee = true;
            Destroy(collision.gameObject);
        }
    }

}
