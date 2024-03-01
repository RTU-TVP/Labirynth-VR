using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    [SerializeField] DoorControllerByCard _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Keycard")
        {
            StartCoroutine(_door.DoorOpener()); }
    }
}
