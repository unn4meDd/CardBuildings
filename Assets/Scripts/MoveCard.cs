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
    private CardMechanics cardMechanics;
    // Start is called before the first frame update
    void Start()
    {

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("OffOnCards", 2f);
        Invoke("Move", 5f);
    }
    public void Move()
    {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        Vector3 offset = movePosition * moveProgress;
        transform.position = startPosition + offset;
    }
    public void OffOnCards()
    {
        // cardMechanics.cards[0].SetActive(false);
        // cardMechanics.cards[1].SetActive(false);
        // cardMechanics.cards[2].SetActive(false);
        // cardMechanics.cards[3].SetActive(false);
        // cardMechanics.cards[4].SetActive(false);
        // cardMechanics.cards[5].SetActive(false);
        // cardMechanics.cards[6].SetActive(false);
        // cardMechanics.cardsBorder[7].SetActive(true);
    }

}
