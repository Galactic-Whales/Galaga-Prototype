using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] protected Transform SpawnT;

    [SerializeField] protected GameObject projectilePrefab;

    public Projectile Shoot()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, SpawnT.position, Quaternion.identity);

        if (projectileInstance != null)
        {
            return projectileInstance.GetComponent<Projectile>();
        }

        return null;
    }
}
    
