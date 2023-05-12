using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dillon Gard, Aga Megia]
 * Date: [5/12/23]
 * [Handles the movement of the regular projectile]
 */
public class ProjectileMovement : MonoBehaviour
{
    //Speed of projectile
    private float speed = 13.0f;
    //Defines the projectile model
    public GameObject projectileModel;
    //Defines player model
    public GameObject player;
    

    private void Start()
    {
        //Once projectile is spawned, the countdown till it is destroyed starts
        StartCoroutine(DestroyProjectile());
    }

    private void Update()
    {
        
        
        //Makes the projectile move forward
            transform.position += transform.forward * speed * Time.deltaTime;
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the projectile hits a blue door...
        if (other.transform.tag == "BlueDoor")
        {
            //Disable the door
            other.gameObject.SetActive(false);
            //Destroy prijectile
            Destroy(gameObject);
        }
        //If the projectile hits a red door
        if (other.transform.tag == "RedDoor")
        {
            //Destroy projectile only because regular bullets can't destroy red doors
            Destroy(gameObject);
        }
    }

    //Timer for bullet destruction after spawn in
    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(projectileModel);
    }
}
