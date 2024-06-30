using UnityEngine;
using System.IO;

public class SaveLoad : DamagePopup
{
    public void SaveGame()
    {
        GameData data = new GameData();

        data.bossHP = bossHP;
        data.healthMultiplier = healthMultiplier;
        data.coinData = coinAmount;
        data.damagePerClick = damagePerClick;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bossdata.json", json);
    }

    public virtual void LoadGame()
    {


        string path = Application.persistentDataPath + "/bossdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            bossHP = data.bossHP;
            healthMultiplier = data.healthMultiplier;
            coinAmount = data.coinData;
            damagePerClick = data.damagePerClick;

        }
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }
}

