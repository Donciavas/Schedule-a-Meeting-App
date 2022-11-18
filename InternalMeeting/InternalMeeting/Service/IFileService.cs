using InternalMeeting.Models;

namespace InternalMeeting.Service
{
    public interface IFileService
    {
        public List<Meeting> ReadMeetings();
        public void WriteMeetings(IList<Meeting> meetingsList);
        public void DeleteFile();
    }
}
