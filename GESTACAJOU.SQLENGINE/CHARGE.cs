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
	public class CHARGE: IDBObject
	{
		#region  private vars & public Properties
		private int _id;

		public int ID
		{
			get { return _id; }
		}
		private int _id_type_cahrge;

		public int ID_TYPE_CAHRGE
		{
			get { return _id_type_cahrge; }
			set { _id_type_cahrge = value; }
		}

		private int _id_chargement;

		public int ID_CHARGEMENT
		{
			get { return _id_chargement; }
			set { _id_chargement = value; }
		}

		private int _cout;

		public int COUT
		{
			get { return _cout; }
			set { _cout = value; }
		}

		private DateTime _date;

		public DateTime DATE
		{
			get { return _date; }
			set { _date = value; }
		}

		private string _chargerment;

		public string CHARGERMENT
		{
			get { return _chargerment; }
		}
		private string _type_charge;

		public string TYPE_CHARGE
		{
			get { return _type_charge; }
		}
		#endregion
		public CHARGE()
		{
		}

		#region  IDBObjects Méthodes
		#region  Save
		public int Save ()
		{
			try
			{
				SqlParameter id=new SqlParameter ("@ID",_id);
				SqlParameter id_type_cahrge=new SqlParameter ("@ID_TYPE_CAHRGE",_id_type_cahrge);
				SqlParameter id_chargement=new SqlParameter ("@ID_CHARGEMENT",_id_chargement);
				SqlParameter cout=new SqlParameter ("@COUT",_cout);
				SqlParameter date=new SqlParameter ("@DATE",_date);
				if (_id==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_CHARGE",id_type_cahrge,id_chargement,cout,date);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_CHARGE",id,id_type_cahrge,id_chargement,cout,date);
				}
                return _id;
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
				SqlParameter id=new SqlParameter ("@ID",_id);
				SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
				"sp_Delete_CHARGE",id);
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
				SqlParameter id=new SqlParameter ("@ID",Id);
				SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
				"sp_Delete_CHARGE",id);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static CHARGE CreateNew()
		{
			return new CHARGE();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id=new SqlParameter ("@ID",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_CHARGE", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID")));

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_TYPE_CAHRGE"))))
							{
								ID_TYPE_CAHRGE = dr.GetInt32(dr.GetOrdinal("ID_TYPE_CAHRGE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_CHARGEMENT"))))
							{
								ID_CHARGEMENT = dr.GetInt32(dr.GetOrdinal("ID_CHARGEMENT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("COUT"))))
							{
								COUT = dr.GetInt32(dr.GetOrdinal("COUT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("DATE"))))
							{
								DATE = dr.GetDateTime(dr.GetOrdinal("DATE"));
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
		public void SetId(int id)
		{
			_id = id;
		}
		public void SetCHARGERMENT(string chargerment)
		{
			_chargerment = chargerment;
		}
		public void SetTYPE_CHARGE(string type_charge)
		{
			_type_charge = type_charge;
		}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<CHARGE> GetList()
		{
				List<CHARGE> _list= new List<CHARGE>();
				SqlDataReader dr = null;
				CHARGE var = null;
				SqlParameter id=new SqlParameter ("@ID","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_CHARGE" ,id);
				while (dr.Read())
				{
				var=new CHARGE();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID")));

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_TYPE_CAHRGE"))))
							{
								var.ID_TYPE_CAHRGE = dr.GetInt32(dr.GetOrdinal("ID_TYPE_CAHRGE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_CHARGEMENT"))))
							{
								var.ID_CHARGEMENT = dr.GetInt32(dr.GetOrdinal("ID_CHARGEMENT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("COUT"))))
							{
								var.COUT = dr.GetInt32(dr.GetOrdinal("COUT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("DATE"))))
							{
								var.DATE = dr.GetDateTime(dr.GetOrdinal("DATE"));
							}
						var.SetCHARGERMENT(dr.GetString(dr.GetOrdinal("CHARGERMENT")));
						var.SetTYPE_CHARGE(dr.GetString(dr.GetOrdinal("TYPE_CHARGE")));
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

