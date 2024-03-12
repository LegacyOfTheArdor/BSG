using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Slider Health;
	private float playerHealth = 100;
	List<GameObject> matchDeck = new List<GameObject>(25);
	List<GameObject> handCards = new List<GameObject>(5);
	List<GameObject> fieldCards = new List<GameObject>(10);

	public Button Deck;
	public GameObject Hand;
	public GameObject Field;

	public GameObject tempcard;

	private GameObject selectedCard;
	private float mouseStart;
	private float mouseEnd;

    // Start is called before the first frame update
    void Start()
    {
		
		matchDeck.Add(tempcard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void updateHealth(float Damage) 
	{ 
		playerHealth -= Damage;	
		Health.value = playerHealth/100;
		Debug.Log("youch");
	}

	public void drawHandcard() 
	{
		Debug.Log("press");
		int randomCard = Random.Range(0, matchDeck.Count);
		
		GameObject card = matchDeck[randomCard];
		handCards.Add(card);
		matchDeck.RemoveAt(randomCard);
		Instantiate(card, Hand.transform);

		for(int i = 0; i < handCards.Count; i++)
		{
			GameObject temp = handCards[i];
			temp.GetComponent<Card>().SetHandIndex(i);
		}

		if(matchDeck.Count <= 0) 
		{
			
		}
	}

	public void moveToField(GameObject card) 
	{
		handCards.Remove(card);
		fieldCards.Add(card);
		card.transform.SetParent(Field.transform, false);
		card.SendMessage("SetOnField", true);
	}

	private void OnMouseDown()
	{
		
	}

	private void OnMouseUp()
	{
		mouseEnd = Input.mousePosition.y;

		float mouseDrag = mouseStart - mouseEnd;

		if (selectedCard != null && mouseDrag > 100)
		{
			moveToField(selectedCard);
		}

		selectedCard = null;
	}
	private void OnMouseDrag()
	{
		
	}
}
