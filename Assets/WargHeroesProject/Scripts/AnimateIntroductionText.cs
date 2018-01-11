using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimateIntroductionText : MonoBehaviour {

	Text text;
	Image img;
	int timeElapsed = 0;
	float timeSinceEndDialog = 0;
	double timeModifier = 0.1;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		img = this.GetComponentInChildren<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed++;

		if (timeElapsed < 2000 * timeModifier) {
			fadeOutOfBlack ();
			modifyText ();
		} else if (timeElapsed < 2500 * timeModifier) {

			timeSinceEndDialog += 0.002f;
			timeSinceEndDialog = Mathf.Min (1.0f, timeSinceEndDialog);

			text.fontSize = 50;
			Color c = text.material.color;
			c.a = timeSinceEndDialog;
			text.material.color = c;
			text.text = "WARG HEROES";

			RectTransform rect = this.GetComponent<RectTransform> ();
			Vector3 pos = rect.position;
			pos.x = 670;
			pos.y = 130;
			Debug.Log (pos.x + " " + pos.y);
			rect.position = pos;

		} else if (timeElapsed < 2999  * timeModifier) {
			timeSinceEndDialog = 0.0f;
		} else if (timeElapsed < 3200  * timeModifier) {
			timeSinceEndDialog += 0.005f;
			fadeToWhite ();
		} else {
			// Transition to next level
			SceneManager.LoadScene("Level1");
		}
	}

	void modifyText() {
		text.text = "It has beem 50 years since we've left Wargen, our home world, to colonize and ";
		text.text += "explore new colonies in the vastness of the universe.";
		Color cl = text.material.color;
		cl.a = 1.0f;
		text.material.color = cl;
		if (timeElapsed > 400  * timeModifier) {
			text.text = "Our mission is to spread life, love and prosperity across the universe, ";
			text.text += "as this is the way of the Warg";
		}
		if (timeElapsed > 800  * timeModifier) {
			text.text = "We are approaching the first habitable world, where we are creating ";
			text.text += "prosperity and expanding life. We have already established a colony.";
		}
		if (timeElapsed > 1200  * timeModifier) {
			text.text = "One day ago, we have lost signal from the colony, and I have been sent ";
			text.text += "to investigate the status.";
		}
		if (timeElapsed > 1600  * timeModifier) {
			text.text = "What could have happened? Are there just disturbances in signal fields,";
			text.text += "or is it something more sinister...";
		}
	}

	void fadeOutOfBlack () {
		Color d = img.color;
		d.r = 0.0f;
		d.g = 0.0f;
		d.b = 0.0f;
		d.a = Mathf.Max(1.0f - (float)((float)timeElapsed * 0.01f), 0.0f);
		img.color = d;
	}

	void fadeToWhite () {
		Color d = img.color;
		d.r = 1.0f;
		d.g = 1.0f;
		d.b = 1.0f;
		d.a = Mathf.Min(timeSinceEndDialog, 1.0f);
		img.color = d;
	}

}
