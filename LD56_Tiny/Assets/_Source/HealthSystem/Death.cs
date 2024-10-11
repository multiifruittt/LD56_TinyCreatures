using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private CheckPoint checkPoint;
    private Health _health;

    public void Construct(Health health)
    {
        _health = health;
        _health.OnDeath += Dieing;
    }

    private void Dieing()
    {
        StartCoroutine("Die");
    }
    IEnumerator Die()
    {
        controller.enabled = false;
        animator.Play("Dieing");
        yield return new WaitForSeconds(2);
        controller.enabled = true;
        checkPoint.Teleport();
       // controller.enabled = false;
        yield return new WaitForSeconds(1);
        controller.enabled = true;

    }
}
