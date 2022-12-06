using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    #region
    Rigidbody2D _rb;
    Vector2 thrustDirection = new Vector2(1, 0);

    [SerializeField]
    private float _thrustForce = 50.0f;
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
    }
}
