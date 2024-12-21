using UnityEngine;

public class UI_GameScene : UI_BaseScene
{
    #region OnClickEvent
    public void OnClickGoToTitleScene()
    {
        Managers.Scene.LoadScene(Define.EScene.TitleScene);
    }
    #endregion

}