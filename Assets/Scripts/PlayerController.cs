using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float moveSpeed;
    [SerializeField] public float moveSpeedMultiplier;
    [SerializeField] public float timeBetweenShots;
    [SerializeField] public float shotSpeed;
    [SerializeField] public bool canShoot;
    [SerializeField] float intensityLength;

    private AudioSource audioSource;
    public AudioClip _laser;
    public AudioClip _playerDeath;
    private EnemyManager em;
    AudioManager am;

    public GameObject bullet;
    private Rigidbody2D rb;
    Light2D myLight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        myLight = GetComponent<Light2D>();
        audioSource = GetComponent<AudioSource>();
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myLight.intensity = Mathf.PingPong(Time.time, intensityLength);

        // Shooting

        if (Input.GetButton("Shoot"))
        {
            if (canShoot)
            {
                GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
                //Physics2D.IgnoreCollision(bulletClone.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
                Rigidbody2D bulletCloneRB2D = bulletClone.GetComponent<Rigidbody2D>();
                Vector2 fwd = transform.up;
                bulletCloneRB2D.AddForce(fwd * shotSpeed);
                audioSource.PlayOneShot(_laser);
                canShoot = false;
                StartCoroutine(shootWaitTimer());
                Destroy(bulletClone, 2);
            }
            
        }
    }

    private void FixedUpdate()
    {
        // Movement
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        movement *= Time.deltaTime;


        transform.Translate(movement);
       

    }

    IEnumerator shootWaitTimer()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            am.PlayerDeathSound();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            collision.gameObject.GetComponent<EnemyAI>().EnemyHit();
            Destroy(gameObject);

        }
    }
}
