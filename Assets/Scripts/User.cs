using System;

[Serializable]
public class User
{
    public string userName;
    public int userScore;
    public float mass;
    public float fireForce;
    public float angle;

    public User()
    {
        userName = PlayerScores.playerName;
        userScore = PlayerScores.playerScore;

        mass = PlayerScores.Mass;
        fireForce = PlayerScores.FireForce;
        angle = PlayerScores.Angle;
    }
}
