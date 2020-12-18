[System.Serializable]
public class SaveData
{
    private int musicVolume = 0;

    private int fxVolume = 0;

    private int ennemiesSpeed = 5;

    private int ennemiesCount = 3;

    private int bonusCount = 2;

    private int coinsCount = 1;

    private int playersSpeed = 10;

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
