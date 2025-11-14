using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;


namespace UNIOZDESKTOP
{
    public partial class TelaInicial : Form
    {
        
        private FormChat? chatWindow = null; // Armazena a janela de chat 
        private System.Windows.Forms.Timer highlightTimer = null!; // Timer para o efeito de "piscar" o grid
        private Color originalCellColor; // Salva a cor original do grid para restaurar depois

        public TelaInicial()
        {
            InitializeComponent();
        }

        // -----------------------------------------------------------------
        // LÓGICA DE POSICIONAMENTO DO CHAT
        // -----------------------------------------------------------------

        /// <summary>
        /// Calcula onde a janela de chat deve aparecer (canto inferior direito da tela principal)
        /// </summary>
        private void PositionChatWindow()
        {
            if (chatWindow == null || chatWindow.IsDisposed)
            {
                return;
            }

            int margin = 10; // Margem da borda

            // Pega a área de trabalho da tela (evita que a janela saia dos limites)
            Rectangle screenArea = Screen.GetWorkingArea(this);

            // Calcula a posição X desejada (canto direito da tela principal)
            int desiredX = this.Bounds.Right - chatWindow.Width - margin;
            // Calcula a posição Y desejada (canto inferior da tela principal)
            int desiredY = this.Bounds.Bottom - chatWindow.Height - margin;

            // Limita o posicionamento para garantir que o chat fique dentro da tela
            int minX = screenArea.Left + margin;
            int maxX = screenArea.Right - chatWindow.Width - margin;
            int finalX = Math.Max(minX, Math.Min(desiredX, maxX)); // Garante X dentro dos limites

            int minY = screenArea.Top + margin;
            int maxY = screenArea.Bottom - chatWindow.Height - margin;
            int finalY = Math.Max(minY, Math.Min(desiredY, maxY)); // Garante Y dentro dos limites

            // Aplica a posição calculada à janela de chat
            chatWindow.Location = new Point(finalX, finalY);
        }

        /// <summary>
        /// Chamado quando a tela principal é MOVIDA ou REDIMENSIONADA.
        /// </summary>
        private void TelaInicial_MoveOrResize(object? sender, EventArgs e)
        {
            if (chatWindow == null || chatWindow.IsDisposed)
            {
                return;
            }

            // Se a tela principal for MINIMIZADA, esconde o chat também
            if (this.WindowState == FormWindowState.Minimized)
            {
                chatWindow.Hide();
            }
            else
            {
                // Se voltar ao normal, mostra o chat e recalcula sua posição
                chatWindow.Show();
                PositionChatWindow();
            }

        }

        // -----------------------------------------------------------------
        // INICIALIZAÇÃO E CARGA DE DADOS
        // -----------------------------------------------------------------

        // Variáveis para guardar os dados do usuário que logou
        private int _usuarioID;
        private string _nomeUsuario = "";

        /// <summary>
        /// Construtor que recebe os dados da tela de Login.
        /// </summary>
        public TelaInicial(int usuarioID, string nomeUsuario)
        {
            InitializeComponent();

            // Armazena os dados do usuário logado nas variáveis globais
            _usuarioID = usuarioID;
            _nomeUsuario = nomeUsuario;

            // "Assina" os eventos: diz ao C# para chamar 'TelaInicial_MoveOrResize'
            // sempre que a tela for movida ou redimensionada.
            this.Move += TelaInicial_MoveOrResize;
            this.Resize += TelaInicial_MoveOrResize;

            // Chama o método que prepara o Timer (do efeito de "piscar")
            ConfigurarTimer();
        }

        /// <summary>
        /// Evento chamado QUANDO A TELA TERMINA DE CARREGAR.
        /// </summary>
        private void TelaInicial_Load(object sender, EventArgs e)
        {
            // Coloca o nome do usuário no Label de boas-vindas
            linkLabel3.Text = _nomeUsuario;

            // CHAMA A FUNÇÃO PRINCIPAL: Carrega os dados do banco no grid
            CarregarChamados();
        }

        /// <summary>
        /// MÉTODO PRINCIPAL: Busca os chamados do usuário no banco.
        /// </summary>
        private void CarregarChamados()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=HelpDeskDB;Integrated Security=True;TrustServerCertificate=True;";
            DataTable dataTable = new DataTable(); // Tabela em memória para receber os dados

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 1. COMANDO: Chama a Stored Procedure "sp_ListarChamados"
                using (SqlCommand command = new SqlCommand("sp_ListarChamados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Passa o ID do usuário como parâmetro (para o banco saber de quem são os chamados)
                    command.Parameters.AddWithValue("@UsuarioID", _usuarioID);

                    try
                    {
                        connection.Open();
                        // 2. EXECUÇÃO: O Adapter preenche o DataTable (nossa tabela em memória)
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        // 3. RESULTADO: Define o DataGridView para MOSTRAR os dados do DataTable
                        dataGridView1.DataSource = dataTable;

                        // 4. ESTILIZAÇÃO: Chama os métodos para deixar o grid orgazinado
                        FormatarGrid();
                        AplicarEstilosCondicionais();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar chamados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // -----------------------------------------------------------------
        // FORMATAÇÃO E ESTILO DO GRID
        // -----------------------------------------------------------------

        /// <summary>
        /// Aplica a formatação visual BÁSICA do grid (cores, fontes, bordas).
        /// </summary>
        private void FormatarGrid()
        {
            // --- Configuração Básica ---
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.FromArgb(250, 250, 250);
         

            // --- Estilo do Cabeçalho ---
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;
            

            // --- Estilo das Linhas ---
            dataGridView1.DefaultCellStyle.Font = new Font("Poppins", 10);
            dataGridView1.RowTemplate.Height = 60; // Altura da linha
       

            // --- Nome dos Cabeçalhos (Tradução) ---
            if (dataGridView1.Columns["NumeroChamado"] != null)
                dataGridView1.Columns["NumeroChamado"].HeaderText = "Número do Chamado";
            if (dataGridView1.Columns["Assunto"] != null)
                dataGridView1.Columns["Assunto"].HeaderText = "Assunto";
            if (dataGridView1.Columns["DataCriacao"] != null)
                dataGridView1.Columns["DataCriacao"].HeaderText = "Data de criação";
            if (dataGridView1.Columns["UltimaAtualizacao"] != null)
                dataGridView1.Columns["UltimaAtualizacao"].HeaderText = "Ultima Atualização";


            // Oculta a coluna "Descricao" (usamos ela internamente, mas não mostramos no grid)
            if (dataGridView1.Columns["Descricao"] != null)
            {
                dataGridView1.Columns["Descricao"].Visible = false;
            }

            // Faz as colunas se ajustarem para preencher o grid
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Salva a cor original (para o efeito de "piscar")
            originalCellColor = dataGridView1.DefaultCellStyle.BackColor;
        }

        /// <summary>
        /// Aplica estilos CONDICIONAIS (Ex: Status "Resolvido" fica Verde)
        /// </summary>
        private void AplicarEstilosCondicionais()
        {
            // --- Define os Estilos ---
            // Estilo para status "Resolvido" (Verde, Sublinhado, Centralizado)
            DataGridViewCellStyle estiloResolvido = new DataGridViewCellStyle();
            estiloResolvido.ForeColor = Color.FromArgb(40, 167, 69); // Verde
            estiloResolvido.Font = new Font("Poppins", 10, FontStyle.Underline);
            estiloResolvido.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Estilo para status "Aberto" (Amarelo, Sublinhado, Centralizado)
            DataGridViewCellStyle estiloAberto = new DataGridViewCellStyle();
            estiloAberto.ForeColor = Color.Goldenrod; // Amarelo
            estiloAberto.Font = new Font("Poppins", 10, FontStyle.Underline);
            estiloAberto.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Estilo padrão (Centralizado)
            DataGridViewCellStyle estiloCentral = new DataGridViewCellStyle();
            estiloCentral.Alignment = DataGridViewContentAlignment.MiddleCenter;
            estiloCentral.ForeColor = Color.FromArgb(102, 102, 102);

            int alturaDesejada = 60;
            dataGridView1.RowTemplate.Height = alturaDesejada;

            try
            {
                // --- Aplica Estilos Fixos ---
                // Centraliza colunas específicas
                dataGridView1.Columns["Assunto"].DefaultCellStyle = estiloCentral;
                dataGridView1.Columns["NumeroChamado"].DefaultCellStyle = estiloCentral;
               

                // --- Aplica Estilos Condicionais (Loop) ---
                // Passa por CADA LINHA do grid
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = alturaDesejada;
                    if (row.IsNewRow) continue; // Ignora a linha nova (em branco)

                    // Pega a célula "Status" da linha atual
                    DataGridViewCell statusCell = row.Cells["Status"];

                    if (statusCell.Value == null || statusCell.Value == DBNull.Value)
                    {
                        continue; // Pula se a célula estiver vazia
                    }
                    string status = statusCell.Value.ToString() ?? "";

                    // VERIFICA O VALOR e aplica o estilo correspondente
                    if (status == "Resolvido")
                    {
                        statusCell.Style = estiloResolvido;
                    }
                    else if (status == "Aberto")
                    {
                        statusCell.Style = estiloAberto;
                    }
                    else
                    {
                        // Se não for nenhum dos dois, aplica o estilo centralizado padrão
                        statusCell.Style = estiloCentral;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao aplicar estilo condicional: " + ex.Message);
            }
        }

        // Método alternativo para carregar o grid (usa uma query SQL direta)
        private void LoadChamadosGrid()
        {
            int idUsuario = this._usuarioID;
            string connectionString = "Data Source=localhost;Initial Catalog=HelpDeskDB;Integrated Security=True;TrustServerCertificate=True;";

            // Query SQL "pura" (diferente da Stored Procedure)
            string query = @"
        SELECT 
            NumeroChamado, 
            Assunto, 
            Status, 
            DataCriacao, 
            UltimaAtualizacao,
            Descricao 
        FROM dbo.Chamado 
        WHERE UsuarioID = @IDUsuario 
        ORDER BY DataCriacao DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDUsuario", idUsuario);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;

                        // ... (Formatação específica deste método)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar histórico de chamados: " + ex.Message);
            }
        }

        // -----------------------------------------------------------------
        // EVENTOS DE CLIQUE E AÇÕES
        // -----------------------------------------------------------------

        /// <summary>
        /// Evento que é DISPARADO PELO FORMULÁRIO DE CHAT.
        /// </summary>
        private void ChatWindow_ChamadoCriado(object? sender, EventArgs e)
        {
            // Quando o chat "avisa" que um chamado foi criado,
            // esta tela simplesmente RECARREGA o grid para mostrar o novo item.
            CarregarChamados();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        /// <summary>
        /// Clique no Link "ABRIR CHAMADO"
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // REUTILIZA a lógica de clicar no ícone do chat.
            picChatIcon_Click(sender, e);
        }

        /// <summary>
        /// Evento chamado ao REDIMENSIONAR a tela (centraliza painéis)
        /// </summary>
        private void TelaInicial_Resize(object sender, EventArgs e)
        {
            // Centraliza o painel superior
            panel3.Left = (this.ClientSize.Width - panel3.Width) / 2;
            // Centraliza o painel principal (do grid)
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Evento de design (vazio)
        }

        /// <summary>
        /// Clique no Link "MEUS CHAMADOS" (Efeito de Piscar/Highlight)
        /// </summary>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1 != null && highlightTimer != null)
            {
                // 1. Muda a cor de fundo do grid para amarelo
                dataGridView1.DefaultCellStyle.BackColor = Color.LightYellow;
                // 2. Foca no grid (para o usuário ver)
                dataGridView1.Focus();
                // 3. INICIA o timer (que vai voltar a cor ao normal)
                highlightTimer.Start();
            }
        }

        /// <summary>
        /// Configura o Timer (chamado na inicialização da tela)
        /// </summary>
        private void ConfigurarTimer()
        {
            if (highlightTimer == null)
            {
                highlightTimer = new System.Windows.Forms.Timer();
                highlightTimer.Interval = 1000; // 1000 ms = 1 segundo

                // "Assina" o evento Tick: O que fazer quando o timer "disparar"
                highlightTimer.Tick += HighlightTimer_Tick;
            }
        }

        /// <summary>
        /// Evento que é chamado quando o Timer "dispara" (depois de 1 segundo)
        /// </summary>
        private void HighlightTimer_Tick(object? sender, EventArgs e)
        {
            if (dataGridView1 != null && highlightTimer != null)
            {
                // 1. DEVOLVE a cor original que salvamos
                dataGridView1.DefaultCellStyle.BackColor = originalCellColor;
                // 2. PARA o timer (para ele não disparar de novo)
                highlightTimer.Stop();
            }
        }

        /// <summary>
        /// Clique no ÍCONE DE CHAT (Ação principal de abrir chat)
        /// </summary>
        private void picChatIcon_Click(object? sender, EventArgs e)
        {
            // 1. VERIFICA SE O CHAT JÁ ESTÁ ABERTO
            if (chatWindow == null || chatWindow.IsDisposed)
            {
                // --- Se NÃO estiver aberto: ---

                // 2. CRIA uma nova instância do FormChat
                chatWindow = new FormChat(this._usuarioID); // Passa o ID do usuário para o chat

                // 3. "ASSINA" O EVENTO:
                // Diz ao chat: "Quando o evento 'ChamadoCriado' acontecer aí,
                // chame o meu método 'ChatWindow_ChamadoCriado' aqui."
                chatWindow.ChamadoCriado += ChatWindow_ChamadoCriado;

                chatWindow.StartPosition = FormStartPosition.Manual;

                // Limpa a variável 'chatWindow' quando o usuário fechar o chat
                chatWindow.FormClosed += (s, args) => { chatWindow = null; };

                // 4. POSICIONA E MOSTRA
                PositionChatWindow(); // Calcula onde ele deve aparecer
                chatWindow.Show(this); // 'Show(this)' vincula o chat a esta tela
            }
            else
            {
                // --- Se JÁ estiver aberto: ---
                // Apenas traz a janela do chat para a frente
                chatWindow.BringToFront();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Evento chamado quando o usuário CLICA NO CABEÇALHO para ordenar (Sort)
        /// </summary>
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            // Se o usuário ordenar, o grid perde a formatação condicional.
            // Então, APLICAMOS DE NOVO o estilo (cores Verde/Amarelo).
            AplicarEstilosCondicionais();
        }

        /// <summary>
        /// Evento de clique no botão de LOGOUT
        /// </summary>
        private void pbLogout_Click(object sender, EventArgs e)
        {
            // 1. Pergunta de confirmação
            var resposta = MessageBox.Show("Você tem certeza que deseja deslogar?\nVocê voltará para a tela de Login.",
                                          "Confirmar Logout",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            // 2. Verifica a resposta
            if (resposta == DialogResult.Yes)
            {
                // REINICIA a aplicação. Isso fecha TODAS as telas
                // e começa o programa do zero (voltando para o Login).
                Application.Restart();
            }
        }
    }
}