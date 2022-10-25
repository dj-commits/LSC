using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    EnemyManager em;
    EnemyAI enemyAI;
    // Start is called before the first frame update
    void Awake()
    {
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().EnemyHit();
            em.SmallEnemyDeathSound();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
