using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour {

    #region Singleton
    public static TurnManager instance = null;
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    #endregion

    public bool isPlayerTurn;
    public bool isNpcTurn;
    public bool isPaused;

    public Text InfoText;


    public void passPlayerTurn()
    {
        this.isPlayerTurn = false;
        this.isNpcTurn = true;
    }
    public void suspendPlayerTurn()
    {
        this.isPlayerTurn = false;
    }
    public void passNPCTurn()
    {
        this.isPlayerTurn = true;
        this.isNpcTurn = false;
    }

    public bool playerCanAct()
    {
        return this.isPlayerTurn && !this.isPaused;
    }
    public bool NPCCanAct()
    {
        return this.isNpcTurn && !this.isPaused;
    }

    public void FoundGoal(){
        StartCoroutine(ShowLeaveMenu());
    }

    public IEnumerator ShowLeaveMenu()
    {
        this.isPaused = true;
        this.InfoText.text = "You are leaving the zone.";
        yield return unPauseAfter(3f);
        MoveOnToNextLevel();
    }
    
    public void PlayerDied(){
        StartCoroutine(ShowDeathMenu());
    }
    public IEnumerator ShowDeathMenu()
    {
        this.isPaused = true; 
        this.InfoText.text = "Y O U   D I E D";
        yield return unPauseAfter(3f);
        ReturnToMain();
    }

    private IEnumerator unPauseAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.isPaused = false;    
    }

    // Use this for initialization
    void Start () {
        this.InfoText.text = "";
	}
	

    public void MoveOnToNextLevel(){
        PlayerStats.instance.days++;
        PlayerStats.instance.currentLocation = (LevelSpec.instance.nextLevelID != -1) ? LevelSpec.instance.levelID: 0;
        
        if (InventoryHandler.instance.rune != null){
            PlayerStats.instance.foundRunes[LevelSpec.instance.levelID] = true;
            InventoryHandler.instance.SetRune(null);
        }
        
        SceneManager.LoadScene(1);
    }

    public void ReturnToMain(){
        Destroy(GlobalValues.instance.gameObject);
        Destroy(MapPanelSetup.instance.gameObject);
        SceneManager.LoadScene(0);
    }
}
