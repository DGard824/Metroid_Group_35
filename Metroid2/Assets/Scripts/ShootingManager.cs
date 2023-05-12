using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Dillon Gard, Aga Megia]
 * Date: [5/12/23]
 * [Manages the shooting mechanic for the player]
 */

public class ShootingManager : MonoBehaviour
{
    //GameObject for the player projectile
    public GameObject playerProjectile;
    //Defines the heavy player projectile
    public GameObject playerProjectileHeavy;
    //Bool to define shot cooldown
    public bool ableToShoot;
    //Bool to determine when heavy bullet pickup is collided with
    public bool heavyBulletsActivated;
    


    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
     
        //If space is pushed...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //If heavy bullets are activated
            if (heavyBulletsActivated)
            {
                //Spawn heavy projectile instead of regular one
                SpawnHeavyProjectile();
            }
            else
            {
                //Spawn regular projectile if bool isn't true
                SpawnProjectile();

            }
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player collides with the heavy bullet pickup...
        if (other.transform.tag == "HeavyBulletPickup")
        {
            //Make pickup invisible
            other.gameObject.SetActive(false);
            //Set bool to true
            heavyBulletsActivated = true;
            //Start countdown till heavy bullets run out
            StartCoroutine(HeavyBulletTimer());
        }
    }

    //Spawns the player projectile
    private void SpawnProjectile()
    {
        //If the player is able to shoot after the cooldown...
        if (ableToShoot)
        {
            //Spawns the player projectile
            Instantiate(playerProjectile, transform.position, transform.rotation);
            //Makes it so the player can't shoot again until cooldown is over
            ableToShoot = false;
            //Starts cooldown
            StartCoroutine(ProjectileCooldown());
            
        }

       
    }
     
    private void SpawnHeavyProjectile()
    {
        if (ableToShoot)
        {
            //Spawns the player projectile
            Instantiate(playerProjectileHeavy, transform.position, transform.rotation);
            //Makes it so the player can't shoot again until cooldown is over
            ableToShoot = false;
            //Starts cooldown
            StartCoroutine(ProjectileCooldown());
        }
        
    }
    //Once a projectile is shot, they player must wait 1 second before shooting again
    private IEnumerator ProjectileCooldown()
    {



        yield return new WaitForSeconds(1);
        ableToShoot = true;


    }
    //Timer for how long the heavy bullets stay activated
    private IEnumerator HeavyBulletTimer()
    {
        yield return new WaitForSeconds(5);
        heavyBulletsActivated = false;
    }

    
}
