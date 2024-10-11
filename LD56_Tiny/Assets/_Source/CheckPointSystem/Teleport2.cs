using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject player;
    [SerializeField] CharacterController characterController;
    [SerializeField] private LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        if ((mask & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log("teleport");
            characterController.enabled = false;
            player.transform.position = teleportTarget.position;
            characterController.enabled = true;
        }
    }
}
