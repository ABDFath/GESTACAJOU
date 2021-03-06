using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using SC.Core;
using SC.Framework.Interfaces;
using System.Data.SqlTypes;
using Business;

namespace GESTACAJOU.SQLENGINE
{
	public class CHARGERMENT: IDBObject
	{
		#region  private vars & public Properties
		private int _id_auto;

		public int ID_AUTO
		{
			get { return _id_auto; }
		}
		private string _intitule;

		public string INTITULE
		{
			get { return _intitule; }
			set { _intitule = value; }
		}

		private int _id_zone;

		public int ID_ZONE
		{
			get { return _id_zone; }
			set { _id_zone = value; }
		}

		private int _prix_achat_total;

		public int PRIX_ACHAT_TOTAL
		{
			get { return _prix_achat_total; }
			set { _prix_achat_total = value; }
		}

		private int _qte_total_achat;

		public int QTE_TOTAL_ACHAT
		{
			get { return _qte_total_achat; }
			set { _qte_total_achat = value; }
		}

		private int _qte_total_sortie;

		public int QTE_TOTAL_SORTIE
		{
			get { return _qte_total_sortie; }
			set { _qte_total_sortie = value; }
		}

		private int _qte_total_vendu;

		public int QTE_TOTAL_VENDU
		{
			get { return _qte_total_vendu; }
			set { _qte_total_vendu = value; }
		}

		private int _prix_revient;

		public int PRIX_REVIENT
		{
			get { return _prix_revient; }
			set { _prix_revient = value; }
		}

		private DateTime _date_operation;

		public DateTime DATE_OPERATION
		{
			get { return _date_operation; }
			set { _date_operation = value; }
		}

		private int _id_utilisateur;

		public int ID_UTILISATEUR
		{
			get { return _id_utilisateur; }
			set { _id_utilisateur = value; }
		}

		private string _sys_utilisateur;

		public string SYS_UTILISATEUR
		{
			get { return _sys_utilisateur; }
		}
		private string _zone;

		public string ZONE
		{
			get { return _zone; }
		}
		#endregion
		public CHARGERMENT()
		{
		}

        public override string ToString()
        {
            return "Chargement "+INTITULE+" du " + DATE_OPERATION;
        }

		#region  IDBObjects Méthodes
		#region  Save
		public int Save ()
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",_id_auto);
				SqlParameter intitule=new SqlParameter ("@INTITULE",_intitule);
				SqlParameter id_zone=new SqlParameter ("@ID_ZONE",_id_zone);
				SqlParameter prix_achat_total=new SqlParameter ("@PRIX_ACHAT_TOTAL",_prix_achat_total);
				SqlParameter qte_total_achat=new SqlParameter ("@QTE_TOTAL_ACHAT",_qte_total_achat);
				SqlParameter qte_total_sortie=new SqlParameter ("@QTE_TOTAL_SORTIE",_qte_total_sortie);
				SqlParameter qte_total_vendu=new SqlParameter ("@QTE_TOTAL_VENDU",_qte_total_vendu);
				SqlParameter prix_revient=new SqlParameter ("@PRIX_REVIENT",_prix_revient);
				SqlParameter date_operation=new SqlParameter ("@DATE_OPERATION",_date_operation);
				SqlParameter id_utilisateur=new SqlParameter ("@ID_UTILISATEUR",_id_utilisateur);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_CHARGERMENT",intitule,id_zone,prix_achat_total,qte_total_achat,qte_total_sortie,qte_total_vendu,prix_revient,date_operation,id_utilisateur);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_CHARGERMENT",id_auto,intitule,id_zone,prix_achat_total,qte_total_achat,qte_total_sortie,qte_total_vendu,prix_revient,date_operation,id_utilisateur);
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
				"sp_Delete_CHARGERMENT",id_auto);
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
				"sp_Delete_CHARGERMENT",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static CHARGERMENT CreateNew()
		{
			return new CHARGERMENT();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_CHARGERMENT", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("INTITULE"))))
							{
								INTITULE = dr.GetString(dr.GetOrdinal("INTITULE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_ZONE"))))
							{
								ID_ZONE = dr.GetInt32(dr.GetOrdinal("ID_ZONE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRIX_ACHAT_TOTAL"))))
							{
								PRIX_ACHAT_TOTAL = dr.GetInt32(dr.GetOrdinal("PRIX_ACHAT_TOTAL"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL_ACHAT"))))
							{
								QTE_TOTAL_ACHAT = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL_ACHAT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL_SORTIE"))))
							{
								QTE_TOTAL_SORTIE = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL_SORTIE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL_VENDU"))))
							{
								QTE_TOTAL_VENDU = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL_VENDU"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRIX_REVIENT"))))
							{
								PRIX_REVIENT = dr.GetInt32(dr.GetOrdinal("PRIX_REVIENT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("DATE_OPERATION"))))
							{
								DATE_OPERATION = dr.GetDateTime(dr.GetOrdinal("DATE_OPERATION"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_UTILISATEUR"))))
							{
								ID_UTILISATEUR = dr.GetInt32(dr.GetOrdinal("ID_UTILISATEUR"));
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
		public void SetSYS_UTILISATEUR(string sys_utilisateur)
		{
			_sys_utilisateur = sys_utilisateur;
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
		public static List<CHARGERMENT> GetList()
		{
				List<CHARGERMENT> _list= new List<CHARGERMENT>();
				SqlDataReader dr = null;
				CHARGERMENT var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_CHARGERMENT" ,id_auto);
				while (dr.Read())
				{
				var=new CHARGERMENT();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("INTITULE"))))
							{
								var.INTITULE = dr.GetString(dr.GetOrdinal("INTITULE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_ZONE"))))
							{
								var.ID_ZONE = dr.GetInt32(dr.GetOrdinal("ID_ZONE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRIX_ACHAT_TOTAL"))))
							{
								var.PRIX_ACHAT_TOTAL = dr.GetInt32(dr.GetOrdinal("PRIX_ACHAT_TOTAL"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL_ACHAT"))))
							{
								var.QTE_TOTAL_ACHAT = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL_ACHAT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL_SORTIE"))))
							{
								var.QTE_TOTAL_SORTIE = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL_SORTIE"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL_VENDU"))))
							{
								var.QTE_TOTAL_VENDU = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL_VENDU"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRIX_REVIENT"))))
							{
								var.PRIX_REVIENT = dr.GetInt32(dr.GetOrdinal("PRIX_REVIENT"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("DATE_OPERATION"))))
							{
								var.DATE_OPERATION = dr.GetDateTime(dr.GetOrdinal("DATE_OPERATION"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("ID_UTILISATEUR"))))
							{
								var.ID_UTILISATEUR = dr.GetInt32(dr.GetOrdinal("ID_UTILISATEUR"));
							}
						var.SetSYS_UTILISATEUR(dr.GetString(dr.GetOrdinal("SYS_UTILISATEUR")));
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

