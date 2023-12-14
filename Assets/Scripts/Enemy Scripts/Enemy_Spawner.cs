using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy2;
    public int enemyCount = 20;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyCount; i++) 
        {
            GameObject enemy = Instantiate(enemy2, transform.position, Quaternion.identity);
        }

    }
}