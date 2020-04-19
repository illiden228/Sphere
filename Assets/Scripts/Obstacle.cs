using UnityEngine;

public class Obstacle : Generated
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
