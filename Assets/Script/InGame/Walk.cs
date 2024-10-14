using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private int distance, time;

    private void Start()
    {
        Vector3 destination = _transform.position + _transform.forward * distance;
        _transform.DOMove(destination, time);
    }
}
