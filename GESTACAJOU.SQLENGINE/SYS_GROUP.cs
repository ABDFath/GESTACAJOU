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
	public class SYS_GROUP: IDBObject
	{
		#region  private vars & public Properties
		private int _id_auto;

		public int ID_AUTO
		{
			get { return _id_auto; }
		}
		private string _nom_group;

		public string NOM_GROUP
		{
			get { return _nom_group; }
			set { _nom_group = value; }
		}

		#endregion
		public SYS_GROUP()
		{
		}

		#region  IDBObjects Méthodes
		#region  Save
		public int Save ()
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",_id_auto);
				SqlParameter nom_group=new SqlParameter ("@NOM_GROUP",_nom_group);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_SYS_GROUP",nom_group);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_SYS_GROUP",id_auto,nom_group);
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
				"sp_Delete_SYS_GROUP",id_auto);
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
				"sp_Delete_SYS_GROUP",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static SYS_GROUP CreateNew()
		{
			return new SYS_GROUP();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_GROUP", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM_GROUP"))))
							{
								NOM_GROUP = dr.GetString(dr.GetOrdinal("NOM_GROUP"));
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
		public static List<SYS_GROUP> GetList()
		{
				List<SYS_GROUP> _list= new List<SYS_GROUP>();
				SqlDataReader dr = null;
				SYS_GROUP var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_GROUP" ,id_auto);
				while (dr.Read())
				{
				var=new SYS_GROUP();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM_GROUP"))))
							{
								var.NOM_GROUP = dr.GetString(dr.GetOrdinal("NOM_GROUP"));
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

