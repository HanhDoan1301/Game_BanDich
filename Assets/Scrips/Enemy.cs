using UnityEngine;

public class Enemy : MonoBehaviour

{
    public float moveSpeed;
    Rigidbody2D rb;
    GameController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeatZone"))
        {

            controller.SetGameoverState(true);
            Destroy(gameObject);
            Debug.Log("Cham");
        }
    }
}
