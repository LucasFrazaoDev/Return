using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonScaleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float m_hoverScale = 1.1f;
    [SerializeField] private float m_duration = 0.2f;
    [SerializeField] private float m_originalScale;

    private bool m_isHovering = false;
    private RectTransform m_buttonTransform;

    private void Start()
    {
        m_buttonTransform = GetComponent<RectTransform>();
        m_originalScale = m_buttonTransform.localScale.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!m_isHovering)
        {
            m_isHovering = true;
            StartCoroutine(ScaleOverTime(m_hoverScale));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_isHovering)
        {
            m_isHovering = false;
            StartCoroutine(ScaleOverTime(m_originalScale));
        }
    }

    private IEnumerator ScaleOverTime(float targetScale)
    {
        float startTime = Time.time;
        float initialScaleValue = m_buttonTransform.localScale.x;

        while (Time.time - startTime < m_duration)
        {
            float progress = (Time.time - startTime) / m_duration;
            float newScaleValue = Mathf.Lerp(initialScaleValue, targetScale, progress);

            m_buttonTransform.localScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);
            yield return null;
        }

        m_buttonTransform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
