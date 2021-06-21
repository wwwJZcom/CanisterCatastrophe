using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
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
            Debug.Log("Player Touched. Oof.");
            ScoreSystem.scoreValue -= 15;
        }
        if (other.tag == "PlayerProjectile")
        {
            Debug.Log("Projectile touched Asteroid. Ineffective.");
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}