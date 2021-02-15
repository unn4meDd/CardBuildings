using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Tabs
    {
        PutCard
    }
    public Tabs tabsDirection;
    [SerializeField]
    public MoveCard moveCard;
    public void Update()
    {
        if (!ispressed)
            return;
        if (tabsDirection == Tabs.PutCard)
            moveCard.PutCard();
    }
    bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
