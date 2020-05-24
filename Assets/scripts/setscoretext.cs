using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setscoretext : MonoBehaviour
{
    public TMP_Text lifeText;
    public TMP_Text scoreText;

    //Der eigentliche Score wird für jeden Frame aktualisiert und angezeigt.
    void Update()
    {
        lifeText.text = FindObjectOfType<defender_controller>().hp.ToString();
        scoreText.text = FindObjectOfType<safescoretext>().score.ToString();
    }
}
