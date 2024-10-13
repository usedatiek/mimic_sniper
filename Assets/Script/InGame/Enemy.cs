using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer bodyMeshRender, jacketMeshRender, pantsMeshRender;
    [SerializeField] private Material litMaterial;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Walk walk;
    [SerializeField] private Transform enemyGroupTransform, enemyTransform;

    private bool isEnd;
    private OutGameUIPresenter outGameUIPresenter;

    private void Start()
    {
        outGameUIPresenter = GameObject.FindWithTag("Presenter").GetComponent<OutGameUIPresenter>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet") && !isEnd)
        {
            isEnd = true;

            outGameUIPresenter.NumberOfSniperShots();

            enemyTransform.parent = enemyGroupTransform;

            if (walk != null)
            {
                walk.enabled = false;
            }

            col.gameObject.SetActive(false);
            _particleSystem.Play();

            bodyMeshRender.material = litMaterial;
            if (jacketMeshRender != null) jacketMeshRender.material = litMaterial;
            if (pantsMeshRender != null) pantsMeshRender.material = litMaterial;

            animator.enabled = false;

            _rigidbody.AddForce((Vector3.up + Vector3.back) * 1000, ForceMode.Acceleration);
        }
    }
}
