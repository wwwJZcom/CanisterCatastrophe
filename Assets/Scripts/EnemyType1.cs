using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : MonoBehaviour
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
            Debug.Log("Player touched by enemy.");
            //other.gameObject.GetComponent<Player>().isDead = false; <--Isn't needed as this will make the player alive if health is 0 but an enemy touches it.
        }
        if (other.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
            ScoreSystem.scoreValue += 100;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}