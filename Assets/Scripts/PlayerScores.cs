using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class PlayerScores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameText;

    private System.Random random = new System.Random();

    User user = new User();

    public static int playerScore;
    public static string playerName;
    public static float FireForce;
    public static float Mass;
    public static float collisionCoords;
    public static float Angle;

    public Projectile projectile;
    public Weapon weapon;
    public ScoreRegister sr;

    void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Puntos: " + playerScore;
    }

    public void UpdateScore()
    {
        scoreText.text = "Puntos: " + user.userScore;
        FireForce = weapon.f_FireForce;
        Mass = weapon.s_MassSlider.value;
        Angle = weapon.s_AngleSlider.value;
    }


    private void PostToDataBase()
    {
        User user = new User();
        RestClient.Put("https://fir-simulador-default-rtdb.firebaseio.com/" + playerName + ".json", user);
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDataBase();
    }

    private void RetrieveFromDataBase()
    {
        RestClient.Get<User>("https://fir-simulador-default-rtdb.firebaseio.com/" + nameText.text + ".json").Then(response =>
        {
            user = response;
            UpdateScore();
            sr.AddNewScore(Mass.ToString(), FireForce.ToString(), Angle.ToString());
        });
    }

    public void OnGetScore()
    {
        RetrieveFromDataBase();
    }
}
