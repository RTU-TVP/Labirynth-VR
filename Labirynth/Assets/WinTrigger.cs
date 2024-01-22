using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject _labirintPlayer;
    [SerializeField] Vector3 vector;
    [SerializeField] GameObject _winCanv;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _labirintPlayer.transform.position = vector;
            _winCanv.SetActive(true);
            StartCoroutine(GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneManagerScr>().Fade());
        }
    }
}
