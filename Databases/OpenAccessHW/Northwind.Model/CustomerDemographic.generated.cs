#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using NorthwindFramework;
using Northwind.Model;


namespace Northwind.Model	
{
	[Table("CustomerDemographics")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[Serializable()]
	public partial class CustomerDemographic : NotificationObject
	{
		private string _customerTypeID;
		[Column("CustomerTypeID", OpenAccessType = OpenAccessType.UnicodeStringFixedLength, IsPrimaryKey = true, Length = 10, Scale = 0, SqlType = "nchar")]
		[Storage("_customerTypeID")]
		public virtual string CustomerTypeID 
		{ 
		    get
		    {
		        return this._customerTypeID;
		    }
		    set
		    {
				if (this.CustomerTypeID == value)
				{
					return;
				}
		        this._customerTypeID = value;
				this.RaisePropertyChanged("CustomerTypeID");
		    }
		}
		
		private string _customerDesc;
		[Column("CustomerDesc", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "ntext")]
		[Storage("_customerDesc")]
		public virtual string CustomerDesc 
		{ 
		    get
		    {
		        return this._customerDesc;
		    }
		    set
		    {
				if (this.CustomerDesc == value)
				{
					return;
				}
		        this._customerDesc = value;
				this.RaisePropertyChanged("CustomerDesc");
		    }
		}
		
		private IList<Customer> _customers = new List<Customer>();
		[JoinTableAssociation(TableName = "CustomerCustomerDemo", OwnerColumns = "CustomerTypeID", TargetColumns = "CustomerID", SourceConstraint = "FK_CustomerCustomerDemo", TargetConstraint = "FK_CustomerCustomerDemo_Customers")]
		[Column("CustomerTypeID", OpenAccessType = OpenAccessType.UnicodeStringFixedLength, IsPrimaryKey = true, Length = 10, Scale = 0, SqlType = "nchar")]
		[Column("CustomerID", OpenAccessType = OpenAccessType.UnicodeStringFixedLength, IsPrimaryKey = true, Length = 5, Scale = 0, SqlType = "nchar")]
		[Storage("_customers")]
		public virtual IList<Customer> Customers 
		{ 
		    get
		    {
		        return this._customers;
		    }
		}
		
	}
}
