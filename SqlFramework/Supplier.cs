namespace SqlFramework
{
    public class Supplier : MainObject
    {
        private int _supplierid;
        private string _firstname = "";
        private string _lastname = "";
        private string _nickname = "";
        private int _amountofinvoices;
        private decimal _totalpurchaseamount;
        private int _bonusesreceived;
        private bool _isverified;
        public Supplier()
        {

        }
        public int SupplierId
        {
            get { return _supplierid; }
            set
            {
                this._supplierid = value;
                InvokePropertyChanged();
            }
        }
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                this._firstname = value;
                InvokePropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastname; }
            set
            {
                this._lastname = value;
                InvokePropertyChanged();
            }
        }
        public string NickName
        {
            get { return _nickname; }
            set
            {
                this._nickname = value;
                InvokePropertyChanged();
            }
        }
        public int AmountOfInvoices
        {
            get { return _amountofinvoices; }
            set
            {
                this._amountofinvoices = value;
                InvokePropertyChanged();
            }
        }
        public decimal TotalPurchaseAmount { get; set; }
        public int BonusesReceived { get; set; }
        public bool IsVerified { get; set; }
        public string FullName { get => $"{this.FirstName} {this.LastName}"; }
    }

}
