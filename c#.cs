using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace ucakbileti

{
    public partial class Form1 : Form
    {
        public Form1()
        {
        
        }

        private void InitializeComponent()
        {
         
ShowList();
        }

        List<müsteri> Müsteri = new List<müsteri>()
        {
            new müsteri()
            {
                FirstName = "veysel",
                LastName ="kor",
                email = "korveysel@mail.com",
                Phone = "0535 555 55 55",

            },
            new müsteri()
            {
                FirstName = "mustafa",
                LastName ="derman",
                email = "mustafaderman22@mail.com",
                Phone = "0544 444 44 44",
            }
        };

public void ShowList()
{
            listView4.Items.Clear();
    foreach (müsteri Müsteri in Müsteri)
    {
        AddmüsteriToListView(Müsteri);
    }
}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Nesne başlatmayı kolaylaştır", Justification = "< bekleyen >")]
        public void AddmüsteriToListView(müsteri Müsteri)
{
    ListViewItem item = new ListViewItem(new string[]
        {
                    Müsteri.FirstName,
                    Müsteri.LastName,
                    Müsteri.Phone,
                    Müsteri.email(),
        });

    item.Tag = Müsteri;
    listView4.Items.Add(item);
}

void EditmüsteriOnListView(ListViewItem pItem, müsteri Müsteri)
{
    pItem.SubItems[0].Text = Müsteri.FirstName;
    pItem.SubItems[1].Text = Müsteri.LastName;
    pItem.SubItems[2].Text = Müsteri.Phone;
    pItem.SubItems[3].Text = Müsteri.Email;
    ;

    pItem.Tag = Müsteri;
}

private void AddCommand(object sender, EventArgs e)
{
    Frmmüsteri frm = new Frmmüsteri()
    {
        Text = "Kişi Ekle",
        StartPosition = FormStartPosition.CenterParent,
        Müsteri = new müsteri()
    };

    if (frm.ShowDialog() == DialogResult.OK)
    {
        Müsteri.Add(frm.Müsteri);
        AddmüsteriToListView(frm.Müsteri);
    }
}

private void EditCommand(object sender, EventArgs e)
{
    if (listView1.SelectedItems.Count == 0)
        return;

    ListViewItem pItem = listView1.SelectedItems[0];
    müsteri secili = pItem.Tag as müsteri;

    Frmmüsteri frm = new Frmmüsteri()
    {
        Text = "Kişi Düzenle",
        StartPosition = FormStartPosition.CenterParent,
        Müsteri = Clone(secili),
    };

    if (frm.ShowDialog() == DialogResult.OK)
    {
        secili = frm.Müsteri;
        EditmüsteriOnListView(pItem, secili);
    }
}

müsteri Clone(müsteri Müsteri)
{
    return new müsteri()
    {
        id = Müsteri.ID,
        FirstName = Müsteri.FirstName,
        LastName = Müsteri.LastName,
        Phone = Müsteri.Phone,
        Email = Müsteri.Email,

    };
}

private void DeleteCommand(object sender, EventArgs e)
        {
            object listView4 = null;
            if (listView2.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem pItem = listView2.SelectedItems[0];
            müsteri secili = pItem.Tag as müsteri;

            var sonuc = MessageBox.Show($"Seçili kişi silinsin mi?\n\n{secili.FirstName} {secili.LastName}",
                 "Silmeyi Onayla",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Müsteri.Remove(secili);
                object listView4 = null;
                listView4.Items.Remove(pItem);
            }
        }

        private void SaveCommand(object sender, EventArgs e)
{
    SaveFileDialog sf = new SaveFileDialog()
    {
        Filter = "Json Formatı|*.json|Xml Formatı|*.xml",
    };

    if (sf.ShowDialog() == DialogResult.OK)
    {
        if (sf.FileName.EndsWith("json"))
        {
            string data = JsonSerializer.Serialize(Müsteri);
            File.WriteAllText(sf.FileName, data);
        }
        else if (sf.FileName.EndsWith("xml"))
        {
            StreamWriter sw = new StreamWriter(sf.FileName);
            XmlSerializer serializer = new XmlSerializer(typeof(List<müsteri>));
            serializer.Serialize(sw, Müsteri);
            sw.Close();
        }
    }
}

private void LoadCommand(object sender, EventArgs e)
{
    OpenFileDialog of = new OpenFileDialog()
    {
        Filter = "Json, Xml Formatları|*.json;*.xml",
    };

    if (of.ShowDialog() == DialogResult.OK)
    {
        if (of.FileName.ToLower().EndsWith("json"))
        {
            string jsondata = File.ReadAllText(of.FileName);
                    Müsteri = JsonSerializer.Deserialize<List<müsteri>>(jsondata);
        }
        else if (of.FileName.ToLower().EndsWith("xml"))
        {
            StreamReader sr = new StreamReader(of.FileName);
            XmlSerializer serializer = new XmlSerializer(typeof(List<müsteri>));
            Müsteri = (List<müsteri>)serializer.Deserialize(sr);
            sr.Close();
        }

        ShowList();
    }
}

string temp = Path.Combine(Application.CommonAppDataPath, "data");
        private object JsonSerializer;

        protected override void OnClosing(CancelEventArgs e, void _)
{
    string data = JsonSerializer.Serialize(Müsteri);
    File.WriteAllText(temp, data);
            _ = base.OnClosing(e, _);
        }

private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
{
    new AboutBox1().ShowDialog();
}



[Serializable]
public class müsteri
{
    public string id;

    [Browsable(false)]
    public string ID
    {
        get
        {
            if (id == null)
                id = Guid.NewGuid().ToString();
            return id;
        }
        set { id = value; }
    }

    [Category("Bilgiler"), DisplayName("Adı")]
    public string FirstName { get; set; }

    [Category("Bilgiler"), DisplayName("Soyadı")]
    public string LastName { get; set; }


    [Category("İletişim"), DisplayName("e-Mail")]
    public string Email { get; set; }
            public string email { get; internal set; }
            [Category("İletişim"), DisplayName("Telefon")]
    public string Phone { get; set; }

           


        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

        }

       