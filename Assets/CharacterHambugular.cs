using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CharacterHambugular : MonoBehaviour
{
    public FirstPersonController controller;

    #region Health
    public float maxHealth, curHealth, maxStamina, curStamina;
    public bool dedAssNibba;
    public int level, maxExp, curExp;

    #endregion
    #region GUITextures
    public GUIStyle healthTexture, staminaTexture, expTexture;
    #endregion




    // Use this for initialization
    void Start()
    {
        maxHealth = 100;
        curHealth = maxHealth;
        maxStamina = 100;
        curStamina = maxStamina;
        maxExp = 60;
        controller = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.enabled = !controller.enabled;
        }
        if (curExp >= maxExp)
        {
            curExp -= maxExp;
            level++;
            maxExp += 60;
            maxHealth += 10;
            maxStamina += 7;
        }
    }
    void LateUpdate()
    {
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth <= 0 && !dedAssNibba)
        {
            curHealth = 0;
            dedAssNibba = true;
        }
        else if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth > maxStamina)
        {
            curStamina = maxStamina;
        }
        if (curStamina < 0)
        {
            curStamina = 0;
        }
    }
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        //Gui element
        //of type box
        //new Rect pos
        // X (horizontal) Start Position
        //Y (vertical) Start Position
        // X Size
        // Y Size
        //Content
        //art or style

        GUI.Box(new Rect(0.5f * scrW, 0.5f * scrH, 4 * scrW, 0.5f * scrH), "");//BG
        GUI.Box(new Rect(0.5f * scrW, 0.5f * scrH, curHealth * (4 * scrW) / maxHealth, 0.5f * scrH), "", healthTexture);//Moving Bar

        GUI.Box(new Rect(0.5f * scrW, scrH, 4 * scrW, 0.5f * scrH), "");//BG
        GUI.Box(new Rect(0.5f * scrW, scrH, curStamina * (4 * scrW) / maxStamina, 0.5f * scrH), "", staminaTexture);//Stamina bar

        GUI.Box(new Rect(0.5f * scrW, 1.5f * scrH, 4 * scrW, 0.5f * scrH), "");//BG
        GUI.Box(new Rect(0.5f * scrW, 1.5f * scrH, curExp * (4 * scrW) / maxExp, 0.5f * scrH), "", expTexture);//Moving Bar
    }

}
