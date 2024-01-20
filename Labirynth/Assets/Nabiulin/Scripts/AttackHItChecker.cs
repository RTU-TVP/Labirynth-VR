using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHItChecker : MonoBehaviour
{
    [SerializeField] GameObject _labirintPlayer;
    [SerializeField] GameObject _losePlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _labirintPlayer.SetActive(false);
            _losePlayer.SetActive(true);
            other.gameObject.GetComponent<PlayerSound>().PlayDeathAudio();
        }
    }
}
