using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHItChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I'm Attack YOU!!!");
            other.gameObject.GetComponent<PlayerSound>().PlayDeathAudio();
        }
    }
}
