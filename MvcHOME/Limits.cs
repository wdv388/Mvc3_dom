//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcHOME
{
    using System;
    using System.Collections.Generic;
    
    public partial class Limits
    {
        public int ID { get; set; }
        public int E_L1 { get; set; }
        public int E_L2 { get; set; }
        public int E_L3 { get; set; }
        public int HomID { get; set; }
    
        public virtual Hom Hom { get; set; }
    }
}
