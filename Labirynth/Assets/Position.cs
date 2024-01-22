using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetXZ;
    private void FixedUpdate()
    {
        transform.position = _camera.position + Vector3.down * offsetY + new Vector3(_camera.forward.x, 0, _camera.forward.z).normalized * offsetXZ;

        transform.rotation = new Quaternion(0, _camera.rotation.y, 0, _camera.rotation.w);
    }
}
