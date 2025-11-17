using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void SetLives(int lives, int maxLives)
    {
        for (int i = 0; i < heartImages.Length; i++)
            heartImages[i].sprite = i < lives ? fullHeart : emptyHeart;
    }
}