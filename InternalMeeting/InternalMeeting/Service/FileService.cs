using InternalMeeting.Models;
using System.Text.Json;

namespace InternalMeeting.Service
{
    public class FileService : IFileService
    {
        private string _path;
        public FileService(string fileName)
        {
            _path = Path.GetFullPath(@"..\..\..\" + fileName);
        }
    }
}
