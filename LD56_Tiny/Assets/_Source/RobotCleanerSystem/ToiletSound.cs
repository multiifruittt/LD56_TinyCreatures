using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletSound : MonoBehaviour
{
    [SerializeField] private AudioSource toiletSound;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private BoxCollider colliderItself;
    private void OnTriggerEnter(Collider other)
    {

        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log("Player");
            toiletSound.Play();
            Destroy(gameObject);
        }
    }
}
