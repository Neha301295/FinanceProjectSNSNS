//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanceProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int Card_ID { get; set; }
        public int Product_ID { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Product Product { get; set; }
    }
}