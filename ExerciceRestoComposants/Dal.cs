using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Donnees
{
    internal class Connect
    {
        private String restoConnectionString;
        private SqlConnection con;

        private Connect()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "resto2";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            this.restoConnectionString = cs.ConnectionString;
            this.con = new SqlConnection(this.restoConnectionString);
        }

        static private Connect singleton = new Connect();
        static internal SqlConnection Connection { get => singleton.con; }
        static internal String ConnectionString { get => singleton.restoConnectionString; }
    }

    internal class DataTables
    {
        //=====================================
        // Pour empecher la suppression d'un composant qui participe 
        // dans une commande, nous devons definir la clé étrangère 
        // aussi entre les DataTables. Alors, les deux DataTable "composants"
        // et "commandes" doivent être disponibles en mémoire, pour faire 
        // marche la clé étrengère correctment, même si on veut utiliser
        // seulement une table afficher les commandes.
        //====================================

        // un adapter pour "composants" et l'autre pour "commandes" 
        private SqlDataAdapter adapterComposants;
        private SqlDataAdapter adapterCommandes;
        private SqlDataAdapter adapterTdc;

        // Initialiser ds une seule fois dans le programme
        // pas une fois pour "composants" et l'autre pour "commandes"
        private DataSet ds = new DataSet();

        private void loadComposants()
        {
            // fonction pour créer et remplir la DataTable "composants"

            adapterComposants = new SqlDataAdapter("SELECT * FROM composants ORDER BY Type_de_Composant, " +
                "Num_du_Composant", Connect.ConnectionString);
            // ====================================================================================
            // === Pour que l'adapter fasse la definition du schema et de clé primaire de 
            // === la DataTable automatiquement (mais cela ne marche pas pour de clé étrangère)
            // === Cette ligne doit être AVANT la ligne adapter.Fill(ds, "COMPANY")
            adapterComposants.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // ====================================================================================                       
            adapterComposants.Fill(ds, "composants");

            //===============================================
            // Déclaration de clé étrangère dans la DataTable "composant"
            // en réferant la DataTable "composants"
            //===============================================
            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
            new DataColumn[] {
                ds.Tables["tdc"].Columns["Type_de_composant"]
            },
            new DataColumn[] {
               ds.Tables["composants"].Columns["Type_de_composant"]
            }
            );
            myFK.DeleteRule = Rule.None;
            myFK.UpdateRule = Rule.None;
            ds.Tables["composants"].Constraints.Add(myFK);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapterComposants);
            adapterComposants.UpdateCommand = builder.GetUpdateCommand();
        }

        private void loadCommandes()
        {
            // fonction pour créer et remplir la DataTable "Commandes"

            adapterCommandes = new SqlDataAdapter(
                "SELECT A.Commande, B.Composant, A.TypeDeComposant " +
                "FROM commandes  A  " +
                "INNER JOIN composants B " +
                "ON (A.TypeDeComposant=B.Type_de_composant) and (A.NumDuComposant=B.Num_du_composant)" +
                "ORDER BY Commande",
                 Connect.ConnectionString);
            adapterCommandes.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterCommandes.Fill(ds, "Commandes");

            //===============================================
            // Déclaration de clé étrangère dans la DataTable "commandes"
            // en réferant la DataTable "composants"
            //===============================================
            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
            new DataColumn[]{
                ds.Tables["composants"].Columns["Type_de_composant"],
                ds.Tables["composants"].Columns["Composant"],
            },
            new DataColumn[] {
                ds.Tables["Commandes"].Columns["TypeDeComposant"],
                ds.Tables["Commandes"].Columns["Composant"],
            }
            );
            myFK.DeleteRule = Rule.None;
            myFK.UpdateRule = Rule.None;
            ds.Tables["Commandes"].Constraints.Add(myFK);
            //===============================================
        }

        private void loadTdc()
        {
            adapterTdc = new SqlDataAdapter("SELECT * FROM tdc ORDER BY Type_de_Composant", Connect.ConnectionString);
            adapterTdc.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // ====================================================================================                       
            adapterTdc.Fill(ds, "tdc");

            SqlCommandBuilder builder = new SqlCommandBuilder(adapterTdc);
            adapterTdc.UpdateCommand = builder.GetUpdateCommand();
        }

        private DataTables()
        {
            // Les DataTable "composants", "commandes" et "tdc" sont créées 
            // et remplis.
            loadTdc();
            loadComposants();
            loadCommandes();
        }

        static private DataTables singleton = new DataTables();

        internal static SqlDataAdapter getAdapterComposants()
        {
            return singleton.adapterComposants;
        }
        internal static SqlDataAdapter getAdapterCommandes()
        {
            return singleton.adapterCommandes;
        }
        internal static SqlDataAdapter getAdapterTdc()
        {
            return singleton.adapterTdc;
        }
        internal static DataSet getDataSet()
        {
            return singleton.ds;
        }
    }

    internal class Composants
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterComposants();
        private static DataSet ds = DataTables.getDataSet();

        static internal DataTable GetComposants()
        {
            return ds.Tables["Composants"];
        }
        static internal int UpdateComposants()
        {
            if (!ds.Tables["composants"].HasErrors)
            {
                return adapter.Update(ds.Tables["composants"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Tdc
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterTdc();
        private static DataSet ds = DataTables.getDataSet();

        static internal DataTable GetTdc()
        {
            return ds.Tables["tdc"];
        }
        static internal int UpdateTdc()
        {
            if (!ds.Tables["tdc"].HasErrors)
            {
                return adapter.Update(ds.Tables["tdc"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Commandes
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCommandes();
        private static DataSet ds = DataTables.getDataSet();

        static internal DataTable GetCommandes()
        {
            // Refresh la DataTable "Commandes"
            ds.Tables["Commandes"].Clear();
            adapter.Fill(ds, "Commandes");
            return ds.Tables["Commandes"];
        }

        static internal bool SupprimerLignes(List<String[]> list)
        {
            bool updated = false;
            Connect.Connection.Open();
            SqlCommand cmd = new SqlCommand("", Connect.Connection);

                cmd.Transaction = Connect.Connection.BeginTransaction();

                foreach (String[] r in list)
                {
                    cmd.CommandText = "DELETE from commandes where (Commande = " +
                        r[0] +
                        ") and (TypeDeComposant = '" + r[1] +
                        "')";
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                updated = true;

            Connect.Connection.Close();
            return updated;
        }

        static internal bool insererLignes(String c, String tdc, String ndc)
        {
            bool updated = false;
            Donnees.Connect.Connection.Open();

            SqlCommand cmd = Donnees.Connect.Connection.CreateCommand();

            cmd.CommandText = "INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) " +
                    "VALUES ( @c , @tdc , @ndc )";
            cmd.Parameters.Add("@c", SqlDbType.Int);
            cmd.Parameters["@c"].Value = c;
            cmd.Parameters.Add("@tdc", SqlDbType.VarChar, 30);
            cmd.Parameters["@tdc"].Value = tdc;
            cmd.Parameters.Add("@ndc", SqlDbType.Int);
            cmd.Parameters["@ndc"].Value = ndc;

            cmd.ExecuteNonQuery();

            updated = true;

            Donnees.Connect.Connection.Close();
            return updated;
        }

        static internal bool modifierLignes(String c, String tdc, String ndc)
        {
            bool updated = false;
            Donnees.Connect.Connection.Open();

            SqlCommand cmd = Donnees.Connect.Connection.CreateCommand();
            cmd.CommandText = "UPDATE commandes SET NumDuComposant = " + ndc +
                    " WHERE (Commande = " + c + ") AND (TypeDeComposant = '" +
                    tdc + "') ";

            cmd.ExecuteNonQuery();

            updated = true;

            Donnees.Connect.Connection.Close();
            return updated;
        }

        static internal DataTable TypeDeComposantDisponiblePourUnClient(int n)
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter(
                    "SELECT DISTINCT Type_de_Composant FROM composants " +
                    "WHERE Type_de_Composant NOT IN " +
                    "(SELECT TypeDeComposant FROM commandes WHERE " +
                    " Commande = " + n + ") " +
                    "ORDER BY Type_de_Composant",
                    Connect.ConnectionString);

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Type_de_Composant", typeof(String));
            dt1.Rows.Add(new object[1] { "-- Sélectionnez --" });
            adapter1.Fill(dt1);
            return dt1;
        }

        static internal DataTable ComposantsDunTypeDeComposant(String tdc)
        {

            SqlDataAdapter adapter2 = new SqlDataAdapter(
               "SELECT DISTINCT Num_du_Composant, Composant FROM composants " +
               "WHERE Type_de_Composant =  @typeDeComposant  " +
               "ORDER BY Composant",
               Connect.ConnectionString);

            adapter2.SelectCommand.Parameters.Add("@typeDeComposant", SqlDbType.VarChar, 30);
            adapter2.SelectCommand.Parameters["@typeDeComposant"].Value = tdc;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Num_du_Composant", typeof(int));
            dt2.Columns.Add("Composant", typeof(String));
            dt2.Rows.Add(new object[2] { -1, "-- Sélectionnez --" });
            adapter2.Fill(dt2);
            return dt2;
        }
    }
}
