using InternalMeeting.Models;

namespace InternalMeeting.Service
{
    public interface IMeetingServices
    {
        public List<Meeting> GetAllMeetings();
        public string AddNewMeeting(Meeting meeting);
        public string DeleteMeeting(Meeting meeting, Person person);
        public (string, Meeting) AddPersonToMeeting(Meeting meeting, string personName);
        public (string, Meeting) DeletePersonFromMeeting(Meeting meeting, string personName);
        public IList<Meeting> GetMeetingsByDescription(string description);
        public IList<Meeting> GetMeetingsByResponsiblePerson(string responsiblePerson);
        public IList<Meeting> GetMeetingsByCategory(Category category);
        public IList<Meeting> GetMeetingsByMeetType(MeetType type);
        public IList<Meeting> GetMeetingsByDates(DateTime fromDate, DateTime toDate);
        public IList<Meeting> GetMeetingByAttendeesNumber(int moreThan);
    }
}
