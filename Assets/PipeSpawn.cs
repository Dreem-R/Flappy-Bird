using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject thepipe;
    public float spawnrate = 5;
    private float timer = 0;
    public float heightoffset = 8;
    private Pipemove pipeMoveScript;

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

        GameObject pipeInstance = Instantiate(thepipe, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint)), transform.rotation);

        if (GameManager.Instance.currentDifficulty == Difficulty.Normal)
        {
            Pipemove pipeMoveScript = pipeInstance.GetComponent<Pipemove>();
            Transform top = pipeMoveScript.Toppipe;
            Transform bottom = pipeMoveScript.Bottompipe;

            pipeMoveScript.targetObject.SetActive(false); // Disable the target object
            top.localPosition = new Vector3(0, top.localPosition.y + pipeMoveScript.openDistance, 0);
            bottom.localPosition = new Vector3(0, bottom.localPosition.y - pipeMoveScript.openDistance, 0);
        }
        else if (GameManager.Instance.currentDifficulty == Difficulty.Easy)
        {
            Pipemove pipeMoveScript = pipeInstance.GetComponent<Pipemove>();
            Transform top = pipeMoveScript.Toppipe;
            Transform bottom = pipeMoveScript.Bottompipe;

            pipeMoveScript.targetObject.SetActive(false); // Disable the target object
            top.localPosition = new Vector3(0, top.localPosition.y + pipeMoveScript.EasyOpen, 0);//Easy Open Distance
            bottom.localPosition = new Vector3(0, bottom.localPosition.y - pipeMoveScript.EasyOpen, 0);
        }
    }

}
