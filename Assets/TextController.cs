using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    // Use this for initialization
    public Text froggo;
    public Fruit f;
    public FruitSpawner fs;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (fs.isGameEnd())
        {
            froggo.text = "Your score is " + f.getScore().ToString() + " Froggos.\nEnjoy Loss";
        }
        else
        {
            froggo.text = "Froggo: " + f.getScore().ToString() +
            "\n" + "Remaining: " + fs.getRemaining().ToString() +
            "\n" + "Combo: " + f.getCombo().ToString() +
            "\n" + "Multiplier: " + f.getMultiplier().ToString() + "x";
        }
        
    }
}
