using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _footsteps;
    [SerializeField] AudioClip _death;
    [SerializeField] GameObject _heartBeat;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _heartBeat.gameObject.SetActive(false);
    }

    public void PlayHeartBeat(bool isLookRadius)
    {
        if (isLookRadius)
        {
            _heartBeat.gameObject.SetActive(true);
        }
        else
        {
            _heartBeat.gameObject.SetActive(false);
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
}
