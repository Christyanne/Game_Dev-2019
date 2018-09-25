using UnityEngine;
using UnityEngine.UI;
using Sysyem.Collections;

public class ScoreManager : MonoBehaviour {

Text ScoreText;

	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();

		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Score < 0)
		    Score = 0;
		ScoreText.text = " " + Score;	
	}
}

    public static void AddPoints (int PointsToAdd) {
		Score += PointsToAdd
	}

	//public static void reset () {
	//Score=0;	
	//}
}	