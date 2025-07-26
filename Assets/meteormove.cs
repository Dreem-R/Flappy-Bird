using UnityEngine;

public class meteormove : MonoBehaviour
{
    private float movespeed = 15;
    private float gravity = 4f;
    public float deadpoint = -10;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * movespeed) * Time.deltaTime;
        transform.position = transform.position + (new Vector3(0,-0.4f,0) * gravity) * Time.deltaTime;
        if (transform.position.x < deadpoint)
        {
            Debug.Log("meteor Deleted");
            Destroy(gameObject);
        }
    }

}
