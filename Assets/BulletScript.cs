using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed; // Set the bullet's velocity in the direction it's facing
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x > 10)
        {
            Debug.Log("Bullet Deleted");
            Destroy(gameObject); // Destroy the bullet if it goes out of bounds
        }
    }
}
