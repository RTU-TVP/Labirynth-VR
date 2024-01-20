using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    [SerializeField] private GameObject Doors;

    [SerializeField] private Vector3 ToStop;

    [SerializeField] bool isWorked;

    [SerializeField] GameObject ElevatorMoveAudio;
    [SerializeField] GameObject ElevatorStopAudio;

    void Start()
    {
        isWorked = false;
        ElevatorStopAudio.SetActive(false);
        ElevatorMoveAudio.SetActive(true);

    }

    private void Update()
    {
        if (transform.position.y <= ToStop.y)
        {
            ElevatorStopAudio.SetActive(true);
            ElevatorMoveAudio.SetActive(false);
            if (!isWorked)
            {
                OpenDoor();
                isWorked = true;
            }
        }
        else
        {
            transform.position -= transform.up * 3.5f * Time.deltaTime;
        }
    }

    private void OpenDoor()
    {
        Doors.GetComponent<DoorControllerByCard>().StartCoroutine(Doors.GetComponent<DoorControllerByCard>().DoorOpener());
    }
}
