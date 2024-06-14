using System.Buffers.Text;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class  BossHP : MonoBehaviour
{
    public double damagePerClick = 1;

    public GameObject nextBoss;
    public Transform spawn;

    private double HP;
    private double currentHP = 10;
    public static double healthMultiplier = 1.75;

    public double MaxHP;

    private Slider healthSlider;
    private Text healthText;

    private void Start()
    {

        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>();

        GameObject textHeal = GameObject.FindWithTag("hpCOUNT");
        healthText = textHeal.GetComponent<Text>();

        LoadGame();

        HP = currentHP * healthMultiplier;
        MaxHP = HP;
        healthSlider.maxValue = (int)(HP);
        healthSlider.value = (int)(HP);

        healthText.text = ((int)HP).ToString() + "/" + ((int)MaxHP).ToString();
    }

    private void Update()
    {
        AttackBoss();
        BossDestroy();
    }


    public void AttackBoss()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {

                    HP -= damagePerClick;

                    Debug.Log("HP = " + (float)HP);
                    healthSlider.value = (int)HP;
                    healthText.text = ((int)HP).ToString() + "/" + ((int)MaxHP).ToString();

                    
                    SaveGame();


                }
            }
        }
    }

    public void BossDestroy()
    {
        if (HP <= 0)
        {
        
            healthSlider.value = healthSlider.maxValue;

            Destroy(gameObject);
            healthMultiplier *= 1.25;
            Instantiate(nextBoss, spawn.position, spawn.rotation);

            
            SaveGame();
        }
    }

    public void SaveGame()
    {
        GameData data = new GameData();
        data.bossHP = HP;
        data.healthMultiplier = healthMultiplier;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bossdata.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/bossdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            HP = data.bossHP;
            healthMultiplier = data.healthMultiplier;
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }






}


