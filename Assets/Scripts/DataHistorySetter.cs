using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataHistorySetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI massText;
    [SerializeField] private TextMeshProUGUI forceText;
    [SerializeField] private TextMeshProUGUI angleText;


    public void UpdateText(string mass, string force, string angle)
    {
        massText.text = mass;
        forceText.text = force;
        angleText.text = angle;

        Destroy(this);
    }
}
