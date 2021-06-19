using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Active : MonoBehaviour
{
    //Needed to reference an enemy spawner that this script will be using.
    public GameObject enemySpawner;
    public float timeToSpawn;
    public float timeToAdd;
    public bool activeCheck;

    void Start()
    {
        //When the game begins, have the defined spawner set as inactive.
        enemySpawner.SetActive(false);
    }

    void Update()
    {
        if (timeToSpawn + timeToAdd < 30)
        {
            timeToAdd += 1;
        }
        else if (timeToSpawn + timeToAdd >= 30)
        {
            enemySpawner.SetActive(true);
        }
    }
}
