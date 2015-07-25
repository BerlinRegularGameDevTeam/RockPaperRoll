using UnityEngine;
using System.Collections;

public class GameCotroller : MonoBehaviour {

	public PlayerController player1;
	public PlayerController player2;

	public Sprite rockSprite;
	public Sprite paperSprite;
	public Sprite scissorSprite;
	public Sprite blankSprite;

	public Transform player1ingame;
	public Transform player2ingame;

	public int evaluatedResult;

	public Transform beatPrefab;

	// time between beats
	public float beat = 1;
	// time after the sweetspot until
	// ----------x------------|
	//    beat ideal offset missed
	public float offset = 0.1f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("pullMoves",beat + offset,beat);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void pullMoves() {

		Instantiate(beatPrefab,new Vector3(0F,-4F,-1F), Quaternion.identity);



		MoveSelection move1 = player1.getSelectedMove ();
		if (move1.move != Move.NONE) {
			float beatTime = Time.time - offset;
			float timeDifferenz = move1.timing - beatTime;
			Debug.Log ("Player 1: " + move1.move + " " + timeDifferenz);
			if(move1.move == Move.ROCK){player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=rockSprite;}
			if(move1.move == Move.PAPER){player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=paperSprite;}
			if(move1.move == Move.SCISSOR){player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=scissorSprite;}
		} else {
	
			Debug.Log ("Player 1: skipped beat");
			player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=blankSprite;

		}


		MoveSelection move2 = player2.getSelectedMove ();
		if (move2.move != Move.NONE) 
		{ 
			float beatTime = Time.time - offset;
			float timeDifferenz = move2.timing - beatTime;
			Debug.Log ("Player 2: " + move2.move + " " + timeDifferenz);
			if(move2.move == Move.ROCK){player2ingame.gameObject.GetComponent<SpriteRenderer>().sprite=rockSprite;}
			if(move2.move == Move.PAPER){player2ingame.gameObject.GetComponent<SpriteRenderer>().sprite=paperSprite;}
			if(move2.move == Move.SCISSOR){player2ingame.gameObject.GetComponent<SpriteRenderer>().sprite=scissorSprite;} 
		}

			else 
			{
			Debug.Log ("Player 2: skipped beat");
			player2ingame.gameObject.GetComponent<SpriteRenderer>().sprite=blankSprite;
				}


		//evaluate
		//quick and dirty~
		if(move1.move == Move.ROCK)
		{
			if(move2.move == Move.ROCK){evaluatedResult = 0;} 
			if(move2.move == Move.PAPER){evaluatedResult = -1;} 
			if(move2.move == Move.SCISSOR){evaluatedResult = 1;} 
			if(move2.move == Move.NONE){evaluatedResult = 1;} 
		}

		if(move1.move == Move.PAPER)
		{
			if(move2.move == Move.ROCK){evaluatedResult = 1;} 
			if(move2.move == Move.PAPER){evaluatedResult = 0;} 
			if(move2.move == Move.SCISSOR){evaluatedResult = -1;} 
			if(move2.move == Move.NONE){evaluatedResult = 1;} 
			
			
		}

		if(move1.move == Move.SCISSOR)
		{
			if(move2.move == Move.ROCK){evaluatedResult = -1;} 
			if(move2.move == Move.PAPER){evaluatedResult = 1;} 
			if(move2.move == Move.SCISSOR){evaluatedResult = 0;} 
			if(move2.move == Move.NONE){evaluatedResult = 1;} 
			
			
		}


		if(move1.move == Move.NONE)
		{
			if(move2.move == Move.ROCK){evaluatedResult = -1;} 
			if(move2.move == Move.PAPER){evaluatedResult = -1;} 
			if(move2.move == Move.SCISSOR){evaluatedResult = -1;} 
			if(move2.move == Move.NONE){evaluatedResult = 0;} 
			
			
		}

		Debug.Log("Result: " + evaluatedResult);



	}
}
