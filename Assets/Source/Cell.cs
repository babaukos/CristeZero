using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class Cell : MonoBehaviour , IPointerClickHandler
{

    public Text text;
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
	
	}
    //
    public void OnPointerClick(PointerEventData eventData)
    {
        //if(text.text == "")
       // {
           if (logic.PlayerStep > 0)
           {
             text.text = logic.PlayerS[logic.curentPlayer];
             logic.CheckIsWin(text.text);
             logic.PlayerStep -= 1;
           }
       // }

    }
}
