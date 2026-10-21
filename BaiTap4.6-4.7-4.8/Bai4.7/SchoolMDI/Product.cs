using System.ComponentModel;

namespace SchoolMDI
{
    public class Product : INotifyPropertyChanged
    {
        private static int _counter = 1;
        private string  _productId   = string.Empty;
        private string  _productName = string.Empty;
        private string  _category    = string.Empty;
        private decimal _price;
        private int     _quantity;

        public string  ProductId   { get => _productId;   set { _productId   = value; OnPC(nameof(ProductId));   } }
        public string  ProductName { get => _productName; set { _productName = value; OnPC(nameof(ProductName)); } }
        public string  Category    { get => _category;    set { _category    = value; OnPC(nameof(Category));    } }
        public decimal Price       { get => _price;       set { _price       = value; OnPC(nameof(Price));       } }
        public int     Quantity    { get => _quantity;    set { _quantity    = value; OnPC(nameof(Quantity));    } }

        public Product() { ProductId = $"SP{_counter:D4}"; _counter++; }
        public Product(string id, string name, string cat, decimal price, int qty)
        { ProductId = id; ProductName = name; Category = cat; Price = price; Quantity = qty; }

        public static void ResetCounter(int v = 1) => _counter = v;
        public string ToCsvLine() =>
            $"\"{ProductId}\",\"{ProductName}\",\"{Category}\",{Price},{Quantity}";

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPC(string n) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
