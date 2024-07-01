using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.ProjectWindowCallback;

public class DamagePopup : Attack
{
    public Transform PosPopUp;
    public TextMeshPro pfUIDmg;


    public void TextLabelDmg (int Damage)
    {
       float duration = 0.5f;
       StartCoroutine(TextAnimate(Damage,duration));
    }

    public override void AttackBoss()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    bossHP -= damagePerClick;
                    healthSlider.value = (int)bossHP;
                    CoinText.text = "Coin = " + FormatNumber((int)coinAmount).ToString();
                    healthText.text = FormatNumber((int)bossHP).ToString() + "/" + FormatNumber((int)UiMaxHP).ToString();
                    Debug.Log("HP = " + (float)bossHP);

                    TextLabelDmg((int)damagePerClick);

                }
            }
        }
    }

    IEnumerator TextAnimate(int Damage, float duration){
        TextMeshPro Item = Instantiate(pfUIDmg, Vector3.zero, Quaternion.identity);
        Item.transform.position = PosPopUp.position;
        Item.GetComponent<TextMeshPro>().text = "-"+FormatNumber((int)Damage).ToString();

        float timeElapsed = 0;
        while (timeElapsed < duration){
            float t = timeElapsed / duration;
            Item.transform.position = Vector3.Lerp(Item.transform.position, new Vector3(Item.transform.position.x + 0f,Item.transform.position.y + 0.10f,Item.transform.position.z), t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(Item,2f);
    }

}
