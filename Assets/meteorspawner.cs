using UnityEngine;

public class meteorspawner : MonoBehaviour
{
    public GameObject Meteor;
    public float spawnrate = 5;
    private float timer = 0;
    private float scale_offset = 0.05f;
    private float scale = 0.06f;
    private float y_lower = -4.5f;
    private float y_upper = 4.5f;
    private meteormove movescript;

    void Start()
    {
        spawnmeteor();
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
            spawnmeteor();
            timer = 0;
        }
    }


    void spawnmeteor()
    {
        GameObject meteorInstance = Instantiate(Meteor, new Vector3(9f, Random.Range(y_lower, y_upper)), transform.rotation);
        
        float randomScale = Random.Range(scale, scale + scale_offset);
        meteorInstance.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

}
