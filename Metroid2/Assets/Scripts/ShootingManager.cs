using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    //GameObject for the player projectile
    public GameObject playerProjectile;
    public GameObject playerProjectileHeavy;
    //Bool to define shot cooldown
    public bool ableToShoot;
    public bool heavyBulletsActivated;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heavyBulletsActivated)
            {
                SpawnHeavyProjectile();
            }
            else
            {
                SpawnProjectile();

            }
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "HeavyBulletPickup")
        {
            other.gameObject.SetActive(false);
            heavyBulletsActivated = true;
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
    private IEnumerator HeavyBulletTimer()
    {
        yield return new WaitForSeconds(9);
        heavyBulletsActivated = false;
    }

    
}
