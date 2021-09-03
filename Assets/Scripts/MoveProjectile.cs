using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private Rigidbody2D Projectile;

    public float moveSpeed = 10.0f;
    void Start()
    {
        Projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Projectile.velocity = new Vector2(0, 1) * moveSpeed;
    }
}
