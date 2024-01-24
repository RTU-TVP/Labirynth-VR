using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UnloadEnd : MonoBehaviour
{
    [SerializeField] private string layer;


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.tag == "Gun MagazineA")
        {
            var x = other.gameObject.GetComponentInParent<XRGrabInteractable>();
            other.transform.parent.tag = "Gun Magazine";
            x.interactionLayers = InteractionLayerMask.GetMask(layer);
        }
    }
}
