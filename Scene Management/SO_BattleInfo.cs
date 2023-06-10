using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Battle Data",menuName="Scriptable Objects/Level/Battle Info")]
public class SO_BattleInfo : ScriptableObject
{
    [Header("Battle Information")]
    [SerializeField] public string BattleName;
    [SerializeField] public Sprite BattleEnvironmentSprite;
    [Header("Battle Rewards")]
    [SerializeField] public int CreditReward;
    [SerializeField] public int SupplyReward;
    [SerializeField] public int InfluenceReward;
    [SerializeField] public BattleMedalAward awardedMedal;
    [Header("Battle Configuration")]
    [SerializeField] public int UnitSupplyLimitForBattle;
    [SerializeField] public bool IsBattleCompleted;
    [SerializeField] List<Unit> PlayerUnits;
    [SerializeField] List<Unit> EnemyUnits;
    [SerializeField] List<Vector3> EnemyUnitSpawnPosition;

    public void GetBattleUnits(out List<Unit> playerUnitList, out List<Unit> enemy)
    {
        playerUnitList=PlayerUnits;
        enemyUnitList=EnemyUnits;
    }

    public List<Vector2> GetEnemySpawnPositions()
    {
        //TODO
    }
}
