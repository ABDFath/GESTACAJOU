using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using SC.Core;
using SC.Framework.Interfaces;
using System.Data.SqlTypes;

namespace GESTACAJOU.SQLENGINE
{
	public class PISTEUR: IDBObject
	{
		#region  private vars & public Properties
		private int _id_auto;

		public int ID_AUTO
		{
			get { return _id_auto; }
		}
		private string _nom;

		public string NOM
		{
			get { return _nom; }
			set { _nom = value; }
		}

		private string _prenom;

		public string PRENOM
		{
			get { return _prenom; }
			set { _prenom = value; }
		}

		private string _contact;

		public string CONTACT
		{
			get { return _contact; }
			set { _contact = value; }
		}

		private string _village;

		public string VILLAGE
		{
			get { return _village; }
			set { _village = value; }
		}

		private int _id_zone;

		public int ID_ZONE
		{
			get { return _id_zone; }
			set { _id_zone = value; }
		}

		private string _zone;

		public string ZONE
		{
			get { return _zone; }
		}
		#endregion
		public PISTEUR()
		{
		}

		#region  IDBObjects Méthodes
		#region  Save
		public int Save ()
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",_id_auto);
				SqlParameter nom=new SqlParameter ("@NOM",_nom);
				SqlParameter prenom=new SqlParameter ("@PRENOM",_prenom);
				SqlParameter contact=new SqlParameter ("@CONTACT",_contact);
				SqlParameter village=new SqlParameter ("@VILLAGE",_village);
				SqlParameter id_zone=new SqlParameter ("@ID_ZONE",_id_zone);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_PISTEUR",nom,prenom,contact,village,id_zone);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_PISTEUR",id_auto,nom,prenom,contact,village,id_zone);
				}
				return _id_auto;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		#region  Delete
		public bool Delete ()
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",_id_auto);
				SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
				"sp_Delete_PISTEUR",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		public bool Delete (int Id)
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
				SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
				"sp_Delete_PISTEUR",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static PISTEUR CreateNew()
		{
			return new PISTEUR();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_PISTEUR", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRENOM"))))
							{
								PRENOM = dr.GetString(dr.GetOrdinal("PRENOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("CONTACT"))))
							{
								CONTACT = dr.GetString(dr.GetOrdinal("CONTACT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("VILLAGE"))))
							{
								VILLAGE = dr.GetString(dr.GetOrdinal("VILLAGE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_ZONE"))))
							{
								ID_ZONE = dr.GetInt32(dr.GetOrdinal("ID_ZONE"));
							}
				}
			return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				dr.Close();
			}
		}
		#endregion
		public void SetId(int id_auto)
		{
			_id_auto = id_auto;
		}
		public void SetZONE(string zone)
		{
			_zone = zone;
		}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<PISTEUR> GetList()
		{
				List<PISTEUR> _list= new List<PISTEUR>();
				SqlDataReader dr = null;
				PISTEUR var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_PISTEUR" ,id_auto);
				while (dr.Read())
				{
				var=new PISTEUR();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								var.NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRENOM"))))
							{
								var.PRENOM = dr.GetString(dr.GetOrdinal("PRENOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("CONTACT"))))
							{
								var.CONTACT = dr.GetString(dr.GetOrdinal("CONTACT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("VILLAGE"))))
							{
								var.VILLAGE = dr.GetString(dr.GetOrdinal("VILLAGE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_ZONE"))))
							{
								var.ID_ZONE = dr.GetInt32(dr.GetOrdinal("ID_ZONE"));
							}
						var.SetZONE(dr.GetString(dr.GetOrdinal("ZONE")));
				_list.Add(var);
				}
			return _list;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				dr.Close();
			}
		}
		#endregion
	}
}

