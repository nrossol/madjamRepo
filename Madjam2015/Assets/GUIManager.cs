using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour 
{
    public enum GUIText
    {
        Tutorial,
        gameOver,
        score
    }

    public GameObject tutorialText;
    public GameObject gameOverText;
    public GameObject scoreText;

    private GameObject[] guiTexts;

    private const float defaultFadeTime = 5.0F;

    public void SetTextGUI(GUIText guiText, bool disableOthers = false)
    {
        if (disableOthers)
        {
            foreach (GameObject text in guiTexts)
            {
                text.SetActive(false);
            }
        }

        guiTexts[(int)guiText].SetActive(true);
    }

    public void DisplayAndFade(GUIText guiText, float timeToFade = defaultFadeTime)
    {
        StartCoroutine(FadeOverTime(guiTexts[(int)guiText].GetComponent<TextMesh>(), defaultFadeTime));
    }

    private IEnumerator FadeOverTime(TextMesh text, float time)
    {
        // TODO: Fade
        // For now just remove from screen after a while.

        float remainingTime = time;

        while (remainingTime <= 0)
        {
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        text.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () 
    {
        guiTexts = new GameObject[3];

        guiTexts[0] = tutorialText;
        guiTexts[1] = gameOverText;
        guiTexts[2] = scoreText;
	}
}
