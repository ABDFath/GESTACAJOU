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
	public class SYS_GROUP_DROIT: IDBObject
	{
		#region  private vars & public Properties
		private string __droit;

		public string _DROIT
		{
			get { return __droit; }
		}
		private string __group;

		public string _GROUP
		{
			get { return __group; }
		}
		#endregion
		public SYS_GROUP_DROIT()
		{
		}

		#region  IDBObjects Méthodes
		#region  Save
        public int Save()
        {
            //try
            return 0;
        }
		#endregion
		#region  Delete
		public bool Delete ()
		{
			try
			{
				SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
				"sp_Delete_SYS_GROUP_DROIT");
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		public bool Delete (int Id)
		{
			return false;
		}
		#endregion
		public static SYS_GROUP_DROIT CreateNew()
		{
			return new SYS_GROUP_DROIT();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
			return false;
		}
		#endregion
		public void Set_DROIT(string _droit)
		{
			__droit = _droit;
		}
		public void Set_GROUP(string _group)
		{
			__group = _group;
		}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<SYS_GROUP_DROIT> GetList()
		{
				List<SYS_GROUP_DROIT> _list= new List<SYS_GROUP_DROIT>();
				SqlDataReader dr = null;
				SYS_GROUP_DROIT var = null;
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_GROUP_DROIT" );
				while (dr.Read())
				{
				var=new SYS_GROUP_DROIT();
                        //var.ID_GROUP = dr.GetInt32(dr.GetOrdinal("ID_GROUP"));
                        //var.ID_DROIT = dr.GetInt32(dr.GetOrdinal("ID_DROIT"));
						var.Set_DROIT(dr.GetString(dr.GetOrdinal("_DROIT")));
						var.Set_GROUP(dr.GetString(dr.GetOrdinal("_GROUP")));
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

