using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Define;

public class SceneManagerEx
{
    public BaseScene CurrScene { get; private set; }

    private EScene nextScene = EScene.Unknown;

    private int loadingProgress = 100; // 0 ~ 100

    public void SetCurrentScene(BaseScene currScene)
    {
        CurrScene = currScene;
    }

    public bool IsCompleteLoadingScene() => loadingProgress == 100;
    public int GetLoadingSceneProgress() => loadingProgress;

    public void LoadScene(Define.EScene type)
    {
        nextScene = type;

        UIFadeEffectParam param = new UIFadeEffectParam(IsCompleteLoadingScene, LoadSceneAsync);
        Managers.UI.OpenPopupUI<UI_FadeEffectPopup>(param);
    }

    public void LoadSceneAsync()
    {
        Managers.Clear();
        coLoadSceneAsync = CoroutineHelper.StartCoroutine(CoLoadSceneAsync(nextScene));
    }

    private Coroutine coLoadSceneAsync = null;
    private IEnumerator CoLoadSceneAsync(Define.EScene type)
    {
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(GetSceneName(type));

        loadingProgress = 0;
        while (!AsyncLoad.isDone)
        {
            loadingProgress = (int)(AsyncLoad.progress * 100.0f);
            yield return null;
        }
        loadingProgress = 100;
        coLoadSceneAsync = null;
    }

    private string GetSceneName(Define.EScene type)
    {
        string name = System.Enum.GetName(typeof(Define.EScene), type);
        return name;
    }

    public void Clear()
    {
        CurrScene.Clear();
    }
}
