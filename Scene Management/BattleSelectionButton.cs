using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSelectionButton : MonoBehaviour
{
   public void BattleSelected (string battleName)
   {
      Debug.Log("Event accessed");
      LevelManager.Instance.LoadScene(battleName);
   }
}
