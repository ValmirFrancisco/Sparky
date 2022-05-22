﻿using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections;

namespace Bongo.DataAccess
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_Two;
        private DbContextOptions<ApplicationDbContext> options;

        public StudyRoomBookingRepositoryTests()
        {
            studyRoomBooking_One = new StudyRoomBooking()
            {
                FirstName = "Asdrubal",
                LastName = "Moncorvo",
                Date = new DateTime(2023, 1, 1),
                Email = "asdrubal.moncorvo@email.com",
                BookingId = 11,
                StudyRoomId = 1
            };

            studyRoomBooking_Two = new StudyRoomBooking()
            {
                FirstName = "Araribóia",
                LastName = "Clayderman",
                Date = new DateTime(2023, 2, 2),
                Email = "arariboia.clayderman@email.com",
                BookingId = 22,
                StudyRoomId = 2
            };
        }

        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
        }

        [Test]
        [Order(1)]
        public void SaveBooking_Booking_One_CheckTheValuesFromDatabase()
        {
            //Arrange

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
            }

            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId==11);
                Assert.AreEqual(studyRoomBooking_One.StudyRoomId, bookingFromDb.StudyRoomId);
                Assert.AreEqual(studyRoomBooking_One.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(studyRoomBooking_One.LastName, bookingFromDb.LastName);
                Assert.AreEqual(studyRoomBooking_One.Email, bookingFromDb.Email);
                Assert.AreEqual(studyRoomBooking_One.Date, bookingFromDb.Date);
                Assert.AreEqual(studyRoomBooking_One.StudyRoomId, bookingFromDb.StudyRoomId);
            }

        }

        [Test]
        [Order(2)]
        public void GetAllSaveBooking_BookingOneAndTwo_CheckBoththeBookingFromDatabase()
        {
            //Arrange
            var expectedResult = new List<StudyRoomBooking> { studyRoomBooking_One, studyRoomBooking_Two };

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
                repository.Book(studyRoomBooking_Two);
            }

            //Act
            List<StudyRoomBooking> actualList;
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                actualList = repository.GetAll(null).ToList();
            }

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualList, new BookingCompare());
        }
    }

    public class BookingCompare : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var booking1 = (StudyRoomBooking)x;
            var booking2 = (StudyRoomBooking)y;
            if (booking1.BookingId != booking2.BookingId)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}