using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    [SerializeField] UI_TestScene ui;

    private void Start()
    {
        ui = FindFirstObjectByType<UI_TestScene>();

        // StartCoroutine(Test1());
        StartCoroutine(Test2());

    }

    public IEnumerator Test1()
    {
        var stream1 = Observable.Interval(TimeSpan.FromSeconds(1));
        stream1.Subscribe(x => Debug.Log($"1 : {Time.time.ToString()}"));
        yield return new WaitForSeconds(0.1f);
        stream1.Subscribe(x => Debug.Log($"2 : {Time.time.ToString()}"));
        yield return new WaitForSeconds(0.1f);
        stream1.Subscribe(x => Debug.Log($"3 : {Time.time.ToString()}"));
    } 

    public IEnumerator Test2()
    {
        var stream2 = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
        stream2.Subscribe(x => Debug.Log($"1 : {Time.time.ToString()}"));
        yield return new WaitForSeconds(0.1f);
        stream2.Subscribe(x => Debug.Log($"2 : {Time.time.ToString()}"));
        yield return new WaitForSeconds(0.1f);
        stream2.Subscribe(x => Debug.Log($"3 : {Time.time.ToString()}"));
    }
}
