using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    public int health = 10;
    private Vector3 startPos;
    private float speed = 2;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
    private void followPlayer()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, Player.transform.position, step, 0.0f);
        Vector3 movePoint = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        movePoint = new Vector3(movePoint.x, transform.position.y, movePoint.z);
        transform.position = movePoint;

        transform.LookAt(Player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerProjectile")
        {
            //Reduce health by 3 
            health -= 3;
            if (health == 0)
            {
                gameObject.SetActive(false);
            }
        }

        if (other.transform.tag == "PlayerProjectileHeavy")
        {
            gameObject.SetActive(false);

        }
    }
}
