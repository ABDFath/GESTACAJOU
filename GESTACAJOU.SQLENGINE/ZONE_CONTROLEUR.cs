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
	public class ZONE_CONTROLEUR: IDBObject
	{
		#region  private vars & public Properties
		private string _utilisateur;

		public string UTILISATEUR
		{
			get { return _utilisateur; }
		}
        //private string _;

        //public string 
        //{
        //    get { return _; }
        //}
		#endregion
		public ZONE_CONTROLEUR()
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
				"sp_Delete_ZONE_CONTROLEUR");
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
		public static ZONE_CONTROLEUR CreateNew()
		{
			return new ZONE_CONTROLEUR();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
			return false;
		}
		#endregion
		public void SetUTILISATEUR(string utilisateur)
		{
			_utilisateur = utilisateur;
		}
        //public void Set(string )
        //{
        //    _ = ;
        //}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<ZONE_CONTROLEUR> GetList()
		{
				List<ZONE_CONTROLEUR> _list= new List<ZONE_CONTROLEUR>();
				SqlDataReader dr = null;
				ZONE_CONTROLEUR var = null;
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_ZONE_CONTROLEUR" );
				while (dr.Read())
				{
				var=new ZONE_CONTROLEUR();
                        //var.ID_UTILISATEUR = dr.GetInt32(dr.GetOrdinal("ID_UTILISATEUR"));
                        //var.ID_ZONE = dr.GetInt32(dr.GetOrdinal("ID_ZONE"));
                        //var.SetUTILISATEUR(dr.GetString(dr.GetOrdinal("UTILISATEUR")));
                        //var.Set(dr.GetString(dr.GetOrdinal("")));
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

