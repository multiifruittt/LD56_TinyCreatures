using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuvirokFromLadder : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private LadderController ladderController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LayerMask KuvirokMask;
    [SerializeField] private Animator animator;
    [SerializeField] private float leftTime;
    [SerializeField] private Transform firstEndPos;
    [SerializeField] private Transform secondEndPos;
    [SerializeField] private Transform playerPos;
    private float timer = 0f;
    private bool isReady = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((KuvirokMask & (1 << other.gameObject.layer)) != 0)
        {
            isReady = true;
            playerController.enabled = false;
            ladderController.enabled = false;
            timer = 0f;
            Debug.Log("ready");
            //StartCoroutine("KuvirokCoroutine");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if ((KuvirokMask & (1 << other.gameObject.layer)) != 0)
        {
            isReady = false;
            playerController.enabled = true;
            ladderController.enabled = false;
            timer = 0f;
        }
    }
    /*IEnumerator KuvirokCoroutine()
    {
        while (isReady)
        {
            timer += Time.deltaTime;
            if (timer < leftTime)
            {
                characterController.Move(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            }
            else
            {
                animator.Play("Kuvirok");
            }
            yield return null;
            yield WaitForSeconds(3);
        }
    }*/
    private void Update()
    {
        if(isReady)
        {
            Debug.Log("Start");
            playerPos.position = Vector3.Lerp(playerPos.position, firstEndPos.position, timer / leftTime);
            timer += Time.deltaTime;
        }
        

    }

}
