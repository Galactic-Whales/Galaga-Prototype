using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectile;

    public float moveSpeed = 30.0f;

    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;
    }
}
