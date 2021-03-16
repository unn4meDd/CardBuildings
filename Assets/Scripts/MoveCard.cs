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
    public GameObject buttonStopMove;
    internal bool needHorizontalMove = true;
    internal bool needVerticalMove = false;
    internal bool needRotatingMove = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
    // Update is called once per frame
    public void Update()
    {
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
    public void Change_needHorMove(bool newValue, string why)
    {
        print("Change_needHorMove");
        needHorizontalMove = newValue;
        print("needHorMove " + newValue);
        print("why " + why);
    }
    public void Change_needRotMove(bool newValue, string why)
    {
        print("Change_needRotMove");
        needRotatingMove = newValue;
        print("needRotMove " + newValue);
        print("why" + why);
    }
    public void Change_needVertMove(bool newValue, string why)
    {
        print("Change_needVertMove");
        needVerticalMove = newValue;
        print("needVertMove " + newValue);
        print("why" + why);
    }
    public void StopHorizontalMove()
    {
        print("StopHorizontalMove");
        needHorizontalMove = false;
        needRotatingMove = true;
        needVerticalMove = false;
    }
    public void StopRotationMove()
    {
        print("StopRotationMove");
        needRotatingMove = false;
        needVerticalMove = false;
        needVerticalMove = true;
    }
    public void StopVerticalMove()
    {
        print("StopVerticalMove");
        needRotatingMove = false;
        needVerticalMove = false;
        var newCard = Instantiate(movingCardExample);
        Destroy(newCard.GetComponent<MoveCard>());
        needHorizontalMove = true;
    }
}