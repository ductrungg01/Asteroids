using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed = 200.0f;
    private float _bulletLifeTime = 2.0f;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = this.AddComponent<Timer>();
        timer.Duration = _bulletLifeTime;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Destroy(this.gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * _bulletSpeed);
    }
}
