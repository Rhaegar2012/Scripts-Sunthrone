using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour,IPauseMenu
{
    [SerializeField] private int menuIndex;
    public int MenuIndex {get{return menuIndex;} set{menuIndex=value;}}
    public void SaveGame()
    {
        //TODO
    }

    public void LoadGame()
    {
        //TODO
    }

    public void MainMenu()
    {
        //TODO
    }

    public void QuitGame()
    {
        //TODO
    }



}
