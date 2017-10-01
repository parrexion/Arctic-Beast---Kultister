using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Coroutine activeMenu;

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

    public void ShowLeaveMenu()
    {
        this.isPaused = true;
        this.InfoText.text = "You are about to leave the zone.";
        this.activeMenu = StartCoroutine(unPauseAfter(5f));
    }
    
    public void ShowDeathMenu()
    {
        this.isPaused = true; 
        this.InfoText.text = "Y O U   D I E D";
        this.activeMenu = StartCoroutine( unPauseAfter(5f) ) ;
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
	
	// Update is called once per frame
	void Update () {
        if (this.isPaused && this.activeMenu != null && Input.GetKeyDown("space"))
        {
            StopCoroutine(this.activeMenu);
            this.activeMenu = null;
        }        
	}
}
