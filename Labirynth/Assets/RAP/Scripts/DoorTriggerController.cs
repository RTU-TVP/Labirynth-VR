using UnityEngine;

namespace RAP.Scripts
{
    public class DoorTriggerController : MonoBehaviour
    {
        private DoorController doorController;
        private void Start()
        {
            doorController = GetComponentInParent<DoorController>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
             doorController.CheckKey(other.GetComponent<CapsulePlayerController>());
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            doorController.CloseDoor();
        }
    }
}
