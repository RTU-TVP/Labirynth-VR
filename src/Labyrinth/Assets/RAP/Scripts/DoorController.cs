using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace RAP.Scripts
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] private DoorTriggerController doorTriggerController;
        [SerializeField] private GameObject door;
        [SerializeField] private float doorOpened;
        [SerializeField] private float doorClosed;

        private void Start()
        {
            doorClosed = door.transform.position.y;
        }

        public void CheckKey(CapsulePlayerController player)
        {
            if (player.hasKey)
            {
                OpenDoor();
            }
        }
    
        private void OpenDoor()
        {
            door.transform.DOMoveY(doorOpened, 1f);
        }
        public void CloseDoor()
        {
            door.transform.DOMoveY(doorClosed, 1f);
        }
    }
}
