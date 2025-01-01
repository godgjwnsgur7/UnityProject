//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    /// <summary>
    /// 씬 이름과 같아야 함
    /// </summary>
    public enum EScene
    {
        Unknown,
        TitleScene,
        GameScene,
    }

    /// <summary>
    /// 유니티 에디터의 레이어와 같아야 함
    /// </summary>
    public enum ELayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,

        Water = 4,
        UI = 5,

        Player = 6,
        Npc = 7,
        Monster = 8,
        Ground = 9,
    }

    /// <summary>
    /// 유니티 에디터에 태그가 있어야 함
    /// </summary>
    public enum ETag
    {
        Untagged,
        
        Respawn,
        Finish,
        EditorOnly,
        MainCamera,
        Player,
        GameController,
        
    }

    public enum EPlayerInputSchemeType
    {
        KeyboardMouse,
        GamePad,
        Touch,
        Joystick,
        XR,
    }

    public enum EPlayerInputMapType
    {
        Player,
        UI,
    }
}