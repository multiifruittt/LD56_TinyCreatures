using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingObj : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    private Health _health;

    public void Construct(Health health)
    {
        _health = health;
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _health.AddScore(-1);
        }

    }
}
