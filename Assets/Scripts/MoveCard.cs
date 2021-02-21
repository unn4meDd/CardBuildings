using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MoveCard : MonoBehaviour
{
    [SerializeField] Vector3 movePosition;
    [SerializeField] Vector3 movePosition2;
    [SerializeField] float moveSpeed = 0.2f;
    [SerializeField] float rotatingSpeed = 0.5f;
    [SerializeField] [Range(0,1)] float moveProgress;
    Vector3 startPosition;
    Vector3 offset;
    Vector3 offset2;
    private CardMechanics cardMechanics;
    public GameObject buttonStopHorizontalMove;
    public GameObject buttonRotationMove;
    public GameObject buttonStopVerticalMove;

    // Start is called before the first frame update
    private bool needHorizontalMove = true;
    private bool needVerticalMove = false;
    private bool needRotatingMove = false;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(needHorizontalMove)
        {
            MoveHorizontal();
        }
        if(needRotatingMove == true)
        {
            MoveRotation();
        }
        if(needVerticalMove == true)
        {
            MoveVertical();
        }
    }
    public void MoveHorizontal()
    {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        offset = movePosition * moveProgress;
        transform.position = startPosition + offset;
    }
    public void MoveRotation()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime * rotatingSpeed);
    }
    public void MoveVertical()
    {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        offset2 = movePosition2 * moveProgress;
        transform.position = startPosition + offset + offset2;
    }
    public void StopHorizontalMove()
    {
        needHorizontalMove = false;
        needRotatingMove = true;
        buttonStopHorizontalMove.SetActive(false);
        buttonRotationMove.SetActive(true);
    }
    public void StopRotationMove()
    {
        needRotatingMove = false;
        needVerticalMove = true;
        buttonStopHorizontalMove.SetActive(false);
        buttonRotationMove.SetActive(false);
        buttonStopVerticalMove.SetActive(true);

    }
    public void StopVerticalMove()
    {
        needVerticalMove = false;
    }
}
