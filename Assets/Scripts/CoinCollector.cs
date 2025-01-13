using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCollector : MonoBehaviour
{
    private Animator _animator;

    private void Awake ()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectables>(out ICollectables icoll))
        {
            icoll.Collect();
            if(icoll is Coin)
            {
              
            _animator.SetTrigger("Collected");
            _animator.SetLayerWeight(1, 1);
            GetComponent<PlayerMover>().canMove = false;
            GetComponent<PlayerMover>()._moveDirection = Vector3.zero;
            }
        }
    
    }


}
