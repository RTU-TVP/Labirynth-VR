using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginButton : MonoBehaviour
{
    [SerializeField] DoorControllerByCard _door;
    bool gameBegin = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "LHand" || other.gameObject.tag == "RHand") && gameBegin == false)
        {
            StartCoroutine(_door.DoorOpener());
            gameBegin = true;
        }
    }
}
