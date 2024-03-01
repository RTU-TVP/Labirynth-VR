using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UnloadGun : MonoBehaviour
{
    [SerializeField] private InputActionReference _unloadBtn;
    [SerializeField] private GameObject _magazine;

    public void MagazineSaveLink(GameObject m) {_magazine = m;}
    public void MagazineForgetLink() {_magazine = null;}
    IEnumerator Unload()
    {
        if (_magazine != null) {
            _magazine.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Nothing");
            _magazine.GetComponent<Magazine>().autoUnload = true;
            yield return new WaitForSeconds(0.5f);
            _magazine.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Magazines");
            _magazine.GetComponent<Magazine>().autoUnload = false;
            _magazine = null;
        }
        yield return null;
    }

    private void Update()
    {
        if (_unloadBtn.action.triggered) { StartCoroutine(Unload()); }
    }
}
