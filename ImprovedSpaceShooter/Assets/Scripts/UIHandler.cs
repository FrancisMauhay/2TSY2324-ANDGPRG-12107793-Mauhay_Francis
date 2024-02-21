using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIHandler : MonoBehaviour
{
    [SerializeField] AudioSource BGM;

    [SerializeField] AudioMixer AudioMixer;

    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SFXSlider;

    bool EnableSound = true;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    
    void Toggle()
    {
        if(!EnableSound)
        {
            EnableSound = true;
            MasterSlider.value = 1;
        }
        else
        {
            EnableSound=false;
            MasterSlider.value = 0;
        }
    }

    public void MasterSliderChange()
    {
        ChangeVol("MasterVolume",MasterSlider.value);
    }

    public void BGMSliderChange()
    {
        ChangeVol("BGMVolume",BGMSlider.value);
    }

    public void SFXSliderChange()
    {
        ChangeVol("SFXVolume",SFXSlider.value);
    }

    void ChangeVol(string name, float value)
    {
        float dbVolume = Mathf.Log10(value) * 20;
        if (value == 0.0f)
        {
            dbVolume = -80.0f;
        }
        AudioMixer.SetFloat(name, dbVolume);
    }
}
