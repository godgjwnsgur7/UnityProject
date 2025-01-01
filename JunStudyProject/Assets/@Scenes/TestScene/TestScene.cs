using UnityEngine;

public class TestScene : MonoBehaviour
{
    [SerializeField] UI_TestScene ui;

    private void Start()
    {
        ui.IsTestCheck += Test1;
        ui.IsTestCheck += Test2;
        ui.IsTestCheck += Test3;
    }

    public bool Test1(bool b)
    {
        return true;
    }

    public bool Test2(bool b)
    {
        return false;
    }

    public bool Test3(bool b)
    {
        return true;
    }
}
