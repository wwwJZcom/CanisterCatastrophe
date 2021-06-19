using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectileObject;

    public float refireRate;
    private float timePassed;
    private bool canShoot;

    private void Start()
    {
        canShoot = true;
        timePassed = 0.0f;
    }

    void Update()
    {
        // Spacebar is used to shoot
        if ((Input.GetKey(KeyCode.Space)) && (canShoot == true))
        {
            Shoot();
            canShoot = false;
            timePassed = 0.0f;
        }

        timePassed += Time.deltaTime;

        if (timePassed >= refireRate)
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        if (!transform.root.GetComponent<Player>().isDead)
        {
            Instantiate(projectileObject, transform.position, transform.rotation);
        }
    }

}