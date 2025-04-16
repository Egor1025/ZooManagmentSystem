namespace ZooManagmentSystem.Domain;

public class FeedingSchedule
{
    public Guid Id { get; private set; }
    public Animal Animal { get; private set; }
    public DateTime FeedingTime { get; private set; }
    public string FoodType { get; private set; }
    public bool IsCompleted { get; private set; }
    public FeedingSchedule(Animal animal, DateTime feedingTime, string foodType)
    {
        Id = Guid.NewGuid();
        Animal = animal;
        FeedingTime = feedingTime;
        FoodType = foodType;
        IsCompleted = false;
    }
    public void ChangeSchedule(DateTime newFeedingTime, string newFoodType)
    {
        FeedingTime = newFeedingTime;
        FoodType = newFoodType;
    }
    public FeedingTimeEvent MarkAsCompleted()
    {
        IsCompleted = true;
        return new FeedingTimeEvent(this);
    }
}
public class AnimalMovedEvent
{
    public Animal Animal { get; private set; }
    public Enclosure SourceEnclosure { get; private set; }
    public Enclosure TargetEnclosure { get; private set; }
    public DateTime Timestamp { get; private set; }
    public AnimalMovedEvent(Animal animal, Enclosure source, Enclosure target)
    {
        Animal = animal;
        SourceEnclosure = source;
        TargetEnclosure = target;
        Timestamp = DateTime.Now;
    }
}