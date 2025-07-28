using Unity.VisualScripting;
using UnityEngine;

public class Birdscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody2D;
    public UI_Script ui_script;
    public float flapspeed;
    public LogicScript LogicScript;
    public bool isBirdAlive = true;
    private bool isImmune = false;
    private float immuneDuration = 3f;
    private float immuneCooldown = 15f;
    private float lastAbilityUseTime = -Mathf.Infinity;
    Sound_Manager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Soundfx").GetComponent<Sound_Manager>();
    }
    void Start()
    {

        LogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isBirdAlive)
        {
            myRigidbody2D.linearVelocity = Vector2.up * flapspeed;
            soundManager.PlaySFX(soundManager.flap);
        }
        else if (Input.GetKeyDown(KeyCode.E) && Time.time >= lastAbilityUseTime + immuneCooldown)
        {
            Debug.Log("E pressed");
            ActivateImmunity();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            LogicScript.pause();
        }

        if ((myRigidbody2D.transform.position.y > 4.4 || myRigidbody2D.transform.position.y < -5) && isBirdAlive == true)
        {
            isBirdAlive = false;
            LogicScript.gameoverscreen();
        }

    }
    private void ActivateImmunity()
    {
        isImmune = true;
        lastAbilityUseTime = Time.time;

        // Change to immune layer
        gameObject.layer = LayerMask.NameToLayer("ImmuneBIrd");

        // visual effect
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

        Invoke(nameof(EndImmunity), immuneDuration);
        ui_script.GhostActive();
    }

    private void EndImmunity()
    {
        isImmune = false;

        gameObject.layer = LayerMask.NameToLayer("Bird");

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
    public bool getbird()
    {
        return isBirdAlive;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBirdAlive == true && collision.gameObject.layer == LayerMask.NameToLayer("Hittable"))
        {
            soundManager.PlaySFX(soundManager.death);
            LogicScript.gameoverscreen();
            isBirdAlive = false;
        }
    }
}
