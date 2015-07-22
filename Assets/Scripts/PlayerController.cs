using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform playercurrentmove;

	public Sprite rockSprite;
	public Sprite paperSprite;
	public Sprite scissorSprite;

	private MoveSelection selectedMove;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void selectMove (Move move)
	{
		if (selectedMove == null) {
			selectedMove = new MoveSelection(move, Time.time);
			Debug.Log ("selected : " + move);

			if(selectedMove.move == Move.ROCK){playercurrentmove.gameObject.GetComponent<SpriteRenderer>().sprite=rockSprite;}
			if(selectedMove.move == Move.PAPER){playercurrentmove.gameObject.GetComponent<SpriteRenderer>().sprite=paperSprite;}
			if(selectedMove.move == Move.SCISSOR){playercurrentmove.gameObject.GetComponent<SpriteRenderer>().sprite=scissorSprite;}


		}
	}

	public MoveSelection getSelectedMove() {
		MoveSelection result = selectedMove;
		selectedMove = null;
		return result;
	}
}
