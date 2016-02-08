using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GESTACAJOU.Models;
using GESTACAJOU.SQLENGINE;

namespace GESTACAJOU.Models.Business
{
    public class DbFactory
    {

        public static List<PisteurModel> GetListPisteur()
        {
            var _pistInDb = GESTACAJOU.SQLENGINE.PISTEUR.GetList();
            List<PISTEUR> _pistList = _pistInDb.ToList();

            List<PisteurModel> _listPist = new List<PisteurModel>();
            _pistList.ForEach(pst =>
            {
                _listPist.Add(PisteurModel.Create(pst.ID_AUTO, pst.NOM, pst.PRENOM, pst.CONTACT, pst.VILLAGE, pst.ID_ZONE));
            });
            return _listPist;
        }

        public static void SavePisteur(PisteurModel model)
        {
            string instanceName = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connPool = new SqlConnection(instanceName))
            {
                if (connPool.State == System.Data.ConnectionState.Closed)
                    connPool.Open();
                PISTEUR dataObj = new PISTEUR();

                dataObj.NOM = model.NOM;
                dataObj.PRENOM = model.PRENOM;
                dataObj.CONTACT = model.TEL;
                dataObj.ID_ZONE = model.ID_ZONE;
                dataObj.VILLAGE = model.VILLAGE;

                if (model.ID_AUTO != 0) dataObj.SetId(model.ID_AUTO);
                try
                {
                    dataObj.Save();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex2)
                {
                    throw ex2;
                }
                finally
                {
                    try { connPool.Close(); }
                    catch (SqlException) { }
                    finally { connPool.Dispose(); }
                }
            }
        }


        public static PisteurModel FindPisteur(int id)
        {
            List<PISTEUR> _list = PISTEUR.GetList();
            PISTEUR item = _list.Find(c => c.ID_AUTO == id);
            //List<PISTEUR> _listPisteur = new List<PISTEUR>();
            PisteurModel _pisteur = new PisteurModel();
            if (item != null)
            {
                _pisteur.ID_AUTO = item.ID_AUTO;
                _pisteur.NOM = item.NOM;
                _pisteur.PRENOM = item.PRENOM;
                _pisteur.ID_ZONE = item.ID_ZONE;
                _pisteur.TEL = item.CONTACT;
                _pisteur.VILLAGE = item.VILLAGE;
                //_listMember.Add(_member);
            }
            return _pisteur;
        }
    }
}