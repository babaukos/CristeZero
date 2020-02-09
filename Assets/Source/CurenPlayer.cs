using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurenPlayer : MonoBehaviour
{
    Text text;
    Logic logic;
	// Use this for initialization
	void Start () 
    {
	    text = gameObject.GetComponentInChildren<Text>();
        logic = GameObject.Find("Panel").GetComponent<Logic>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        text.text = logic.PlayerS[logic.curentPlayer];
	}
}
