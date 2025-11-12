using UnityEngine;

public class ScoreRegister : MonoBehaviour
{
    private DataHistorySetter dhs;
    [SerializeField] private GameObject DataPrefab;
    public void AddNewScore(string mass, string force, string angle)
    {
        Instantiate(DataPrefab, transform);
        dhs = GetComponentInChildren<DataHistorySetter>();
        dhs.UpdateText(mass, force, angle);
    }
    
}


