using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MoveCard : MonoBehaviour
{
    public GameObject[] cards = new GameObject[7];
    public GameObject[] cardsBorder = new GameObject[7];
    public GameObject movingCardExample;
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
    public GameObject buttonStopRotationMove;
    public GameObject buttonStopVerticalMove;
    private bool needHorizontalMove = false;
    private bool needVerticalMove = false;
    private bool needRotatingMove = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        needHorizontalMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(needHorizontalMove == true)
        {
            MoveHorizontal();
            buttonStopHorizontalMove.SetActive(true);
            buttonStopRotationMove.SetActive(false);
            buttonStopVerticalMove.SetActive(false);
        }
        if(needRotatingMove == true)
        {
            MoveRotation();
            buttonStopHorizontalMove.SetActive(false);
            buttonStopRotationMove.SetActive(true);
            buttonStopVerticalMove.SetActive(false);
        }
        if(needVerticalMove == true)
        {
            MoveVertical();
            buttonStopHorizontalMove.SetActive(false);
            buttonStopRotationMove.SetActive(false);
            buttonStopVerticalMove.SetActive(true);
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
        needVerticalMove = false;
    }
    public void StopRotationMove()
    {
        needRotatingMove = false;
        needVerticalMove = false;
        needVerticalMove = true;
    }
    public void StopVerticalMove()
    {
        needRotatingMove = false;
        needVerticalMove = false;
        Destroy(GetComponent<MoveCard>());
        Instantiate(movingCardExample);
        buttonStopHorizontalMove.SetActive(true);
        buttonStopRotationMove.SetActive(false);
        buttonStopVerticalMove.SetActive(false);    
        needHorizontalMove = true;
    }
}