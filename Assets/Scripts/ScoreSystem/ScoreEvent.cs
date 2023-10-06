using EventBusMechanism;

public struct ScoreEvent : IEvent
{
    public int Score;

    public ScoreEvent(int score)
    {
        Score = score;
    }
}
