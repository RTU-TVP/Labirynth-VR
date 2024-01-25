using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Locator : MonoBehaviour
{
    public string finishTag = "Finish";
    public string keycardTag = "Keycard";
    [SerializeField] private Transform target;
    private NavMeshPath path;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _locatorOnClip;
    [SerializeField] private AudioClip _locatorErrorClip;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        target = FindTargetWithTag(keycardTag);
        path = new NavMeshPath();
        DrawPath();
        this.enabled = false;
    }

    void Update()
    {
        DrawPath();

        if (target != null && target.CompareTag(keycardTag) && Vector3.Distance(transform.position, target.position) < 3.0f)
        {
            target = FindTargetWithTag(finishTag);
            DrawPath();
        }
    }

    void DrawPath()
    {
        if (target != null)
        {
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = path.corners.Length;
            lineRenderer.SetPositions(path.corners);
        }

        if (path.corners.Length <= 0)
        {
            this.enabled = false;
        }
    }

    private void OnEnable()
    {
        _source.PlayOneShot(_locatorOnClip);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
    }

    private void OnDisable()
    {
        _source.PlayOneShot(_locatorErrorClip);

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    Transform FindTargetWithTag(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag)?.transform;
    }
}