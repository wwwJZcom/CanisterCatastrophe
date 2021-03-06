using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanisterSpawner_Left : MonoBehaviour
{
    public GameObject objectToSpawn;
    
    private float randomValue;
    private float timePassed;
    public bool canSpawn;
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

        if (timePassed >= 11f)
        {
            randomChance();
        }
    }

    private void SpawnFuel()
    {
        float xPos = Random.Range((spawnBounds.size.x * -0.5f), (spawnBounds.size.x * 0.5f)) + spawnBounds.gameObject.transform.position.x;
        float zPos = Random.Range((spawnBounds.size.z * -0.5f), (spawnBounds.size.z * 0.5f)) + spawnBounds.gameObject.transform.position.z;

        Vector3 spawnPos = new Vector3(xPos, 0.0f, zPos);

        Quaternion spawnRot = new Quaternion();
        float rotationAngle = Random.Range(250.0f, 290.0f);
        spawnRot = Quaternion.Euler(0f, rotationAngle, 0f);

        Instantiate(objectToSpawn, spawnPos, spawnRot);
    }

    private void randomChance()
    {
        randomValue = Random.value;

        if (randomValue >= 0.1f && randomValue <= 0.41f)
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
