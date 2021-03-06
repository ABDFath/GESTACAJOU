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
	public class SYS_DROIT: IDBObject
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

		private string _code;

		public string CODE
		{
			get { return _code; }
			set { _code = value; }
		}

		#endregion
		public SYS_DROIT()
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
				SqlParameter code=new SqlParameter ("@CODE",_code);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_SYS_DROIT",nom,code);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_SYS_DROIT",id_auto,nom,code);
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
				"sp_Delete_SYS_DROIT",id_auto);
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
				"sp_Delete_SYS_DROIT",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static SYS_DROIT CreateNew()
		{
			return new SYS_DROIT();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_DROIT", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("CODE"))))
							{
								CODE = dr.GetString(dr.GetOrdinal("CODE"));
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
		public static List<SYS_DROIT> GetList()
		{
				List<SYS_DROIT> _list= new List<SYS_DROIT>();
				SqlDataReader dr = null;
				SYS_DROIT var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_DROIT" ,id_auto);
				while (dr.Read())
				{
				var=new SYS_DROIT();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								var.NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("CODE"))))
							{
								var.CODE = dr.GetString(dr.GetOrdinal("CODE"));
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

