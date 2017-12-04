using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeobjectSprite : MonoBehaviour {
    
    public SpriteRenderer EnglishImage;
    public Sprite ChineseSprite;
    public Sprite OriginalSprite;
    //private SpriteRenderer sprite;
    void awake()
    {
        if (!PlayerPrefs.HasKey("LanguageNumber")) PlayerPrefs.SetInt("LanguageNumber", 0);

    }
    void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("LanguageNumber") == 1)
        {
            EnglishImage.GetComponent<SpriteRenderer>().sprite = ChineseSprite;

        }


        else if (PlayerPrefs.GetInt("LanguageNumber") == 0)
        {
            EnglishImage.GetComponent<SpriteRenderer>().sprite = OriginalSprite;

        }
    }
}
