using InternalMeeting.Models;

namespace InternalMeeting.Service
{
    
    public class MeetingServices : IMeetingServices
    {
        public FileService _fileService;

        public MeetingServices(string fileName)
        {
            _fileService = new FileService(fileName);
        }
    }
}
