using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowersController : MonoBehaviour {

    public int startingLife;
    private int life;
    private int maxHealth;
    private int power;
    public Image healthBar;
    public GameObject playerAtack;

    AudioSource deathSound;
    public bool playOnce = true;

    SelectedArea selectedAreaScrp;

    GameObject badge;
    public GameObject badge1;
    public GameObject badge2;
    public GameObject badge3;
    public int myPlayerCode;

    bool pausedGame = true;
    bool callDeathOnce;



    // Use this for initialization
    void Start () {
        deathSound = GetComponent<AudioSource>();
        playOnce = true;
        callDeathOnce = true;
        selectedAreaScrp = GameObject.FindGameObjectWithTag("select").GetComponent<SelectedArea>();
        life = startingLife;
        maxHealth = startingLife;

    }
    public void ReportCollision(int obstype, int dmg, int heal)
    {

        selectedAreaScrp.Contact(obstype, power, dmg, myPlayerCode, heal);
    }
   public void SetLife(int dmg)
    {
        life = life - dmg;
    }
    public void setPlayerCode(int code)
    {
        myPlayerCode = code;
    }
	public void SetPower(int type)
    {
        power = type;
    }
    public int GetPower()
    {
        return power;
    }
    public void InstantiateBadge()
    {
        if(power == 1)
        {
            if(badge != null)
            {
                Destroy(badge);
            }
            
                badge = Instantiate(badge1, gameObject.transform);
                badge.transform.localPosition = new Vector3(0, 2, 0);


        }
        else if(power == 2)
        {
            if (badge != null)
            {
                Destroy(badge);
            }
            
            
                badge = Instantiate(badge2, gameObject.transform);
                badge.transform.localPosition = new Vector3(0, 2, 0);
            

        }
        else if(power == 3)
        {
            if (badge != null)
            {
                Destroy(badge);
            }
            
            
                badge = Instantiate(badge3, gameObject.transform);
                badge.transform.localPosition = new Vector3(0, 2, 0);
            

        }
    }

	// Update is called once per frame
	void Update () {
        if(life <= 0)
        {
            if (callDeathOnce)
            {
                selectedAreaScrp.EndGame();

                callDeathOnce = false;
                if (playOnce)
                {
                    deathSound.Play();
                    playOnce = false;
                }
            }
        }
		 
        
            healthBar.fillAmount = (float)life / (float)maxHealth;

        


    }

    
}
