using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Player : MonoBehaviour
{
    public double damagePerClick = 1;
    public Text damagePOP;
    public float displayDuration = 1.0f;

    private void Start()
    {
        if (damagePOP == null)
        {
            damagePOP = GetComponentInChildren<Text>();
        }
        damagePOP.gameObject.SetActive(false); 
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    ShowDamageText();
                }
            }
        }
    }

    private void ShowDamageText()
    {
        if (damagePOP != null)
        {
            damagePOP.text = "-" + damagePerClick.ToString();
            damagePOP.gameObject.SetActive(true);
            StartCoroutine(HideDamageTextAfterDelay());
        }
    }

    private IEnumerator HideDamageTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        damagePOP.gameObject.SetActive(false);
    }

    public void SaveGame()
    {
        GameData data = new GameData();
        data.damagePerClick = damagePerClick;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", json);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/gamedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            damagePerClick = data.damagePerClick;
        }
    }
}
