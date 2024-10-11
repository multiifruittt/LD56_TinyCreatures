using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallDownDamage : MonoBehaviour
{
    [SerializeField] Transform playerT;
    [SerializeField] CharacterController controller;
    [SerializeField] float dieDist;

    private Health _health;
    private float lastPosY = 0f;
    private float fallDistance = 0f;

    public void Construct(Health health)
    {
        _health = health;
    }
   
    private void Update()
    {
        if(lastPosY > playerT.transform.position.y)
        {
            fallDistance += lastPosY - playerT.transform.position.y;
        }

        lastPosY = playerT.transform.position.y; 

        if(fallDistance >= dieDist && controller.isGrounded)
        {
            _health.AddScore(-1);
            ApplyNormal();
        }

        if(fallDistance <= dieDist && controller.isGrounded)
        {
            ApplyNormal();
        }

    }

    private void ApplyNormal()
    {
        fallDistance = 0f;
        lastPosY = 0f;
    }
}
