using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Player : BossHP
{
    public double damage = 1;
    public Text damagePOP;
    public float displayDuration = 1.0f;

    private void Start()
    {

        damage = damagePerClick;

        if (damagePOP == null)
        {
            damagePOP = GetComponentInChildren<Text>();
        }
        damagePOP.gameObject.SetActive(false);

        LoadGame();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    damage = damagePerClick;
                    ShowDamageText();
                }
            }
        }
    }
    private void ShowDamageText()
    {
        if (damagePOP != null)
        {
            damagePOP.text = "-" + damage.ToString();
            damagePOP.gameObject.SetActive(true);
            StartCoroutine(HideDamageTextAfterDelay());
        }
    }

    private IEnumerator HideDamageTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        damagePOP.gameObject.SetActive(false);
    }

    public override void SaveGame()
    {
        GameData data = new GameData();
        data.damagePerClick = damage;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", json);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public override void LoadGame()
    {
        string path = Application.persistentDataPath + "/gamedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            damage = data.damagePerClick;
        }
    }
}