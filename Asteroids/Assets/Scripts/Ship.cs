using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    #region Fields
    Rigidbody2D _rb;
    float _radius;
    Vector2 thrustDirection = new Vector2(1, 0);
    float _rotateDegreesPerSecond = 100.0f;

    [SerializeField]
    private float _thrustForce = 20.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        CircleCollider2D _circleCollider = this.GetComponent<CircleCollider2D>();
        _radius = _circleCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;

        if (pos.x - _radius >= ScreenUtils.ScreenRight)
        {
            this.transform.position = new Vector3(ScreenUtils.ScreenLeft, pos.y, pos.z);
        } else if (pos.x + _radius <= ScreenUtils.ScreenLeft)
        {
            this.transform.position = new Vector3(ScreenUtils.ScreenRight, pos.y, pos.z);
        } else if (pos.y - _radius >= ScreenUtils.ScreenTop)
        {
            this.transform.position = new Vector3(pos.x, ScreenUtils.ScreenBottom, pos.z);
        } else if (pos.y + _radius <= ScreenUtils.ScreenBottom)
        {
            this.transform.position = new Vector3(pos.x, ScreenUtils.ScreenTop, pos.z);
        }
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
        }
    }
}
