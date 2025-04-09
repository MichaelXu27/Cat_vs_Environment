using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUp : MonoBehaviour
{
    public TMP_Text levelText;//outlet for the levelup text

    public float flashDuration = 2f;    
    public float flashRate = 0.25f;     

    Coroutine flashRoutine;


    void Awake()
    {
        levelText.gameObject.SetActive(false);
    }

    public void Play(int levelNumber)
    {
        levelText.text = $"LEVEL {levelNumber}!";
        if (flashRoutine != null) StopCoroutine(flashRoutine);
        flashRoutine = StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        levelText.gameObject.SetActive(true);
        float timer = 0f;
        bool visible = true;

        while (timer < flashDuration)
        {
            levelText.enabled = visible;
            visible = !visible;
            yield return new WaitForSeconds(flashRate);
            timer += flashRate;
        }

        levelText.gameObject.SetActive(false);
        flashRoutine = null;
    }
}
