using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIOZDESKTOP
{
    /// <summary>
    /// Formulário que funciona como um Chatbot (Máquina de Estados)
    /// para auto-atendimento e criação de chamados.
    /// </summary>
    public partial class FormChat : Form
    {
        // --- Variáveis de Controle do Chat ---

        // A variável MAIS IMPORTANTE: controla em qual "passo" da conversa o chat está.
        // Ex: 0 = Menu, 1 = Opção 1, 900 = Pedir detalhes, etc.
        private int chatState = 0;

        // Variáveis para armazenar os dados do chamado
        private string tipoChamado = "";
        private string detalheChamado = "";
        private int idUsuarioLogado; // ID recebido da TelaInicial
        private string assuntoChamado = "";

        // Evento "Aviso": Usado para "avisar" a TelaInicial que um chamado foi criado
        // (para que ela possa recarregar o grid)
        public event EventHandler? ChamadoCriado;

        /// <summary>
        /// Construtor do FormChat
        /// </summary>
        /// <param name="idUsuario">Recebe o ID do usuário logado na TelaInicial</param>
        public FormChat(int idUsuario)
        {
            InitializeComponent();

            // Armazena o ID do usuário que está logado
            this.idUsuarioLogado = idUsuario;

            // Define o botão 'btnSend' como o botão padrão (para a tecla "Enter" funcionar)
            this.AcceptButton = btnSend;
        }


        /// <summary>
        /// Evento de clique no botão "Fechar"
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha este formulário de chat
        }

        /// <summary>
        /// Evento disparado quando o formulário de chat é efetivamente MOSTRADO
        /// </summary>
        private void FormChat_Shown(object? sender, EventArgs e)
        {
            // Inicia a conversa no estado 0 (Menu Principal)
            AtualizarEstadoChat(0);
        }

        // -----------------------------------------------------------------
        // MOTOR DO CHAT (LÓGICA DO BOT)
        // -----------------------------------------------------------------

        /// <summary>
        /// O "Cérebro" do Bot. Define o que o bot FALA em cada estado.
        /// </summary>
        /// <param name="estado">O novo estado da conversa (chatState)</param>
        private void AtualizarEstadoChat(int estado)
        {
            // 1. Atualiza o estado global
            chatState = estado;

            // 2. O Switch decide qual mensagem o bot deve enviar
            switch (estado)
            {
                case 0: // Estado 0: Menu Principal
                    AddMessage("Olá! Sou o assistente virtual da UNIOZ. Digite o número da opção desejada:", false);
                    string menu = "1. Como redefinir minha senha?\n" +
                                  "2. Onde encontro meu boleto?\n" +
                                  "3. Onde vejo minhas notas e faltas?\n" +
                                  "4. Como falar com o suporte técnico?\n" +
                                  "5. Como trancar meu curso?";
                    AddMessage(menu, false);
                    break;

                case 1: // Estado 1: Usuário escolheu "Redefinir Senha"
                    assuntoChamado = "Redefinir senha"; 
                    AddMessage("Para redefinir sua senha, acesse o portal do aluno e clique em 'Esqueci minha senha' na tela de login.", false);
                    AddMessage("Isso resolveu seu problema?\n1 - Sim\n2 - Não", false);
                    break;

                case 2: // Estado 2: Usuário escolheu "Boleto"
                    assuntoChamado = "Onde encontro meu boleto";
                    AddMessage("Seu boleto está disponível na sua Secretaria Virtual no menu 'Financeiro' > 'Meus Boletos'.", false);
                    AddMessage("Isso resolveu seu problema?\n1 - Sim\n2 - Não", false);
                    break;

                case 3: // Estado 3: Usuário escolheu "Notas e Faltas"
                    assuntoChamado = "Notas e Faltas";
                    AddMessage("Você pode consultar suas notas e faltas no menu 'Acadêmico' > 'Histórico/Notas'.", false);
                    AddMessage("Isso resolveu seu problema?\n1 - Sim\n2 - Não", false);
                    break;

                case 4: // Estado 4: Usuário escolheu "Suporte Técnico"
                    assuntoChamado = "Suporte Técnico";
                    AddMessage("Entendido. Para eu te encaminhar ao suporte por favor, descreva seu problema em detalhes:", false);
                    // O chat agora vai esperar o usuário digitar o problema (ver btnSend_Click)
                    break;

                case 5: // Estado 5: Usuário escolheu "Trancar Curso"
                    assuntoChamado = "Trancar meu curso";
                    AddMessage("Para trancar seu curso, você deve abrir um requerimento na Secretaria Virtual > 'Requerimentos'", false);
                    AddMessage("Isso resolveu seu problema?\n1 - Sim\n2 - Não", false);
                    break;

                // Escalonamento 
                case 900: // Estado 900: Usuário disse "Não" (Não resolveu)
                    tipoChamado = "Atendimento Humano";
                    AddMessage("Sinto muito que não tenha resolvido.", false);
                    AddMessage("Vou encaminhar seu caso para um atendente.", false);
                    AddMessage("Por favor, descreva seu problema em detalhes:", false);
                    // O chat agora vai esperar o usuário digitar o problema
                    break;

                // Final
                case 998: // Estado 998: Registrando chamado "Aberto"
                    AddMessage("Perfeito. Estou registrando seu chamado...", false);

                    // Altera o Status para aberto
                    // CHAMA O BANCO DE DADOS
                    bool sucessoAberto = SalvarChamado("Aberto");

                    if (sucessoAberto)
                    {
                        AddMessage("Pronto! Um atendente entrará em contato em breve.", false);
                    }
                    AddMessage("Digite 0 para voltar ao início.", false);
                    chatState = 0; // Reseta o chat para o menu
                    break;

                case 999: // Estado 999: Registrando chamado "Resolvido"
                    AddMessage("Que ótimo! Fico feliz em ter ajudado.", false);
                    AddMessage("Estou registrando esta interação para nosso histórico.", false);

                    // Status Resolvido
                    // CHAMA O BANCO DE DADOS
                    bool sucessoResolvido = SalvarChamado("Resolvido");

                    if (sucessoResolvido)
                    {
                        AddMessage("Registro salvo!", false);
                    }
                    AddMessage("Digite 0 para voltar ao início.", false);
                    chatState = 0; // Reseta o chat para o menu
                    break;
            }
        }


        // -----------------------------------------------------------------
        // LÓGICA DE INTERFACE (UI)
        // -----------------------------------------------------------------

        /// <summary>
        /// Adiciona uma "bolha" de mensagem no chat (cria controles dinamicamente)
        /// </summary>
        /// <param name="texto">O texto da mensagem</param>
        /// <param name="isUserMessage">True: balão azul (usuário), False: balão cinza (bot)</param>
        private void AddMessage(string texto, bool isUserMessage)
        {
            // Define a largura máxima do balão (75% da largura do painel)
            int maxWidth = (int)(panelMessages.ClientSize.Width * 0.75);
            if (maxWidth < 150) maxWidth = 150;

            // 1. Cria o Label (o balão de texto)
            Label lblMessage = new Label
            {
                Text = texto,
                Font = new Font("Poppins", 9),
                Padding = new Padding(10),
                Margin = new Padding(5),
                AutoSize = true, // Permite que o label cresça com o texto
                MaximumSize = new Size(maxWidth, 0) // ... mas não mais que a largura máxima
            };

            // Truque para o 'wrap' de texto funcionar:
            Size labelSize = lblMessage.GetPreferredSize(new Size(maxWidth, 0)); // Calcula o tamanho
            lblMessage.AutoSize = false; // Desliga o AutoSize
            lblMessage.Size = labelSize; // Define o tamanho manualmente

            // 2. Cria o Painel "Wrapper" (para alinhar o balão à esquerda ou direita)
            Panel wrapperPanel = new Panel
            {
                Width = panelMessages.ClientSize.Width - 10,
                Height = labelSize.Height + 10,
                BackColor = Color.Transparent
            };

            // 3. Define a Cor e Posição (Alinhamento)
            if (isUserMessage)
            {
                // Mensagem do Usuário (Azul, alinhado à Direita)
                lblMessage.BackColor = Color.LightSkyBlue;
                lblMessage.Location = new Point(wrapperPanel.Width - labelSize.Width - 5, 5); // Alinha à direita
            }
            else
            {
                // Mensagem do Bot (Cinza, alinhado à Esquerda)
                lblMessage.BackColor = Color.Gainsboro;
                lblMessage.Location = new Point(5, 5); // Alinha à esquerda
            }

            // 4. Adiciona o Label (balão) dentro do Painel (linha)
            wrapperPanel.Controls.Add(lblMessage);
            // 5. Adiciona o Painel (linha) dentro do 'panelMessages' (o chat todo)
            panelMessages.Controls.Add(wrapperPanel);

            // Rola o chat para baixo automaticamente
            panelMessages.ScrollControlIntoView(wrapperPanel);
        }

        // --- Código para mover o formulário sem borda ---
        // (Permite clicar e arrastar a janela)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FormChat_MouseDown(object sender, MouseEventArgs e)
        {
            // Permite arrastar o formulário
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // --- Fim do código para mover ---

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }


        // -----------------------------------------------------------------
        // MOTOR DO CHAT (LÓGICA DO USUÁRIO)
        // -----------------------------------------------------------------

        /// <summary>
        /// O "Cérebro" do Usuário. Decide o que fazer com a entrada do usuário
        /// baseado no estado atual (chatState).
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string userText = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userText)) return; // Ignora se o texto estiver vazio

            // 1. Adiciona a mensagem do usuário na tela
            AddMessage(userText, true);
            txtInput.Clear(); // Limpa a caixa de texto

            // Normaliza a entrada para facilitar as verificações (sim/não/0)
            string normalizedInput = userText.ToLower().Trim();

            // 2. O Switch decide o que fazer com a resposta, baseado no estado ATUAL
            switch (chatState)
            {
                case 0: // Estado 0: Estava no Menu Principal
                    if (int.TryParse(userText, out int opMenu)) 
                    {
                        if (opMenu >= 1 && opMenu <= 5)
                        {
                            // Usuário digitou 1, 2, 3, 4 ou 5
                            // Pula para o estado correspondente
                            AtualizarEstadoChat(opMenu);
                        }
                        // Retorna ao menu
                        else if (opMenu == 0)
                        {
                            // Se o usuário digitar 0 no menu, mostra o menu novamente
                            AtualizarEstadoChat(0);
                        }
                        else
                        {
                            AddMessage("Opção inválida. Por favor, digite um número de 1 a 5.", false);
                        }
                    }
                    else
                    {
                        AddMessage("Não entendi. Por favor, digite apenas o número da opção (1-5).", false);
                    }
                    break;

                // --- Estados de Confirmação (Esperando "Sim" ou "Não") ---
                case 1: // Veio de "Redefinir Senha"
                case 2: // Veio de "Boleto"
                case 3: // Veio de "Notas"
                case 5: // Veio de "Trancar Curso"

                    // (Feature 'sim/não') ***
                    if (normalizedInput == "1" || normalizedInput == "sim") // Sim, resolvido!
                    {
                        detalheChamado = "Resolvido pelo Chatbot (Auto-atendimento)";
                        // ATUALIZA O ESTADO: Pula para o estado 999 (Salvar como Resolvido)
                        AtualizarEstadoChat(999);
                    }
                    //(Feature 'sim/não') ***
                    else if (normalizedInput == "2" || normalizedInput == "não" || normalizedInput == "nao") // Não, preciso de ajuda
                    {
                        //Pula para o estado 900 (Escalonamento)
                        AtualizarEstadoChat(900);
                    }
                    
                    else if (normalizedInput == "0") // Usuário quer voltar ao menu
                    {
                        //Pula para o estado 0 (Menu Principal)
                        AtualizarEstadoChat(0);
                    }
                    else
                    {
                        AddMessage("Opção inválida. Digite 1 (Sim), 2 (Não) ou 0 (Menu).", false);
                    }
                    break;

                // --- Estados de Coleta de Texto (Esperando a descrição do problema) ---
                case 4:  // Veio de "Suporte Técnico"
                case 900: // Veio de "Escalação"

                   
                    // Salva a descrição que o usuário acabou de digitar
                    detalheChamado = userText;

                    // Pula para o estado 998 (Salvar como Aberto)
                    AtualizarEstadoChat(998);
                    break;

                // Se o usuário digitar "0" em qualquer outro estado (ex: após salvar)
                default:
                    if (normalizedInput == "0")
                    {
                        AtualizarEstadoChat(0); // Volta ao menu
                    }
                    else
                    {
                        AddMessage("Digite 0 para voltar ao menu principal.", false);
                    }
                    break;
            }
        }

        // -----------------------------------------------------------------
        // LÓGICA DE BANCO DE DADOS
        // -----------------------------------------------------------------

        /// <summary>
        /// Salva o chamado no banco de dados.
        /// </summary>
        /// <param name="statusFinal">O status do chamado ("Aberto" ou "Resolvido")</param>
        /// <returns>True se salvou com sucesso, False se deu erro.</returns>
        private bool SalvarChamado(string statusFinal)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=HelpDeskDB;Integrated Security=True;TrustServerCertificate=True;";

            // Garante que o tipo de chamado tenha um valor padrão
            if (string.IsNullOrEmpty(tipoChamado))
            {
                tipoChamado = "Atendimento Humano";
            }
            DateTime dataAtual = DateTime.Now;

            // Define um número de chamado temporário
            string tempNumeroChamado = "AGUARDANDO_ID";

            // Query 1: INSERE o chamado e retorna o ID (SCOPE_IDENTITY)
            string queryInsert = @"
        INSERT INTO dbo.Chamado 
            (Assunto, Descricao, Status, DataCriacao, UltimaAtualizacao, UsuarioID, NumeroChamado) 
        VALUES 
            (@Assunto, @Descricao, @Status, @DataCriacao, @UltimaAtualizacao, @IDUsuario, @NumeroChamadoTemp);
        SELECT SCOPE_IDENTITY();"; // Retorna o ID que acabou de ser criado

            // Query 2: ATUALIZA o chamado para ter um NumeroChamado legível
            string queryUpdate = @"
        UPDATE dbo.Chamado 
        SET NumeroChamado = @NumeroChamadoFinal 
        WHERE ChamadoID = @ChamadoID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    int novoChamadoID = 0;

                    // 1. EXECUTA A QUERY DE INSERT
                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@Assunto", assuntoChamado);
                        cmdInsert.Parameters.AddWithValue("@Descricao", detalheChamado);
                        cmdInsert.Parameters.AddWithValue("@Status", statusFinal);
                        cmdInsert.Parameters.AddWithValue("@DataCriacao", dataAtual);
                        cmdInsert.Parameters.AddWithValue("@UltimaAtualizacao", dataAtual);
                        cmdInsert.Parameters.AddWithValue("@IDUsuario", this.idUsuarioLogado);
                        cmdInsert.Parameters.AddWithValue("@NumeroChamadoTemp", tempNumeroChamado);

                        // ExecuteScalar é usado para pegar o "SELECT SCOPE_IDENTITY()"
                        object? result = cmdInsert.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            // Salva o ID do chamado que acabou de ser criado
                            novoChamadoID = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("Não foi possível obter o ID do novo chamado.");
                        }
                    }

                    // 2. EXECUTA A QUERY DE UPDATE
                    if (novoChamadoID > 0)
                    {
                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn))
                        {
                            // Define o NumeroChamado como o próprio ID (ex: Chamado "10")
                            cmdUpdate.Parameters.AddWithValue("@NumeroChamadoFinal", novoChamadoID.ToString());
                            cmdUpdate.Parameters.AddWithValue("@ChamadoID", novoChamadoID);
                            cmdUpdate.ExecuteNonQuery(); // Apenas executa, não retorna nada
                        }

                        // 3. AVISA O USUÁRIO E A TELA INICIAL
                        AddMessage($"Chamado Nº {novoChamadoID} registrado com sucesso!", false);

                        // DISPARA O EVENTO: "Avisa" a TelaInicial que um chamado foi criado
                        ChamadoCriado?.Invoke(this, EventArgs.Empty);

                        return true; // Sucesso
                    }
                    else
                    {
                        return false; // Falha
                    }
                }
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                AddMessage("Ops! Tive um problema para registrar seu chamado no banco.", false);
                AddMessage($"Erro: {ex.Message}", false);
                return false; // Falha
            }
        }

        private void panelMessages_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}