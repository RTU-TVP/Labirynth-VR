using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TagChange : MonoBehaviour
{
    [SerializeField] private string _off;
    [SerializeField] private string _on;
    public void TagOff()
    {
        gameObject.tag = _off;
    }
    public void TagOn()
    {
        gameObject.tag = _on;
    }
}
