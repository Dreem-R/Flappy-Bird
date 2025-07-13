using System;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bird;
    public GameObject bulletPrefab;
    public Birdscript Birdscript;

    private void Start()
    {
        Bird = GameObject.FindWithTag("Player");
        Birdscript = Bird.GetComponent<Birdscript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Birdscript.getbird())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
