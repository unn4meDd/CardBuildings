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
        // buttonStopHorizontalMove = GameObject.Find("BSHM").GetComponent<GameObject>();
        // buttonStopRotationMove = GameObject.Find("BSRM").GetComponent<GameObject>();
        // buttonStopVerticalMove = GameObject.Find("BSVM").GetComponent<GameObject>();
        startPosition = transform.position;
        needHorizontalMove = true;
        UpdateActiveBtn();
    }
    private void UpdateActiveBtn()
    {
        buttonStopHorizontalMove.SetActive(needHorizontalMove);
        buttonStopRotationMove.SetActive(needRotatingMove);
        buttonStopVerticalMove.SetActive(needVerticalMove);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        print(needHorizontalMove + " " + needRotatingMove + " " + needVerticalMove);
        if(needHorizontalMove == true)
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
        needVerticalMove = false;
        UpdateActiveBtn();
    }
    public void StopRotationMove()
    {
        needRotatingMove = false;
        needVerticalMove = false;
        needVerticalMove = true;
        UpdateActiveBtn();
    }
    public void StopVerticalMove()
    {
        needRotatingMove = false;
        needVerticalMove = false;
        Destroy(GetComponent<MoveCard>());
        Instantiate(movingCardExample);
        needHorizontalMove = true;
        UpdateActiveBtn();
    }
}