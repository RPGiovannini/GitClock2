namespace GitClock.Domain.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string PersonName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal HourlyRate { get; set; }

    public TaskEntity(string personName, string description, DateTime startDate, DateTime endDate, decimal hourlyRate)
    {
        Id = Guid.NewGuid();
        PersonName = personName;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        HourlyRate = hourlyRate;
    }

    public void Update(string personName, string description, DateTime startDate, DateTime endDate, decimal hourlyRate)
    {
        PersonName = personName;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        HourlyRate = hourlyRate;
    }
}