using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MoveCard : MonoBehaviour
{
    [SerializeField] Vector3 movePosition;
    [SerializeField] float moveSpeed = 0.2f;
    [SerializeField] float rotatingSpeed = 0.5f;
    [SerializeField] [Range(0,1)] float moveProgress;
    Vector3 startPosition;
    Vector3 offset;
    private CardMechanics cardMechanics;
    public GameObject buttonStopCard;
    public GameObject buttonRotation;
    // Start is called before the first frame update
    private bool needHorizontalMove = true;
    private bool needRotatingMove = false;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(needHorizontalMove)
        {
            MoveHorizontal();
        }
        if(needRotatingMove == true)
        {
            MoveRotation();
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
    public void StopHorizontalMove()
    {
        needHorizontalMove = false;
        needRotatingMove = true;
        buttonStopCard.SetActive(false);
        buttonRotation.SetActive(true);
    }
    public void StopRotationMove()
    {
        needRotatingMove = false;
    }
}
