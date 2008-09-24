﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
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
	
	
	public partial class Red : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCables(Cables instance);
    partial void UpdateCables(Cables instance);
    partial void DeleteCables(Cables instance);
    partial void InsertComputadores(Computadores instance);
    partial void UpdateComputadores(Computadores instance);
    partial void DeleteComputadores(Computadores instance);
    partial void InsertEquipos(Equipos instance);
    partial void UpdateEquipos(Equipos instance);
    partial void DeleteEquipos(Equipos instance);
    partial void InsertEstaciones(Estaciones instance);
    partial void UpdateEstaciones(Estaciones instance);
    partial void DeleteEstaciones(Estaciones instance);
    partial void InsertPuertos(Puertos instance);
    partial void UpdatePuertos(Puertos instance);
    partial void DeletePuertos(Puertos instance);
    partial void InsertPuertosCompletos(PuertosCompletos instance);
    partial void UpdatePuertosCompletos(PuertosCompletos instance);
    partial void DeletePuertosCompletos(PuertosCompletos instance);
    #endregion
		
		public Red(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Red(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Red(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Red(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Cables> Cables
		{
			get
			{
				return this.GetTable<Cables>();
			}
		}
		
		public System.Data.Linq.Table<Computadores> Computadores
		{
			get
			{
				return this.GetTable<Computadores>();
			}
		}
		
		public System.Data.Linq.Table<Equipos> Equipos
		{
			get
			{
				return this.GetTable<Equipos>();
			}
		}
		
		public System.Data.Linq.Table<Estaciones> Estaciones
		{
			get
			{
				return this.GetTable<Estaciones>();
			}
		}
		
		public System.Data.Linq.Table<Puertos> Puertos
		{
			get
			{
				return this.GetTable<Puertos>();
			}
		}
		
		public System.Data.Linq.Table<PuertosCompletos> PuertosCompletos
		{
			get
			{
				return this.GetTable<PuertosCompletos>();
			}
		}
	}
	
	[Table()]
	public partial class Cables : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _IdPuerto1;
		
		private System.Guid _IdPuerto2;
		
		private EntityRef<Puertos> _Puertos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnIdPuerto1Changing(System.Guid value);
    partial void OnIdPuerto1Changed();
    partial void OnIdPuerto2Changing(System.Guid value);
    partial void OnIdPuerto2Changed();
    #endregion
		
		public Cables()
		{
			this._Puertos = default(EntityRef<Puertos>);
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_IdPuerto1", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdPuerto1
		{
			get
			{
				return this._IdPuerto1;
			}
			set
			{
				if ((this._IdPuerto1 != value))
				{
					if (this._Puertos.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdPuerto1Changing(value);
					this.SendPropertyChanging();
					this._IdPuerto1 = value;
					this.SendPropertyChanged("IdPuerto1");
					this.OnIdPuerto1Changed();
				}
			}
		}
		
		[Column(Storage="_IdPuerto2", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdPuerto2
		{
			get
			{
				return this._IdPuerto2;
			}
			set
			{
				if ((this._IdPuerto2 != value))
				{
					this.OnIdPuerto2Changing(value);
					this.SendPropertyChanging();
					this._IdPuerto2 = value;
					this.SendPropertyChanged("IdPuerto2");
					this.OnIdPuerto2Changed();
				}
			}
		}
		
		[Association(Name="p1", Storage="_Puertos", ThisKey="IdPuerto1", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true)]
		public Puertos Puertos
		{
			get
			{
				return this._Puertos.Entity;
			}
			set
			{
				Puertos previousValue = this._Puertos.Entity;
				if (((previousValue != value) 
							|| (this._Puertos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Puertos.Entity = null;
						previousValue.Cables.Remove(this);
					}
					this._Puertos.Entity = value;
					if ((value != null))
					{
						value.Cables.Add(this);
						this._IdPuerto1 = value.Id;
					}
					else
					{
						this._IdPuerto1 = default(System.Guid);
					}
					this.SendPropertyChanged("Puertos");
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
	
	[Table()]
	public partial class Computadores : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _DefaultGateWay;
		
		private EntityRef<Equipos> _Equipos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnDefaultGateWayChanging(string value);
    partial void OnDefaultGateWayChanged();
    #endregion
		
		public Computadores()
		{
			this._Equipos = default(EntityRef<Equipos>);
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._Equipos.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_DefaultGateWay", DbType="NVarChar(100)")]
		public string DefaultGateWay
		{
			get
			{
				return this._DefaultGateWay;
			}
			set
			{
				if ((this._DefaultGateWay != value))
				{
					this.OnDefaultGateWayChanging(value);
					this.SendPropertyChanging();
					this._DefaultGateWay = value;
					this.SendPropertyChanged("DefaultGateWay");
					this.OnDefaultGateWayChanged();
				}
			}
		}
		
		[Association(Name="ComputadoresEquipos", Storage="_Equipos", ThisKey="Id", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true)]
		public Equipos Equipos
		{
			get
			{
				return this._Equipos.Entity;
			}
			set
			{
				Equipos previousValue = this._Equipos.Entity;
				if (((previousValue != value) 
							|| (this._Equipos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Equipos.Entity = null;
						previousValue.Computadores = null;
					}
					this._Equipos.Entity = value;
					if ((value != null))
					{
						value.Computadores = this;
						this._Id = value.Id;
					}
					else
					{
						this._Id = default(System.Guid);
					}
					this.SendPropertyChanged("Equipos");
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
	
	[Table()]
	public partial class Equipos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private int _X;
		
		private int _Y;
		
		private int _TipoDeEquipo;
		
		private System.Guid _IdEstacion;
		
		private string _Nombre;
		
		private EntityRef<Computadores> _Computadores;
		
		private EntityRef<Estaciones> _Estaciones;
		
		private EntitySet<Puertos> _Puertos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnXChanging(int value);
    partial void OnXChanged();
    partial void OnYChanging(int value);
    partial void OnYChanged();
    partial void OnTipoDeEquipoChanging(int value);
    partial void OnTipoDeEquipoChanged();
    partial void OnIdEstacionChanging(System.Guid value);
    partial void OnIdEstacionChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    #endregion
		
		public Equipos()
		{
			this._Computadores = default(EntityRef<Computadores>);
			this._Estaciones = default(EntityRef<Estaciones>);
			this._Puertos = new EntitySet<Puertos>(new Action<Puertos>(this.attach_Puertos), new Action<Puertos>(this.detach_Puertos));
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_X", DbType="Int NOT NULL")]
		public int X
		{
			get
			{
				return this._X;
			}
			set
			{
				if ((this._X != value))
				{
					this.OnXChanging(value);
					this.SendPropertyChanging();
					this._X = value;
					this.SendPropertyChanged("X");
					this.OnXChanged();
				}
			}
		}
		
		[Column(Storage="_Y", DbType="Int NOT NULL")]
		public int Y
		{
			get
			{
				return this._Y;
			}
			set
			{
				if ((this._Y != value))
				{
					this.OnYChanging(value);
					this.SendPropertyChanging();
					this._Y = value;
					this.SendPropertyChanged("Y");
					this.OnYChanged();
				}
			}
		}
		
		[Column(Storage="_TipoDeEquipo", DbType="Int NOT NULL")]
		public int TipoDeEquipo
		{
			get
			{
				return this._TipoDeEquipo;
			}
			set
			{
				if ((this._TipoDeEquipo != value))
				{
					this.OnTipoDeEquipoChanging(value);
					this.SendPropertyChanging();
					this._TipoDeEquipo = value;
					this.SendPropertyChanged("TipoDeEquipo");
					this.OnTipoDeEquipoChanged();
				}
			}
		}
		
		[Column(Storage="_IdEstacion", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdEstacion
		{
			get
			{
				return this._IdEstacion;
			}
			set
			{
				if ((this._IdEstacion != value))
				{
					if (this._Estaciones.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdEstacionChanging(value);
					this.SendPropertyChanging();
					this._IdEstacion = value;
					this.SendPropertyChanged("IdEstacion");
					this.OnIdEstacionChanged();
				}
			}
		}
		
		[Column(Storage="_Nombre", DbType="NVarChar(100)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[Association(Name="ComputadoresEquipos", Storage="_Computadores", ThisKey="Id", OtherKey="Id", IsUnique=true, IsForeignKey=false, DeleteRule="CASCADE")]
		public Computadores Computadores
		{
			get
			{
				return this._Computadores.Entity;
			}
			set
			{
				Computadores previousValue = this._Computadores.Entity;
				if (((previousValue != value) 
							|| (this._Computadores.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Computadores.Entity = null;
						previousValue.Equipos = null;
					}
					this._Computadores.Entity = value;
					if ((value != null))
					{
						value.Equipos = this;
					}
					this.SendPropertyChanged("Computadores");
				}
			}
		}
		
		[Association(Name="EquiposEstaciones", Storage="_Estaciones", ThisKey="IdEstacion", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true)]
		public Estaciones Estaciones
		{
			get
			{
				return this._Estaciones.Entity;
			}
			set
			{
				Estaciones previousValue = this._Estaciones.Entity;
				if (((previousValue != value) 
							|| (this._Estaciones.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Estaciones.Entity = null;
						previousValue.Equipos.Remove(this);
					}
					this._Estaciones.Entity = value;
					if ((value != null))
					{
						value.Equipos.Add(this);
						this._IdEstacion = value.Id;
					}
					else
					{
						this._IdEstacion = default(System.Guid);
					}
					this.SendPropertyChanged("Estaciones");
				}
			}
		}
		
		[Association(Name="PuertoEquipo", Storage="_Puertos", ThisKey="Id", OtherKey="IdEquipo", DeleteRule="CASCADE")]
		public EntitySet<Puertos> Puertos
		{
			get
			{
				return this._Puertos;
			}
			set
			{
				this._Puertos.Assign(value);
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
		
		private void attach_Puertos(Puertos entity)
		{
			this.SendPropertyChanging();
			entity.Equipos = this;
		}
		
		private void detach_Puertos(Puertos entity)
		{
			this.SendPropertyChanging();
			entity.Equipos = null;
		}
	}
	
	[Table()]
	public partial class Estaciones : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Nombre;
		
		private System.Data.Linq.Binary _Foto;
		
		private string _Descripcion;
		
		private System.DateTime _Fecha;
		
		private EntitySet<Equipos> _Equipos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnFotoChanging(System.Data.Linq.Binary value);
    partial void OnFotoChanged();
    partial void OnDescripcionChanging(string value);
    partial void OnDescripcionChanged();
    partial void OnFechaChanging(System.DateTime value);
    partial void OnFechaChanged();
    #endregion
		
		public Estaciones()
		{
			this._Equipos = new EntitySet<Equipos>(new Action<Equipos>(this.attach_Equipos), new Action<Equipos>(this.detach_Equipos));
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_Nombre", DbType="NVarChar(100)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[Column(Storage="_Foto", DbType="Image", CanBeNull=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Foto
		{
			get
			{
				return this._Foto;
			}
			set
			{
				if ((this._Foto != value))
				{
					this.OnFotoChanging(value);
					this.SendPropertyChanging();
					this._Foto = value;
					this.SendPropertyChanged("Foto");
					this.OnFotoChanged();
				}
			}
		}
		
		[Column(Storage="_Descripcion", DbType="NVarChar(2000)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this.OnDescripcionChanging(value);
					this.SendPropertyChanging();
					this._Descripcion = value;
					this.SendPropertyChanged("Descripcion");
					this.OnDescripcionChanged();
				}
			}
		}
		
		[Column(Storage="_Fecha", DbType="DateTime NOT NULL")]
		public System.DateTime Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[Association(Name="EquiposEstaciones", Storage="_Equipos", ThisKey="Id", OtherKey="IdEstacion", DeleteRule="CASCADE")]
		public EntitySet<Equipos> Equipos
		{
			get
			{
				return this._Equipos;
			}
			set
			{
				this._Equipos.Assign(value);
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
		
		private void attach_Equipos(Equipos entity)
		{
			this.SendPropertyChanging();
			entity.Estaciones = this;
		}
		
		private void detach_Equipos(Equipos entity)
		{
			this.SendPropertyChanging();
			entity.Estaciones = null;
		}
	}
	
	[Table()]
	public partial class Puertos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _IdEquipo;
		
		private string _Nombre;
		
		private EntitySet<Cables> _Cables;
		
		private EntityRef<Equipos> _Equipos;
		
		private EntityRef<PuertosCompletos> _PuertosCompletos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnIdEquipoChanging(System.Guid value);
    partial void OnIdEquipoChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    #endregion
		
		public Puertos()
		{
			this._Cables = new EntitySet<Cables>(new Action<Cables>(this.attach_Cables), new Action<Cables>(this.detach_Cables));
			this._Equipos = default(EntityRef<Equipos>);
			this._PuertosCompletos = default(EntityRef<PuertosCompletos>);
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_IdEquipo", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdEquipo
		{
			get
			{
				return this._IdEquipo;
			}
			set
			{
				if ((this._IdEquipo != value))
				{
					if (this._Equipos.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdEquipoChanging(value);
					this.SendPropertyChanging();
					this._IdEquipo = value;
					this.SendPropertyChanged("IdEquipo");
					this.OnIdEquipoChanged();
				}
			}
		}
		
		[Column(Storage="_Nombre", DbType="NVarChar(100)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[Association(Name="p1", Storage="_Cables", ThisKey="Id", OtherKey="IdPuerto1", DeleteRule="CASCADE")]
		public EntitySet<Cables> Cables
		{
			get
			{
				return this._Cables;
			}
			set
			{
				this._Cables.Assign(value);
			}
		}
		
		[Association(Name="PuertoEquipo", Storage="_Equipos", ThisKey="IdEquipo", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true)]
		public Equipos Equipos
		{
			get
			{
				return this._Equipos.Entity;
			}
			set
			{
				Equipos previousValue = this._Equipos.Entity;
				if (((previousValue != value) 
							|| (this._Equipos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Equipos.Entity = null;
						previousValue.Puertos.Remove(this);
					}
					this._Equipos.Entity = value;
					if ((value != null))
					{
						value.Puertos.Add(this);
						this._IdEquipo = value.Id;
					}
					else
					{
						this._IdEquipo = default(System.Guid);
					}
					this.SendPropertyChanged("Equipos");
				}
			}
		}
		
		[Association(Storage="_PuertosCompletos", ThisKey="Id", OtherKey="Id", IsUnique=true, IsForeignKey=false, DeleteRule="CASCADE")]
		public PuertosCompletos PuertosCompletos
		{
			get
			{
				return this._PuertosCompletos.Entity;
			}
			set
			{
				PuertosCompletos previousValue = this._PuertosCompletos.Entity;
				if (((previousValue != value) 
							|| (this._PuertosCompletos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PuertosCompletos.Entity = null;
						previousValue.Puertos = null;
					}
					this._PuertosCompletos.Entity = value;
					if ((value != null))
					{
						value.Puertos = this;
					}
					this.SendPropertyChanged("PuertosCompletos");
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
		
		private void attach_Cables(Cables entity)
		{
			this.SendPropertyChanging();
			entity.Puertos = this;
		}
		
		private void detach_Cables(Cables entity)
		{
			this.SendPropertyChanging();
			entity.Puertos = null;
		}
	}
	
	[Table()]
	public partial class PuertosCompletos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _DireccionIP;
		
		private System.Nullable<int> _Mascara;
		
		private string _DireccionMAC;
		
		private EntityRef<Puertos> _Puertos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnDireccionIPChanging(string value);
    partial void OnDireccionIPChanged();
    partial void OnMascaraChanging(System.Nullable<int> value);
    partial void OnMascaraChanged();
    partial void OnDireccionMACChanging(string value);
    partial void OnDireccionMACChanged();
    #endregion
		
		public PuertosCompletos()
		{
			this._Puertos = default(EntityRef<Puertos>);
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._Puertos.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_DireccionIP", DbType="NVarChar(100)")]
		public string DireccionIP
		{
			get
			{
				return this._DireccionIP;
			}
			set
			{
				if ((this._DireccionIP != value))
				{
					this.OnDireccionIPChanging(value);
					this.SendPropertyChanging();
					this._DireccionIP = value;
					this.SendPropertyChanged("DireccionIP");
					this.OnDireccionIPChanged();
				}
			}
		}
		
		[Column(Storage="_Mascara", DbType="Int")]
		public System.Nullable<int> Mascara
		{
			get
			{
				return this._Mascara;
			}
			set
			{
				if ((this._Mascara != value))
				{
					this.OnMascaraChanging(value);
					this.SendPropertyChanging();
					this._Mascara = value;
					this.SendPropertyChanged("Mascara");
					this.OnMascaraChanged();
				}
			}
		}
		
		[Column(Storage="_DireccionMAC", DbType="NVarChar(100)")]
		public string DireccionMAC
		{
			get
			{
				return this._DireccionMAC;
			}
			set
			{
				if ((this._DireccionMAC != value))
				{
					this.OnDireccionMACChanging(value);
					this.SendPropertyChanging();
					this._DireccionMAC = value;
					this.SendPropertyChanged("DireccionMAC");
					this.OnDireccionMACChanged();
				}
			}
		}
		
		[Association(Name="PuertosCompletos", Storage="_Puertos", ThisKey="Id", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true)]
		public Puertos Puertos
		{
			get
			{
				return this._Puertos.Entity;
			}
			set
			{
				Puertos previousValue = this._Puertos.Entity;
				if (((previousValue != value) 
							|| (this._Puertos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Puertos.Entity = null;
						previousValue.PuertosCompletos = null;
					}
					this._Puertos.Entity = value;
					if ((value != null))
					{
						value.PuertosCompletos = this;
						this._Id = value.Id;
					}
					else
					{
						this._Id = default(System.Guid);
					}
					this.SendPropertyChanged("Puertos");
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
