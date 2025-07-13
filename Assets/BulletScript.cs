using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public LogicScript LogicScript;
    public GameObject ImpactEffect;

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
         Checks for collision with the target object
            -CompareTag is used to check if the collided object has the tag "Target"
            - If it does, it logs a message, destroys the target object, and increments the score
            - It also instantiates an impact effect at the collision point
            - Impact Prefab is parented to the pipe prefab
        */
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Target");
            Destroy(collision.gameObject); // Destroy the enemy on collision
            Destroy(gameObject); // Destroy the bullet on hit
            LogicScript.addscore(1); // Increment the score by 1

            Vector3 impactPosition = collision.transform.position; // Get the position of the collision
            impactPosition = new Vector3(impactPosition.x+1.2f, impactPosition.y, 0); // Changing X axis to shift impact closer to pipe
            GameObject impact = Instantiate(ImpactEffect, impactPosition, transform.rotation); // Instantiate impact effect
            impact.transform.SetParent(collision.transform.parent);
        }
    }
}
