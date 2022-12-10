using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float _radius;

    // Start is called before the first frame update
    void Start()
    {
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
        }
        else if (pos.x + _radius <= ScreenUtils.ScreenLeft)
        {
            this.transform.position = new Vector3(ScreenUtils.ScreenRight, pos.y, pos.z);
        }
        else if (pos.y - _radius >= ScreenUtils.ScreenTop)
        {
            this.transform.position = new Vector3(pos.x, ScreenUtils.ScreenBottom, pos.z);
        }
        else if (pos.y + _radius <= ScreenUtils.ScreenBottom)
        {
            this.transform.position = new Vector3(pos.x, ScreenUtils.ScreenTop, pos.z);
        }
    }
}
