using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_TestScene : MonoBehaviour
{
    [SerializeField] TestScene scene;

    [SerializeField] Button btn;

    public event Func<bool, bool> IsTestCheck;

    private void Awake()
    {
        btn.OnClickAsObservable().Subscribe(_ => OnClickTest1());
    }

    public void OnClickTest1()
    {
        bool b = IsTestCheck.Invoke(true);

        Debug.LogWarning(b);
    }

    public void OnClickTest2()
    {
        bool b = IsTestCheck.Invoke(false);

        Debug.LogWarning(b);
    }

    public void OnClickTest3()
    {

    }

    public void OnClickTest4()
    {

    }

    private bool TestTrue() => true;
    private bool TestFalse() => false;
}
