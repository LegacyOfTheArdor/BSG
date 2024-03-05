using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Slider Health;
	private float playerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
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

	void moveToField() 
	{ 
	
	}
}
