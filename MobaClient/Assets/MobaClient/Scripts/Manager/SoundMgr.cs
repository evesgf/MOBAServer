using UnityEngine;
using System.Collections;
using LarkFramework;
using System;

/// <summary>
/// 声音管理类
/// </summary>
public class SoundMgr : SingletonMono<SoundMgr> {

    /// <summary>
    /// 用来播放循环的背景音乐
    /// </summary>
    [SerializeField]
    private AudioSource bgmAudioSource;

    /// <summary>
    /// 特效的音乐
    /// </summary>
    [SerializeField]
    private AudioSource effectAudioSource;

    private void Start()
    {
        bgmAudioSource.loop = true;
        bgmAudioSource.playOnAwake = true;

        effectAudioSource.loop = false;
        effectAudioSource.playOnAwake = false;
    }

    #region 背景音乐 2017-4-19 23:14:54
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBgMusic(AudioClip clip)
    {
        if (clip == null)
            return;

        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    /// <summary>
    /// 背景音乐的音量
    /// </summary>
    public float BGVolume
    {
        get { return bgmAudioSource.volume; }
        set { bgmAudioSource.volume = value; }
    }

    /// <summary>
    /// 停止背景音乐的播放
    /// </summary>
    public void StopBgMusic()
    {
        bgmAudioSource.clip = null;
        bgmAudioSource.Stop();
    }
    #endregion

    #region 特效音乐 2017-4-19 23:19:11
    public void PlayEffectMusic(AudioClip clip)
    {
        if (clip == null)
            return;

        effectAudioSource.clip = clip;
        effectAudioSource.Play();
    }
    #endregion
}
