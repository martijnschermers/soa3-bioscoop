using System.Xml;
using System.Text.Json;

namespace Bioscoop.Domain
{
    public class Order(int OrderNr, bool IsStudentOrder)
    {
        private readonly int _orderNr = OrderNr;
        private readonly bool _isStudentOrder = IsStudentOrder;
        private readonly List<MovieTicket> _movieTickets = [];

        public int GetOrderNr()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket movieTicket)
        {
            _movieTickets.Add(movieTicket);
        }

        public double CalculatePrice()
        {
            double price = 0;

            for (int i = 0; i < _movieTickets.Count; i++)
            {
                var movieTicket = _movieTickets[i];
                var movieScreening = movieTicket.GetMovieScreening();

                if (_isStudentOrder && i % 2 != 0)
                {
                    break;
                }

                if (Helpers.IsWeekDay(movieScreening.GetDateAndTime()))
                {
                    break;
                }

                price += movieTicket.getPrice();

                if (_isStudentOrder && movieTicket.isPremiumTicket())
                {
                    price += 2;
                }

                if (!_isStudentOrder && movieTicket.isPremiumTicket())
                {
                    price += 3;
                }

                if (!_isStudentOrder && Helpers.IsWeekendDay(movieScreening.GetDateAndTime()) && _movieTickets.Count >= 6)
                {
                    price *= 0.90;
                }

            }

            return price;
        }

        public void Export(TicketExportFormat exportFormat, string filePath)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                if (filePath is null || filePath.Equals("")) filePath = "orderInfo.txt";
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Order Number: " + _orderNr);
                        writer.WriteLine("Is Student Order: " + _isStudentOrder);
                        writer.WriteLine("Movie Tickets:");

                        foreach (var ticket in _movieTickets)
                        {
                            writer.WriteLine($"Ticket: {ticket.ToString()}");
                        }
                    }
                    break;
                case TicketExportFormat.JSON:
                    if (filePath is null || filePath.Equals("")) filePath = "orderInfo.json";
                    string json = JsonSerializer.Serialize(this);
                    File.WriteAllText(filePath, json);
                    break;
            }
        }
    }
}
