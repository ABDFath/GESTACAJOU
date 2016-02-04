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
	public class ZONE: IDBObject
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

		#endregion
		public ZONE()
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
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_ZONE",nom);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_ZONE",id_auto,nom);
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
				"sp_Delete_ZONE",id_auto);
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
				"sp_Delete_ZONE",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static ZONE CreateNew()
		{
			return new ZONE();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_ZONE", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
						NOM = dr.GetString(dr.GetOrdinal("NOM"));
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
		public static List<ZONE> GetList()
		{
				List<ZONE> _list= new List<ZONE>();
				SqlDataReader dr = null;
				ZONE var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_ZONE" ,id_auto);
				while (dr.Read())
				{
				var=new ZONE();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
						var.NOM = dr.GetString(dr.GetOrdinal("NOM"));
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

