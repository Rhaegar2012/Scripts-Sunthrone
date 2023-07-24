using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthSystem : MonoBehaviour
{
    //Events
    public static event EventHandler<Unit> OnAnyUnitDestroyed;
    public static event EventHandler OnDamaged;
    //Fields
    private int healthPoints;
    private int totalHealth;
    private Unit unit;
    void Awake()
    {
        //Subscribe to damage event from attack action
        unit= GetComponent<Unit>();
        healthPoints=unit.GetHealth();
        totalHealth=healthPoints;
    }


    public void TakeDamage(int damageAmount)
    {
        healthPoints-=unit.DamageAmount;
        OnDamaged?.Invoke(this,EventArgs.Empty);
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
