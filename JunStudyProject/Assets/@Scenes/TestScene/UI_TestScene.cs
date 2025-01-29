using System;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class UI_TestScene : MonoBehaviour
{
    [SerializeField] TestScene scene;
    [SerializeField] Button testBtn;

    Subject<int> test;

    private void Start()
    {
        scene = FindFirstObjectByType<TestScene>();

    }
}
