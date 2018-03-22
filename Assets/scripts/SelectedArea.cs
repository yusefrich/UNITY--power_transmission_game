using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SelectedArea : MonoBehaviour {
    public int startingAtack;
    public int startingDef;
    private int atack;
    private int def;

    TextMeshProUGUI atackText;
    TextMeshProUGUI defText;
    public TextMeshProUGUI score;
    public Text maxScore1;
    public Text maxScore2;
    public Text maxScore3;


    //movementPlaces
    public Transform selected1;
    public Transform selected2;
    public GameObject camera; 

    bool player12Switch = true;
    bool player23Switch = false;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    PowersController player1Cont;
    PowersController player2Cont;
    PowersController player3Cont;
    public GameObject playerAtack;

    //canvas
    public GameObject startMenuCanvas;
    public GameObject endMenuCanvas;
    public GameObject pauseMenuCanvas;
    protected bool paused = true;// true = game paused, false == game not paused
    bool dead = false;

    //run time
    float start;
    float total;
    private int level;
    public float totalPerLevel;
    public float spawnSpace;

    // Use this for initialization
    void Start () {
        maxScore1.text = "MaxScore: " + PlayerPrefs.GetInt("highscore",0).ToString();
        maxScore2.text = "MaxScore: " + PlayerPrefs.GetInt("highscore",0).ToString();
        maxScore3.text = "MaxScore: " + PlayerPrefs.GetInt("highscore",0).ToString();


        start = gameObject.transform.position.x  - start;

        if (startMenuCanvas.activeInHierarchy == false)
        {
            StartGame();
        }
         player1Cont = player1.GetComponent<PowersController>();
        player2Cont = player2.GetComponent<PowersController>();
        player3Cont = player3.GetComponent<PowersController>();
        //seting players code
        player1Cont.setPlayerCode(1);
        player2Cont.setPlayerCode(2);
        player3Cont.setPlayerCode(3);
        //settingPowers
        player1Cont.SetPower(1);
        player2Cont.SetPower(2);
        player3Cont.SetPower(3);
        //instantiatingPowers
        player1Cont.InstantiateBadge();
        player2Cont.InstantiateBadge();
        player3Cont.InstantiateBadge();

        //reference for displaying info


        atack = startingAtack;
        def = startingDef;
	}
	public void StartGame()
    {
        paused = false;
        startMenuCanvas.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        //modifiingMyPossition
        gameObject.transform.position = new Vector3(camera.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        atackText = GameObject.FindGameObjectWithTag("BAtack").GetComponent<TextMeshProUGUI>();
        defText = GameObject.FindGameObjectWithTag("BDef").GetComponent<TextMeshProUGUI>();


        atackText.SetText("Atk: " + atack.ToString()); 
        defText.SetText("Def: " + def.ToString()); 

        CalculateLevel();
        int scoreValue = (int)total;
        score.SetText("Score: " + scoreValue.ToString());


        if (scoreValue > PlayerPrefs.GetInt("highscore",0))
        {
            PlayerPrefs.SetInt("highscore", scoreValue);
            maxScore1.text = "MaxScore: " + scoreValue.ToString();
            maxScore2.text = "MaxScore: " + scoreValue.ToString();
            maxScore3.text = "MaxScore: " + scoreValue.ToString();

        }

        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = true;
                pauseMenuCanvas.SetActive(true);

            }

        }
        if (!paused)
        {
            
            if (Input.GetKeyDown("w"))
            {
                transform.localPosition = new Vector3(transform.localPosition.x, selected1.transform.localPosition.y, transform.localPosition.z);
                player12Switch = true;
                player23Switch = false;
                //fast switch
                int power1 = player1Cont.GetPower();
                int power2 = player2Cont.GetPower();
                player1Cont.SetPower(power2);
                player2Cont.SetPower(power1);
                //instantiating badges
                player1Cont.InstantiateBadge();
                player2Cont.InstantiateBadge();
                player3Cont.InstantiateBadge();

            }
             if (Input.GetKeyDown("s"))
            {
                transform.localPosition = new Vector3(transform.localPosition.x, selected2.transform.localPosition.y, transform.localPosition.z);
                player23Switch = true;
                player12Switch = false;
                //fastswitch
                int power2 = player2Cont.GetPower();
                int power3 = player3Cont.GetPower();
                player2Cont.SetPower(power3);
                player3Cont.SetPower(power2);
                //instantiating badges
                player1Cont.InstantiateBadge();
                player2Cont.InstantiateBadge();
                player3Cont.InstantiateBadge();

            }

            if (Input.GetKeyDown("e"))
            {
                if (player12Switch)
                {
                    int power1 = player1Cont.GetPower();
                    int power2 = player2Cont.GetPower();
                    player1Cont.SetPower(power2);
                    player2Cont.SetPower(power1);
                    //instantiating badges
                    player1Cont.InstantiateBadge();
                    player2Cont.InstantiateBadge();
                    player3Cont.InstantiateBadge();


                }
                else if (player23Switch)
                {
                    int power2 = player2Cont.GetPower();
                    int power3 = player3Cont.GetPower();
                    player2Cont.SetPower(power3);
                    player3Cont.SetPower(power2);
                    //instantiating badges
                    player1Cont.InstantiateBadge();
                    player2Cont.InstantiateBadge();
                    player3Cont.InstantiateBadge();


                }
            }

        }

    }
    public void SwitchOne()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, selected1.transform.localPosition.y, transform.localPosition.z);
        player12Switch = true;
        player23Switch = false;
        //fast switch
        int power1 = player1Cont.GetPower();
        int power2 = player2Cont.GetPower();
        player1Cont.SetPower(power2);
        player2Cont.SetPower(power1);
        //instantiating badges
        player1Cont.InstantiateBadge();
        player2Cont.InstantiateBadge();
        player3Cont.InstantiateBadge();

    }
    public void SwitchTwo()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, selected2.transform.localPosition.y, transform.localPosition.z);
        player23Switch = true;
        player12Switch = false;
        //fastswitch
        int power2 = player2Cont.GetPower();
        int power3 = player3Cont.GetPower();
        player2Cont.SetPower(power3);
        player3Cont.SetPower(power2);
        //instantiating badges
        player1Cont.InstantiateBadge();
        player2Cont.InstantiateBadge();
        player3Cont.InstantiateBadge();

    }
    public void Contact(int obsType, int powerType, int dmg, int playerCode, int heal)
    {
        if (playerCode == 1)//codigo do jogador
        {
            if (powerType == 1)//tipo do poder do jogador
            {
                if(obsType == 1)//tipo do obstaculo do jogador
                {
                    if(atack < dmg)
                    {
                        //jogador perde o combate
                        int data = dmg -atack;
                        player1Cont.SetLife(data);
                        atack--;
                    }else
                    {
                        //jogador ganha o combate
                        atack--;
                    }
                }
                if (obsType == 2)
                {

                    //jogador tem dano mas encontra uma trap
                    player1Cont.SetLife(dmg);
                }
                if(obsType == 3)
                {
                    atack = atack + heal;
                }
            }
            else if (powerType == 2)
            {
                if(obsType == 1)
                {
                    if(def < dmg)
                    {
                        player1Cont.SetLife(dmg - def);
                        def--;
                        def--;
                    }
                    else
                    {
                        def--;
                        def--;
                    }
                }else if(obsType == 2)
                {
                    if (def < dmg)
                    {
                        player1Cont.SetLife(dmg - def);
                        def--;
                    }
                    else
                    {
                        def--;
                    }
                }else if (obsType == 3)
                {
                    def = def + heal;
                }
            }
            else if (powerType == 3)
            {
                player1Cont.SetLife(dmg);
                if(obsType == 3)
                {
                    player1Cont.SetLife(-heal);
                }
            }

        }
        if (playerCode == 2)//codigo do jogador
        {
            if (powerType == 1)//tipo do poder do jogador
            {
                if (obsType == 1)//tipo do obstaculo do jogador
                {
                    if (atack < dmg)
                    {
                        //jogador perde o combate
                        int data = dmg - atack;
                        player2Cont.SetLife(data);
                        atack--;
                    }
                    else
                    {
                        //jogador ganha o combate
                        atack--;
                    }
                }
                if (obsType == 2)
                {

                    //jogador tem dano mas encontra uma trap
                    player2Cont.SetLife(dmg);
                }
                if (obsType == 3)
                {
                    atack = atack + heal;
                }
            }
            else if (powerType == 2)
            {
                if (obsType == 1)
                {
                    if (def < dmg)
                    {
                        player2Cont.SetLife(dmg - def);
                        def--;
                        def--;
                    }
                    else
                    {
                        def--;
                        def--;
                    }
                }
                else if (obsType == 2)
                {
                    if (def < dmg)
                    {
                        player2Cont.SetLife(dmg - def);
                        def--;
                    }
                    else
                    {
                        def--;
                    }
                }
                else if (obsType == 3)
                {
                    def = def + heal;
                }
            }
            else if (powerType == 3)
            {
                player2Cont.SetLife(dmg);
                if (obsType == 3)
                {
                    player2Cont.SetLife(-heal);
                }
            }

        }
        if (playerCode == 3)//codigo do jogador
        {
            if (powerType == 1)//tipo do poder do jogador
            {
                if (obsType == 1)//tipo do obstaculo do jogador
                {
                    if (atack < dmg)
                    {
                        //jogador perde o combate
                        int data = dmg - atack;
                        player3Cont.SetLife(data);
                        atack--;
                    }
                    else
                    {
                        //jogador ganha o combate
                        atack--;
                    }
                }
                if (obsType == 2)
                {

                    //jogador tem dano mas encontra uma trap
                    player3Cont.SetLife(dmg);
                }
                if (obsType == 3)
                {
                    atack = atack + heal;
                }
            }
            else if (powerType == 2)
            {
                if (obsType == 1)
                {
                    if (def < dmg)
                    {
                        player3Cont.SetLife(dmg - def);
                        def--;
                        def--;
                    }
                    else
                    {
                        def--;
                        def--;
                    }
                }
                else if (obsType == 2)
                {
                    if (def < dmg)
                    {
                        player3Cont.SetLife(dmg - def);
                        def--;
                    }
                    else
                    {
                        def--;
                    }
                }
                else if (obsType == 3)
                {
                    def = def + heal;
                }
            }
            else if (powerType == 3)
            {
                player3Cont.SetLife(dmg);
                if (obsType == 3)
                {
                    player3Cont.SetLife(-heal);
                }
            }

        }

    }
    public bool GetGameState()
    {
        return paused;
    }
    public void PauseGame()
    {
        paused = true;
        pauseMenuCanvas.SetActive(true);
    }
    public void ReturnGame()
    {
        paused = false;
        pauseMenuCanvas.SetActive(false);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("restart");
        paused = false;
        dead = false;
        endMenuCanvas.SetActive(false);
    }
    public void EndGame()
    {
        paused = true;
        dead = true;
        endMenuCanvas.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetGameState(bool isPaused)
    {
        paused = isPaused;
    }
    //incrissingDificulty
    void CalculateLevel()
    {
        total = gameObject.transform.position.x - start;
        print(total);
        if (total > totalPerLevel)
        {
            totalPerLevel = totalPerLevel + spawnSpace;
            level++;
            print("NEW LEVEL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1 === " + level);
        }

    }
    public int GetLevel()
    {
        return level;
    }


}
