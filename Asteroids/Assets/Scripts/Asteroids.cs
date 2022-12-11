using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        // Random the Asteroid's sprite
        System.Random rnd = new System.Random();
        GetComponent<SpriteRenderer>().sprite = sprites[rnd.Next(sprites.Length)];
    }

    public void Initialize(Direction direction)
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 30);
        switch (direction)
        {
            case Direction.Up: angle += 75; break;
            case Direction.Left: angle += 150; break;
            case Direction.Down: angle += 225; break;
            case Direction.Right: angle += 300; break;
        }
        angle *= Mathf.Deg2Rad;

        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }
}
