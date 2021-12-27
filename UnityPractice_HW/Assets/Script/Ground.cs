using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GroundController groundController;
    void Start()
    {
        groundController = GameObject.FindObjectOfType<GroundController>();
        if(groundController.spawnCount != 7)
        {
            SpawnObstacle();
            SpawnCoin();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        groundController.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame

    void Update()
    {
        
    }

    public GameObject obstacle;
    public GameObject rock;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 4);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
        int rockSpawnIndex = Random.Range(4, 7);
        if (rockSpawnIndex > 5)
            ;
        else
        {
            Transform rockspawnPoint = transform.GetChild(rockSpawnIndex).transform;
            Instantiate(rock, rockspawnPoint.position, Quaternion.identity, transform);
        }
      
    }

    public GameObject coin;

    void SpawnCoin()
    {
        int coinToSpawn = 2;
        for(int i = 0; i < coinToSpawn; i++)
        {
            GameObject temp = Instantiate(coin,transform);
            temp.transform.position = GetRandomPointInColloder(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInColloder(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x), 
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z) );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInColloder(collider);
        }

        point.y = 0.8f;
        return point;
    }
}
