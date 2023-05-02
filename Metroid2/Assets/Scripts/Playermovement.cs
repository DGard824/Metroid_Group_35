using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour
{
    private Vector3 startPos;
    private Rigidbody rigid_body;
    public float speed;
    public float jumpForce;
    public int fallDepth;
    public int lives;
    public int count;
    public Text livesText;
    public Text countText;




    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        setCountText();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 add_position = Vector3.zero;


        //moves left
        if (Input.GetKey("a"))
        {
            add_position += Vector3.left * Time.deltaTime * speed;

        }

        //moves right
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }

        //code for jumping
        if (Input.GetKey("space"))
        {
            rigid_body.AddForce(Vector3.up * jumpForce);
        }


        GetComponent<Transform>().position += add_position;

        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }


    void setCountText()
    {
        countText.text = "Count:" + count.ToString();
        livesText.text = "Lives:" + lives.ToString();
        if (lives <= 0)
        {

        }
    }


    private void Respawn()
    {
        transform.position = startPos;
        lives--;
        setCountText();

        if (lives <= 0)
        {
            this.enabled = false;
        }

    }

}

