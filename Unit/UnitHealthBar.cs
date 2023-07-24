using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBar : MonoBehaviour
{
    [SerializeField] Image unitHealthBarImage;
    private UnitHealthSystem unitHealthSystem;
    // Start is called before the first frame update
    void Start()
    {
        UnitHealthSystem.OnDamaged+=UnitHealthSystem_OnDamaged;
        unitHealthSystem=GetComponent<UnitHealthSystem>();

    }

    public void UnitHealthSystem_OnDamaged(object sender , EventArgs empty)
    {
        
        unitHealthBarImage.fillAmount=unitHealthSystem.GetHealthNormalized();
    }
}
