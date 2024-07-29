using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick movement;
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    private Transform playerTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = transform;
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }

    public void MovementPlayer()
    {
        Vector2 direction = movement.Direction;
        if (direction.y != 0 || direction.x != 0)
        {
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
            Runanimate(true);

            // Flip the character based on movement direction
            if (direction.x > 0)
            {
                playerTransform.localScale = new Vector3(1, 1, 1); // Facing right
            }
            else if (direction.x < 0)
            {
                playerTransform.localScale = new Vector3(-1, 1, 1); // Facing left
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
