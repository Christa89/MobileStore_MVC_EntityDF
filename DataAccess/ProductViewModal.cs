using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.ComponentModel.DataAnnotations;

//namespace MobileStore.Models
namespace DataAccess
{







    // ---------------------------------------------------------------

    [MetadataType(typeof(tblModelMetaData))]
    public partial class tblModel
    {
        public Nullable<DateTime> PurcharseDate { get; set; }
    }

    public partial class tblModelMetaData
    {
       
        public int ModelId { get; set; }

        [Display(Name="Mobile Name")]
        public string ModelName { get; set; }
        public string ModelImagePath { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<float> Price { get; set; }
        public Nullable<int> DiscountId { get; set; }
        public Nullable<int> StockId { get; set; }
        public virtual tblBrand tblBrand { get; set; }
        public virtual ICollection<tblCart> tblCarts { get; set; }
        public virtual tblDiscount tblDiscount { get; set; }
        public virtual tblStock tblStock { get; set; }
        public virtual tblType tblType { get; set; }
    }


    // ---------------------------------------------------------------


    [MetadataType(typeof(tblCartMetaData))]
    public partial class tblCart{ }

    public partial class tblCartMetaData
    {
        [Display(Name = "Order Date")]
        public Nullable<System.DateTime> PurcharseDate { get; set; }
    }

    // ---------------------------------------------------------------

    [MetadataType(typeof(tblCustomerMetaData))]
    public partial class tblCustomer { }

    public partial class tblCustomerMetaData
    {

        [Display(Name = "Customer Name")]
        public string CustName { get; set; }

        [Display(Name = "Shipping Address")]
        public string Addess { get; set; }

        [Display(Name = "Contact No")]
        public string PhoneNo { get; set; }
    }



    // ---------------------------------------------------------------

    public partial class tblDiscount
    {
      

      
    }

    public partial class tblStock
    {
      

    }


    public partial class tblType
    {
       

       
    }

 
}