using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSelectionButton : MonoBehaviour
{
   //TODO Refactor this method to call unit selection menu instead of launching battle by itself
   public void BattleSelected (string battleName)
   {
      LevelManager.Instance.LoadScene(battleName,true);
   }
}
