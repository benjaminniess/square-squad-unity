[System.Serializable]
public class SaveData
{
    private int musicVolume = 80;

    private int fxVolume = -20;

    public int GetMusicVolume()
    {
        return musicVolume;
    }

    public int GetFXVolume()
    {
        return fxVolume;
    }

    public void SetMusicVolume(int volume)
    {
        musicVolume = volume;
    }

    public void SetFXVolume(int volume)
    {
        fxVolume = volume;
    }
}
