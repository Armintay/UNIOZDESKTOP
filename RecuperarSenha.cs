using Microsoft.Data.SqlClient;
using System;
// ... (outros 'usings' do .NET)
using System.Windows.Forms;
// ...

namespace UNIOZDESKTOP
{
    /// <summary>
    /// Formulário para o usuário validar sua identidade antes de alterar a senha.
    /// </summary>
    public partial class RecuperarSenha : Form
    {
        public RecuperarSenha()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // -----------------------------------------------------------------
        // FUNÇÃO PRINCIPAL DE VALIDAÇÃO (BANCO DE DADOS)
        // -----------------------------------------------------------------
        /// <summary>
        /// Verifica no banco de dados se TODOS os dados fornecidos correspondem a um único usuário.
        /// </summary>
        /// <returns>True se o usuário for encontrado, False se não.</returns>
        private bool VerificarDadosNoBanco(String ra, String email, String telefone, String token)
        {
            try
            {
                // 1. CONEXÃO: Abre a conexão com o banco.
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();

                    // 2. QUERY SQL: A query exige que TODAS as condições sejam verdadeiras.
                    // O usuário deve acertar o RA, Email, Telefone E o Token recebido.
                    string sql = "SELECT 1 FROM Usuario " +
                                 "WHERE RA = @RA AND Email = @Email AND Telefone = @Telefone AND Token = @Token";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 3. PARÂMETROS: Adiciona os dados do formulário de forma segura
                        cmd.Parameters.AddWithValue("@RA", ra);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@Token", token);

                        // 4. EXECUÇÃO: ExecuteScalar é usado aqui.
                        // Ele retorna a primeira coluna da primeira linha (no caso, o "1" da query)
                        // ou 'null' se a query não encontrar NENHUMA correspondência.
                        object resultado = cmd.ExecuteScalar();

                        // 5. RESULTADO: Se 'resultado' não for nulo, significa que encontrou o "1".
                        // Isso confirma que o usuário existe e todos os dados estão corretos.
                        return (resultado != null);
                    }
                }
            }
            catch (Exception e)
            {
                // Em caso de erro de conexão (ex: banco offline), avisa o usuário.
                MessageBox.Show("Erro ao verificar os dados: " + e.Message, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Retorna 'false' se houver erro
            }
        }

        // -----------------------------------------------------------------
        // EVENTO PRINCIPAL (BOTÃO CONFIRMAR)
        // -----------------------------------------------------------------
        /// <summary>
        /// Evento de clique do botão "Confirmar Dados".
        /// </summary>
        private void Confirm_dados_Click(object sender, EventArgs e)
        {
            // 1. COLETA DE DADOS: Pega os valores dos campos de texto.
            string ra = txtRA.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            string token = Validacao_token.Text;

            // 2. VALIDAÇÃO DE CAMPOS: Verifica se algum campo está vazio.
            if (string.IsNullOrWhiteSpace(ra) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Para a execução aqui
            }

            // 3. VERIFICAÇÃO NO BANCO: Chama a função anterior passando os dados.
            bool dadosValidos = VerificarDadosNoBanco(ra, email, telefone, token);

            // 4. TOMADA DE DECISÃO:
            if (dadosValidos)
            {
                // SUCESSO: Os dados bateram.
                MessageBox.Show("Dados validados com sucesso! Você será redirecionado para criar uma nova senha.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. NAVEGAÇÃO:
                this.Hide(); // Esconde a tela atual
                AlterarSenha frmAlterar = new AlterarSenha(ra); // Cria a próxima tela (AlterarSenha)
                frmAlterar.ShowDialog(); // Mostra a tela de alterar senha
                this.Close(); // Fecha esta tela (RecuperarSenha)
            }
            else
            {
                // FALHA: Os dados não bateram (ou o token estava errado).
                MessageBox.Show("Os dados informados não conferem com nosso cadastro ou o token está incorreto.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Validacao_token_TextChanged(object sender, EventArgs e)
        {

        }

        // -----------------------------------------------------------------
        // FUNÇÃO DE USABILIDADE (UX)
        // -----------------------------------------------------------------
        /// <summary>
        /// Permite que o usuário pressione "Enter" para confirmar.
        /// </summary>
        private void RecuperarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                // Impede o som de "bip" do Windows
                e.SuppressKeyPress = true;

                // REUTILIZA A LÓGICA: Chama o clique do botão de confirmar
                Confirm_dados_Click(sender, e);
            }
        }

        private void txtRA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}