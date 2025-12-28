using UnityEngine;
using UnityEngine.UI;

public class SettingsSwitcher : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource musicSource;
    public AudioSource[] sfxSources;

    [Header("UI Images")]
    public Image musicImage;
    public Image sfxImage;

    [Header("States")]
    public bool musicOn = true;
    public bool sfxOn = true;

    [Header("Transparency Settings")]
    [Range(0f, 1f)] public float offAlpha = 0.5f; // прозрачность, когда выключено
    [Range(0f, 1f)] public float onAlpha = 1f;    // прозрачность, когда включено

    private void Start()
    {
        ApplyMusicState();
        ApplySfxState();
    }

    // --------------------
    // SWITCHERS
    // --------------------

    public void SwitchMusic()
    {
        musicOn = !musicOn;
        ApplyMusicState();
    }

    public void SwitchSfx()
    {
        sfxOn = !sfxOn;
        ApplySfxState();
    }

    // --------------------
    // APPLY STATES
    // --------------------

    void ApplyMusicState()
    {
        if (musicSource != null)
            musicSource.mute = !musicOn;

        if (musicImage != null)
        {
            Color c = musicImage.color;
            c.a = musicOn ? onAlpha : offAlpha;
            musicImage.color = c;
        }
    }

    void ApplySfxState()
    {
        foreach (AudioSource sfx in sfxSources)
        {
            if (sfx != null)
                sfx.mute = !sfxOn;
        }

        if (sfxImage != null)
        {
            Color c = sfxImage.color;
            c.a = sfxOn ? onAlpha : offAlpha;
            sfxImage.color = c;
        }
    }
}
