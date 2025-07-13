using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public LogicScript LogicScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed; // Set the bullet's velocity in the direction it's facing
        LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         Checks for collision with the target object.
        */
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Target");
            Destroy(collision.gameObject); // Destroy the enemy on collision
            Destroy(gameObject); // Destroy the bullet on hit
            LogicScript.addscore(1); // Increment the score by 1
        }
    }
}
