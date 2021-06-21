using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerType1_Top : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnRate;

    public bool increaseAt2500;
    public bool increaseAt5000;
    public bool increaseAt7500;
    public bool increaseAt10000;
    private float timePassed;
    private bool canSpawn;
    private BoxCollider spawnBounds;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        increaseAt2500 = false;
        increaseAt5000 = false;
        increaseAt7500 = false;
        increaseAt10000 = false;
        spawnBounds = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            SpawnEnemy();
            canSpawn = false;
            timePassed = 0.0f;
        }

        if (ScoreSystem.scoreValue >= 2500)
        {
            if (increaseAt2500 = false)
            {
                spawnRate -= 0.5f;
                increaseAt2500 = true;
            }
            else
            {
                increaseAt2500 = true;
            }
        }

        if (ScoreSystem.scoreValue > 5000)
        {
            if (increaseAt5000 = false)
            {
                spawnRate -= 0.5f;
                increaseAt2500 = true;
            }
            else
            {
                increaseAt5000 = true;
            }
        }

        if (ScoreSystem.scoreValue > 7500)
        {
            if (increaseAt7500 = false)
            {
                spawnRate -= 0.5f;
                increaseAt2500 = true;
            }
            else
            {
                increaseAt7500 = true;
            }
        }

        if (ScoreSystem.scoreValue > 10000)
        {
            if (increaseAt10000 = false)
            {
                spawnRate -= 1.5f;
                increaseAt2500 = true;
            }
            else
            {
                increaseAt10000 = true;
            }
        }


        timePassed += Time.deltaTime;

        if (timePassed >= spawnRate)
        {
            canSpawn = true;
        }
    }

    private void SpawnEnemy()
    {
        float xPos = Random.Range((spawnBounds.size.x * -0.5f), (spawnBounds.size.x * 0.5f)) + spawnBounds.gameObject.transform.position.x;
        float zPos = Random.Range((spawnBounds.size.z * -0.5f), (spawnBounds.size.z * 0.5f)) + spawnBounds.gameObject.transform.position.z;

        Vector3 spawnPos = new Vector3(xPos, 0.0f, zPos);

        Quaternion spawnRot = new Quaternion();
        float rotationAngle = Random.Range(170.0f, 190.0f);
        spawnRot = Quaternion.Euler(0f, rotationAngle, 0f);

        Instantiate(enemyToSpawn, spawnPos, spawnRot);
    }
}
