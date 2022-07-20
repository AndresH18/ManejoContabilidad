namespace ModelEntities
{
    public class ProductoFactura
    {
        public int Code { get; set; }
        public string Description { get; set; } = Guid.NewGuid().ToString();
        public string UM { get; set; } = Guid.NewGuid().ToString();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public double Discount { get; set; }
        public double recargo { get; set; }
        public double IVA { get; set; }
        public double ICA { get; set; }
        public double INC { get; set; }
        public decimal Total => Quantity * UnitPrice;

        public ProductoFactura()
        {
            var r = new Random();

            Code = r.Next(100);
            Quantity = r.Next(100);
            UnitPrice = (decimal) Math.Round(r.NextDouble(), 2);
            Discount = Math.Round(r.NextDouble(), 2);
            recargo = Math.Round(r.NextDouble(), 2);
            IVA = Math.Round(r.NextDouble(), 2);
            ICA = Math.Round(r.NextDouble(), 2);
            INC = Math.Round(r.NextDouble(), 2);
        }

        public ProductoFactura(int code, int quantity, decimal unitPrice, double discount, double recargo, double iva,
            double ica, double inc)
        {
            Code = code;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            this.recargo = recargo;
            IVA = iva;
            ICA = ica;
            INC = inc;
        }
    }
}