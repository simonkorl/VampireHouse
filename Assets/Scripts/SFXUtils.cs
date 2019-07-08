﻿using UnityEngine;

public static class SFXUtils
{
    public enum Clips {
        Switch,
        Brickbreaking,
        ElectricMotor,
        ElectricMotorOff,
        Control,
        Discontrol,
        Pulley,
        WoodenBox,
        Count
    };

    private static bool _initialized = false;
    private static AudioClip[] _clips;
    private static AudioSource _audioSrc;

    private static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;
        _clips = new AudioClip[(int)Clips.Count];
		_clips[(int)Clips.Switch] = Resources.Load<AudioClip>("Audio/SFX/switch");
		_clips[(int)Clips.Brickbreaking] = Resources.Load<AudioClip>("Audio/SFX/brickbreaking");
		_clips[(int)Clips.ElectricMotor] = Resources.Load<AudioClip>("Audio/SFX/electricmotor");
		_clips[(int)Clips.ElectricMotorOff] = Resources.Load<AudioClip>("Audio/SFX/electricmotoroff");
		_clips[(int)Clips.Control] = Resources.Load<AudioClip>("Audio/SFX/control");
		_clips[(int)Clips.Discontrol] = Resources.Load<AudioClip>("Audio/SFX/discontrol");
		_clips[(int)Clips.Pulley] = Resources.Load<AudioClip>("Audio/SFX/pulley");
		_clips[(int)Clips.WoodenBox] = Resources.Load<AudioClip>("Audio/SFX/woodenbox");

        GameObject obj = GameObject.Find("Audio Manager");
        if (obj == null)
        {
            obj = new GameObject("Audio Manager");
            Object.DontDestroyOnLoad(obj);
        }
		_audioSrc = obj.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    public static AudioClip GetClip(Clips clip)
    {
        Initialize();
        return _clips[(int)clip];
    }

    public static void PlayOnce(Clips clip, float volume)
    {
        Initialize();
        _audioSrc.PlayOneShot(GetClip(clip), volume);
    }
}
