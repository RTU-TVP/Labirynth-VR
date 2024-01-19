using DG.Tweening;
using RAP.Scripts;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorControllerByCard : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject[] redLights;
    [SerializeField] private GameObject[] greenLights;

    [SerializeField] private float doorOpened;
    [SerializeField] private float doorClosed;
    [SerializeField] private float openTime;
    [SerializeField] private float openingTime;

    bool _isOpening = false;
    public bool PlayerInTrigger;

    private void Start()
    {
        doorClosed = door.transform.position.y;
    }

    public IEnumerator DoorOpener() 
    {
        if (!_isOpening)
        {
            _isOpening = true;
            OpenDoor();
            yield return new WaitForSeconds(openTime);
            while (true)
            {
                if (PlayerInTrigger) { yield return new WaitForEndOfFrame(); }
                else
                {
                    CloseDoor();
                    _isOpening = false;
                    break;
                }
            }
            yield return null;
        }
    }

    private void Lights()
    {
        for (int i = 0; i < 2; i++)
        {
            redLights[i].SetActive(!redLights[i].activeSelf);
            greenLights[i].SetActive(!greenLights[i].activeSelf);
        }
    }

    private void OpenDoor()
    {
        door.transform.DOMoveY(doorOpened, openingTime);
        Lights();
    }
    private void CloseDoor()
    {
        door.transform.DOMoveY(doorClosed, openingTime);
        Lights();
    }

}
