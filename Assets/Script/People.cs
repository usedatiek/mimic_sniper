using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer bodyMeshRender, jacketMeshRender, pantsMeshRender;
    [SerializeField] private Material litMaterial;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Walk walk;
    [SerializeField] private GameObject peopleGameObject;

    private bool isEnd;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet") && !isEnd)
        {
            isEnd = true;

            GameObject.FindWithTag("PeopleManager").GetComponent<PeopleManager>().DefeatedCounts();
            GameObject.FindWithTag("UiManager").GetComponent<UiManager>().CameraChanger();

            Transform peopleGroupTransform = GameObject.FindWithTag("PeopleGroup").gameObject.transform;

            peopleGameObject.transform.parent = peopleGroupTransform;


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
