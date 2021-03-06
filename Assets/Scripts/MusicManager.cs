using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    public Slider slider;

    AudioSource audio
    {
        get => GetComponent<AudioSource>();
    }

    public AudioMixer mixer;

    [SerializeField]
    private string volumeName;

    [SerializeField]
    private Text volumeLabel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateValueOnChange(slider.value);

        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }

    public void UpdateValueOnChange(float value)
    {
        if (mixer != null)
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);

        if (volumeLabel != null)
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }

    public void SoundTurnOff() => audio.enabled = false;

    public void SoundTurnOn() => audio.enabled = true;
}