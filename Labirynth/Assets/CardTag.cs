using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardTag : MonoBehaviour
{
    private IXRSelectInteractable m_gameObject;
    public void ChangeTagOff()
    {
        m_gameObject = gameObject.GetComponent<XRSocketInteractorByTag>().GetOldestInteractableSelected();
        m_gameObject.transform.gameObject.GetComponent<TagChange>().TagOff();
    }
    public void ChangeTagOn()
    {
        m_gameObject.transform.gameObject.GetComponent<TagChange>().TagOn();
    }
}
