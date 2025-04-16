namespace ZooManagmentSystem.Domain;

public class FeedingTimeEvent
{
    public FeedingSchedule FeedingSchedule { get; private set; }
    public DateTime Timestamp { get; private set; }
    public FeedingTimeEvent(FeedingSchedule schedule)
    {
        FeedingSchedule = schedule;
        Timestamp = DateTime.Now;
    }
}