using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHItChecker : MonoBehaviour
{
    [SerializeField] GameObject _labirintPlayer;
    [SerializeField] GameObject _losePlayer;
    [SerializeField] GameObject _loseCanv;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _labirintPlayer.SetActive(false);
            _losePlayer.SetActive(true);
            _loseCanv.SetActive(true);
            StartCoroutine(GameObject.FindGameObjectsWithTag("SceneLoader")[0].GetComponent<SceneManagerScr>().Fade());
            other.gameObject.GetComponent<PlayerSound>().PlayDeathAudio();
        }
    }
}
