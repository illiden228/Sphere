using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Generated
{
    [SerializeField] private int _value;

    public int Value => _value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
