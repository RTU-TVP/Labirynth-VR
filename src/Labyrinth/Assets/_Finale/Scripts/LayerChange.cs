using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LayerChange : MonoBehaviour
{
    [SerializeField] private string _off="MagazineInGun";
    [SerializeField] private string _on="Magazines";
    public void IntLayerOff()
    {
        gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask(_off);
        GameObject.FindObjectOfType<UnloadGun>().GetComponent<UnloadGun>().MagazineSaveLink(gameObject);
    }
    public void IntLayerOn()
    {
        gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask(_on);
        GameObject.FindObjectOfType<UnloadGun>().MagazineForgetLink();
    }
}
