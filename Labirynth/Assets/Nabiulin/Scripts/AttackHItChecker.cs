using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHItChecker : MonoBehaviour
{
    [SerializeField] GameObject _labirintPlayer;
    [SerializeField] Vector3 pos;
    [SerializeField] GameObject _loseCanv;

    bool isAttacked;

    private void Start()
    {
        isAttacked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isAttacked)
            {
                _loseCanv.SetActive(true);
                StartCoroutine(GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneManagerScr>().Fade());
                StartCoroutine(PlayerChangePos());
                other.gameObject.GetComponent<PlayerSound>().PlayDeathAudio();
                isAttacked = true;
            }
        }
    }
    private IEnumerator PlayerChangePos()
    {
        yield return new WaitForSeconds(1);
        _labirintPlayer.transform.position = pos;
    }
}
