using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSelectionButton : MonoBehaviour
{
   [SerializeField] GameObject unitSelectionMenu;
   //TODO Refactor this method to call unit selection menu instead of launching battle by itself
   public void BattleSelected (SO_BattleInfo battleInfo)
   {
      BattleInformationMenu battleInformation=unitSelectionMenu.GetComponent<BattleInformationMenu>();
      battleInformation.SetBattleInfo(battleInfo);
      unitSelectionMenu.SetActive(true);
   }
}
