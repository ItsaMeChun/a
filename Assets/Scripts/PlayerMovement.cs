using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6;
    private float minSpeed = 6;
    public float moveInput;
    public bool isGrounded;

    public Rigidbody2D rb;
    private Collider2D coll;

    public float jumpValue = 0f;
    public float maxJumpValue = 20f;
    private float gainJumpValue = 0.3f;

    public float fallValue = 0f;
    public float fallMultiplier = 0.1f;
    public float maxFallValue = 30f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //collider2D = transform.Find("foot").GetComponent<Collider2D>();
        coll = rb.transform.Find("foot").GetComponent<Collider2D>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log(collision.tag);
    //    //switch (collision.gameObject.tag)
    //    //{
    //    //    case "ground":
    //    //        isGrounded = true;
    //    //        Debug.Log(collision.tag);
    //    //        break;
    //    //    case "wall":
    //    //        Debug.Log(collision.tag);
    //    //        isGrounded = false;
    //    //        break;
    //    //}
    //    if (collision.gameObject.tag == "ground") isGrounded = true;
    //    else if (collision.gameObject.tag == "wall") isGrounded = false;
    //    else isGrounded = true;
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ground") isGrounded = true;
        else if (collision.gameObject.tag == "wall") isGrounded = false;
        else isGrounded = true;
    }
    // void OnCollisionExit2D(Collision2D other)
    // {
    //     Debug.Log(other.gameObject.tag);
    // }
    private void Update()
    {
        if (isGrounded == true)
        {
            Move();
            Jump();
        }
        else Fall();
    }

    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKey("space"))
        {
            jumpValue += gainJumpValue;
            if (jumpValue > maxJumpValue) jumpValue = maxJumpValue;
            this.speed = 0;
        }
        if (Input.GetKeyUp("space"))
        {
            this.speed = minSpeed;
            if (jumpValue > 0)
            {
                isGrounded = false;
                rb.velocity = new Vector2(moveInput * speed, jumpValue);
                //rb.velocity += Vector2.up * moveInput * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            //else
            //{
            //    isGrounded = true;
            //}
            this.jumpValue = 0;
            //rb.velocity += Vector2.up * Physic2D.gravity.y
        }
    }

    private void Fall()
    {
        if (isGrounded == false)
        {
            fallValue += fallMultiplier;
            if (fallValue > maxFallValue) fallValue = maxFallValue;
        }
        if (isGrounded == true)
        {
            fallValue = 0;
        }
        //rb.velocity = 
    }
}
