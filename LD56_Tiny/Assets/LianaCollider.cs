using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianaCollider : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject worldCanvas;


    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            
            worldCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {

            worldCanvas.SetActive(false);
        }
    }
}
