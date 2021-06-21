using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner_BottomLeft: MonoBehaviour
{
    public GameObject objectToSpawn;
    
    private float randomValue;
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
            SpawnFuel();
            canSpawn = false;
            timePassed = 0.0f;
        }

        timePassed += Time.deltaTime;

        if (timePassed >= 7f)
        {
            randomChance();
        }
    }

    private void SpawnFuel()
    {
        float xPos = Random.Range((spawnBounds.size.x * -0.3f), (spawnBounds.size.x * 0.3f)) + spawnBounds.gameObject.transform.position.x;
        float zPos = Random.Range((spawnBounds.size.z * -0.3f), (spawnBounds.size.z * 0.3f)) + spawnBounds.gameObject.transform.position.z;

        Vector3 spawnPos = new Vector3(xPos, 0.0f, zPos);

        Quaternion spawnRot = new Quaternion();
        float rotationAngle = Random.Range(20.0f, 60.0f);
        spawnRot = Quaternion.Euler(0f, rotationAngle, 0f);

        Instantiate(objectToSpawn, spawnPos, spawnRot);
    }

    private void randomChance()
    {
        randomValue = Random.value;

        if (randomValue >= 0.1f && randomValue <= 0.48f)
        {
            canSpawn = true;
            Debug.Log("TRUE!");
            Debug.Log(randomValue);
            timePassed = 0.0f;
        }
        else
        {
            canSpawn = false;
            timePassed = 0.0f;
            Debug.Log(randomValue);
        }
    }
}
