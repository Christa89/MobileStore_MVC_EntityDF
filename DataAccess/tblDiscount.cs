//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDiscount
    {
        public tblDiscount()
        {
            this.tblModels = new HashSet<tblModel>();
        }
    
        public int DiscountId { get; set; }
        public Nullable<float> DisCountPersantage { get; set; }
        public string DiscountName { get; set; }
    
        public virtual ICollection<tblModel> tblModels { get; set; }
    }
}