using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basic_Man : Card
{

	GameObject Field;
	
	
    // Start is called before the first frame update
    void Start()
    {
		Field = GameObject.FindGameObjectWithTag("Field");
        health = 1;
		speed = 1;
		cost = 0;
		damage = 20;
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float Attack()
    {
        return damage;
    }

	void OnMouseDown() 
	{
		Field.GetComponent<playingField>().playerMoves(Attack());
		Debug.Log("press");
	}
	
}
