using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Objectbehaviour : MonoBehaviour
{

    [SerializeField] float _speed;

    [SerializeField] bool _isMoving;

    public GameObject _targetPoint;

    public NavMeshAgent agent;

    private void Start()
    {
        Renderer r = gameObject.GetComponent<Renderer>();

        r.enabled = false;
    }

    private void Update()
    {
        if (_isMoving)
        {
            //agent.SetDestination(_targetPoint.transform.position);
        }
    }

}



