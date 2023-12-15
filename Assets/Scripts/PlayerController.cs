using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    [SerializeField] float speedx, jumpForce, distOfBullet;
    [SerializeField] bool isGrounded;
    [SerializeField] GameObject bullet;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        AnimationController();
        PlayerAttack();
    }

    void PlayerMovement()
    {
        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speedx, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speedx, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }
    void AnimationController()
    {
        if(rb.velocity.y > 0)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isFalling", false);
        }
        if(rb.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumping", false);
        }
        if(rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
        if (rb.velocity.x != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.F) && sr.flipX)
        {
            GameObject _bullet = bullet;
            Instantiate(bullet, new Vector2((transform.position.x - distOfBullet), transform.position.y), Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.F) && sr.flipX == false)
        {
            GameObject _bullet = bullet;
            Instantiate(bullet, new Vector2((transform.position.x + distOfBullet), transform.position.y), Quaternion.identity);
        }

    }
}
