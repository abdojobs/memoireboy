using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MemoireBoy2013
{
    public static class BDGestionAccess2013
    {

        #region "Champs"

        private static string chaine_connexion = "";
        private static string baseDeDonnees = "";
        private static string dataSourcePath = "";
        public static string TotalPathForBase = "";

        // Objets de connexion à la base de données
        public static OleDbConnection connexion_access = null;
        public static OleDbCommand commande = null;
        public static OleDbDataAdapter dap = null;


        #endregion

        public static bool OUVRIRconnexionBD(string basename)
        {
            string chemin = "";
            bool changePath = false;

            if (TotalPathForBase == "")
            {
                chaine_connexion = @"Provider=Microsoft.Jet.OLEDB.4.0;"
                    + @"Data Source=.\bd\" + basename + ".mdb";
                // assure la connectivité avec Access

                int pos = chaine_connexion.IndexOf(@".\");
                chemin = chaine_connexion.Substring(pos);

                //return false; // pour tester et gérer l'absence de connexion
            }
            else
            {
                chaine_connexion = @"Provider=Microsoft.Jet.OLEDB.4.0;"
                            + @"Data Source="+TotalPathForBase;
                chemin = TotalPathForBase;
                changePath = true;
            }
            

            try
            {

                FileInfo lefichier = new FileInfo(chemin);

                if (lefichier.Exists == true)
                {
                    if (changePath) 
                    { 
                        System.IO.File.Copy(TotalPathForBase, @".\bd\memoireboy2013.mdb");

                        chaine_connexion = @"Provider=Microsoft.Jet.OLEDB.4.0;"+ @"Data Source=.\bd\memoireboy2013.mdb";
                        Application.Restart();
                     
                    }
                    connexion_access = new OleDbConnection(chaine_connexion);
                    connexion_access.Open();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }


        public static bool FERMERconnexionBD(string basename)
        {
            bool bol = false;
            string chemin = "";

            if (TotalPathForBase == "")
            {
                chaine_connexion = @"Provider=Microsoft.Jet.OLEDB.4.0;"
                    + @"Data Source=.\bd\" + basename + ".mdb";
                // assure la connectivité avec Access

                int pos = chaine_connexion.IndexOf(@".\");
                chemin = chaine_connexion.Substring(pos);

                return false; // pour tester et gérer l'absence de connexion
            }
            else
            {
                chaine_connexion = @"Provider=Microsoft.Jet.OLEDB.4.0;"
                            + @"Data Source=" + TotalPathForBase;
                chemin = TotalPathForBase;
            }

            try
            {

                FileInfo lefichier = new FileInfo(chemin);

                if (lefichier.Exists == true)
                {
                    connexion_access = new OleDbConnection(chaine_connexion);
                    connexion_access.Close();
                    bol = true;
                }

            }
            catch
            {
                return false;
            }

            return bol;

        }

        public static bool GRPPERS_EXIST(int grpid, int persid)
        {
            bool bol = false;

            try
            {

                // -------------  creation d'une tache avec ID


                string req = "select count(*) from grppers where grpid = "+grpid+" and persid = "+persid;

                OleDbCommand cmdacc = new OleDbCommand(req, BDGestionAccess2013.connexion_access);

                int res = (int)cmdacc.ExecuteScalar();

                if (res > 0) { bol = true; }

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }

            return bol;
        }



        public static void CREA_GRPPERS(int grpid, int persid)
        {
            try
            {

                // -------------  creation d'une tache avec ID
                bool bol = BDGestionAccess2013.GRPPERS_EXIST(grpid, persid);

                if (!bol)
                {
                    string ins = "Insert into grppers (grpid,persid) values (" + grpid + "," + persid + ")";

                    OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                    int res = cmdacc.ExecuteNonQuery();
                }

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }



        public static void DELETE_GRPPERS(int grpid, int persid)
        {
            try
            {

                    string ins = "delete from grppers where grpid = "+grpid+ " and persid = "+persid;

                    OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                    int res = cmdacc.ExecuteNonQuery();
 

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }



        public static void DELETE_GROUPE(int grpid)
        {
            try
            {

                string del = "delete from groupes where idgrp = " + grpid;

                OleDbCommand cmdacc = new OleDbCommand(del, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();


                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static List<string> REQUETEUR_GROUPES(string requete)
        {

            List<string> Lt = new List<string>();

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    Lt.Add(lecteur.GetString(1));
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return Lt;

        }

        public static int GROUPES_GETIDBYLIB(string lib)
        {

            int id=-1;

            string requete = "select * from groupes where libgrp = '" + lib + "'";

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    id= lecteur.GetInt32(0);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return id;

        }

        public static int PERSONNES_GETIDBYPERS(PersonneClass p)
        {

            int id=-1;
            string requete = "select idpers from personnes where prenompers = '" + p.prenom + "' and nompers= '"+p.nom+"' and mailpers ='"+p.e_mail+"'";

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    id = lecteur.GetInt32(0);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return id;

        }

        public static List<PersonneClass> REQUETEUR_PERSONNES(string requete)
        {

            List<PersonneClass> Lt = new List<PersonneClass>();

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    PersonneClass t = new PersonneClass(lecteur.GetInt32(0),
                                         lecteur.GetString(1),
                                         lecteur.GetString(2),
                                         lecteur.GetString(3),
                                         lecteur.GetString(4),
                                         lecteur.GetString(5),
                                         lecteur.GetString(6),
                                         lecteur.GetString(7),
                                         lecteur.GetString(8),
                                         lecteur.GetString(9),
                                         lecteur.GetString(10),
                                         lecteur.GetString(11),
                                         lecteur.GetString(12),
                                         lecteur.GetString(13),
                                         lecteur.GetString(14),
                                         lecteur.GetString(15),
                                         lecteur.GetString(16),
                                         lecteur.GetString(17));
                    Lt.Add(t);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return Lt;

        }


        public static PersonneClass GET_PERSONNEBY(int id)
        {

            PersonneClass per = null;
            string requete = "select * from personnes where idpers=" + id;

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    per = new PersonneClass(lecteur.GetInt32(0),
                                         lecteur.GetString(1),
                                         lecteur.GetString(2),
                                         lecteur.GetString(3),
                                         lecteur.GetString(4),
                                         lecteur.GetString(5),
                                         lecteur.GetString(6),
                                         lecteur.GetString(7),
                                         lecteur.GetString(8),
                                         lecteur.GetString(9),
                                         lecteur.GetString(10),
                                         lecteur.GetString(11),
                                         lecteur.GetString(12),
                                         lecteur.GetString(13),
                                         lecteur.GetString(14),
                                         lecteur.GetString(15),
                                         lecteur.GetString(16),
                                         lecteur.GetString(17));
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return per;

        }


        public static List<Taches> REQUETEUR_TACHES(string requete)
        {

            List<Taches> Lt = new List<Taches>();

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    Taches t = new Taches(lecteur.GetInt32(0), 
                                         lecteur.GetString(1).Replace("''","'"),
                                         lecteur.GetString(2).Replace("''", "'"), 
                                         lecteur.GetString(3),
                                         lecteur.GetString(4), 
                                         lecteur.GetString(5), 
                                         lecteur.GetString(6),
                                         lecteur.GetString(7), 
                                         lecteur.GetString(8), 
                                         lecteur.GetInt32(9),
                                         lecteur.GetInt32(10), 
                                         lecteur.GetBoolean(11));
                    Lt.Add(t);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\r\n"+ex.InnerException);
            }

          

            return Lt;

        }


        public static List<string> REQUETEUR_TITRES_TACHES(string requete)
        {

            List<string> Lst = new List<string>();

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    string t = lecteur.GetString(0);
                    Lst.Add(t.Replace("''", "'"));
                }

                lecteur.Close();

            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return Lst;

        }


        public static int COUNT(string table, string requeteCount)
        {

            int cpt = -1;

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requeteCount, BDGestionAccess2013.connexion_access);
                cpt = (int)cmdaccess.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return cpt;

        }


        public static void REPORT_UNE_DATE(Taches tach, DateTime dt)
        {
            try
            {

                string autredate = dt.ToShortDateString();


                string rqt = "Update taches set datdebt = '" + autredate + "' where idt = " + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(rqt, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void REPORT_A_DEMAIN(Taches tach, DateTime dt)
        {
            try
            {
                string today = dt.ToShortDateString();
                string lendemain = dt.AddDays(1).ToShortDateString();


                #region "report lendemain"

                string rqt = "Update taches set datdebt = '" + lendemain + "' where idt = " + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(rqt, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }  
        }


        public static void REPORT_A_HIER(Taches tach, DateTime dt)
        {
            try
            {
                string today = dt.ToShortDateString();
                string lendemain = dt.AddDays(-1).ToShortDateString();


                #region "report hier"

                string rqt = "Update taches set datdebt = '" + lendemain + "' where idt = " + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(rqt, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void MODIFIE_TACHE(Taches tach)
        {
            try
            {

                // -------------  modif d'une tache


                string ins = "Update taches set titret='" + tach.Titre.Replace("'", "''") + "',descript='" + tach.Description.Replace("'", "''") + "',datdebt='" + tach.Datdeb + "',datfint='" + tach.Datfin + "',heuredebt='" + tach.Heuredeb + "',heurefint='" + tach.Heurefin + "',destinatt=" + tach.DestinatId + ",archive=" + tach.Archive + " where idt=" + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void MODIFIE_TACHE_ARCHIVEMOINS(Taches tach)
        {
            try
            {

                // -------------  modif d'une tache


                string ins = "Update taches set archive=false where idt=" + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void MODIFIE_TACHE_ARCHIVEPLUS(Taches tach)
        {
            try
            {

                // -------------  modif d'une tache


                string ins = "Update taches set archive=true where idt=" + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void CREA_TACHE(Taches tach,Int32 tachID)
        {
            try
            {

                // -------------  creation d'une tache avec ID


                string ins = "Insert into taches (idt,titret,descript,datdebt,datfint,heuredebt,heurefint,datecreat,heurecreat,auteurt,destinatt,archive) values (" + tachID + ",'" + tach.Titre.Replace("'", "''") + "','" +
                                                                                                                                                                           tach.Description.Replace("'", "''") + "','" +
                                                                                                                                                                           tach.Datdeb + "','" +
                                                                                                                                                                           tach.Datfin + "','" +
                                                                                                                                                                           tach.Heuredeb + "','" +
                                                                                                                                                                           tach.Heurefin + "','" +
                                                                                                                                                                           tach.Datcrea + "','" +
                                                                                                                                                                           tach.Heurecrea + "'," +
                                                                                                                                                                           tach.AuteurId + "," +
                                                                                                                                                                           tach.DestinatId + "," +
                                                                                                                                                                           tach.Archive + ")";

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void CREA_TACHE(Taches tach)
        {
            try
            {

                // -------------  creation d'une tache


                string ins = "Insert into taches (titret,descript,datdebt,datfint,heuredebt,heurefint,datecreat,heurecreat,auteurt,destinatt,archive) values ('" + tach.Titre.Replace("'", "''") + "','" +
                                                                                                                                                                           tach.Description.Replace("'", "''") + "','" +
                                                                                                                                                                           tach.Datdeb + "','" +
                                                                                                                                                                           tach.Datfin + "','" +
                                                                                                                                                                           tach.Heuredeb + "','" +
                                                                                                                                                                           tach.Heurefin + "','" +
                                                                                                                                                                           tach.Datcrea + "','" +
                                                                                                                                                                           tach.Heurecrea + "'," +
                                                                                                                                                                           tach.AuteurId + "," +
                                                                                                                                                                           tach.DestinatId + "," +
                                                                                                                                                                           tach.Archive + ")";

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);                                                                         

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void SUPPRIME_TACHE(Taches tach)
        {
            try
            {

                // -------------  effacer une tache


                string del = "DELETE from taches where idt=" + tach.TacheID;

                OleDbCommand cmdacc = new OleDbCommand(del, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }




   


        public static void CREA_PERSONNE(PersonneClass P)
        {
            try
            {

                // -------------  creation d'une tache


                string ins = "Insert into personnes (civpers,prenompers,nompers,datenaisspers,mailpers,telpers,mobilepers,faxpers,adrpers,cppers,villepers,bppers,imagepers,notepers,cvpers,sitepers,activitepers) values ('" + P.civilite + "','" +
                                                                                                                                                                           P.prenom + "','" +
                                                                                                                                                                           P.nom.Replace("'", "''") + "','" +
                                                                                                                                                                           P.dateNaissance + "','" +
                                                                                                                                                                           P.e_mail + "','" +
                                                                                                                                                                           P.telfixe + "','" +
                                                                                                                                                                           P.telportable + "','" +
                                                                                                                                                                           P.fax + "','" +
                                                                                                                                                                           P.adresse.Replace("'", "''") + "','" +
                                                                                                                                                                           P.cp +"','"+
                                                                                                                                                                           P.ville.Replace("'", "''") + "','" +
                                                                                                                                                                           P.bp + "','" +
                                                                                                                                                                           P.adrImage + "','" +
                                                                                                                                                                           P.note.Replace("'", "''") + "','" +
                                                                                                                                                                           P.adrDocCV + "','" +
                                                                                                                                                                           P.site + "','" +
                                                                                                                                                                           P.activite + "')";

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P"></param>
        /// <param name="droits"></param>
        /// <param name="prefs">0:uilisateur |1:administrateur</param>
        public static void CREA_USER(PersonneClass P,int droits,int prefs,string login,string password)
        {
            try
            {

                string ins = "Insert into users (persuserid,droitsuser,prefsuser,loginuser,passworduser) values (" + P.idPers + "," + droits + "," + prefs + ",'" + login + "','" + MD5CLASS.getMd5Hash(password) + "')"; 

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void CREA_GROUPES(string grp)
        {
            try
            {

                // -------------  creation d'une tache avec ID


                string ins = "Insert into groupes (libgrp) values ('" + grp + "')";
                                                                                                                                           
                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }



        public static void SUPPRIME_USER(PersonneClass pers)
        {
            try
            {

                // -------------  modif d'une tache


                string mod = "delete from users where persuserid=" + pers.idPers;

                OleDbCommand cmdacc = new OleDbCommand(mod, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static Users REQUETEUR_USERS(string login, string mdp)
        {

            string requete = "select * from users where loginuser='" + login + "' and passworduser ='" + MD5CLASS.getMd5Hash(mdp) + "'";
            Users u = null;

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    u = new Users();
                    u.persUserId = lecteur.GetInt32(1);
                    u.droitsuser = lecteur.GetInt32(2);
                    u.prefsuser = lecteur.GetInt32(3);
                    u.login = lecteur.GetString(4);
                    u.password = lecteur.GetString(5);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return u;

        }


        public static Users USERS_EXIST(string login)
        {

            string requete = "select * from users where loginuser='" + login +"'";
            Users u = null;

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    u = new Users();
                    u.persUserId = lecteur.GetInt32(1);
                    u.droitsuser = lecteur.GetInt32(2);
                    u.prefsuser = lecteur.GetInt32(3);
                    u.login = lecteur.GetString(4);
                    u.password = lecteur.GetString(5);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return u;

        }





        public static void SUPPRIME_PERSONNE(PersonneClass pers)
        {
            try
            {

                // -------------  modif d'une tache


                string mod = "delete from personnes where idpers=" + pers.idPers;

                OleDbCommand cmdacc = new OleDbCommand(mod, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        public static void MODIFIE_PERSONNE(PersonneClass pers)
        {
            try
            {

                // -------------  modif d'une tache


                string mod = "Update personnes set civpers='" + pers.civilite + "',prenompers='" + pers.prenom.Replace("'", "''")+
                              "',nompers ='" + pers.nom.Replace("'", "''") + "',datenaisspers='" + pers.dateNaissance + 
                              "',mailpers='" + pers.e_mail +
                              "',telpers='"+pers.telfixe+ "',mobilepers='"+pers.telportable+"',faxpers='"+pers.fax+
                              "',adrpers='" + pers.adresse.Replace("'", "''") + "',cppers='" + pers.cp + "',villepers='" +
                                pers.ville + "',bppers='" + pers.bp +
                              "',imagepers='" + pers.adrImage + "',notepers='" + pers.note.Replace("'", "''") +
                              "',cvpers='" + pers.adrDocCV +
                              "',sitepers='"+pers.site+"',activitepers='"+pers.activite+"' where idpers="+pers.idPers;

                OleDbCommand cmdacc = new OleDbCommand(mod, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static bool TABLE_EXIST(string table)
        {

            try
            {

                // -------------  rechercher si table existe



                DataTable Tables = connexion_access.GetSchema("tables");
                for (int i = 0; i < Tables.Rows.Count; i++)
                {
                    string comp = Tables.Rows[i][2].ToString();
                    if (table.CompareTo(comp) == 0)
                    {
                        return true;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }

            return false;

        }


        public static void CREATE_TABLE(string requeteCrea)
        {

            try
            {

                // -------------  Creation d'une table

                string crea = requeteCrea;

                OleDbCommand cmdacc = new OleDbCommand(crea, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }


        }


        public static string REQUETEUR_JOURNAL(string requete)
        {

            string txt="";

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    txt = lecteur.GetString(1);
                }

                lecteur.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return txt.Replace("''", "'");

        }

        /// <summary>
        /// creation dans le journal d'un jour
        /// </summary>
        /// <param name="jour">le texte du jour</param>
        /// <param name="date">la date à laquelle créer le texte</param>
        public static void CREA_JOUR_DS_JOURNAL(string jour, string date)
        {
            try
            {

                // -------------  creation d'une tache avec ID


                string ins = "Insert into journal (textj,datej) values ('" + jour.Replace("'","''") + "','"+date+"')";

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        public static void MODIF_JOUR_DS_JOURNAL(string jour, string date)
        {
            try
            {

                // -------------  modif d'un jour ds journal


                string ins = "update journal set textj='" + jour + "', datej='" + date + "'";

                OleDbCommand cmdacc = new OleDbCommand(ins, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }



        public static void SUPPRIME_JOUR_DS_JOURNAL(string date)
        {
            try
            {

                // -------------  modif d'une tache


                string dj = "delete from journal where datej='" + date + "'";

                OleDbCommand cmdacc = new OleDbCommand(dj, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();

                // -------------------------------------------------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }


        public static void UPDATE_VERSIONMB(int VersionWEB)
        {
            try
            {

                string rqt = "Update version set numversion = '" + VersionWEB.ToString() +"'";

                OleDbCommand cmdacc = new OleDbCommand(rqt, BDGestionAccess2013.connexion_access);

                int res = cmdacc.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }



        public static string LIT_OLDVERSIONMB()
        {

            string txt = "";
            string requete = "select * from version where idversion=1";

            try
            {

                OleDbCommand cmdaccess = new OleDbCommand(requete, BDGestionAccess2013.connexion_access);
                OleDbDataReader lecteur = cmdaccess.ExecuteReader();


                while (lecteur.Read())
                {
                    txt = lecteur.GetString(1);
                }

                lecteur.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException);
            }



            return txt;

        }

    }
}
