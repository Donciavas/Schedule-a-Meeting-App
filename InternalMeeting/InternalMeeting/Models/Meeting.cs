namespace InternalMeeting.Models
{
    public class Meeting
    {
        public string Name { get; set; }
        public Person ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public MeetType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Person> PersonList { get; set; }

        public Meeting(string name, Person responsiblePerson, string description, Category category, MeetType type, DateTime startDate, DateTime endDate)
        {
            Name = name;
            ResponsiblePerson = responsiblePerson;
            Description = description;
            Category = category;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            PersonList = new List<Person>() { ResponsiblePerson };
        }
    }
}
