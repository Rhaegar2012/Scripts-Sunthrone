using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSelectionMarker : MonoBehaviour
{
    [SerializeField] private Button battleSelectionButton;
    [SerializeField] private Image selectionIconImage;
    [SerializeField] private Sprite bronzeMedalSprite;
    [SerializeField] private Sprite silverMedalSprite;
    [SerializeField] private Sprite goldMedalSprite;
    [SerializeField] private Sprite noneMedalSprite;
    [SerializeField] private string battleName;

    //Properties
    public string BattleName {get{return battleName;}set{battleName=value;}}

    public void UpdateButtonIcon(BattleMedalAward award)
    {
        switch(award)
        {
            case BattleMedalAward.NoMedal:
                selectionIconImage.sprite=noneMedalSprite;
                break;
            case BattleMedalAward.Bronze:
                selectionIconImage.sprite=bronzeMedalSprite;
                break;
            case BattleMedalAward.Silver:
                selectionIconImage.sprite=silverMedalSprite;
                break;
            case BattleMedalAward.Gold:
                selectionIconImage.sprite=goldMedalSprite;
                break;
        }
    }
}
