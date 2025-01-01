using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class UI_TestScene : MonoBehaviour
{
    [SerializeField] TestScene scene;

    public event Func<bool, bool> IsTestCheck;
    
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
