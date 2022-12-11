using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    #region Fields
    Rigidbody2D _rb;
    
    Vector2 thrustDirection = new Vector2(1, 0);
    float _rotateDegreesPerSecond = 100.0f;

    [SerializeField]
    private float _thrustForce = 20.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            _rb.AddForce(thrustDirection * _thrustForce);
        }

        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            float rotationAmount = _rotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
            float angle = transform.rotation.eulerAngles.z * (Mathf.PI / 180.0f);
            thrustDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
