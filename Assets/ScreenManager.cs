using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public GameObject painelGroupPause;

    public RectTransform buttonsGroupPause;
    // Start is called before the first frame update

    public void PauseGame()
    {
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
    }

    public void CallButtons()
    {
        LeanTween.scale(buttonsGroupPause, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeInSine);
        LeanTween.alpha(painelGroupPause.GetComponent<RectTransform>(), 0.5f, 1f).setOnComplete(PauseGame);
    }
}
