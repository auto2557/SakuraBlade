using System.Buffers.Text;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class  BossHP : MonoBehaviour
{
    public static double damagePerClick = 1;

    public GameObject nextBoss;
    public Transform spawn;

    private double HP;
    private double currentHP = 10;
    public static double healthMultiplier = 1.75;

    public double MaxHP;

    private Slider healthSlider;
    private Text healthText;

    
    public Text CoinText;
    public static double coin;
    public static double coinValue;
    public static double coinAmount;

    public GameObject spawnCoin;
    public Vector2 spawnArea;


    private void Start()
    {
        
        double randomCoin = Random.Range(50,100);


        coin = randomCoin;

        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>();

        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();

        GameObject textHeal = GameObject.FindWithTag("hpCOUNT");
        healthText = textHeal.GetComponent<Text>();


        LoadGame();

        HP = currentHP * healthMultiplier;
        MaxHP = HP;
        healthSlider.maxValue = (int)(HP);
        healthSlider.value = (int)(HP);

        CoinText.text = "Coin = " + ((int)coinAmount).ToString();
        healthText.text = ((int)HP).ToString() + "/" + ((int)MaxHP).ToString();
    }

    private void Update()
    {
        AttackBoss();
        BossDestroy();
    }


    private void AttackBoss()
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


    private void BossDestroy()
    {

        if (HP <= 0)
        {
        
            healthSlider.value = healthSlider.maxValue;

            Destroy(gameObject);
            SpawnObjects();

            healthMultiplier *= 1.25;
            Instantiate(nextBoss, spawn.position, spawn.rotation);
           

            coinAmount += coin;
            CoinText.text = "Coin = " + ((int)coinAmount).ToString();


            CoinText.text = "Coin = " + coinAmount.ToString();

            SaveGame();

        }
       
    }

    private void SpawnObjects()
    {

        int randomCoinspawn = Random.Range(20, 35);
        for (int i = 0; i < randomCoinspawn; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2)

                );
            GameObject spawnedCoin = Instantiate(spawnCoin, randomPosition, Quaternion.identity);

            Destroy(spawnedCoin, 5f);
        }
    }

    public virtual void SaveGame()
    {
        GameData data = new GameData();
       
        data.bossHP = HP;
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
            HP = data.bossHP;
            healthMultiplier = data.healthMultiplier;
            coinAmount = data.coinData;
            damagePerClick = data.damagePerClick;
           
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }






}


