using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CoucheAffaires
{
    class Commandes
    {
        static internal DataTable TypeDeComposantDisponiblePourUnClient(int n)
        {
            // Règle d'affaire : le premier composant d'une commande doit être le plât principal.

            // 1. Récuperez tous les types de composants disponible pour la commande "n". 
            // C'est-à-dire, les types de composants qui ne sont pas encore commandés dans la commande "n".
            DataTable dt = Donnees.Commandes.TypeDeComposantDisponiblePourUnClient(n);

            // Vérifiez si le type de composant 'plât principal' n'est pas encore commandé 
            DataRow[] temp = dt.Select("Type_de_Composant='plat principal'");
            DataTable resultat;
            if (temp.Length > 0)    // si le plât principal n'est pas encore commandé, faites-le la seule option.  
            {
                resultat = new DataTable();
                resultat.Columns.Add("Type_de_Composant", typeof(String));
                resultat.Rows.Add(new object[1] { "-- Sélectionez --" });
                resultat.Rows.Add(new object[1] { "plat principal" });
            }
            else if (temp.Length == 0)             // sinon laissez passer tous les options disponibles.
            {
                DataRow[] tempBoisson = dt.Select("Type_de_Composant='boisson'");
                if (tempBoisson.Length > 0)    // si le plât principal n'est pas encore commandé, faites-le la seule option.  
                {
                    resultat = new DataTable();
                    resultat.Columns.Add("Type_de_Composant", typeof(String));
                    resultat.Rows.Add(new object[1] { "-- Sélectionez --" });
                    resultat.Rows.Add(new object[1] { "boisson" });
                }
                else
                {
                    resultat = dt;
                }
            }
            else
            {
                resultat = dt;
            }
            return resultat;
        }
    }
}
