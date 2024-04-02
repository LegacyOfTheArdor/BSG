using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Slider Health;

	private float playerHealth = 100;
	private float actionPoints = 100;

	public GameObject PrivateCards;
	

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

	public void UpdateHealth(float Damage)
	{
		playerHealth -= Damage;
		Health.value = playerHealth / 100;
		Debug.Log("youch");
	}

	public float GetHealth()
	{
		return playerHealth;
	}

	public float GetActionpoints()
	{
		return actionPoints;
	}

	public void DrawHandcard()
	{
		Debug.Log("press");
		int randomCard = Random.Range(0, matchDeck.Count);

		GameObject card = matchDeck[randomCard];
		handCards.Add(card);
		matchDeck.RemoveAt(randomCard);
		Instantiate(card, Hand.transform);


		if (matchDeck.Count <= 0)
		{

		}
	}

	public void MoveToField(GameObject card)
	{
		handCards.Remove(card);
		fieldCards.Add(card);
		card.transform.SetParent(Field.transform, false);
		card.SendMessage("SetOnField", true);


		for (int i = 0; i < fieldCards.Count; i++)
		{
			GameObject temp = fieldCards[i];
			temp.GetComponent<Card>().SetFieldIndex(i);
		}

	}

	public List<GameObject> GetFieldList()
	{
		return fieldCards;
	}

	public void HideCards()
	{
		PrivateCards.SetActive(false);
	}

	public void ShowCards()
	{
		PrivateCards.SetActive(true);
	}

	public void TempCount() 
	{
		Debug.Log(matchDeck.Count);
	}
}
