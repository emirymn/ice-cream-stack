using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target, targetto;
    [Space]
    [SerializeField] private float moveSpeed;
    [Space]
    [SerializeField] private Vector3 followOffset;
    [SerializeField] private Vector3 rotationOffset;
    public static CameraFollower instance;

    #region EDITOR
    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        targetto = GameObject.Find("------Player").transform;
    }
    private void OnValidate()
    {
        if (target != null)
        {
            transform.position = target.position + followOffset;
        }
        transform.eulerAngles = rotationOffset;
    }
    #endregion

    #region MonoBehaviour METHODS
    private void LateUpdate()
    {
        Movement();
    }
    #endregion

    private void Movement()
    {
        if (target == null) return;
        // Vector3 targetPos = target.position + followOffset;
        Vector3 targetPos = targetto.position + followOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}