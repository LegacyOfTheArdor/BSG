using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playingField : MonoBehaviour
{
	GameObject playerONE;
	GameObject playerTWO;

    // Start is called before the first frame update
    void Start()
    {
		playerTWO = GameObject.FindGameObjectWithTag("player2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void playerMoves(float damage) 
	{
		playerTWO.GetComponent<Player>().updateHealth(damage);
	}
}
