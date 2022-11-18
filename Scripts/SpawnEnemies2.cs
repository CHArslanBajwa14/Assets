using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemies2 : MonoBehaviour
{
    public  GameObject[] enemyPrefabs;
   

    


    private float spawnPosX=4.88f;
    private float spwanPosZ=4.22f;
    //the position in Y direction in which cubes and balls will spawn

    private float startDelay=1f;
    //after which time function will be called

    private float spawnInterval=8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemies",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomEnemies()
    {
        int enemyIndex=Random.Range(0,enemyPrefabs.Length);
        //it wil create the array of objects to be spawned

        Vector3 spawnPos=new Vector3(Random.Range(spawnPosX,spwanPosZ),spawnPosX,spwanPosZ);
        //it will define the position and limit of spawning
    
    Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
     }
        
}

