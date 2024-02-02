using System.Text.Json;

namespace Domain
{
    public class Order(int orderNr, bool isStudentOrder)
    {
        private readonly List<MovieTicket> _movieTickets = [];

        public int GetOrderNr()
        {
            return orderNr;
        }

        public void AddSeatReservation(MovieTicket movieTicket)
        {
            _movieTickets.Add(movieTicket);
        }

        public double CalculatePrice()
        {
            double price = 0;

            for (int i = 0; i < _movieTickets.Count; i++) {
                var movieTicket = _movieTickets[i];
                var movieScreening = movieTicket.GetMovieScreening();

                if (isStudentOrder && i % 2 != 0) {
                    break;
                }

                if (Helpers.IsWeekDay(movieScreening.GetDateAndTime())) {
                    break;
                }

                price += movieTicket.GetPrice();

                if (isStudentOrder && movieTicket.IsPremiumTicket()) {
                    price += 2;
                }

                if (!isStudentOrder && movieTicket.IsPremiumTicket()) {
                    price += 3;
                }
            }

            if (!isStudentOrder && Helpers.IsWeekendDay(_movieTickets[0].GetMovieScreening().GetDateAndTime()) &&
                _movieTickets.Count >= 6) {
                price *= 0.90;
            }

            return price;
        }

        public void Export(TicketExportFormat exportFormat, string filePath)
        {
            switch (exportFormat) {
                case TicketExportFormat.Plaintext:
                    if (filePath.Equals("")) filePath = "orderInfo.txt";
                    using (StreamWriter writer = new StreamWriter(filePath)) {
                        writer.WriteLine("Order Number: " + orderNr);
                        writer.WriteLine("Is Student Order: " + isStudentOrder);
                        writer.WriteLine("Movie Tickets:");

                        foreach (var ticket in _movieTickets) {
                            writer.WriteLine($"Ticket: {ticket}");
                        }
                    }

                    break;
                case TicketExportFormat.Json:
                    if (filePath.Equals("")) filePath = "orderInfo.json";
                    var json = JsonSerializer.Serialize(this);
                    File.WriteAllText(filePath, json);
                    break;
            }
        }
    }
}