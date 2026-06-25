using UnityEngine;

public class VienDan : MonoBehaviour
{
    public float moveSpeed;
    public float timetoDestroy;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timetoDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            Debug.Log("trung");
        } 
    }
}
