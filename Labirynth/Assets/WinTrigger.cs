using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject _labirintPlayer;
    [SerializeField] GameObject _winPlayer;
    [SerializeField] GameObject _winCanv;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _labirintPlayer.SetActive(false);
            _winPlayer.SetActive(true);
            _winCanv.SetActive(true);
            StartCoroutine(GameObject.FindGameObjectsWithTag("SceneLoader")[0].GetComponent<SceneManagerScr>().Fade());
            other.gameObject.GetComponent<PlayerSound>().PlayDeathAudio();
        }
    }
}
