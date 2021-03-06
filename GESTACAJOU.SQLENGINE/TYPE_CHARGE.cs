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
	public class TYPE_CHARGE: IDBObject
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

		private int _plafond;

		public int PLAFOND
		{
			get { return _plafond; }
			set { _plafond = value; }
		}

		#endregion
		public TYPE_CHARGE()
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
				SqlParameter plafond=new SqlParameter ("@PLAFOND",_plafond);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_TYPE_CHARGE",nom,plafond);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_TYPE_CHARGE",id_auto,nom,plafond);
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
				"sp_Delete_TYPE_CHARGE",id_auto);
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
				"sp_Delete_TYPE_CHARGE",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static TYPE_CHARGE CreateNew()
		{
			return new TYPE_CHARGE();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_TYPE_CHARGE", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PLAFOND"))))
							{
								PLAFOND = dr.GetInt32(dr.GetOrdinal("PLAFOND"));
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
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<TYPE_CHARGE> GetList()
		{
				List<TYPE_CHARGE> _list= new List<TYPE_CHARGE>();
				SqlDataReader dr = null;
				TYPE_CHARGE var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_TYPE_CHARGE" ,id_auto);
				while (dr.Read())
				{
				var=new TYPE_CHARGE();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								var.NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PLAFOND"))))
							{
								var.PLAFOND = dr.GetInt32(dr.GetOrdinal("PLAFOND"));
							}
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

