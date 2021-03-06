﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MESEntities : DbContext
    {
        public MESEntities()
            : base("name=MESEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_Base_AuthorityItem> T_Base_AuthorityItem { get; set; }
        public virtual DbSet<T_Base_FormTagName> T_Base_FormTagName { get; set; }
        public virtual DbSet<T_Base_Menu> T_Base_Menu { get; set; }
        public virtual DbSet<T_Base_User> T_Base_User { get; set; }
        public virtual DbSet<T_Base_UserGroup> T_Base_UserGroup { get; set; }
        public virtual DbSet<T_Base_UserGroupRe> T_Base_UserGroupRe { get; set; }
        public virtual DbSet<T_Base_UserRole> T_Base_UserRole { get; set; }
        public virtual DbSet<T_Info_AttachFile> T_Info_AttachFile { get; set; }
        public virtual DbSet<T_Info_CommDataDictType> T_Info_CommDataDictType { get; set; }
        public virtual DbSet<T_Info_CommonDataDict> T_Info_CommonDataDict { get; set; }
        public virtual DbSet<T_Info_CompanyInfo> T_Info_CompanyInfo { get; set; }
        public virtual DbSet<T_Info_Customer> T_Info_Customer { get; set; }
        public virtual DbSet<T_Info_Modules> T_Info_Modules { get; set; }
        public virtual DbSet<T_Info_Product> T_Info_Product { get; set; }
        public virtual DbSet<T_Info_ProductBOM> T_Info_ProductBOM { get; set; }
        public virtual DbSet<T_sys_BusinessTables> T_sys_BusinessTables { get; set; }
        public virtual DbSet<T_sys_DataSN> T_sys_DataSN { get; set; }
        public virtual DbSet<T_sys_DocSN> T_sys_DocSN { get; set; }
        public virtual DbSet<T_sys_FieldNameDefs> T_sys_FieldNameDefs { get; set; }
        public virtual DbSet<T_sys_Log> T_sys_Log { get; set; }
        public virtual DbSet<T_sys_LogDtl> T_sys_LogDtl { get; set; }
        public virtual DbSet<T_sys_LogFields> T_sys_LogFields { get; set; }
        public virtual DbSet<T_sys_LoginLog> T_sys_LoginLog { get; set; }
        public virtual DbSet<T_WCS_Address> T_WCS_Address { get; set; }
        public virtual DbSet<T_WCS_Alarm> T_WCS_Alarm { get; set; }
        public virtual DbSet<T_WCS_AlarmRecord> T_WCS_AlarmRecord { get; set; }
        public virtual DbSet<T_WCS_ExecError> T_WCS_ExecError { get; set; }
        public virtual DbSet<T_WCS_HS> T_WCS_HS { get; set; }
        public virtual DbSet<T_WCS_Operation> T_WCS_Operation { get; set; }
        public virtual DbSet<T_WCS_Port> T_WCS_Port { get; set; }
        public virtual DbSet<T_WCS_RoadWay> T_WCS_RoadWay { get; set; }
        public virtual DbSet<T_WCS_SC> T_WCS_SC { get; set; }
        public virtual DbSet<T_WCS_Station> T_WCS_Station { get; set; }
        public virtual DbSet<WMS_BillAccount> WMS_BillAccount { get; set; }
        public virtual DbSet<WMS_BillAccountDtl> WMS_BillAccountDtl { get; set; }
        public virtual DbSet<WMS_BillAdjust> WMS_BillAdjust { get; set; }
        public virtual DbSet<WMS_BillAdjustDtl> WMS_BillAdjustDtl { get; set; }
        public virtual DbSet<WMS_BillCheck> WMS_BillCheck { get; set; }
        public virtual DbSet<WMS_BillCheckDtl> WMS_BillCheckDtl { get; set; }
        public virtual DbSet<WMS_BillIn> WMS_BillIn { get; set; }
        public virtual DbSet<WMS_BillInDtl> WMS_BillInDtl { get; set; }
        public virtual DbSet<WMS_BillMove> WMS_BillMove { get; set; }
        public virtual DbSet<WMS_BillMoveDtl> WMS_BillMoveDtl { get; set; }
        public virtual DbSet<WMS_BillOut> WMS_BillOut { get; set; }
        public virtual DbSet<WMS_BillOutDtl> WMS_BillOutDtl { get; set; }
        public virtual DbSet<WMS_Customer> WMS_Customer { get; set; }
        public virtual DbSet<WMS_Department> WMS_Department { get; set; }
        public virtual DbSet<WMS_Material> WMS_Material { get; set; }
        public virtual DbSet<WMS_Pallet> WMS_Pallet { get; set; }
        public virtual DbSet<WMS_Stock> WMS_Stock { get; set; }
        public virtual DbSet<WMS_StockDtl> WMS_StockDtl { get; set; }
        public virtual DbSet<WMS_Task> WMS_Task { get; set; }
        public virtual DbSet<WMS_TaskDtl> WMS_TaskDtl { get; set; }
        public virtual DbSet<WMS_TaskLog> WMS_TaskLog { get; set; }
        public virtual DbSet<WMS_WareCell> WMS_WareCell { get; set; }
        public virtual DbSet<WMS_Warehouse> WMS_Warehouse { get; set; }
        public virtual DbSet<WMS_StockDtl_History> WMS_StockDtl_History { get; set; }
    }
}
