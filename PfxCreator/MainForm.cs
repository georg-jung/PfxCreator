using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace PfxCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            Text = $"{Text} {fileVersion}";
        }

        private T ReadPem<T>(string pem)
        {
            using (var sr = new StringReader(pem))
            {
                var pemReader = new PemReader(sr);
                return (T)pemReader.ReadObject();
            }
        }

        private X509Certificate ReadCertificate(string certPem)
        {
            return ReadPem<X509Certificate>(certPem);
        }

        private AsymmetricKeyParameter ReadPrivateKey(string keyPem)
        {
            return ReadPem<AsymmetricKeyParameter>(keyPem);
        }

        private void WritePfx(string certPem, string keyPem, string password, string filePath)
        {
            var cert = ReadCertificate(certPem);
            var certEntry = new X509CertificateEntry(cert);
            var chain = new X509CertificateEntry[] { certEntry };

            var privKey = ReadPrivateKey(keyPem);

            var store = new Pkcs12StoreBuilder().Build();
            store.SetKeyEntry("", new AsymmetricKeyEntry(privKey), chain);

            using (var p12file = File.Create(filePath))
            {
                store.Save(p12file, password.ToCharArray(), new SecureRandom());
            }
        }

        private void savePfxButton_Click(object sender, EventArgs e)
        {
            string fileName;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PKCS #12 files (*.pfx)|*.pfx|PKCS #12 files (*.p12)|*.p12";
                if (sfd.ShowDialog() == DialogResult.OK)
                    fileName = sfd.FileName;
                else
                    return;
            }

            try
            {
                WritePfx(certTextBox.Text, privateKeyTextBox.Text, pfxPasswordTextBox.Text, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while exporting your certificate:\n\n{ex}",
                    "Error while exporting certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void topmostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = topmostCheckBox.Checked;
        }
    }
}
