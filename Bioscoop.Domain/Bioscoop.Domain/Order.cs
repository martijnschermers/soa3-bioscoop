namespace Bioscoop.Domain
{
    public class Order
    {
        private readonly int _orderNr;
        private readonly bool _isStudentOrder;

        public Order(int OrderNr, bool IsStudentOrder)
        {
            _orderNr = OrderNr;
            _isStudentOrder = IsStudentOrder;
        }

        public int GetOrderNr()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket movieTicket)
        {
            //TODO
        }

        public double CalculatePrice()
        {
            // TODO deel 1
        }

        public void Export(TicketExportFormat exportFormat)
        {

        }
    }
}
