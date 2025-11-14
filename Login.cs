using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace UNIOZDESKTOP
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

            // INICIALIZAÇÃO: Garante que a senha apareça como "•"
            textSenha.UseSystemPasswordChar = true;
        }

        // -----------------------------------------------------------------
        // FUNÇÃO PRINCIPAL: LOGIN
        // -----------------------------------------------------------------
        private void labelLogin_Click(object sender, EventArgs e)
        {
            // 1. VALIDAÇÃO: Verifica se os campos estão preenchidos.
            if (string.IsNullOrWhiteSpace(textRA.Text) || string.IsNullOrWhiteSpace(textSenha.Text))
            {
                MessageBox.Show("Por favor, preencha o RA e a Senha.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Para a execução aqui
            }

            // 2. CONEXÃO: Prepara a conexão com o banco (o 'using' cuida de fechar)
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 3. COMANDO: Define qual Stored Procedure usar (sp_LoginUsuario)
                    using (SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adiciona os valores dos campos de texto como parâmetros
                        cmd.Parameters.AddWithValue("@RA", textRA.Text);
                        cmd.Parameters.AddWithValue("@Senha", textSenha.Text);

                        // Executa o comando e lê o retorno
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // 4. RESULTADO: Verifica se o banco encontrou o usuário
                            if (reader.HasRows)
                            {
                                // SUCESSO: Usuário encontrado
                                reader.Read(); // Lê os dados do usuário

                                // Pega o ID e o Nome que vieram do banco
                                int usuarioID = reader.GetInt32(0);
                                string nomeUsuario = reader.GetString(2);

                                // 5. NAVEGAÇÃO: Esconde a tela de login e abre a Tela Inicial
                                this.Hide();
                                TelaInicial telaInicial = new TelaInicial(usuarioID, nomeUsuario);
                                telaInicial.ShowDialog(); // ShowDialog "pausa" esta tela

                                // Quando a TelaInicial fechar, o programa fecha
                                this.Close();
                            }
                            else
                            {
                                // FALHA: Usuário ou senha inválidos
                                MessageBox.Show("RA ou Senha inválidos. Tente novamente.", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ERRO DE CONEXÃO: (Ex: Banco offline)
                    MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -----------------------------------------------------------------
        // FUNÇÃO SECUNDÁRIA: RECUPERAR SENHA
        // -----------------------------------------------------------------
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // FLUXO DE RECUPERAÇÃO DE SENHA:

            // 1. Abre a tela de "RecuperarSenha"
            RecuperarSenha telaRecuperar = new RecuperarSenha();

            // 2. Esconde o Login (temporariamente)
            this.Hide();

            // 3. Mostra a tela de recuperação
            telaRecuperar.ShowDialog();

            // 4. Quando o usuário fechar a tela de recuperação, mostra o Login de novo
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // -----------------------------------------------------------------
        // FUNÇÃO DE USABILIDADE (UX): LOGIN COM "ENTER"
        // -----------------------------------------------------------------
        private void textSenha_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                // Impede o "bip" sonoro do Windows
                e.SuppressKeyPress = true;

                // REUTILIZA A FUNÇÃO DE LOGIN:
                // Em vez de copiar o código, ele "aperta" o botão de login para nós.
                labelLogin_Click(sender, e);
            }
        }

        private void roundedPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void picVerSenha_Click(object sender, EventArgs e)
        {

        }

        private void textRA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}