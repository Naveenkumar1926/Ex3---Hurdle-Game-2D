using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jumpForce;
    private Rigidbody2D rb;
    public Score cc;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveip = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveip, 0, 0) * Time.deltaTime * speed;
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroy"))
        {
            cc.coincount++;
            Destroy(collision.gameObject);
        }
    }
}
