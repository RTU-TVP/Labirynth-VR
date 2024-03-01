using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeightToCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float XOffset;
    [SerializeField] private float YOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        /*transform.position = _camera.position + new Vector3(_camera.forward.x, 0, _camera.forward.z).normalized * 0.1f;
        transform.position -= Vector3.up * YOffset;
        transform.localPosition -= Vector3.right * XOffset;*/
        transform.position = new Vector3(transform.position.x, _camera.position.y-YOffset, transform.position.z);
    }
}
