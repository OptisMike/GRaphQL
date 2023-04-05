using System;
using System.Collections.Generic;
using System.Text;

namespace GRaphQL
{
    class Deal
    {
        public string sellerName { get; }
        public string sellerInn { get; }
        public string buyerName { get; }
        public string buyerInn { get; }
        public string woodVolumeBuyer { get; }
        public string woodVolumeSeller { get; }
        public string dealDate { get; }
        public string dealNumber { get; }

        public Deal(string sellerName, string sellerInn, string buyerName, string buyerInn, string woodVolumeBuyer, string woodVolumeSeller, string dealDate, string dealNumber)
        {
            this.sellerName = sellerName;
            this.sellerInn = sellerInn;
            this.buyerName = buyerName;
            this.buyerInn = buyerInn;
            this.woodVolumeBuyer = woodVolumeBuyer;
            this.woodVolumeSeller = woodVolumeSeller;
            this.dealDate = dealDate;
            this.dealNumber = dealNumber;
        }
    }
}
