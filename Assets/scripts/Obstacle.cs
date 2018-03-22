using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Obstacle : MonoBehaviour
{

    public int startingDmg;
    private int dmg;
    public int myType;
    public int healQuant;
    public TextMeshProUGUI obsInfo;

    //Textures
    public Sprite enemy;
    public Sprite trap;
    public Sprite heal;
    Renderer rend;
    

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(myType == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = enemy;
        }else if (myType == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = trap;
        }else if (myType == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = heal;
        }
        //rend = enemy;

        if (obsInfo == null)
        {
            Debug.Log("need to atach the Text obeject to the obsInfo variable");
        }
        else
        {
            if(myType == 1)
            {
                obsInfo.SetText("Enemy - ATK: " + dmg.ToString());

            }
            else if (myType == 2)
            {
                obsInfo.SetText("Trap - DMG: " + dmg.ToString());

            }
            else if (myType == 3)
            {
                obsInfo.SetText("CURA: " + healQuant.ToString());

            }
        }
        //enemy or trap behavour
    }
    public int GetDmg()
    {
        return dmg;
    }
    public int GetObsType()
    {
        return myType;
    }
    public int getHealQuant()
    {
        return healQuant;
    }
    public void SetDmg(int value)
    {
        dmg = value;
    }
    public void SetObsType(int value)
    {
        myType = value;
    }
    public void setHealQuant(int value)
    {
        healQuant = value;
    }
}
