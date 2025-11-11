using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    [Header("Flash Settings")]
    public Color flashColor = new Color(1f, 0f, 0f, 0.9f);
    public float fadeIn = 0.06f;
    public float hold   = 0.04f;
    public float fadeOut= 0.20f;
    public int pulses   = 1;

    private SpriteRenderer[] srs;
    private Color[] baseColors;
    private bool flashing;

    void Awake()
    {
        srs = GetComponentsInChildren<SpriteRenderer>(true);
        baseColors = new Color[srs.Length];
        for (int i = 0; i < srs.Length; i++) baseColors[i] = srs[i].color;
    }

    public void Trigger()
    {
        if (!flashing) StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        flashing = true;

        for (int p = 0; p < Mathf.Max(1, pulses); p++)
        {
            // fade in
            float t = 0f;
            while (t < fadeIn)
            {
                t += Time.deltaTime;
                float a = t / fadeIn;
                for (int i = 0; i < srs.Length; i++)
                    srs[i].color = Color.Lerp(baseColors[i], flashColor, a);
                yield return null;
            }

            // hold
            if (hold > 0f) yield return new WaitForSeconds(hold);

            // fade out
            t = 0f;
            while (t < fadeOut)
            {
                t += Time.deltaTime;
                float a = t / fadeOut;
                for (int i = 0; i < srs.Length; i++)
                    srs[i].color = Color.Lerp(flashColor, baseColors[i], a);
                yield return null;
            }
        }

        for (int i = 0; i < srs.Length; i++) srs[i].color = baseColors[i];

        flashing = false;
    }
}