namespace WinFormsApp1;

public partial class Form1 : Form
{
    List<Carte> cartes = new List<Carte>();
    List<PictureBox> pictureBoxes = new List<PictureBox>();

    Carte? carte1 = null;
    Carte? carte2 = null;
    PictureBox? pb1 = null;
    PictureBox? pb2 = null;

    int essais = 0;
    int secondes = 0;

    Random random = new Random();
    bool bloque = false;

    System.Windows.Forms.Timer chrono = new System.Windows.Forms.Timer();

    public Form1()
    {
        InitializeComponent();

        this.Text = "Memory SecurIT";

        chrono.Interval = 1000;
        chrono.Tick += Chrono_Tick;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DemarrerPartie();
    }

    private void btnQuitter_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnQuitter_Click_1(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Chrono_Tick(object? sender, EventArgs e)
    {
        secondes++;
        lblTemps.Text = "Temps : " + secondes + " s";
    }

    private void DemarrerPartie()
    {
        this.Controls.Clear();

        btnJouer.Enabled = false;

        essais = 0;
        secondes = 0;
        bloque = false;

        lblEssais.Text = "Essais : 0";
        lblTemps.Text = "Temps : 0 s";

        this.Controls.Add(btnJouer);
        this.Controls.Add(lblEssais);
        this.Controls.Add(lblTemps);
        this.Controls.Add(btnQuitter);

        chrono.Start();

        cartes.Clear();
        pictureBoxes.Clear();

        carte1 = null;
        carte2 = null;
        pb1 = null;
        pb2 = null;

        for (int i = 1; i <= 8; i++)
        {
            cartes.Add(new Carte(i));
            cartes.Add(new Carte(i));
        }

        cartes = cartes.OrderBy(c => random.Next()).ToList();

        int taille = 70;
        int espace = 10;
        int index = 0;

        for (int ligne = 0; ligne < 4; ligne++)
        {
            for (int colonne = 0; colonne < 4; colonne++)
            {
                PictureBox pb = new PictureBox();

                pb.Width = taille;
                pb.Height = taille;
                pb.Left = 30 + colonne * (taille + espace);
                pb.Top = 120 + ligne * (taille + espace);

                pb.BackColor = Color.DarkSlateBlue;
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                Carte carte = cartes[index];
                pb.Tag = carte;

                pb.Click += Carte_Click;

                this.Controls.Add(pb);
                pictureBoxes.Add(pb);

                index++;
            }
        }
    }

    private void Carte_Click(object? sender, EventArgs e)
    {
        if (bloque) return;

        PictureBox pb = (PictureBox)sender!;
        Carte carte = (Carte)pb.Tag!;

        if (carte.Etat != EtatCarte.Cachee) return;

        carte.Etat = EtatCarte.Revelee;
        pb.BackColor = Color.LightBlue;

        Label texte = new Label();
        texte.Text = carte.Id.ToString();
        texte.Font = new Font("Arial", 20, FontStyle.Bold);
        texte.TextAlign = ContentAlignment.MiddleCenter;
        texte.Dock = DockStyle.Fill;
        texte.BackColor = Color.LightBlue;

        pb.Controls.Add(texte);

        if (carte1 == null)
        {
            carte1 = carte;
            pb1 = pb;
        }
        else
        {
            carte2 = carte;
            pb2 = pb;
            essais++;
            lblEssais.Text = "Essais : " + essais;

            if (carte1.Id == carte2.Id)
            {
                carte1.Etat = EtatCarte.Trouvee;
                carte2.Etat = EtatCarte.Trouvee;

                pb1.BackColor = Color.Green;
                pb2.BackColor = Color.Green;

                carte1 = null;
                carte2 = null;
                pb1 = null;
                pb2 = null;

                VerifierVictoire();
            }
            else
            {
                bloque = true;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;

                timer.Tick += (s, ev) =>
                {
                    timer.Stop();

                    carte1!.Etat = EtatCarte.Cachee;
                    carte2!.Etat = EtatCarte.Cachee;

                    pb1!.Controls.Clear();
                    pb2!.Controls.Clear();

                    pb1.BackColor = Color.DarkSlateBlue;
                    pb2.BackColor = Color.DarkSlateBlue;

                    carte1 = null;
                    carte2 = null;
                    pb1 = null;
                    pb2 = null;

                    bloque = false;
                };

                timer.Start();
            }
        }
    }

    private void VerifierVictoire()
    {
        if (cartes.All(c => c.Etat == EtatCarte.Trouvee))
        {
            chrono.Stop();
            btnJouer.Enabled = true;

            MessageBox.Show("Victoire ! Tu as gagné en " + essais + " essais et " + secondes + " secondes.");
        }
    }
}