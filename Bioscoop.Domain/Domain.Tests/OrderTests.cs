using Bioscoop.Domain;

namespace Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void SecondTicketIsFreeForStudents()
        {
            // Arrange
            var movie = new Movie("James Bond");
            var movieScreening = new MovieScreening(movie, new DateTime(2024, 1, 27), 12.00);

            var order = new Order(1, true);
            order.AddSeatReservation(new(movieScreening, false, 1, 1));
            order.AddSeatReservation(new(movieScreening, false, 1, 2));

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.Equal(12.00, price);
        }
    }
}