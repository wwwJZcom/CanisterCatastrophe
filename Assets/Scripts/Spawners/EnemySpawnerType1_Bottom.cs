using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerType1_Bottom : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnRate;

    private float timePassed;
    private bool canSpawn;
    private BoxCollider spawnBounds;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
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

        timePassed += Time.deltaTime;

        if (timePassed >= spawnRate)
            canSpawn = true;
    }

    private void SpawnEnemy()
    {
        float xPos = Random.Range((spawnBounds.size.x * -0.5f), (spawnBounds.size.x * 0.5f)) + spawnBounds.gameObject.transform.position.x;
        float zPos = Random.Range((spawnBounds.size.z * -0.5f), (spawnBounds.size.z * 0.5f)) + spawnBounds.gameObject.transform.position.z;

        Vector3 spawnPos = new Vector3(xPos, 0.0f, zPos);

        Quaternion spawnRot = new Quaternion();
        float rotationAngle = Random.Range(0.1f, 20.0f);
        spawnRot = Quaternion.Euler(0f, rotationAngle, 0f);

        Instantiate(enemyToSpawn, spawnPos, spawnRot);
    }
}
