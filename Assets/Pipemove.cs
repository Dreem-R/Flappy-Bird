using UnityEngine;

public class Pipemove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movespeed = 5;
    public float deadpoint = -10;
    public Transform Toppipe;
    public Transform Bottompipe;
    public bool isOpening = false;
    public float openDistance = 10f;
    public float openSpeed = 30f;

    private Vector3 topTarget;
    private Vector3 bottomTarget;
    private bool targetsSet = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * movespeed) * Time.deltaTime;
        
       if (isOpening)
        {
            Debug.Log("Pipe is Opening");
            movePipe();
        }
        else if (transform.position.x < deadpoint)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    public void movePipe()
    {
        Toppipe.localPosition = Vector3.MoveTowards(Toppipe.localPosition, topTarget, Time.deltaTime * openSpeed);
        Bottompipe.localPosition = Vector3.MoveTowards(Bottompipe.localPosition, bottomTarget, Time.deltaTime * openSpeed);

        //Stop opening once both pipes reached target
        if (Toppipe.localPosition == topTarget && Bottompipe.localPosition == bottomTarget)
        {
            isOpening = false;
            Debug.Log("Pipe Finished Opening");
        }
    }
    public void PipeOpen()
    {
        if (!targetsSet)
        {
            topTarget = new Vector3(0, Toppipe.localPosition.y + openDistance, 0);
            bottomTarget = new Vector3(0, Bottompipe.localPosition.y - openDistance, 0);
            targetsSet = true;
        }
        isOpening = true;
        Debug.Log("PipeOpen Called");
    }
}
