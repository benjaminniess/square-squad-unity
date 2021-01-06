[System.Serializable]
public class SaveData
{
    private int musicVolume;

    private int fxVolume;

    private int ennemiesSpeed;

    private int ennemiesCount;

    private int bonusCount;

    private int coinsCount;

    private int playersSpeed;

    public void Reset()
    {
        musicVolume = 0;
        fxVolume = 0;
        ennemiesSpeed = 2;
        ennemiesCount = 3;
        bonusCount = 2;
        coinsCount = 1;
        playersSpeed = 3;
    }

    public int GetMusicVolume()
    {
        return musicVolume;
    }

    public int GetFXVolume()
    {
        return fxVolume;
    }

    public int GetPlayersSpeed()
    {
        return playersSpeed;
    }

    public int GetEnnemiesSpeed()
    {
        return ennemiesSpeed;
    }

    public int GetEnnemmiesCount()
    {
        return ennemiesCount;
    }

    public int GetBonusCount()
    {
        return bonusCount;
    }

    public int GetCoinsCount()
    {
        return coinsCount;
    }

    public void SetMusicVolume(int volume)
    {
        if (volume <= -50)
        {
            volume = -80;
        }

        musicVolume = volume;
    }

    public void SetFXVolume(int volume)
    {
        fxVolume = volume;
    }

    public void SetPlayersSpeed(int speed)
    {
        playersSpeed = speed;
    }

    public void SetEnnemiesSpeed(int speed)
    {
        ennemiesSpeed = speed;
    }

    public void SetEnnemiesCount(int count)
    {
        ennemiesCount = count;
    }

    public void SetBonusCount(int count)
    {
        bonusCount = count;
    }

    public void SetCoinsCount(int count)
    {
        coinsCount = count;
    }
}
