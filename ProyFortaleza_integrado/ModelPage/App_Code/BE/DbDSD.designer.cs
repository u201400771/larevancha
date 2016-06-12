﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BE
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TRABAJO_DSD")]
	public partial class DbDSDDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertMAESTRO_BANCOS(MAESTRO_BANCOS instance);
    partial void UpdateMAESTRO_BANCOS(MAESTRO_BANCOS instance);
    partial void DeleteMAESTRO_BANCOS(MAESTRO_BANCOS instance);
    #endregion
		
		public DbDSDDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TRABAJO_DSDConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DbDSDDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbDSDDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbDSDDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbDSDDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<MAESTRO_BANCOS> MAESTRO_BANCOS
		{
			get
			{
				return this.GetTable<MAESTRO_BANCOS>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MAESTRO_BANCOS")]
	public partial class MAESTRO_BANCOS : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _CODIGO_BANCO;
		
		private string _DESCRIPCION;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCODIGO_BANCOChanging(string value);
    partial void OnCODIGO_BANCOChanged();
    partial void OnDESCRIPCIONChanging(string value);
    partial void OnDESCRIPCIONChanged();
    #endregion
		
		public MAESTRO_BANCOS()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CODIGO_BANCO", DbType="NVarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string CODIGO_BANCO
		{
			get
			{
				return this._CODIGO_BANCO;
			}
			set
			{
				if ((this._CODIGO_BANCO != value))
				{
					this.OnCODIGO_BANCOChanging(value);
					this.SendPropertyChanging();
					this._CODIGO_BANCO = value;
					this.SendPropertyChanged("CODIGO_BANCO");
					this.OnCODIGO_BANCOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPCION", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DESCRIPCION
		{
			get
			{
				return this._DESCRIPCION;
			}
			set
			{
				if ((this._DESCRIPCION != value))
				{
					this.OnDESCRIPCIONChanging(value);
					this.SendPropertyChanging();
					this._DESCRIPCION = value;
					this.SendPropertyChanged("DESCRIPCION");
					this.OnDESCRIPCIONChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591