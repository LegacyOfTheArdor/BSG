using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basic_Man : Card
{

	
	
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
		if (isOnField == false)
		{
			MoveToField(Myself);
		}
		else 
		{
			Attack();
			Debug.Log("attack");
		}
	}

	void OnMouseUp()
	{
		
	}

}
