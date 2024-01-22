using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHItChecker : MonoBehaviour
{
    [SerializeField] GameObject _labirintPlayer;
    [SerializeField] Vector3 pos;
    [SerializeField] GameObject _loseCanv;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _labirintPlayer.transform.position = pos;
            _loseCanv.SetActive(true);
            StartCoroutine(GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneManagerScr>().Fade());
            other.gameObject.GetComponent<PlayerSound>().PlayDeathAudio();
        }
    }
}
