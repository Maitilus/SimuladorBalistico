using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject toggleTarget;

    public void UpdateText()
    {
        text.text = Mathf.RoundToInt(slider.value).ToString();
    }

    public void ToggleActive()
    {
        if (toggleTarget.activeSelf) { toggleTarget.SetActive(false); }
        else { toggleTarget.SetActive(true); }
    }
}
