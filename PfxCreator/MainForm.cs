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

        /// <returns>True if a private key was written, false if just the certificate was written.</returns>
        private bool WritePfx(string certPem, string keyPem, string password, string filePath)
        {
            var cert = ReadCertificate(certPem);
            var certEntry = new X509CertificateEntry(cert);

            if (certEntry?.Certificate == null)
                throw new ArgumentException("The string given as a PEM representation of the certificate could not be read accordingly.", nameof(certPem));

            AsymmetricKeyParameter privKey = null;
            if (!string.IsNullOrEmpty(keyPem))
            {
                privKey = ReadPrivateKey(keyPem);
                if (privKey == null)
                    throw new ArgumentException("The string given as a PEM representation of the private key could not be read accordingly.", nameof(keyPem));
            }

            var store = new Pkcs12StoreBuilder().Build();
            if (privKey != null)
            {
                var chain = new X509CertificateEntry[] { certEntry };
                store.SetKeyEntry("", new AsymmetricKeyEntry(privKey), chain);
            }
            else
                store.SetCertificateEntry("", certEntry);

            using (var p12file = File.Create(filePath))
            {
                store.Save(p12file, password.ToCharArray(), new SecureRandom());
            }
            return privKey != null;
        }

        private void savePfxButton_Click(object sender, EventArgs e)
        {
            string fileName;
            var certPem = certTextBox.Text;
            var psw = pfxPasswordTextBox.Text;
            if (string.IsNullOrEmpty(certPem))
            {
                MessageBox.Show("You did not specify a certificate. To export a PFX file, at least the certificate is needed.",
                        "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(psw))
                if (MessageBox.Show("You did not specify a password. If you continue saving the PFX file, it will be " +
                    "saved encrypted but with an empty string as passphrase. Do you want to continue?",
                    "No password specified", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

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
                var keyWritten = WritePfx(certPem, privateKeyTextBox.Text, psw, fileName);
                if (!keyWritten)
                    MessageBox.Show("You did not specify a private key. The exported PFX file contains just the certificate.",
                        "PFX without private key", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
