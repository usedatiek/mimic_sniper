using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 0.01f;

    void Update()
    {
        _transform.position += _transform.forward * _speed;
    }
}
