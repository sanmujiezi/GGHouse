using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractTip : MonoBehaviour
{
    private Image m_Line;
    private TextMeshProUGUI m_Text;

    private void Awake()
    {
        m_Line = transform.Find("InteractCanvas/Root/m_Line").GetComponent<Image>();
        m_Text = transform.Find("InteractCanvas/Root/m_Text").GetComponent<TextMeshProUGUI>();
    }

    public void SetTextContent(string content)
    {
        m_Text.text = content;
    }

    public void SetProgress(float progress)
    {
        if (progress >= 0 && progress <= 1)
        {
            m_Line.fillAmount = progress;
        }
    }
}