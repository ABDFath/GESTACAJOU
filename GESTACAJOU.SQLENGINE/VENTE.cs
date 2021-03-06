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
	public class VENTE: IDBObject
	{
		#region  private vars & public Properties
		private int _id_auto;

		public int ID_AUTO
		{
			get { return _id_auto; }
		}
		private int _id_partenaire;

		public int ID_PARTENAIRE
		{
			get { return _id_partenaire; }
			set { _id_partenaire = value; }
		}

		private int _montant_total;

		public int MONTANT_TOTAL
		{
			get { return _montant_total; }
			set { _montant_total = value; }
		}

		private int _qte_total;

		public int QTE_TOTAL
		{
			get { return _qte_total; }
			set { _qte_total = value; }
		}

		private DateTime _date_operation;

		public DateTime DATE_OPERATION
		{
			get { return _date_operation; }
			set { _date_operation = value; }
		}

		private string _partenaire;

		public string PARTENAIRE
		{
			get { return _partenaire; }
		}
		#endregion
		public VENTE()
		{
		}

		#region  IDBObjects Méthodes
		#region  Save
		public int Save ()
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",_id_auto);
				SqlParameter id_partenaire=new SqlParameter ("@ID_PARTENAIRE",_id_partenaire);
				SqlParameter montant_total=new SqlParameter ("@MONTANT_TOTAL",_montant_total);
				SqlParameter qte_total=new SqlParameter ("@QTE_TOTAL",_qte_total);
				SqlParameter date_operation=new SqlParameter ("@DATE_OPERATION",_date_operation);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
					"sp_Insert_VENTE",id_partenaire,montant_total,qte_total,date_operation);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
					"sp_Update_VENTE",id_auto,id_partenaire,montant_total,qte_total,date_operation);
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
				SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
				"sp_Delete_VENTE",id_auto);
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
				SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
				"sp_Delete_VENTE",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static VENTE CreateNew()
		{
			return new VENTE();
		}

        public override string ToString()
        {
            return "Vente du "+ DATE_OPERATION +";Partenaire : "+ PARTENAIRE + "; Montant Total : "+MONTANT_TOTAL;
        }
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_VENTE", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
						ID_PARTENAIRE = dr.GetInt32(dr.GetOrdinal("ID_PARTENAIRE"));

						if(!(dr.IsDBNull(dr.GetOrdinal("MONTANT_TOTAL"))))
							{
								MONTANT_TOTAL = dr.GetInt32(dr.GetOrdinal("MONTANT_TOTAL"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL"))))
							{
								QTE_TOTAL = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL"));
							}
						DATE_OPERATION = dr.GetDateTime(dr.GetOrdinal("DATE_OPERATION"));

                       this.SetPARTENAIRE(dr.GetString(dr.GetOrdinal("PARTENAIRE")));
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
		public void SetPARTENAIRE(string partenaire)
		{
			_partenaire = partenaire;
		}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<VENTE> GetList()
		{
				List<VENTE> _list= new List<VENTE>();
				SqlDataReader dr = null;
				VENTE var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_VENTE" ,id_auto);
				while (dr.Read())
				{
				var=new VENTE();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
						var.ID_PARTENAIRE = dr.GetInt32(dr.GetOrdinal("ID_PARTENAIRE"));

						if(!(dr.IsDBNull(dr.GetOrdinal("MONTANT_TOTAL"))))
							{
								var.MONTANT_TOTAL = dr.GetInt32(dr.GetOrdinal("MONTANT_TOTAL"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("QTE_TOTAL"))))
							{
								var.QTE_TOTAL = dr.GetInt32(dr.GetOrdinal("QTE_TOTAL"));
							}
						var.DATE_OPERATION = dr.GetDateTime(dr.GetOrdinal("DATE_OPERATION"));
						var.SetPARTENAIRE(dr.GetString(dr.GetOrdinal("PARTENAIRE")));
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

