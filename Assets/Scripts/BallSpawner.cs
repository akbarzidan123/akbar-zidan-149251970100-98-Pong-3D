using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public int spdBall;
    private int random;
    public List<GameObject> spawnLocation;
    public List<GameObject> ballContainer = new List<GameObject>();
    private Vector3 directionBall;
    public GameObject ball;
    private Rigidbody ballRb;
    private float timer;
    public int intervalSpawn;
    void Start()
    {
        RandomBall();
        SpawnBall();
    }
    void Update()
    {
        if(timer > intervalSpawn)
        {
            RandomBall();
            SpawnBall();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    public void RandomBall()
    {
        float tempX = 0;
        float tempY = 0;
        float tempZ = 0;
        random = Random.Range(0, spawnLocation.Count);
        if(random == 0)
        {
            tempX = spawnLocation[random].transform.position.x-1f;
            tempZ = spawnLocation[random].transform.position.z+1f;
        }
        if(random == 1)
        {
            tempX = spawnLocation[random].transform.position.x+1f;
            tempZ = spawnLocation[random].transform.position.z+1f;
        }
        if(random == 2)
        {
            tempX = spawnLocation[random].transform.position.x-1f;
            tempZ = spawnLocation[random].transform.position.z-1f;
        }
        if(random == 3)
        {
            tempX = spawnLocation[random].transform.position.x+1f;
            tempZ = spawnLocation[random].transform.position.z-1f;
        }
        tempY = spawnLocation[random].transform.position.y;
        directionBall = new Vector3(tempX, tempY, tempZ);
    }
    // 0 = kiri atas
    // 1 = kanan atas
    // 2 = kiri bawah
    // 3 = kanan bawah
    public void SpawnBall()
    {
        if(ballContainer.Count < 5)
        {
            GameObject ballSpawn = Instantiate(ball, directionBall, Quaternion.identity);
            ballRb = ballSpawn.GetComponent<Rigidbody>();
            ballSpawn.transform.SetParent(gameObject.transform);
            ballContainer.Add(ballSpawn);
            AddForce();
        }
    }
    #region AddForceBall
    public void AddForce()
    {
        if(random == 0)
            {
                ballRb.AddForce(-1.5f * spdBall, 0, 1 * spdBall);
            }
            if(random == 1)
            {
                ballRb.AddForce(1 * spdBall, 0, 1.5f * spdBall);
            }
            if(random == 2)
            {
                ballRb.AddForce(-1 * spdBall, 0, -1.5f * spdBall);
            }
            if(random == 3)
            {
                ballRb.AddForce(1.5f * spdBall, 0, -1 * spdBall);
            }
    }
    #endregion
}
