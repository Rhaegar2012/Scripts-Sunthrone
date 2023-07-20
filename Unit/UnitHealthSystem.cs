using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthSystem : MonoBehaviour
{
    //Events
    public static event EventHandler<Unit> OnAnyUnitDestroyed;
    public static event EventHandler<UnitHealthSystem> OnDamaged;
    //Fields
    private int healthPoints;
    private int totalHealth;
    private Unit unit;
    void Awake()
    {
        //Subscribe to damage event from attack action
        AttackAction.OnUnitDamaged+=AttackAction_OnUnitDamaged;
        unit= GetComponent<Unit>();
        healthPoints=unit.GetHealth();
        totalHealth=healthPoints;
    }


    public void AttackAction_OnUnitDamaged(object sender, Unit unit)
    {
        healthPoints-=unit.DamageAmount;
        OnDamaged?.Invoke(this,this);
        if(healthPoints<=0)
        {
            Die();
        }
       
    }
    public int GetHealth()
    {
        return healthPoints;
    }
    private void Die()
    {
        Destroy(gameObject);
        OnAnyUnitDestroyed?.Invoke(this,unit);
    }
    public float GetHealthNormalized()
    {
        return (float)healthPoints/totalHealth;
    }



}
