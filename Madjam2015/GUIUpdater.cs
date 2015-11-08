using System;
using System.Collections.Generic;

using UnityEngine;

public class GUIUpdater
{
    public GameManager gameManager;

    public TextMesh healthText;
    public TextMesh scoreText;

    public void Update()
    {
        scoreText.text = "Score: " + ((int)gameManager.surivedTime).ToString();
    }


}
