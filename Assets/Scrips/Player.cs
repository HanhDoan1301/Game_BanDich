using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public GameObject VienDan;
    public Transform shootingPoint;

    public float fireRate = 0.2f;   // 0.2 giây bắn 1 viên
    private float nextFireTime = 0f;

    public AudioSource audioSource;
    public AudioClip shootingSound;

    GameController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.IsGameover())
            return;
        float xDix = Input.GetAxisRaw("Horizontal");
        if (xDix < 0 && transform.position.x <= -7.8 || xDix > 0 && transform.position.x >= 7.8)
            return;
        transform.position += Vector3.right * moveSpeed * xDix * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    public void shoot()
    {
        if(VienDan && shootingPoint )
        {
            if(audioSource && shootingPoint)
            {
                audioSource.PlayOneShot(shootingSound);
            }
            Instantiate(VienDan, transform.position, Quaternion.identity);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            controller.SetGameoverState(true);
            Destroy(collision.gameObject);

            Debug.Log("Ket thuc");
        }
    }
}
