using UnityEngine;
using System.Collections;

public class GameCotroller : MonoBehaviour {

	public PlayerController player1;
	public PlayerController player2;

	public Sprite rockSprite;
	public Sprite paperSprite;
	public Sprite scissorSprite;

	public Transform player1ingame;
	public Transform player2ingame;

	public Transform player1currentmove;
	public Transform player2currentmove;

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

		Instantiate(beatPrefab,new Vector3(-3F,-4F,-1F), Quaternion.identity);

		MoveSelection move1 = player1.getSelectedMove ();
		if (move1 != null) {
			float beatTime = Time.time - offset;
			float timeDifferenz = move1.timing - beatTime;
			Debug.Log (move1.move + " " + timeDifferenz);
		} else {
			Debug.Log ("skipped beat");
		}
		if(move1.move == Move.ROCK){player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=rockSprite;}
		if(move1.move == Move.PAPER){player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=paperSprite;}
		if(move1.move == Move.SCISSOR){player1ingame.gameObject.GetComponent<SpriteRenderer>().sprite=scissorSprite;}

	}
}
