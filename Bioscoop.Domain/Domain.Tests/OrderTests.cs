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

        [Fact]
        public void FreeTicketsOnWeekDays()
        {
            // Arrange
            var movie = new Movie("James Bond");
            var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 1), 12.00);

            var studentOrder = new Order(1, true);
            studentOrder.AddSeatReservation(new(movieScreening, false, 1, 2));

            var order = new Order(1, false);
            order.AddSeatReservation(new(movieScreening, false, 1, 2));

            // Act
            var price = order.CalculatePrice();
            var studentPrice = studentOrder.CalculatePrice();
            var totalPrice = price + studentPrice;

            // Assert
            Assert.Equal(0, totalPrice);
        }

        [Fact]
        public void GroupDiscountWithSixTickets()
        {
            // Arrange
            var movie = new Movie("James Bond");
            var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 3), 12.00);

            var order = new Order(1, false);
            order.AddSeatReservation(new(movieScreening, false, 1, 1));
            order.AddSeatReservation(new(movieScreening, false, 1, 2));
            order.AddSeatReservation(new(movieScreening, false, 1, 3));
            order.AddSeatReservation(new(movieScreening, false, 1, 4));
            order.AddSeatReservation(new(movieScreening, false, 1, 5));
            order.AddSeatReservation(new(movieScreening, false, 1, 6));

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.Equal(64.8, price);
        }

        [Fact]
        public void PremiumTicketForStudents()
        {
            // Arrange
            var movie = new Movie("James Bond");
            var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 3), 12.00);

            var order = new Order(1, true);
            order.AddSeatReservation(new(movieScreening, true, 1, 1));
            order.AddSeatReservation(new(movieScreening, true, 1, 2));

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.Equal(14.00, price);
        }

        [Fact]
        public void PremiumTicketForNonStudents()
        {
            // Arrange
            var movie = new Movie("James Bond");
            var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 3), 12.00);

            var order = new Order(1, false);
            order.AddSeatReservation(new(movieScreening, true, 1, 1));
            order.AddSeatReservation(new(movieScreening, true, 1, 2));
            order.AddSeatReservation(new(movieScreening, true, 1, 3));
            order.AddSeatReservation(new(movieScreening, true, 1, 4));
            order.AddSeatReservation(new(movieScreening, true, 1, 5));
            order.AddSeatReservation(new(movieScreening, true, 1, 6));

            // Act
            var price = order.CalculatePrice();

            // Assert
            Assert.Equal(81.00, price);
        }
    }
}