using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTargetReach : MonoBehaviour
{
    [SerializeField] private float _reachPointOffset = 0.002f;
    [SerializeField] private Transform _target;
    [SerializeField] private UnityEvent Reached;
    [SerializeField] private bool _wasReached = false;
    private void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, _target.position);
        if (dist < _reachPointOffset)
        {
            if (!_wasReached)
            {
                Reached.Invoke();
                _wasReached = true;
            }
        }
        else 
        {
            _wasReached = false;
        }
    }
}
