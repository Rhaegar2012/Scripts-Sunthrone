using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : SingletonMonobehaviour<TurnSystem>
{
    //Events
    public event EventHandler OnTurnChanged;
    //Fields
    private int turnNumber=1;
    private bool playerTurn=true;
    
    public bool IsPlayerTurn()
    {
        return playerTurn;
    }
    public int GetTurnNumber()
    {
        return turnNumber;
    }
    public void NextTurn()
    {
        playerTurn=!playerTurn;
        turnNumber++;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }
}
