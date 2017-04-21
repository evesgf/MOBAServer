using UnityEngine;
using System.Collections;

public class Paths : MonoBehaviour {

    /// <summary>
    /// ui声音的路径
    /// </summary>
    public const string RES_SOUND_UI = "Sound/UI/";

    /// <summary>
    /// 获取声音的全路径
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetSoundFullName(string name)
    {
        return RES_SOUND_UI + name;
    }

    /// <summary>
    /// UI的路径
    /// </summary>
    public const string RES_UI = "UI/";
}
