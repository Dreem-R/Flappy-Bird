using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject thepipe;
    public float spawnrate = 5;
    private float timer = 0;
    public float heightoffset = 8;
    public float openDistance = 2f;
    public float openSpeed = 3f;

    void Start()
    {
        spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnpipe();
            timer = 0;
        }
    }

    void spawnpipe()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;

        Instantiate(thepipe, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint)), transform.rotation);

    }

}
