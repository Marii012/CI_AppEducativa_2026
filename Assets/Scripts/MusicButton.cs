using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;

    private Image icon;

    void Start()
    {
        icon = GetComponent<Image>();
        UpdateIcon();
    }

    public void ToggleMusic()
    {
        MusicPlayer.Instance.ToggleMusic();
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (MusicPlayer.Instance == null || icon == null) return;

        icon.sprite = MusicPlayer.Instance.IsMuted()
            ? musicOffIcon
            : musicOnIcon;
    }
}