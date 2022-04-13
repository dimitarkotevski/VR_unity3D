using System.Collections;
using UnityEngine;

public class movingBoxex : MonoBehaviour
{
    public Vector3 a, b;
    public float deltaTime = 1f / 30f, currentTime, x1, x2;
    public SpriteRenderer SR;
    GameObject newSprite;
    void Start()
    {
        InvokeRepeating("UpdateDestiny", 0f, 3f);
        InvokeRepeating("Move", 0f, deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col) // if object collides with screen bounds then change destination to middle of the screen.
    {
        b = new Vector3(0, 0, 0);
    }

    void Move()
    {
        currentTime += deltaTime;
        gameObject.transform.position = Vector3.Lerp(a, b, currentTime);
    }

    void UpdateDestiny()
    {
        currentTime = 0.0f;
        a = gameObject.transform.position;
        x1 = a.x;
        b = gameObject.transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
        x2 = b.x;
        if (x2 < x1)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}