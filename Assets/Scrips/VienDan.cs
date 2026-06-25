using UnityEngine;

public class VienDan : MonoBehaviour
{
    public float moveSpeed;
    public float timetoDestroy;
    Rigidbody2D rb;
    GameController controller;
    AudioSource audioSource;
    public AudioClip hitSound;
    public GameObject hitVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = FindAnyObjectByType<GameController>();
        audioSource = FindAnyObjectByType<AudioSource>();
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
            //tang diem
            controller.ScoreIncrement();
            if(audioSource && hitSound)
            {
                audioSource.PlayOneShot(hitSound);
            }
            if (hitVFX)
            {
                Instantiate(hitVFX, collision.transform.position, Quaternion.identity);

            }

            Destroy(gameObject);
            Destroy(collision.gameObject);

            Debug.Log("trung");
        } 
        else if (CompareTag("TopLimit"))
        {
            Destroy(gameObject);
        }
    }
}
