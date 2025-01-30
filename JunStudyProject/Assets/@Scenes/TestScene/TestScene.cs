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

    }
}
