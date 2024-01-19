using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndoors : MonoBehaviour
{
    [SerializeField] private DoorControllerByCard doorControllerByCard;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorControllerByCard.PlayerInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorControllerByCard.PlayerInTrigger = false;
        }
    }
}
