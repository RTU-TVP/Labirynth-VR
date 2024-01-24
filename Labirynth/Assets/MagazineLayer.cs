using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazineLayer : MonoBehaviour
{
    private IXRSelectInteractable m_gameObject;
    public void ChangeLayerOff()
    {
        m_gameObject = gameObject.GetComponent<XRSocketInteractorByTag>().GetOldestInteractableSelected();
        m_gameObject.transform.gameObject.GetComponent<LayerChange>().IntLayerOff();
    }
    public void ChangeLayerOn()
    {
        print("1");
        if (!m_gameObject.transform.gameObject.GetComponent<Magazine>().autoUnload)
        {
            print("2");
            m_gameObject.transform.gameObject.GetComponent<LayerChange>().IntLayerOn();
        }
    }
}

