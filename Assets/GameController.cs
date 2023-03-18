using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject ship;
    private GameObject asteroid;

    public float maxRange = 10f;
    public float minRange = 5f;
    public float maximumScale = 10f;
    public float minimumScale = 5f;
    public float spawnInterval = 3f;

    public Vector3 screenCenter;

    public float gameOverDelay = 1f;
    public float gameOverExpire = 10f;

    public GameObject scoreValue;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    bool isPlayerAlive;
    float time = 0.0f;
    float minimumY;
    float maximumY;
    float minimumX;
    float maximumX;


    void Start()
    {
        
        // Setting the active panel
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);

        // Instantiating player
        ship = Instantiate(ship, new Vector3(0, 0, 0), Quaternion.Euler(-90, 0, 0));
        screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        this.minimumY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).y;
        this.maximumY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -Camera.main.transform.position.z)).y;
        this.minimumX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).x;
        this.maximumX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -Camera.main.transform.position.z)).x;


    }

    public Vector3 GetNewPosition(Vector3 position)
    {
                return new Vector3(screenCenter.x - position.x, screenCenter.y - position.y, 0);
            }

    bool FindPlayer
    {
        get
        {
            Collider[] colliders = ship.GetComponents<Collider>();
            Collider collider = colliders[0].isTrigger ? colliders[0] : colliders[1];
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            return GeometryUtility.TestPlanesAABB(planes, collider.bounds);
        }
    }

    public GameObject Asteroid { get => asteroid; set => asteroid = value; }

    // Update is called once per frame
    void Update()
    {
        if (!FindPlayer)
        {
            ship.transform.position = GetNewPosition(ship.transform.position);
        }

        time += Time.deltaTime;

        if (time >= spawnInterval)
        {
            time = time - spawnInterval;

        }
    }
    


}






