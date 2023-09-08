using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 25f;
    private float shootDelay = 0;

    public GameObject hitEffect;
    public GameObject gun;

    public AudioSource hitSFX;
    void Start()
    {
        
    }
    void Update()
    {
        // If left mouse button is pressed the player will shoot.
        if(Input.GetButtonDown("Fire1") && Time.time >= shootDelay)
        {
            shootDelay = Time.time;
            Shoot();
        }
    }
    // Shoot function uses raycast to do damage & kill the enemy.
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hit))
        {
            hitSFX.Play();

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            // Instantiates a particle effect when raycast hits something and destroys it after 2 seconds.
            GameObject impactGO = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
