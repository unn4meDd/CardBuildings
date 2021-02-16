using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMechanics : MonoBehaviour
{
    public GameObject cardHouse1;

    public GameObject[] cards = new GameObject[7];
    public GameObject[] cardsBorder = new GameObject[7];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DisableCardHouse", 2f);
        Invoke("EnableCardsBorder", 4f);
    }
    public void DisableCardHouse()
    {
        cardHouse1.SetActive(false);
    }
    public void EnableCardsBorder()
    {
        cardsBorder[0].SetActive(true);
    }
}
