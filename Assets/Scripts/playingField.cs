using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingField : MonoBehaviour
{
	Player PlayerONE;
	Player PlayerTWO;

	List<GameObject> playerONECards = new List<GameObject>(10);
	List<GameObject> playerTWOCards = new List<GameObject>(10);

	List<List<GameObject>> PlayerONEmoves = new List<List<GameObject>>(10);
	List<List<GameObject>> PlayerTWOmoves = new List<List<GameObject>>(10);


	private bool PlayerONEturn = true;
	private bool PlayerTWOturn = false;

	bool firstturn = true;
	bool limitToggle = false;

	public GameObject privacyScreen;

	public Slider POVhealth;
	public Slider POVactionpoints;
	public Slider EnemyHealth;

	public GameObject PlayerONEField;
	public GameObject PlayerTWOField;
	public GameObject PlayerCards;
	public GameObject EnemyCards;
	public GameObject ChooseHero;
	public GameObject ChooseEnemy;

	public List<GameObject> move;

	// Start is called before the first frame update
	void Start()
    {
		PlayerONE = GameObject.FindGameObjectWithTag("player1").GetComponent<Player>();
		PlayerTWO = GameObject.FindGameObjectWithTag("player2").GetComponent<Player>();

		playerONECards = PlayerONE.GetFieldList();
		playerTWOCards = PlayerTWO.GetFieldList();

    }

    // Update is called once per frame
    void Update()
    {
		if (!firstturn) 
		{
			if (move.Count > 0 && move.Count < 2 && limitToggle == false)
			{
				ToggleChoice(true);
				limitToggle = true;
			}
			if (move.Count == 2)
			{
				ToggleChoice(false);

				if (PlayerONEturn)
				{
					Debug.Log("move added for player 1");
					PlayerONEmoves.Add(move);
					move.RemoveAt(0);
					move.RemoveAt(0);

					Debug.Log("remove move");
					limitToggle = false;
				}
				else
				{

					Debug.Log("move added for player 2");
					PlayerTWOmoves.Add(move);
					move.RemoveAt(0);
					move.RemoveAt(0);
					Debug.Log("remove move");
				}
			}

		}
		
	}

	void ToggleChoice(bool toggle) 
	{
		

		if(toggle == true) 
		{
			ChooseHero.SetActive(true);
			ChooseEnemy.SetActive(false);
			Debug.Log("toggle 1");
		}
		else 
		{
			ChooseHero.SetActive(false);
			ChooseEnemy.SetActive(true);

			Debug.Log("toggle 2");
		}
	
	}

	public void EndTurn() 
	{


		if(PlayerONEturn == true && PlayerTWOturn == false) 
		{	
			PlayerONEturn = false;
			PlayerTWOturn = true;
			FlipBoard();
		}
		else if(PlayerONEturn == false && PlayerTWOturn == true)
		{
			PlayerTWOturn = false;
			PlayerONEturn = true;
			
		
			

			FlipBoard();
		}
		else 
		{
			
			FlipBoard();
			

		}
	}

	void AddTurn() 
	{ 
		
	}

	private void FlipBoard() 
	{
			
	
		if(privacyScreen.activeSelf) 
		{
			privacyScreen.SetActive(false);
		}
		else 
		{
			privacyScreen.SetActive(true);
		}

		if (PlayerONEturn)
		{
			Debug.Log("player one turn = "+PlayerONEturn);

			POVhealth.value = PlayerONE.GetHealth() / 100;
			POVactionpoints.value = PlayerONE.GetActionpoints() / 100;
			EnemyHealth.value = PlayerTWO.GetHealth() / 100;

			PlayerONE.ShowCards();
			PlayerONEField.transform.SetParent(PlayerCards.transform, false);
			PlayerTWOField.transform.SetParent(EnemyCards.transform, false);
			PlayerTWO.HideCards();

			if (firstturn == true)
			{
				
				EnemyCards.SetActive(false);
			}
		}
		else if (PlayerTWOturn == true)
		{

			Debug.Log("player two turn = " + PlayerTWOturn);

			POVhealth.value = PlayerTWO.GetHealth() / 100;
			POVactionpoints.value = PlayerTWO.GetActionpoints() / 100;
			EnemyHealth.value = PlayerONE.GetHealth() / 100;

			PlayerTWO.ShowCards();
			PlayerTWOField.transform.SetParent(PlayerCards.transform, false);
			PlayerONEField.transform.SetParent(EnemyCards.transform, false);
			PlayerONE.HideCards();

			if (firstturn == true) 
			{
				
				EnemyCards.SetActive(false);
			}
			

		}
		else 
		{
			POVhealth.value = 1;
			POVactionpoints.value = 1; 
			EnemyHealth.value = 1;
			firstturn = false;
			EnemyCards.SetActive(true);
		}

	}

	public void PlayerReady() 
	{
		privacyScreen.SetActive(false);
		
		if(PlayerONEturn == true && firstturn == true) 
		{
			firstturn = false;
			EnemyCards.SetActive(true);
		}
	}

	public void CheckCard(GameObject card) 
	{
		if (PlayerONEturn) 
		{
			if (card.tag == "player1card") 
			{ 
				
			}
		}
		else 
		{ 
		
		
		}
		
	}
	
}
