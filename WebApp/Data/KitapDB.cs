using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public class KitapDB
    {
        private SqlConnection Conn;
        public KitapDB(string strConn)
        {
            Conn = new SqlConnection(strConn);
        }

        public void Ekle(Kitap kitap)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Kitap values(@KitapAd,@Fiyat)", Conn);

            cmd.Parameters.AddWithValue("@KitapAd", kitap.KitapAd);
            cmd.Parameters.AddWithValue("@Fiyat", kitap.Fiyat);

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        public List<Kitap> Liste()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("Select*From Kitap", Conn);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Kitap> kitaplar = new List<Kitap>();
            while (dr.Read())
            {
                Kitap kitap = new Kitap { KitapID = Convert.ToInt32(dr[0]), KitapAd = dr[1].ToString(), Fiyat = Convert.ToDecimal(dr[2]) };
                kitaplar.Add(kitap);
            }

            Conn.Close();

            return kitaplar;
        }
    }
}
