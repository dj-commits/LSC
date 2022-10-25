using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    [SerializeField] public int enemyCount;
    [SerializeField] bool canSpawn;
    [SerializeField] float enemySpawnDelay;

    public GameObject player;
    public GameObject smallEnemy;
    public GameObject largeEnemy;
    public GameObject bossEnemy;
    private List<GameObject> Enemies;

    float xRNG;
    float yRNG;

    void Start()
    {
        canSpawn = true;
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // Enemy Spawn Logic
        if (enemyCount < 3)
        {
            if(canSpawn)
            {
                float xRNG = Random.Range(6, -6);
                float yRNG = Random.Range(4, -2);
                Vector3 randomSpawnLocation = new Vector3(xRNG, yRNG, 8);
                GameObject enemyClone = Instantiate(smallEnemy, randomSpawnLocation, transform.rotation);
                enemyCount++;
                canSpawn = false;
                StartCoroutine(enemySpawnTimer());
                
            }
        }
        
    }

    IEnumerator enemySpawnTimer()
    {
        //Debug.Log("Entering enemySpawnTimer Coroutine");
        yield return new WaitForSeconds(enemySpawnDelay);
        canSpawn = true;
    }
}
