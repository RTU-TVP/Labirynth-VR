using System;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace RAP.Scripts
{ 
    public class HintHandler : MonoBehaviour
    {
        private Transform hint;
        private GameObject canvas;
        private Transform player;
        private Transform parentObj;
        private void Start()
        {
            parentObj = transform.parent;
            hint = transform;
            canvas = transform.GetChild(0).gameObject;
            player = GameObject.Find("Player+Pause").transform;
            
            parentObj.GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrab);
            parentObj.GetComponent<XRGrabInteractable>().selectExited.AddListener(OnUnGrab);
        }

        private void Update()
        {
            RotationLock();
        }

        private void OnGrab(SelectEnterEventArgs args)
        {
            canvas.SetActive(false);
        }
        
        private void OnUnGrab(SelectExitEventArgs args)
        {
            canvas.SetActive(true);
        }

        private void RotationLock()
        {
            hint.LookAt(new Vector3(player.position.x, hint.position.y, player.position.z));
        }
        
    
    }
}
