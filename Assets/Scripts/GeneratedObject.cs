using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneratedObject : MonoBehaviour
{
    private float _speed;

    public void Init(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
