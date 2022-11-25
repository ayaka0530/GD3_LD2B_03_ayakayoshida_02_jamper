using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    private float speed = 0.05f;

    private int jumpCount = 0;
    private float jumpForce = 25f;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left") || (Input.GetKey(KeyCode.A)))
        {
            position.x -= speed;

        }
        else if (Input.GetKey("right") || (Input.GetKey(KeyCode.D)))
        {
            position.x += speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)
        {
            //this.rbody2D.AddForce(transform.up * jumpForce);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpForce, 0);
            jumpCount++;
        }
        var pos = transform.position;
        //ƒGƒŠƒAŽw’è‚µ‚ÄˆÚ“®‚·‚é
        //position.x = Mathf.Clamp(position.x, -7.33f, 6.5f);
        //position.y = Mathf.Clamp(position.y, -3.63f, 3.63f);

        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            jumpCount = 0;
        }
    }

}
