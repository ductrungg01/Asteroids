using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroids : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    const float MinImpulseForce = 0.5f;
    const float MaxImpulseForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // Random the Asteroid's sprite
        System.Random rnd = new System.Random();
        GetComponent<SpriteRenderer>().sprite = sprites[rnd.Next(sprites.Length)];
    }

    public void Initialize(Direction direction, Vector3 position)
    {
        // set the position of the asteroid
        this.transform.position = position;

        // apply impulse force to get game object moving
        
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

    public void StartMoving(Vector3 pos)
    {
        this.transform.position = pos;

        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            
            // make the localScale smaller
            Vector3 localScale = this.transform.localScale;
            localScale *= 0.5f;
            this.transform.localScale = localScale;

            // Refactor the circle collider
            this.GetComponent<CircleCollider2D>().radius /= 2.0f;

            var newAsteroid1 = Instantiate(this.gameObject);
            var newAsteroid2 = Instantiate(this.gameObject);

            newAsteroid1.GetComponent<Asteroids>().StartMoving(this.gameObject.transform.position);
            newAsteroid2.GetComponent<Asteroids>().StartMoving(this.gameObject.transform.position);

            Destroy(this.gameObject);
        }
    }
}
