using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CografiBilgiSistemiProjesi;

namespace CografiBilgiSistemiProjesi
{
    public partial class Form1 : Form
    {
        GMapOverlay katman1;
        List<Arac> list;
       
        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            aracListesiniOlustur();

        }
        
        private void aracListesiniOlustur()
        {
            list = new List<Arac>();
            list.Add(new Arac("34AC01", "TIR", "Ankara", "Istanbul", new PointLatLng(40.05, 32.22)));
            list.Add(new Arac("06AC02", "Kamyon", "Izmir", "Istanbul", new PointLatLng(39.22, 27.67)));

            list.Add(new Arac("35AC03", "Hafif Ticari", "Ankara", "Istanbul", new PointLatLng(40.05, 30.24)));

            list.Add(new Arac("07AC04", "TIR", "Istanbul", "Ankara", new PointLatLng(40.30, 32.47)));

            list.Add(new Arac("34AC05", "Kamyon", "Ankara", "Izmir", new PointLatLng(38.75, 30.43)));


        }

        public void InitializeMap()
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = new GMap.NET.PointLatLng(36.0, 42.0);
            map.Zoom = 4;
            map.MinZoom = 3;
            map.MaxZoom = 25;
            katman1 = new GMapOverlay();
            map.Overlays.Add(katman1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEnlem.Text) || string.IsNullOrWhiteSpace(textBoxBoylam.Text))
            {
                MessageBox.Show("Lütfen enlem ve boylam değerlerini girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBoxEnlem.Text, out double enlem) || !double.TryParse(textBoxBoylam.Text, out double boylam))
            {
                MessageBox.Show("Geçerli bir sayı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            PointLatLng location1 = new PointLatLng(Convert.ToDouble(textBoxEnlem.Text) , Convert.ToDouble(textBoxBoylam.Text) );
          
            GMarkerGoogle marker = new GMarkerGoogle(location1, GMarkerGoogleType.blue_dot);
            marker.ToolTipText = "\nLokasyon\n Tir \n From Ankara \n To Istanbul";
            katman1.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.Tag = 101;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            map.Dispose();
            Application.Exit();         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointLatLng location2 = new PointLatLng(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            GMarkerGoogle marker2 = new GMarkerGoogle(location2, GMarkerGoogleType.red_dot);
            marker2.Tag = 102;
            katman1.Markers.Add (marker2);
        }

        private void map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //string markerId = Convert.ToString(item.Tag);
            //Console.WriteLine($"id si {markerId} olan event e kliklendi ");

            string secilenAracinPlakasi = Convert.ToString(item.Tag);
            foreach (Arac arac in list)
            {
                if(secilenAracinPlakasi == arac.Plaka)
                {
                    textBox3.Text = arac.Plaka;
                    textBox4.Text = arac.Tipi;
                    textBox5.Text = arac.From;
                    textBox6.Text = arac.To;
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Arac arac in list)
            {
                GMarkerGoogle markerTmp = new GMarkerGoogle(arac.Konum, GMarkerGoogleType.green_dot);
                markerTmp.Tag = arac.Plaka;
                markerTmp.ToolTipText = arac.ToString();
                katman1.Markers.Add(markerTmp);

            }
        }

      
    }
}
