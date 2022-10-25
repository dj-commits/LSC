using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyAI : MonoBehaviour
{
    EnemyManager em;
    Transform player;
    Light2D myLight;
    [SerializeField] float enemyMovementTimer;
    [SerializeField] float intensityLength;
    private AudioSource audioSource;
    public AudioClip _smallEnemyDeathClip;
    [SerializeField] float speed;  
    public bool canMove;
    // Start is called before the first frame update
    void Awake()
    {
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        canMove = true;
        myLight = GetComponent<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        myLight.intensity = Mathf.PingPong(Time.time, intensityLength);

        // Movement
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            StartCoroutine(enemyMovementDelay());
        }
    }

    public void EnemyHit()
    {
        canMove = false;
        em.enemyCount--;        
        Destroy(gameObject);
    }

    IEnumerator enemyMovementDelay()
    {
        //Debug.Log("Entering enemyMovementDelay Coroutine");
        yield return new WaitForSeconds(enemyMovementTimer);
        canMove = true;
    }
}
