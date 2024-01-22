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
            _winCanv.SetActive(true);
            StartCoroutine(GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneManagerScr>().Fade());
            StartCoroutine(PlayerChangePos());
        }
    }
    private IEnumerator PlayerChangePos()
    {
        yield return new WaitForSeconds(1);
        _labirintPlayer.transform.position = vector;
    }
}
