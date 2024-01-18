using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderOffScript : MonoBehaviour
{
    [SerializeField] private XROffsetGrabInteractable slider;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Gun") { slider.enabled = false; }
    }
}
