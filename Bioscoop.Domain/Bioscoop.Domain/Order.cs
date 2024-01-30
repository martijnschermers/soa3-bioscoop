namespace Bioscoop.Domain
{
    public class Order
    {
        private readonly int _orderNr;
        private readonly bool _isStudentOrder;
        private readonly List<MovieTicket> _movieTickets;

        public Order(int OrderNr, bool IsStudentOrder)
        {
            _orderNr = OrderNr;
            _isStudentOrder = IsStudentOrder;
            _movieTickets = new List<MovieTicket>();
        }

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

            List<MovieTicket> movieTicketsCopy = _movieTickets;

            for (int i = 0; i < _movieTickets.Count; i++)
            {
                var movieTicket = _movieTickets[i];
                var movieScreening = movieTicket.GetMovieScreening();

                if (_isStudentOrder && i % 2 != 0)
                {
                    movieTicketsCopy.Remove(movieTicket);
                }
    
                if (Helpers.IsWeekDay(movieScreening.GetDateAndTime()))
                {
                    movieTicketsCopy.Remove(movieTicket);
                }

            }

            return price;
        }

        public void Export(TicketExportFormat exportFormat)
        {

        }
    }
}
