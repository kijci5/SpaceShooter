using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text text;
	public static int points=0;

	void Start () {
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Score (points);
	}
	void Reset(){
		text.text = "Score:0";
	}
	public void Score(int points){
		text.text = "Score: " + points;
	}
}
