using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static class AudioName
    {
        public static string BGM { get; } = "bgm";
        public static string Miss { get; } = "miss";
        public static string MissNeta { get; } = "miss_neta";
        public static string Jump { get; } = "jump";
        public static string GameOver { get; } = "gameover_e";
        public static string Through { get; } = "though";
        public static string Warning { get; } = "warning";
        public static string ItemGet { get; } = "itemget";
        public static string Damage1 { get; } = "damage0";
        public static string Damage2 { get; } = "damage1";
        public static string GameOver6 { get; } = "gameover6";
        public static string Item0 { get; } = "item0";
        public static string Item1 { get; } = "item1";
        public static string Jump1 { get; } = "jump 1";
        public static string Menu { get; } = "menu";
        public static string Sentaku { get; } = "sentaku";
        public static string Sentaku0 { get; } = "sentaku0";
    }

    [SerializeField] private AudioSource _bgmAudioSource = null;
    [SerializeField] private AudioSource _seAudioSource = null;

    public void PlaySE(string audioName)
    {
        _seAudioSource.clip = Resources.Load("Sounds/" + audioName) as AudioClip;
        _seAudioSource.Play();
    }

    public void PlayBGM()
    {
        _bgmAudioSource.loop = true;
        _bgmAudioSource.clip = Resources.Load("Sounds/" + AudioName.BGM) as AudioClip;
        _bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        _bgmAudioSource.Stop();
    }
}