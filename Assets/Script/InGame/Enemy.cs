using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer bodyMeshRender, jacketMeshRender, pantsMeshRender;
    [SerializeField] private Material litMaterial;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem effect;
    [SerializeField] private Walk walk;
    [SerializeField] private Transform enemyGroupTransform, enemyTransform;
    private OutGameUIPresenter outGameUIPresenter;

    private const int force = 1000;

    private void Start()
    {
        outGameUIPresenter = GameObject.FindWithTag("Presenter").GetComponent<OutGameUIPresenter>();
    }

    public void BulletHit()
    {
        outGameUIPresenter.NumberOfSniperShots();

        enemyTransform.parent = enemyGroupTransform;

        if (walk != null)
        {
            walk.enabled = false;
        }

        effect.Play();

        bodyMeshRender.sharedMaterial = litMaterial;
        if (jacketMeshRender != null) jacketMeshRender.sharedMaterial = litMaterial;
        if (pantsMeshRender != null) pantsMeshRender.sharedMaterial = litMaterial;

        animator.enabled = false;

        _rigidbody.AddForce((Vector3.up + Vector3.back) * force, ForceMode.Acceleration);
    }
}
