using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform projectileSpawn;

    public GameObject projectile;
    public float nextFire = 0.1f;
    private float currentTime = 0.0f;

    void Update()
    {
        shoot();
    }

    public void shoot()
    {
        currentTime += Time.deltaTime;

        if (Input.GetButtonDown ("Fire1") && currentTime >= nextFire)
        {
            Instantiate (projectile, projectileSpawn.position, Quaternion.identity);
            currentTime = 0.0f;
        }
    }
}
    
