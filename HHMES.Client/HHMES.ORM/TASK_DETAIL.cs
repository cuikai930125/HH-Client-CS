//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HHMES.ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class TASK_DETAIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TASK_DETAIL()
        {
            this.INVENTORY = new HashSet<INVENTORY>();
            this.INVENTORY1 = new HashSet<INVENTORY>();
            this.INVENTORY_HISTORY = new HashSet<INVENTORY_HISTORY>();
        }
    
        public int ID { get; set; }
        public int TASK_HEADERID { get; set; }
        public Nullable<int> BILL_DETAILID { get; set; }
        public Nullable<int> ADJUSTBILL_DETAILID { get; set; }
        public Nullable<int> STOCKTAKINGBILL_DETAILID { get; set; }
        public Nullable<int> CHECKBILL_DETAILID { get; set; }
        public int ITEMID { get; set; }
        public int INVENTORYSTS_CFG { get; set; }
        public decimal QUANTITY { get; set; }
        public string REFERENCECODE { get; set; }
        public string WMSTASKHEADER { get; set; }
        public string WMSTASKDETAIL { get; set; }
        public Nullable<int> INVENTORYID { get; set; }
        public string DEFINE01 { get; set; }
        public string DEFINE02 { get; set; }
        public string DEFINE03 { get; set; }
        public string DEFINE04 { get; set; }
        public string DEFINE05 { get; set; }
        public string DEFINE06 { get; set; }
        public string CREATEBY { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string MODIFYBY { get; set; }
        public Nullable<System.DateTime> MODIFYTIME { get; set; }
        public Nullable<bool> ISDELETED { get; set; }
        public Nullable<int> INVENTORY_ID { get; set; }
    
        public virtual ADJUSTBILL_DETAIL ADJUSTBILL_DETAIL { get; set; }
        public virtual BILL_DETAIL BILL_DETAIL { get; set; }
        public virtual CHECKBILL_DETAIL CHECKBILL_DETAIL { get; set; }
        public virtual CONFIG_DETAIL CONFIG_DETAIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTORY> INVENTORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTORY> INVENTORY1 { get; set; }
        public virtual INVENTORY INVENTORY2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTORY_HISTORY> INVENTORY_HISTORY { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual STOCKTAKINGBILL_DETAIL STOCKTAKINGBILL_DETAIL { get; set; }
        public virtual TASK_HEADER TASK_HEADER { get; set; }
    }
}