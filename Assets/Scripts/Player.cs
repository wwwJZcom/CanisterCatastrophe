using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    public float Timer;

    public int maxHealth = 100;
    public int currentHealth;
    public int delayAmount = 1;
    public int deathCount = 3;

    public HealthBar healthBar;
    public GameObject gameOverScreen;
    public GameObject HUD;

    public bool isTouchingEnemy;

    [HideInInspector]
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        ScoreSystem.scoreValue = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isDead = false;
        isTouchingEnemy = false;
        gameOverScreen.SetActive(false);
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
        if (currentHealth == 0)
        {
            isDead = true;
        }


        if (!isDead)
        {
            isTouchingEnemy = false;

            // The following are movement keys (mapped to wasd)
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.right * movementSpeed * -1 * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * movementSpeed * -1f * Time.deltaTime, Space.World);
            }

            // The following are rotation keys (mapped to the arrows)
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up * rotationSpeed * -1 * Time.deltaTime);
            }

            // The following makes the health decrease every second, since delayAmount = 1 (as defined at the top of the script)
            Timer += Time.deltaTime;
            if (Timer >= delayAmount)
            {
                Timer = 0f;
                currentHealth--;
                healthBar.SetHealth(currentHealth);
            }

            // Restricts player movement to inside the border. If they travel further than intended, they will be put back in bounds.
            // z axis
            if (transform.position.z <= -23.25f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -23.25f);
            }
            else if (transform.position.z >= 23.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 23.0f);
            }

            // x axis
            if (transform.position.x <= -42.5f)
            {
                transform.position = new Vector3(-42.5f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= 42.5f)
            {
                transform.position = new Vector3(42.5f, transform.position.y, transform.position.z);
            }
        }

        if (isDead)
        {
            Time.timeScale -= 0.01f;
            if (Time.timeScale <= 0.001f)
            {
                Timer += Time.deltaTime;
                Time.timeScale = 0.002f;
                gameOverScreen.SetActive(true);
                HUD.SetActive(false);
            }
        }

    }

    // The following is executed once the Player and an object tagged as "Enemy" collide
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isTouchingEnemy = true;
            Debug.Log("Ouch!");
            TakeDamage(8);
            ScoreSystem.scoreValue -= 15;
        }

        if (other.tag == "Asteroid")
        {
            isTouchingEnemy = true;
            Debug.Log("Oof!");
            TakeDamage(12);
            ScoreSystem.scoreValue -= 20;
        }

        if (other.tag == "Fuel")
        {
            Debug.Log("Yes!");
            increaseHealth(19);
        }
    }

    // This part of code defines what the function TakeDamage does
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void increaseHealth(int health)
    {
        if (currentHealth > 0)
        {
            currentHealth += health;
            healthBar.SetHealth(currentHealth);
            if (currentHealth > 101)
            {
                currentHealth = 100;
            }
        }
        else
        {
            currentHealth = 0;
        }
    }
}
