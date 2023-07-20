using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBar : MonoBehaviour
{
    [SerializeField] Image unitHealthBarImage;
    // Start is called before the first frame update
    void Start()
    {
        UnitHealthSystem.OnDamaged+=UnitHealthSystem_OnDamaged;
    }

    public void UnitHealthSystem_OnDamaged(object sender , UnitHealthSystem unitHealthSystem)
    {
        unitHealthBarImage.fillAmount=unitHealthSystem.GetHealthNormalized();
    }
}
