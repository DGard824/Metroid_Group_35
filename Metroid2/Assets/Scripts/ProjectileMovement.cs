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
        //CHANGE SO THAT IT INSTANTIATES ACCORDING TO THE FRONT OF THE PLAYER
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3);
        Destroy(projectileModel);
    }
}
