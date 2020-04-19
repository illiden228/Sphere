using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generated : MonoBehaviour
{
    protected float _speed;

    public void Init(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
