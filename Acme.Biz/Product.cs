using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{   /// <summary>
    /////    Manages products carried.....
    /// </summary>
    public class Product
    {
#region constants
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
#endregion
#region constructors
        public Product()
        {
            Console.WriteLine("nice product");
            // 3) ALWAYS instantiate an instance of a vendor
            // this.ProductVendor = new Vendor();
            this.MinimumPrice = .96m;
          
        }
        public Product(int productID, string productName, string productDescription)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }

            Console.WriteLine("No. " + ProductID + " called: " + ProductName + " is a " + ProductDescription);
        }
#endregion
#region properties
        private DateTime? availabilityDate;
        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private string productName;
        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set { productName = value; }
        }

        private string productDescription;
        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        // 2) instantiating a vendor object when class 'Product' is called
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                // lazy loading: een instance van vendor maken alleen alsie nodig is
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                
                return productVendor;
            }
            set { productVendor = value; }
        }
#endregion
#region methods
        public string SayHello()
        {
            //// 1) instantiating a vendor object ONLY when this method is called
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage 
                (
                "New Product",
                this.ProductName, 
                "sales@abc.com"
                );

            // var result = LogAction("saying hello");
        

            return "Hello, your " 
                + ProductName 
                + " with Product number: '" 
                + ProductID 
                + "' is a " 
                + ProductDescription
                +" available on: "
                + AvailabilityDate?.ToShortDateString();
        }
#endregion
    }
}
