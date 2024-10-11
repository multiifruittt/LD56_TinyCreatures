using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        if ((mask & (1 << other.gameObject.layer)) != 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
