using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody2d;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive;
    public Animator animator;
    public AudioSource[] sounds;

    private void Start()
    {
        birdIsAlive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rigidBody2d.velocity = Vector2.up * flapStrength;
            animator.SetBool("isJump", true);
            sounds[0].Play();
        }
        else
            animator.SetBool("isJump", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dead();
    }

    private void dead()
    {
        birdIsAlive = false;
        animator.SetBool("isDied", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        logic.gameOver();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LiveZone"))
            dead();
    }
}
