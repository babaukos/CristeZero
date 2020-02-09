using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Logic : MonoBehaviour 
{
     public List<string> PlayerS;
     public int curentPlayer;

     public GameObject cellObj;
     public float cellSize;
     private Cell[ , ] cell;
     public short WithHeight;
     public GameObject Menu;
     public GameObject TextWin;
     public int PlayerStep = 1;
     //public Cell 


	// Use this for initialization
	void Start () 
    {
        Menu.active = false;
        cell = new Cell[ WithHeight, WithHeight];
        for(short y = 0; y < WithHeight; y++)
        {
            for (short x = 0; x < WithHeight; x++)
            {
                GameObject cl = (GameObject) Instantiate(cellObj, transform.position, transform.rotation);
                cl.transform.parent = transform;
                cl.transform.localPosition = new Vector3(x * cellSize, y * cellSize, 0);
                cell[x, y] = cl.GetComponent<Cell>(); 
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    // Проверка на победителя
    public void CheckIsWin(string symbol)
    {
        int mdig, supdig, hor, ver;

        // Проверяем горизонталь и вертикаль
        for (int x = 0; x < WithHeight; x++)
        {
            hor = 0; ver = 0;
            for (int y = 0; y < WithHeight; y++)
            {
                if (cell[x, y].text.text == symbol)
                {
                    hor++;
                }
                if (cell[y, x].text.text == symbol)
                {
                    ver++;
                }
            }
            if ((hor == WithHeight) ||( ver == WithHeight))
            {
                TextWin.GetComponent<Text>().text = "Winner : " + PlayerS[curentPlayer];
                Menu.active = true;
            }

        }

        mdig = 0; supdig = 0;
        // Диагонали
        for (int x = 0; x < WithHeight; x++)
        {
            if (cell[x, x].text.text == symbol)
            {
                mdig++;
            }
            if (cell[x, 2 - x].text.text == symbol)
            {
                supdig++;
            }
        }
        if ((mdig == WithHeight) || (supdig == WithHeight))
        {
            TextWin.GetComponent<Text>().text = "Winner : " + PlayerS[curentPlayer];
            Menu.active = true;
        }

    }

    // Переключаем игрока
    public void NextPlayer() 
    {
        if (curentPlayer < PlayerS.Count-1)
        {
           curentPlayer += 1;
           PlayerStep = 1;
        }
        else 
            {
               curentPlayer = 0;
               PlayerStep = 1;
            }
    }

    // Перезагружаем игру
    public void RestartGame()
    {
        for (short y = 0; y < WithHeight; y++)
        {
            for (short x = 0; x < WithHeight; x++)
            {
                cell[x, y].text.text = " ";
            }
        }
        PlayerStep = 1;
        Menu.active = false;
    }

    // Выходим из игры
    public void ExitGame() 
    {
        Application.Quit();
    }
}
