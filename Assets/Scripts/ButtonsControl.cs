using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControl : MonoBehaviour
{
    public MoveCard moveCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MyBtnHandler()
    {
        print(moveCard.needHorizontalMove + " " + moveCard.needRotatingMove + " " + moveCard.needVerticalMove);
        if(moveCard.needHorizontalMove == true)
        {
            moveCard.Change_needHorMove(true, "horMove");
            // moveCard.StopHorizontalMove();
        }
        print(moveCard.needHorizontalMove + " " + moveCard.needRotatingMove + " " + moveCard.needVerticalMove);
        if(moveCard.needRotatingMove == true)
        {
            moveCard.Change_needRotMove(true, "rotMove");
            // moveCard.StopRotationMove();
        }
        print(moveCard.needHorizontalMove + " " + moveCard.needRotatingMove + " " + moveCard.needVerticalMove);
        if(moveCard.needVerticalMove == true)
        {
            moveCard.Change_needVertMove(true, "vertMove");
            // moveCard.StopVerticalMove();
        }
        print(moveCard.needHorizontalMove + " " + moveCard.needRotatingMove + " " + moveCard.needVerticalMove);
    }
}
