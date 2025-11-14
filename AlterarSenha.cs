using Microsoft.Data.SqlClient;
using System;
// ... (outros 'usings' do .NET)
using System.Windows.Forms;
// ...

namespace UNIOZDESKTOP
{
    /// <summary>
    /// Formulário final onde o usuário define sua nova senha.
    /// </summary>
    public partial class AlterarSenha : Form
    {
        // Variável global para armazenar o RA do usuário
        // que foi validado na tela anterior.
        private string _raUsuario;

        /// <summary>
        /// Construtor que recebe o RA do usuário validado.
        /// </summary>
        /// <param name="raUsuario">O RA do usuário (ex: "123456")</param>
        public AlterarSenha(string raUsuario)
        {
            InitializeComponent();

            // Salva o RA recebido na variável global
            this._raUsuario = raUsuario;
        }

        // -----------------------------------------------------------------
        // EVENTO PRINCIPAL (BOTÃO CONFIRMAR NOVA SENHA)
        // -----------------------------------------------------------------

        /// <summary>
        /// Evento de clique do botão "Confirmar".
        /// </summary>
        private void label_Click(object sender, EventArgs e)
        {
            {
                // 1. COLETA DE DADOS: Pega a nova senha e a confirmação.
                string novaSenha = txtNovaSenha.Text;
                string confirmarSenha = txtConfirmarSenha.Text;

                // --- 1. VALIDAÇÃO DE TAMANHO MÍNIMO ---
                if (string.IsNullOrWhiteSpace(novaSenha) || novaSenha.Length < 6)
                {
                    MessageBox.Show("A nova senha deve ter no mínimo 6 caracteres.",
                                    "Senha Curta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Para a execução
                }

                // --- 2. VALIDAÇÃO DE CONFIRMAÇÃO ---
                if (novaSenha != confirmarSenha)
                {
                    MessageBox.Show("As senhas não coincidem. Por favor, digite novamente.",
                                    "Senhas Diferentes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return; // Para a execução
                }

                // --- 3. ATUALIZAR O BANCO DE DADOS ---
                try
                {
                    using (SqlConnection conn = DbConnection.GetConnection())
                    {
                        conn.Open();

                        // A Query SQL usa o RA que foi salvo na variável '_raUsuario'
                        // quando a tela foi aberta.
                        string sql = "UPDATE Usuario SET Senha = @NovaSenha WHERE RA = @RA";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            // Define os parâmetros da query
                            cmd.Parameters.AddWithValue("@NovaSenha", novaSenha); // A nova senha
                            cmd.Parameters.AddWithValue("@RA", this._raUsuario); // O RA do usuário

                            // Executa o comando. ExecuteNonQuery() retorna o
                            // número de linhas que foram afetadas.
                            int linhasAfetadas = cmd.ExecuteNonQuery();

                            if (linhasAfetadas > 0)
                            {
                                // SUCESSO: O update funcionou (encontrou e atualizou 1 linha)
                                MessageBox.Show("Senha alterada com sucesso!",
                                                "Sucesso",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);

                                this.Close(); // Fecha a tela de alterar senha
                            }
                            else
                            {
                                // ERRO INESPERADO: O RA era válido, mas o UPDATE falhou
                                MessageBox.Show("Não foi possível encontrar o usuário para alterar a senha.",
                                                "Erro Inesperado",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ERRO DE BANCO: (Ex: Conexão caiu)
                    MessageBox.Show("Erro ao atualizar a senha: " + ex.Message,
                                    "Erro de Banco",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }


        private void txtNovaSenha_TextChanged(object sender, EventArgs e)
        {

        }

        // -----------------------------------------------------------------
        // FUNÇÃO DE USABILIDADE (UX)
        // -----------------------------------------------------------------
        /// <summary>
        /// Permite que o usuário pressione "Enter" para confirmar a nova senha.
        /// </summary>
        private void AlterarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla foi "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                // Impede o som de "bip"
                e.SuppressKeyPress = true;

                // REUTILIZA A LÓGICA: Chama o clique do botão de confirmar
                label_Click(sender, e);
            }
        }
    }
}