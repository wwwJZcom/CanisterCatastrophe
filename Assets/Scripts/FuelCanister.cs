using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanister : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Collected.");
            Destroy(gameObject);
            ScoreSystem.scoreValue += 25;
        }
        if (other.tag == "PlayerProjectile")
        {
            Debug.Log("Projectile touched fuel.");
            Destroy(gameObject);
            ScoreSystem.scoreValue -= 10;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}