using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//<summary>
//Singleton monobehaviour is an abstract class for all the singletons that need to extend monobehaviour.
//Singletons will be generic
//<summary>

public abstract class  SingletonMonobehaviour<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T Instance{get; private set;}
    protected string className;
    protected virtual void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            Debug.LogWarning($"Instance of class {className} already exists");
            return;
        }
        Instance=this as T;
    }
}
