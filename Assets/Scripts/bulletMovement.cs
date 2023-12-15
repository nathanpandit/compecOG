using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float bulletShootingSpeed;
    [SerializeField] GameObject player;
    SpriteRenderer characterSR;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterSR = player.GetComponent<SpriteRenderer>();

        if (characterSR.flipX == false)
        {
            rb.velocity = new Vector2(bulletShootingSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-bulletShootingSpeed, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
