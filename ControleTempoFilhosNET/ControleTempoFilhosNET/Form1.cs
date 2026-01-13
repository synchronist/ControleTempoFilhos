using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ControleTempoFilhosNET
{
    public partial class Form1 : Form
    {
        private readonly Timer timerLeoJogo = new();
        private readonly Timer timerLeoAssistir = new();
        private readonly Timer timerBernardoJogo = new();

        private TimeSpan leoJogo;
        private TimeSpan leoAssistir;
        private TimeSpan bernardoJogo;

        private Label lblLeoJogo;
        private Label lblLeoAssistir;
        private Label lblBernardoJogo;

        public Form1()
        {
            InitializeComponent();

            leoJogo = TimeSpan.FromMinutes(90);
            leoAssistir = TimeSpan.FromMinutes(150);
            bernardoJogo = TimeSpan.FromMinutes(150);

            Text = "Controle de Tempo dos Filhos";
            Size = new Size(640, 520);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(18, 18, 18);
            Font = new Font("Segoe UI", 10);

            CriarLayout();
            ConfigurarTimers();
        }

        private void CriarLayout()
        {
            lblLeoJogo = CriarBloco(
                "🎮 Leonardo — Jogo",
                leoJogo,
                Color.FromArgb(0, 120, 215),
                20,
                () => timerLeoJogo.Start(),
                () => timerLeoJogo.Stop(),
                () => Resetar(ref leoJogo, TimeSpan.FromMinutes(90), lblLeoJogo)
            );

            lblLeoAssistir = CriarBloco(
                "📺 Leonardo — Assistir",
                leoAssistir,
                Color.FromArgb(170, 90, 255),
                180,
                () => timerLeoAssistir.Start(),
                () => timerLeoAssistir.Stop(),
                () => Resetar(ref leoAssistir, TimeSpan.FromMinutes(150), lblLeoAssistir)
            );

            lblBernardoJogo = CriarBloco(
                "🎮 Bernardo — Jogo",
                bernardoJogo,
                Color.FromArgb(0, 190, 130),
                340,
                () => timerBernardoJogo.Start(),
                () => timerBernardoJogo.Stop(),
                () => Resetar(ref bernardoJogo, TimeSpan.FromMinutes(150), lblBernardoJogo)
            );
        }

        private Label CriarBloco(
            string titulo,
            TimeSpan tempoInicial,
            Color cor,
            int top,
            Action start,
            Action pause,
            Action reset)
        {
            var panel = new Panel
            {
                Size = new Size(580, 140),
                Location = new Point(20, top),
                BackColor = Color.FromArgb(28, 28, 28)
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                ForeColor = cor,
                Font = new Font("Segoe UI Semibold", 13),
                Location = new Point(15, 10),
                AutoSize = true
            };

            var lblTempo = new Label
            {
                Text = tempoInicial.ToString(@"hh\:mm\:ss"),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                Location = new Point(15, 45),
                AutoSize = true
            };

            var btnStart = CriarBotao("▶ Iniciar", cor, 360, 20, start);
            var btnPause = CriarBotao("⏸ Pausar", Color.Gray, 460, 20, pause);
            var btnReset = CriarBotao("⏹ Resetar", Color.DarkRed, 360, 70, reset);

            panel.Controls.AddRange(new Control[]
            {
                lblTitulo, lblTempo, btnStart, btnPause, btnReset
            });

            Controls.Add(panel);
            return lblTempo;
        }

        private Button CriarBotao(string texto, Color cor, int x, int y, Action acao)
        {
            var btn = new Button
            {
                Text = texto,
                BackColor = cor,
                ForeColor = Color.White,
                Location = new Point(x, y),
                Size = new Size(95, 35),
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => acao();
            return btn;
        }

        private void ConfigurarTimers()
        {
            timerLeoJogo.Interval = 1000;
            timerLeoAssistir.Interval = 1000;
            timerBernardoJogo.Interval = 1000;

            timerLeoJogo.Tick += (s, e) => Atualizar(ref leoJogo, lblLeoJogo, timerLeoJogo);
            timerLeoAssistir.Tick += (s, e) => Atualizar(ref leoAssistir, lblLeoAssistir, timerLeoAssistir);
            timerBernardoJogo.Tick += (s, e) => Atualizar(ref bernardoJogo, lblBernardoJogo, timerBernardoJogo);
        }

        private void Atualizar(ref TimeSpan tempo, Label label, Timer timer)
        {
            if (tempo.TotalSeconds <= 0)
            {
                timer.Stop();
                SystemSounds.Exclamation.Play();
                MessageBox.Show("⏰ Tempo encerrado!", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tempo = tempo.Subtract(TimeSpan.FromSeconds(1));
            label.Text = tempo.ToString(@"hh\:mm\:ss");
        }

        private void Resetar(ref TimeSpan atual, TimeSpan original, Label label)
        {
            atual = original;
            label.Text = atual.ToString(@"hh\:mm\:ss");
        }
    }
}
