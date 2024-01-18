using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class PlayerSound : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _footsteps;
    [SerializeField] AudioClip _death;
    [SerializeField] GameObject _heartBeat;

    [Header("Post-Proccess")]
    [SerializeField] GameObject _idleVolume;
    [SerializeField] GameObject _panicVolume;

    [SerializeField] InputActionReference inputMove;

    [SerializeField]
    float range;
    bool inRange;

    [SerializeField]
    Transform enemy;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _heartBeat.gameObject.SetActive(false);

        if(enemy == null)
        {
            enemy = GameObject.FindWithTag("Monster").transform;
        }
        else
        {
            return;
        }

        inRange = true;

        _idleVolume.gameObject.SetActive(true);
        _panicVolume.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(enemy.position, transform.position);

        if (distance <= range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        PlayHeartBeat(inRange);

        if (inputMove.action.ReadValue<Vector2>() != Vector2.zero)
        {
            FootstepsAudio();
        }
    }

    public void PlayHeartBeat(bool inLookRadius)
    {
        if (inLookRadius)
        {
            _heartBeat.gameObject.SetActive(true);
            _idleVolume.gameObject.SetActive(false);
            _panicVolume.gameObject.SetActive(true);
        }
        else
        {
            _heartBeat.gameObject.SetActive(false);
            _idleVolume.gameObject.SetActive(true);
            _panicVolume.gameObject.SetActive(false);
        }
    }

    public void FootstepsAudio()
    {
        if (!_source.isPlaying)
        {
            _source.PlayOneShot(_footsteps);
        }
    }

    public void PlayDeathAudio()
    {
        if (!_source.isPlaying)
        {
            _source.PlayOneShot(_death);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
