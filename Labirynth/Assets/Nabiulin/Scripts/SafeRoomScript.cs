using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRoomScript : MonoBehaviour
{
    [SerializeField] private GameObject _ambient;
    [SerializeField] private GameObject _roomMusic;

    [SerializeField] private EnemyAI _enemyAI;

    private void Start()
    {
        _ambient.SetActive(true);
        _roomMusic.SetActive(false);
        _enemyAI = GameObject.FindWithTag("Monster").GetComponent<EnemyAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyAI.player = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyAI.player = GameObject.FindWithTag("Player").transform;
        }
    }
}
