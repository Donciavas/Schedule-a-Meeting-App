using InternalMeeting.Models;
using InternalMeeting.Service;
using System;
using Xunit;

namespace InternalMeeting.Tests
{
    public class MeetingServicesTest
    {
        [Fact]
        public void Test_If_MeetingService_Function_AddNewMeeting_Corectly_Add_Meeting_To_File_And_are_Equal()
        {
            MeetingServices meetingServices = new("Test1.json");
            var newMeeting = new Meeting("FirstTest", new Person("Jack"), "Testing to Add new meeting",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            var readFromFile = meetingServices.GetAllMeetings();

            Assert.Equal(newMeeting.Description, readFromFile[0].Description);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_AddNewMeeting_Dont_add_the_Same_Meeting_Twice()
        {
            MeetingServices meetingServices = new("Test2.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Testing Add new meeting dont add the same",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            var copynewMeeting = new Meeting("Test", new Person("Jack"), "Testing Add new meeting dont add the same",
                           (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(copynewMeeting);
            var readFromFile = meetingServices.GetAllMeetings();
            var meetingNumberInFile = readFromFile.Count;
            Assert.Equal(1, meetingNumberInFile);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_DeleteMeeting_Delete_Meeting_Then_Resposible_Persons_Equal()
        {
            MeetingServices meetingServices = new("Test3.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Testing delete function",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            var deletingMeetig = new Meeting("Test", new Person("Jack"), "Testing delete function tray to delete this",
                           (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(deletingMeetig);
            meetingServices.DeleteMeeting(deletingMeetig, new Person("Jack"));

            var readFromFile = meetingServices.GetAllMeetings();
            var meetingNumberInFile = readFromFile.Count;

            Assert.Equal(1, meetingNumberInFile);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_DeleteMeeting_Dont_Delete_Meeting_Then_Resposible_Person_differs()
        {
            MeetingServices meetingServices = new("Test4.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Testing delete function",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            var deletingMeetig = new Meeting("Test", new Person("Jack"), "Testing delete function tray to delete this",
                           (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(deletingMeetig);
            meetingServices.DeleteMeeting(deletingMeetig, new Person("Test"));

            var readFromFile = meetingServices.GetAllMeetings();
            var meetingNumberInFile = readFromFile.Count;

            Assert.Equal(2, meetingNumberInFile);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_AddPersonToMeeting_Adds_New_Person_To_The_Meeting()
        {
            MeetingServices meetingServices = new("Test5.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Adding person to the meeting",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);

            meetingServices.AddPersonToMeeting(newMeeting, "John");
            var readFromFile = meetingServices.GetAllMeetings();
            var newPersonExist = readFromFile[0].PersonList.Exists(p => p.Name == "John");

            Assert.True(newPersonExist);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_AddPersonToMeeting_When_Adding_Existing_Person_It_Wont_Add()
        {
            MeetingServices meetingServices = new("Test6.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Adding person to the meeting which already exists",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);

            meetingServices.AddPersonToMeeting(newMeeting, "John");
            meetingServices.AddPersonToMeeting(newMeeting, "John");
            var readFromFile = meetingServices.GetAllMeetings();
            var personNumberInMeeting = readFromFile[0].PersonList.Count;

            Assert.Equal(2, personNumberInMeeting);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_AddPersonToMeeting_When_Adding_Person_Which_Have_An_Overlaping_Meeting_Gives_Warning_Masage()
        {
            MeetingServices meetingServices = new("Test7.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Adding person to the meeting have Overlaping meeting",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            meetingServices.AddPersonToMeeting(newMeeting, "John");
            var overlapingMeeting = new Meeting("Test2", new Person("Josh"), "Adding person to the meeting have Overlaping meeting",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 12:30"));
            meetingServices.AddNewMeeting(overlapingMeeting);
            Meeting updatedMeting;
            string warningMesage;
            (warningMesage, updatedMeting) = meetingServices.AddPersonToMeeting(overlapingMeeting, "John");
            
            Assert.Equal("WARNING: Person John have an overlaping meeting", warningMesage);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_DeletePersonFromMeeting_When_deletind_Person_Which_Dont_Exists_Gives_Warning_Masage()
        {
            MeetingServices meetingServices = new("Test8.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Deleting person from the meeting which don't exists",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            meetingServices.AddPersonToMeeting(newMeeting, "John");
           
            Meeting updatedMeting;
            string warningMesage;
            (warningMesage, updatedMeting) = meetingServices.DeletePersonFromMeeting(newMeeting, "Josh");

            Assert.Equal("Wrong Person name, Josh don't exist in the meeting", warningMesage);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_DeletePersonFromMeeting_When_deletind_Responsible_Person_Gives_Warning_Masage()
        {
            MeetingServices meetingServices = new("Test9.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Deleting person from the meeting",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            meetingServices.AddPersonToMeeting(newMeeting, "John");
            meetingServices.AddPersonToMeeting(newMeeting, "Josh");
            Meeting updatedMeting;
            string warningMesage;
            (warningMesage, updatedMeting) = meetingServices.DeletePersonFromMeeting(newMeeting, "Jack");

            Assert.Equal("Resposible person Jack can't be removed from list", warningMesage);

            meetingServices.DeleteJsonFile();
        }
        [Fact]
        public void Test_If_MeetingService_Function_DeletePersonFromMeeting_Deletind_person()
        {
            MeetingServices meetingServices = new("Test10.json");
            var newMeeting = new Meeting("Test", new Person("Jack"), "Deleting person from the meeting",
                                       (Category)1, (MeetType)1, DateTime.Parse("1998-07-12 10:30"), DateTime.Parse("1998-07-12 11:30"));
            meetingServices.AddNewMeeting(newMeeting);
            meetingServices.AddPersonToMeeting(newMeeting, "John");
            meetingServices.AddPersonToMeeting(newMeeting, "Josh");
            meetingServices.DeletePersonFromMeeting(newMeeting, "John");
            var readFromFile = meetingServices.GetAllMeetings();
            var personNumberInMeeting = readFromFile[0].PersonList.Count;

            Assert.Equal(2, personNumberInMeeting);

            meetingServices.DeleteJsonFile();
        }
    }
}