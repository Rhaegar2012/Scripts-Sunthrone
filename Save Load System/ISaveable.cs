public interface ISaveable
{
    //Properties
    string ISaveableUniqueID {get;set;}
    GameObjectSave GameObjectSave {get;set;}
    //Registers object with game save load manager
    void ISaveableRegister();
    //Deristers object with game save load manager
    void ISaveableDeregister();
    //Stores scene state
    void ISaveableStoreSceneState(string sceneName);
    //Restores scene state
    void ISaveableRestoreSceneState();


}
