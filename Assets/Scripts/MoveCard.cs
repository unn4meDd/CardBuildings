using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MoveCard : MonoBehaviour
{
    [SerializeField] Vector3 movePosition;
    [SerializeField] float moveSpeed;
    [SerializeField] [Range(0,1)] float moveProgress;
    Vector3 startPosition;
    Vector3 offset;
    private CardMechanics cardMechanics;
    // Start is called before the first frame update
    private bool needHorizontalMove = true;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(needHorizontalMove)
        {
            Move();
        }
    }
    public void Move()
    {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        offset = movePosition * moveProgress;
        transform.position = startPosition + offset;
    }
    public void StopHorizontalMove()
    {
        needHorizontalMove = false;
    }
}
