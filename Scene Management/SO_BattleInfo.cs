using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Battle Data",menuName="Scriptable Objects/Level/Battle Info")]
public class SO_BattleInfo : ScriptableObject
{
    [SerializeField] public string BattleName;
    [SerializeField] public int CreditReward;
    [SerializeField] public int SupplyReward;
    [SerializeField] public int InfluenceReward;
    [SerializeField] public int UnitSupplyLimitForBattle;
    [SerializeField] public bool IsBattleCompleted;
    [SerializeField] List<Unit> EnemyUnits;
    [SerializeField] List<Vector3> EnemyUnitSpawnPosition;
}
