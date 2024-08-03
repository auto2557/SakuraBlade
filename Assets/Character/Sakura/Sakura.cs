using UnityEngine;

public class Sakura : PlayerScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
         GameObject joy = GameObject.FindGameObjectWithTag("GameController");
        movement = joy.GetComponent<Joystick>();
    }
    private void FixedUpdate()
    {
        MovementPlayer();
    }

}
