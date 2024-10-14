using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform myTransfrom;
    [SerializeField] private int distance, time;

    private void Start()
    {
        Vector3 destination = myTransfrom.position + myTransfrom.forward * distance;
        myTransfrom.DOMove(destination, time);
    }
}
