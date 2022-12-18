using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyForce(Vector2 direction)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * _bulletSpeed);
    }
}
