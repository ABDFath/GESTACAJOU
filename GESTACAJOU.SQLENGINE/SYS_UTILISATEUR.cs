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
	public class SYS_UTILISATEUR: IDBObject
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

		private string _pwd;

		public string PWD
		{
			get { return _pwd; }
			set { _pwd = value; }
		}

		private int _id_group;

		public int ID_GROUP
		{
			get { return _id_group; }
			set { _id_group = value; }
		}

		private string __group;

		public string _GROUP
		{
			get { return __group; }
		}

        public static List<SYS_UTILISATEUR> CONTROLEURS { get; set; }

		#endregion
		public SYS_UTILISATEUR()
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
				SqlParameter pwd=new SqlParameter ("@PWD",_pwd);
				SqlParameter id_group=new SqlParameter ("@ID_GROUP",_id_group);
				if (_id_auto==0)
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Insert_SYS_UTILISATEUR",nom,prenom,contact,pwd,id_group);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(DbLink.Instance.Connection, CommandType.StoredProcedure,
					"sp_Update_SYS_UTILISATEUR",id_auto,nom,prenom,contact,pwd,id_group);
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
				"sp_Delete_SYS_UTILISATEUR",id_auto);
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
				"sp_Delete_SYS_UTILISATEUR",id_auto);
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
		#endregion
		public static SYS_UTILISATEUR CreateNew()
		{
			return new SYS_UTILISATEUR();
		}
		#region  LoadId
		public bool LoadId(int Id)
		{
				SqlDataReader dr = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO",Id);
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_UTILISATEUR", Id);
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

						if(!(dr.IsDBNull(dr.GetOrdinal("PWD"))))
							{
								PWD = dr.GetString(dr.GetOrdinal("PWD"));
							}
						ID_GROUP = dr.GetInt32(dr.GetOrdinal("ID_GROUP"));
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
		public void Set_GROUP(string _group)
		{
			__group = _group;
		}
		public void SaveExtras ()
		{
		}
		#endregion
		#region  GetList()
		public static List<SYS_UTILISATEUR> GetList()
		{
				List<SYS_UTILISATEUR> _list= new List<SYS_UTILISATEUR>();
				SqlDataReader dr = null;
				SYS_UTILISATEUR var = null;
				SqlParameter id_auto=new SqlParameter ("@ID_AUTO","0");
			try
			{
				 dr=SqlHelper.ExecuteReader(DbLink.Instance.Connection,
				"SPGETLIST_SYS_UTILISATEUR" ,id_auto);
				while (dr.Read())
				{
				var=new SYS_UTILISATEUR();
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

						if(!(dr.IsDBNull(dr.GetOrdinal("PWD"))))
							{
								var.PWD = dr.GetString(dr.GetOrdinal("PWD"));
							}
						var.ID_GROUP = dr.GetInt32(dr.GetOrdinal("ID_GROUP"));
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

        public static List<SYS_UTILISATEUR> GetList_CONTROLEURS()
        {
            List<SYS_UTILISATEUR> _list = new List<SYS_UTILISATEUR>();
            SqlDataReader dr = null;
            SYS_UTILISATEUR var = null;
           
            try
            {
                dr = SqlHelper.ExecuteReader(Connexion.Cnx,
               "SPGETLIST_CONTROLEUR");
                while (dr.Read())
                {
                    var = new SYS_UTILISATEUR();
                    var.SetId(dr.GetInt32(dr.GetOrdinal("ID_AUTO")));

                    if (!(dr.IsDBNull(dr.GetOrdinal("CONTROLEUR"))))
                    {
                        var.NOM = dr.GetString(dr.GetOrdinal("CONTROLEUR"));
                    }

                    _list.Add(var);
                }
                CONTROLEURS = _list;
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

