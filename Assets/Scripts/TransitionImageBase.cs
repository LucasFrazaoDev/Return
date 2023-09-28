using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class TransitionImageBase : MonoBehaviour
{
    [SerializeField] protected Image m_transitionImage;

    private float m_fillAmountProgress = 1.0f;
    private float m_transitionDuration = 2.0f;

    protected IEnumerator TransitionEffect(bool isStarting, int sceneIndex = 0)
    {
        m_transitionImage.gameObject.SetActive(true);

        float startFillAmount = isStarting ? 1.0f : 0f;
        float endFillAmount = isStarting ? 0f : 1.0f;

        float elapsedTime = 0f;

        while (elapsedTime < m_transitionDuration)
        {
            m_fillAmountProgress = Mathf.Lerp(startFillAmount, endFillAmount, elapsedTime / m_transitionDuration);

            m_transitionImage.fillAmount = m_fillAmountProgress;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensuring that the fill amount remains at an appropriate value
        m_transitionImage.fillAmount = isStarting ? 0f : 1.0f;

        if (isStarting)
            m_transitionImage.gameObject.SetActive(false);

        if (!isStarting)
            SceneManager.LoadScene(sceneIndex);
    }
}
