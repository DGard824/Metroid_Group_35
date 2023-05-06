using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float speed = 13.0f;
    public GameObject projectileModel;
    public GameObject player;
    

    private void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    private void Update()
    {
        
        
        
            transform.position += transform.forward * speed * Time.deltaTime;
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "BlueDoor")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3);
        Destroy(projectileModel);
    }
}
