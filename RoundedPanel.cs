using System;
using System.Drawing;
using System.Drawing.Drawing2D; // Importante: É o que permite desenhar formas (GraphicsPath)
using System.Windows.Forms;


namespace UNIOZDESKTOP
{
    /// <summary>
    /// Componente customizado que HERDA de um Painel padrão,
    /// mas permite ter bordas arredondadas e uma borda colorida.
    /// </summary>
    public class RoundedPanel : Panel // Esta classe É um Panel
    {
        // --- PROPRIEDADES CUSTOMIZADAS ---
        // Estas são as variáveis internas que guardam os valores

        private int _cornerRadius = 20; // Raio do canto padrão
        private Color _borderColor = Color.Gray; // Cor da borda padrão
        private int _borderSize = 1; // Tamanho da borda padrão

        /// <summary>
        /// Define o raio dos cantos.
        /// Aparecerá na janela de "Propriedades" do Visual Studio.
        /// </summary>
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); } // 'Invalidate()' força o painel a se redesenhar
        }

        /// <summary>
        /// Define a cor da borda.
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        /// <summary>
        /// Define a espessura da borda.
        /// </summary>
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
        }

        /// <summary>
        /// Construtor do painel.
        /// </summary>
        public RoundedPanel()
        {
            // 'DoubleBuffered = true' é uma otimização de performance
            // que evita que o painel "pisque" (flickering) ao ser redesenhado.
            this.DoubleBuffered = true;

            // Aplica a região arredondada assim que o controle é criado
            ApplyRegion();
        }

        /// <summary>
        /// Evento chamado sempre que o painel é redimensionado.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // É crucial recalcular a região arredondada para o novo tamanho
            ApplyRegion();
        }


        /// <summary>
        /// O CORAÇÃO do componente. Este método é chamado pelo Windows
        /// sempre que o painel precisa ser "desenhado" na tela.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Desenha o painel padrão (que será coberto)

            // Pega o objeto "Gráfico" (a "caneta" para desenhar)
            Graphics g = e.Graphics;
            // 'AntiAlias' é o que deixa as curvas SUAVES (sem serrilhado)
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define o retângulo de desenho
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);


            // 1. GERA A FORMA: Chama a função que calcula o "caminho" arredondado
            GraphicsPath path = GetRoundedPath(rect, _cornerRadius);


            // 2. PREENCHIMENTO: Pinta o FUNDO do painel
            // (usa a cor 'this.BackColor' definida no designer)
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillPath(brush, path); // Preenche a forma ('path') com o pincel
            }


            // 3. BORDA: Desenha a LINHA da borda, se ela for maior que zero
            if (_borderSize > 0)
            {
                using (Pen pen = new Pen(_borderColor, _borderSize))
                {
                    g.DrawPath(pen, path); // Desenha a linha da forma ('path')
                }
            }
        }


        /// <summary>
        /// Aplica a "Região" de corte. Isso é o que realmente faz
        /// os cantos "sumirem" (clipping) e não serem apenas pintados por cima.
        /// </summary>
        private void ApplyRegion()
        {
            // Garante que o painel tenha um tamanho válido
            if (this.Width > 0 && this.Height > 0)
            {
                // Pega o "caminho" (path) arredondado
                using (GraphicsPath path = GetRoundedPath(this.ClientRectangle, _cornerRadius))
                {
                    // Define a 'Região' do controle. O Windows vai "cortar" (clip)
                    // tudo que estiver fora deste 'path'.
                    this.Region = new Region(path);
                }
            }
        }

        /// <summary>
        /// A "Receita" do formato. Cria um 'GraphicsPath' (um caminho)
        /// que descreve a forma de um retângulo com cantos arredondados.
        /// </summary>
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            // Se o raio for 0, apenas retorna um retângulo normal
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // 'AddArc' desenha uma seção de 90 graus de um círculo (um canto)
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // O processo é "desenhar" os 4 cantos:
            // Canto superior esquerdo (Começa em 180°, gira 90°)
            path.AddArc(arcRect, 180, 90);

            // Canto superior direito (Move o 'arcRect' para a direita)
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // Canto inferior direito (Move o 'arcRect' para baixo)
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // Canto inferior esquerdo (Move o 'arcRect' para a esquerda)
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            // Fecha a forma (liga o último ponto ao primeiro)
            path.CloseFigure();
            return path;
        }
    }
}