using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public GameObject VienDan;
    public Transform shootingPoint;

    public float fireRate = 0.2f;   // 0.2 giây bắn 1 viên
    private float nextFireTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            Instantiate(VienDan, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ket thuc");
        }
    }
}
