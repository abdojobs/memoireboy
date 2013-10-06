using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoireBoy2013
{
    public class Taches
    {

        public Taches() { }

        public Taches(Int32 tid, string ttitre, string tdesc, string tdatdeb,
                            string tdatfin, string theuredeb, string theurefin,
                            string tdatecrea, string theurecrea, Int32 tauteur, Int32 tdestinat,
                            Boolean tarchive)
        {
            this.TacheID = tid;
            this.Titre = ttitre;
            this.Description = tdesc;
            this.Datdeb = tdatdeb;
            this.Datfin = tdatfin;
            this.Heuredeb = theuredeb;
            this.Heurefin = theurefin;
            this.Datcrea = tdatecrea;
            this.Heurecrea = theurecrea;
            this.AuteurId = tauteur;
            this.DestinatId = tdestinat;
            this.Archive = tarchive;


        }



       #region "champs de la tache"

            private Int32 tacheid;
            public Int32 TacheID
            {
                get { return tacheid; }
                set { tacheid = value; }
            }

            private string titre;
            public string Titre
            {
                get { return titre; }
                set { titre = value; }
            }

            private string description;
            public string Description
            {
                get { return description; }
                set { description = value; }
            }


            private string datdeb;
            public string Datdeb
            {
                get { return datdeb; }
                set { datdeb = value; }
            }

            private string datfin;
            internal string Datfin
            {
                get { return datfin; }
                set { datfin = value; }
            }

            private string heuredeb;
            public string Heuredeb
            {
                get { return heuredeb; }
                set {
                        heuredeb = value; 
                    }
            }

            private string heurefin;
            public string Heurefin
            {
                get { return heurefin; }
                set { heurefin = value; }
            }

            private string datcrea;
            public string Datcrea
            {
                get { return datcrea; }
                set { datcrea = value; }
            }

            private string heurecrea;
            public string Heurecrea
            {
                get { return heurecrea; }
                set { heurecrea = value; }
            }


            private Int32 auteurid;
            public Int32 AuteurId
            {
                get { return auteurid; }
                set { auteurid = value; }
            }

            private Int32 destinatid;
            public Int32 DestinatId
            {
                get { return destinatid; }
                set { destinatid = value; }
            }

            private Boolean archive;
            public Boolean Archive
            {
                get { return archive; }
                set { archive = value; }
            }



		#endregion
		




    }
}
