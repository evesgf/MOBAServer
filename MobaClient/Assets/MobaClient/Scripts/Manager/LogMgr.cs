using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 封装log输出
/// </summary>
public class LogMgr {

    //debug
    public static Action<object> Debug = UnityEngine.Debug.Log;

    //release
    //public static void Debug(string text) { }
}
