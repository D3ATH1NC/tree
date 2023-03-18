using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidController : MonoBehaviour
{
    public float spinRate = 100f;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public float spawnRadius = 10f;
    public float damage = 20f;
    public float damageCooldown = 1f;
    private float currentTime = 0f;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        // Generate a random position within the spawn radius
        Vector3 randomPos = new Vector3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()) * spawnRadius;
        randomPos.z = 0f;
        transform.position = randomPos;

        // Generate a random direction for movement
        Vector2 randomDir = new Vector2((float)random.NextDouble(), (float)random.NextDouble()).normalized;

        // Generate a random speed within the given range
        float randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);

        // Apply the random direction and speed to the asteroid's rigidbody
        Rigidbody asteroidRB = GetComponent<Rigidbody>();
        asteroidRB.velocity = new Vector3(randomDir.x, randomDir.y, 0) * randomSpeed;

        asteroidRB.AddTorque(new Vector3(0, 0, UnityEngine.Random.Range(-1f, 1f)) * spinRate);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentTime < damageCooldown)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0f;

                HealthController healthController = other.gameObject.GetComponent<HealthController>();

                if (healthController != null)
                {
                    healthController.DealDamage((int)damage);
                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * spinRate);
    }
}
