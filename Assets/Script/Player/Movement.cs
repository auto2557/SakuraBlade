using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick movement;
    public float speed;
    protected Rigidbody2D rb;
    public Animator animator;

    public GameObject hitblockR;
    public GameObject hitblockL;

    protected SpriteRenderer spriteRenderer;
    private bool isFacingRight = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    virtual public void MovementPlayer()
    {
        Vector2 direction = movement.Direction;
        if (direction.y != 0 || direction.x != 0)
        {
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
            Runanimate(true);

            if (direction.x > 0 && !isFacingRight)
            {
                spriteRenderer.flipX = false; 
                hitblockR.SetActive(true);   
                hitblockL.SetActive(false);  
                isFacingRight = true;
            }
            else if (direction.x < 0 && isFacingRight)
            {
                spriteRenderer.flipX = true; 
                hitblockR.SetActive(false);  
                hitblockL.SetActive(true);   
                isFacingRight = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            Runanimate(false);
        }
    }

    public void Runanimate(bool isRunning)
    {
        animator.SetBool("Running", isRunning);
    }
}
