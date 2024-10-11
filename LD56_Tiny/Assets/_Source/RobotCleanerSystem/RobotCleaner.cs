using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCleaner : MonoBehaviour
{
    public Transform[] points; // точки подряд
    public float[] time; // время до следующей точки
    private int current = 0;
    private float timer = 0f;
    private float timerForWaiting = 0f;
    private int next = 1;
    public Transform target;
    private bool isMovingRight = true;
    void Update()
    {
        MovingToTargets();
    }
    private void MovingToTargets()
    {
        target.position = Vector3.Lerp(points[current].position, points[next].position, timer / time[current]);
        timerForWaiting += Time.deltaTime;
        if (timerForWaiting >= 2)
        {
            timer += Time.deltaTime;
            if (timer >= time[current])
            {
                if (next == points.Length - 1)
                {
                    isMovingRight = false;
                }
                else if (next == 0)
                {
                    isMovingRight = true;
                }

                if (isMovingRight)
                {
                    timer = 0f;
                    current = next;
                    next++;
                    Debug.Log(next);
                    timerForWaiting = 0f;
                }
                else
                {
                    timer = 0f;
                    current = next;
                    next--;
                    Debug.Log(next);
                    timerForWaiting = 0f;
                }
            }
              
        }
       
    }
    private void WaitForSeconds()
    {
        
    }
}
