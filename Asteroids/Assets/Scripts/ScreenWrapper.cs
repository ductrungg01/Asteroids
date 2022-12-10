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

    private void OnBecameInvisible()
    {
        Vector3 pos = this.transform.position;

        if (pos.x > ScreenUtils.ScreenRight)
        {
            this.transform.position = new Vector3(ScreenUtils.ScreenLeft, pos.y, pos.z);
        }
        else if (pos.x < ScreenUtils.ScreenLeft)
        {
            this.transform.position = new Vector3(ScreenUtils.ScreenRight, pos.y, pos.z);
        }
        else if (pos.y > ScreenUtils.ScreenTop)
        {
            this.transform.position = new Vector3(pos.x, ScreenUtils.ScreenBottom, pos.z);
        }
        else if (pos.y < ScreenUtils.ScreenBottom)
        {
            this.transform.position = new Vector3(pos.x, ScreenUtils.ScreenTop, pos.z);
        }
    }
}
