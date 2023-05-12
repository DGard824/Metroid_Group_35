using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Dillon Gard, Aga Megia]
 * Date: [5/12/23]
 * [Handles movement of heavy projectile]
 */
public class HeavyProjectileMovement : MonoBehaviour
{
    //Variable for speed of projectile
    private float speed = 13.0f;
    //Defines the projectile model
    public GameObject projectileModel;
    //Defines the player model
    public GameObject player;


    private void Start()
    {
        //Starts countdown until projectile is destroyed
        StartCoroutine(DestroyProjectile());
    }

    private void Update()
    {


        //Makes projectile move forward at defines rate
        transform.position += transform.forward * speed * Time.deltaTime;



    }

    private void OnTriggerEnter(Collider other)
    {
        //If projectile collides with blue door, it destroys the blue door 
        if (other.transform.tag == "BlueDoor")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //If the projectile collides with a red door...
        if (other.transform.tag == "RedDoor")
        {
            //Disable the door
            other.gameObject.SetActive(false);
            //Destroy the projectile
            Destroy(gameObject);
        }
    }

    //Timer for projectile destruction after spawn in
    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(projectileModel);
    }
}
