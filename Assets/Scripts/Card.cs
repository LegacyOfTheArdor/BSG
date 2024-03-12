using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	protected float health;
	protected float speed;
	protected float cost;
	protected float damage;
	protected bool isOnField = false;
	protected GameObject Field;
	public GameObject Myself;
	protected float startMousePosition;
	protected float endMousePosition;
	protected int handIndex;
	protected int fieldIndex;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetOnField(bool value) 
	{
		isOnField = value;
		Debug.Log("words field stuff");
	}
	public void SetHandIndex(int index) 
	{
		handIndex = index;
	}

	protected void MoveToField(GameObject thisCard)
	{
		
		transform.parent.parent.GetComponent<Player>().moveToField(thisCard);
	}

}
