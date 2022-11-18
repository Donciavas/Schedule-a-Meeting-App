using InternalMeeting.Models;
using InternalMeeting.Service;

namespace InternalMeeting.Repository
{
    public class MeetingRepository 
    {
        private readonly MeetingServices _meetingServices = new("Meetings.json");
        public void StartProgram(Person person)
        {
            var logoff = false;
            while(!logoff)
            {
                ConsoleMsg.FirstSelection(person.Name);
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    switch (command)
                    {
                     
                    }
                }else ConsoleMsg.WrongInputMsg();
            }
        }
       
    }
}