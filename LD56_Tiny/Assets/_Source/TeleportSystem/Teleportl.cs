using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleportl : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform TransformPos;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CharacterController characterController;
    private bool _isInRange = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _isInRange = true;
            Debug.Log("teleport");
            //characterController.enabled = false;
            
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _isInRange = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isInRange)
            {
                Debug.Log(TransformPos.position);
                characterController.enabled = false;
                playerTransform.position = new Vector3(TransformPos.position.x, TransformPos.position.y + 2, TransformPos.position.z);
                characterController.enabled = true;
            }
        }
    }
}
