using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _ttl;
    [SerializeField] float _livingTime=0;

 
    private void FixedUpdate()
    {
        if (_ttl < _livingTime) Destroy(gameObject);
        _livingTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster") {
            //Stan monster
            collision.gameObject.GetComponent<EnemyAI>().HitStun(10f);
            Destroy(gameObject); 
        }
    }
}
