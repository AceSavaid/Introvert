using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<Transform> enemySpawns = new List<Transform>();

    public List<GameObject> items = new List<GameObject>();
    public GameObject spawnArea;
    float timer = 0;
    public float itemSpawnRate = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawn in enemySpawns)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], spawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= itemSpawnRate)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-22, 22), Random.Range(-22, 22), 0);
            GameObject spawnItem = Instantiate(items[Random.Range(0,items.Count)], this.transform.position + spawnPos, Quaternion.identity);
            timer = 0;
        }
    }
}
