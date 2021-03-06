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
	public class PARTENAIRE: IDBObject
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

		private string _prenom;

		public string PRENOM
		{
			get { return _prenom; }
			set { _prenom = value; }
		}

		private string _contact;

		public string CONTACT
		{
			get { return _contact; }
			set { _contact = value; }
		}

		#endregion
		public PARTENAIRE()
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
				SqlParameter prenom=new SqlParameter ("@PRENOM",_prenom);
				SqlParameter contact=new SqlParameter ("@CONTACT",_contact);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
					"sp_Insert_PARTENAIRE",nom,prenom,contact);
				}
				else
				{
                    SqlHelper.ExecuteNonQuery(Connexion.Cnx, CommandType.StoredProcedure,
					"sp_Update_PARTENAIRE",id_auto,nom,prenom,contact);
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
				"sp_Delete_PARTENAIRE",id_auto);
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
				"sp_Delete_PARTENAIRE",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static PARTENAIRE CreateNew()
		{
			return new PARTENAIRE();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_PARTENAIRE", Id);
				while (dr.Read())
				{
						SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRENOM"))))
							{
								PRENOM = dr.GetString(dr.GetOrdinal("PRENOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("CONTACT"))))
							{
								CONTACT = dr.GetString(dr.GetOrdinal("CONTACT"));
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

        public override string ToString()
        {
            return NOM + " " + PRENOM;
        }
		#endregion
		#region  GetList()
		public static List<PARTENAIRE> GetList()
		{
				List<PARTENAIRE> _list= new List<PARTENAIRE>();
				SqlDataReader dr = null;
				PARTENAIRE var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
				"SPGETLIST_PARTENAIRE" ,id_auto);
				while (dr.Read())
				{
				var=new PARTENAIRE();
						var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

						if(!(dr.IsDBNull(dr.GetOrdinal("NOM"))))
							{
								var.NOM = dr.GetString(dr.GetOrdinal("NOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("PRENOM"))))
							{
								var.PRENOM = dr.GetString(dr.GetOrdinal("PRENOM"));
							}

						if(!(dr.IsDBNull(dr.GetOrdinal("CONTACT"))))
							{
								var.CONTACT = dr.GetString(dr.GetOrdinal("CONTACT"));
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

