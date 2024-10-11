using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private CheckPoint checkPoint;
    [SerializeField] private BoxCollider boxCollider;
    private Health _health;

    public void Construct(Health health)
    {
        _health = health;
        _health.OnDeath += Dieing;
        _health.OnGameOver += GameOver;
    }

    private void Dieing()
    {
        StartCoroutine("Die");
    }
    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator Die()
    {
        controller.enabled = false;
        boxCollider.enabled = false;
        animator.Play("Dieing");
        yield return new WaitForSeconds(2);
        controller.enabled = true;
        checkPoint.Teleport();
       // controller.enabled = false;
        yield return new WaitForSeconds(1);
        controller.enabled = true;
        boxCollider.enabled = true;

    }
}
