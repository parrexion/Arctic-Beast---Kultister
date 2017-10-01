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

    public Text LeaveText;

    public void passPlayerturn()
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
        this.LeaveText.text = "You are about to leave the zone.";
        StartCoroutine(unPauseAfter(5f));
    }

    private IEnumerator unPauseAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.isPaused = false;    
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
