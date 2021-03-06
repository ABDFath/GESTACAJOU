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
	public class VENTE_DETAILS: IDBObject
	{
		#region  private vars & public Properties
		private int _id_auto;

		public int ID_AUTO
		{
			get { return _id_auto; }
		}
		private int _id_vente;

		public int ID_VENTE
		{
			get { return _id_vente; }
			set { _id_vente = value; }
		}

		private int _id_chargement;

		public int ID_CHARGEMENT
		{
			get { return _id_chargement; }
			set { _id_chargement = value; }
		}

		private int _prix_unitaire;

		public int PRIX_UNITAIRE
		{
			get { return _prix_unitaire; }
			set { _prix_unitaire = value; }
		}

		private int _qte;

		public int QTE
		{
			get { return _qte; }
			set { _qte = value; }
		}

		private int _total;

		public int TOTAL
		{
			get { return _total; }
			set { _total = value; }
		}

        private VENTE _vente;

        public VENTE VENTES
        {
            get { return _vente; }
        }
		private string _chargement;

        public string CHARGERMENT
		{
			get { return _chargement; }
		}
		#endregion
		public VENTE_DETAILS()
		{
		}

       

		#region  IDBObjects Méthodes
		#region  Save
		public int Save ()
		{
			try
			{
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",_id_auto);
				SqlParameter id_vente=new SqlParameter ("@ID_VENTE",_id_vente);
				SqlParameter id_chargement=new SqlParameter ("@ID_CHARGEMENT",_id_chargement);
				SqlParameter prix_unitaire=new SqlParameter ("@PRIX_UNITAIRE",_prix_unitaire);
				SqlParameter qte=new SqlParameter ("@QTE",_qte);
				SqlParameter total=new SqlParameter ("@TOTAL",_total);
				if (_id_auto==0)
				{
                    SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
					"sp_Insert_VENTE_DETAILS",id_vente,id_chargement,prix_unitaire,qte,total);
				}
				else
				{
                    SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
					"sp_Update_VENTE_DETAILS",id_auto,id_vente,id_chargement,prix_unitaire,qte,total);
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
				"sp_Delete_VENTE_DETAILS",id_auto);
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
				"sp_Delete_VENTE_DETAILS",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static VENTE_DETAILS CreateNew()
		{
			return new VENTE_DETAILS();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_VENTE_DETAILS", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
						ID_VENTE = dr.GetInt32(dr.GetOrdinal("ID_VENTE"));
						ID_CHARGEMENT = dr.GetInt32(dr.GetOrdinal("ID_CHARGEMENT"));
						PRIX_UNITAIRE = dr.GetInt32(dr.GetOrdinal("PRIX_UNITAIRE"));
						QTE = dr.GetInt32(dr.GetOrdinal("QTE"));
						TOTAL = dr.GetInt32(dr.GetOrdinal("TOTAL"));
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
        //public void Set(string )
        //{
        //    _ = ;
        //}
        public void SetCHARGERMENT(string chargement)
		{
			_chargement = chargement;
		}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<VENTE_DETAILS> GetList()
		{
				List<VENTE_DETAILS> _list= new List<VENTE_DETAILS>();
				SqlDataReader dr = null;
				VENTE_DETAILS var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_VENTE_DETAILS" ,id_auto);
				while (dr.Read())
				{
				var=new VENTE_DETAILS();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
						var.ID_VENTE = dr.GetInt32(dr.GetOrdinal("ID_VENTE"));
						var.ID_CHARGEMENT = dr.GetInt32(dr.GetOrdinal("ID_CHARGEMENT"));
						var.PRIX_UNITAIRE = dr.GetInt32(dr.GetOrdinal("PRIX_UNITAIRE"));
						var.QTE = dr.GetInt32(dr.GetOrdinal("QTE"));
						var.TOTAL = dr.GetInt32(dr.GetOrdinal("TOTAL"));
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

        public static List<VENTE_DETAILS> GetListByVente(int idVente,int idChargement)
        {
            List<VENTE_DETAILS> _list = new List<VENTE_DETAILS>();
            SqlDataReader dr = null;
            VENTE_DETAILS var = null;
            SqlParameter id_vente = new SqlParameter("@ID_VENTE", idVente);
            SqlParameter id_chargement = new SqlParameter("@ID_CHARGEMENT", idChargement);
            try
            {
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
               "SPGETLIST_VENTE_DETAILSBY_VENTE", id_vente, id_chargement);
                while (dr.Read())
                {
                    var = new VENTE_DETAILS();
                    var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));
                    var.ID_VENTE = dr.GetInt32(dr.GetOrdinal("ID_VENTE"));
                    var.ID_CHARGEMENT = dr.GetInt32(dr.GetOrdinal("ID_CHARGEMENT"));
                    var.PRIX_UNITAIRE = dr.GetInt32(dr.GetOrdinal("PRIX_UNITAIRE"));
                    var.QTE = dr.GetInt32(dr.GetOrdinal("QTE"));
                    var.TOTAL = dr.GetInt32(dr.GetOrdinal("TOTAL"));
                    var.SetCHARGERMENT(dr.GetString(dr.GetOrdinal("CHARGERMENT")));
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

