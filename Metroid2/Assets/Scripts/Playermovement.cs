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
    public bool isRotated = false;
    public bool isGrounded;
    




    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 add_position = Vector3.zero;


        if (Physics.Raycast(transform.position, Vector3.down, GetComponent<CapsuleCollider>().height / 2 + 0.1f))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }



        //moves left
        if (Input.GetKey("a"))
        {
            if (!isRotated)
            {
                

                transform.Rotate(0, 180, 0, Space.Self);
                isRotated = true;
            }
            add_position += Vector3.left * Time.deltaTime * speed;

        }

        //moves right
        if (Input.GetKey("d"))
        {
            if (isRotated)
            {
                isRotated = false;
                transform.Rotate(0, 180, 0, Space.Self);
            }
            add_position += Vector3.right * Time.deltaTime * speed;
            
            
        }

        //code for jumping
        if (Input.GetKey("w"))
        {
            if (isGrounded)
            {
                rigid_body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
           
        }


        GetComponent<Transform>().position += add_position;

        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JetPack"))
        {
            other.gameObject.SetActive(false);
            jumpForce = 50;
        }

    }


    private void Respawn()
    {
        transform.position = startPos;
        //lives--;
        //setCountText();

        //if (lives <= 0)
        //{
            //this.enabled = false;
        //}
    }

        

    

}

