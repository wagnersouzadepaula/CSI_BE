using CSI_BE.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Font;
using PdfSharp;


namespace CSI_BE.Services
{
    public static class MontaPdf
    {
        public static byte[] MontarPdf(ContratoSocialDTO pj)
        {

            List<string> Clausulas = new List<string>();
            int qtdeCaracteresSocio1 = pj.Socio1.Nome.Length;
            int qtdeCaracteresSocio2 = pj.Socio2.Nome.Length;
            string underlineAssinatura = "_";

            #region - Cláusulas do contrato
            string titulo = $"Contrato social de {pj.Pj.Nome}";
            Clausulas.Add($"{pj.Socio1.Nome}, {pj.Socio1.Nacionalidade}, {pj.Socio1.EstadoCivil}, {pj.Socio1.MaioridadeCivil}, {pj.Socio1.Profissao}, nº do CPF {pj.Socio1.Cpf}, {pj.Socio1.Rg}, residente e domiciliado no(a) {pj.Socio1.Endereco}, {pj.Socio1.NroImovel}, {pj.Socio1.Complemento}, {pj.Socio1.Bairro}, {pj.Socio1.Cidade}, {pj.Socio1.Uf}, {pj.Socio1.Cep} e ");
            Clausulas.Add($"{pj.Socio2.Nome}, {pj.Socio2.Nacionalidade}, {pj.Socio2.EstadoCivil}, {pj.Socio2.MaioridadeCivil}, {pj.Socio2.Profissao}, nº do CPF {pj.Socio2.Cpf}, {pj.Socio2.Rg}, residente e domiciliado no(a) {pj.Socio2.Endereco}, {pj.Socio2.NroImovel}, {pj.Socio2.Complemento}, {pj.Socio2.Bairro}, {pj.Socio2.Cidade}, {pj.Socio2.Uf}, {pj.Socio2.Cep}");
            Clausulas.Add("resolvem constituir uma Sociedade Simples LTDA mediante as seguintes cláusulas e condições:");
            Clausulas.Add($"CLÁUSULA 1ª. A sociedade girará com a denominação de {pj.Pj.Nome} e terá sede e domicilio na  {pj.Pj.Endereco}, {pj.Pj.NroImovel}, {pj.Pj.Complemento}, {pj.Pj.Bairro}, {pj.Pj.Cidade}, {pj.Pj.Uf}, {pj.Pj.Cep}.");
            Clausulas.Add($"CLÁUSULA 2ª. O capital social será de R${pj.Pj.QuotaSocio1 + pj.Pj.QuotaSocio2},00 dividido em {pj.Pj.QuotaSocio1 + pj.Pj.QuotaSocio2} quotas no valor nominal R$ 1,00 (um real) cada, totalmente integralizadas neste ato em moeda corrente do País, pelos sócios da seguinte forma: O(a) Sócio(a) {pj.Socio1.Nome} é detentor(a) de {pj.Pj.QuotaSocio1} quotas e o(a) sócio(a) {pj.Socio2.Nome} é detentor(a) de {pj.Pj.QuotaSocio2} quotas.");
            Clausulas.Add("Parágrafo único. A responsabilidade de cada sócio é restrita ao valor de suas quotas, mas todos respondem solidariamente pela integralização do capital social de conformidade com o artigo 1052 da lei 10.406/2002.");
            Clausulas.Add($"CLÁUSULA 3ª. O objeto social da sociedade ora constituída é: {pj.Cnae}");
            Clausulas.Add($"CLÁUSULA 4ª. A sociedade iniciará suas atividades em {pj.Pj.PrazoInicialDeDuracao.Day}/{pj.Pj.PrazoInicialDeDuracao.Month}/{pj.Pj.PrazoInicialDeDuracao.Year} e seu prazo de duração é indeterminado.");
            Clausulas.Add($"CLÁUSULA 5ª. As quotas são indivisíveis e não poderão ser cedidas ou transferidas a terceiros sem o consentimento do outro sócio, a quem fica assegurado, em igualdade de condições e preço direito de preferência para a sua aquisição se postas à venda, formalizando, se realizada a cessão delas, a alteração contratual pertinente.");
            Clausulas.Add($"CLÁUSULA 6ª. A administração da sociedade caberá aos sócios {pj.Socio1.Nome} e {pj.Socio2.Nome} com os poderes e atribuições de administração em conjunto ou isoladamente, autorizado o uso do nome empresarial, vedado, no entanto, em atividades estranhas ao interesse social ou assumir obrigações seja em favor de qualquer dos quotistas ou de terceiros, bem como onerar ou alienar bens imóveis da sociedade, sem autorização do(s) outro(s) sócio(s).");
            Clausulas.Add("CLÁUSULA 7ª.Ao término da cada exercício social, em 31 de dezembro, os administradores prestarão contas justificadas de sua administração, procedendo à elaboração do inventário, do balanço patrimonial e do balanço de resultado econômico, cabendo aos sócios, na proporção de suas quotas, a distribuição dos lucros ou perdas.");
            Clausulas.Add("CLÁUSULA 8ª. Nos quatro meses seguintes ao término do exercício social, os sócios deliberarão sobre as contas e designarão administrador(es) quando for o caso.");
            Clausulas.Add("CLÁUSULA 9ª. A sociedade poderá a qualquer tempo, abrir ou fechar filial ou outra dependência, mediante alteração contratual assinada por todos os sócios.");
            Clausulas.Add("CLÁUSULA 10ª. Os sócios poderão, de comum acordo, fixar uma retirada mensal, a título de “pro labore”, observadas as disposições regulamentares pertinentes.");
            Clausulas.Add("CLÁUSULA 11ª. Falecendo ou tornando-se interditado qualquer sócio, a sociedade continuará suas atividades com os herdeiros, sucessores, ou com o(s) sócio(s) remanescente.");
            Clausulas.Add("Parágrafo Primeiro - Não sendo possível ou inexistindo interesse destes ou do(s) sócio(s) remanescente(s), o valor de seus haveres será apurado e liquidado com base na situação patrimonial da sociedade, à data de ocorrência do evento, verificada em balanço especialmente levantado.");
            Clausulas.Add("Parágrafo Segundo - O mesmo procedimento será adotado em outros casos em que a sociedade decida em relação a seus sócios.");
            Clausulas.Add("CLÁUSULA 12ª. Este Instrumento Contratual, é regido pela Lei 10.406/2002, tendo como regência supletiva as Normas Regimentais da Sociedade Anônima Lei 6.404/76.");
            Clausulas.Add("CLÁUSULA 13ª. (Os) Administrador(es) declara(m), sob as penas da lei, de que não está(ão) impedidos de exercer a administração da sociedade, por lei especial, ou em virtude de condenação criminal, ou por se encontrar(em) sob os efeitos dela, a pena que vede, ainda que temporariamente, o acesso a cargos públicos; ou por crime falimentar, de prevaricação, peita ou suborno, concussão, peculato, ou contra a economia popular, contra o sistema financeiro nacional, contra normas de defesa da concorrência, contra as relações de consumo, fé pública, ou a propriedade, conforme o artigo 1.011 parágrafo 1º da Lei 10.406/2002.");
            Clausulas.Add($"CLÁUSULA 14ª. Fica eleito o foro da Cidade de {pj.Pj.Cidade}, {pj.Pj.Uf}, para o exercício e o cumprimento dos direitos e obrigações resultantes deste contrato.");
            Clausulas.Add($"E por estarem assim justos e contratados assinam o presente instrumento em 3 vias.");
            Clausulas.Add(" ");
            Clausulas.Add($"{pj.Pj.Cidade}, {pj.Pj.Uf}, {pj.Pj.PrazoInicialDeDuracao}");
            Clausulas.Add(" ");
            Clausulas.Add(VerificaQtdeDeUnderlines(qtdeCaracteresSocio1, qtdeCaracteresSocio2, underlineAssinatura));
            Clausulas.Add($"{pj.Socio1.Nome}");
            Clausulas.Add(" ");
            Clausulas.Add(VerificaQtdeDeUnderlines(qtdeCaracteresSocio1, qtdeCaracteresSocio2, underlineAssinatura));
            Clausulas.Add($"{pj.Socio2.Nome}");
            Clausulas.Add("");
            Clausulas.Add($"Verifique a autenticidade do contrato em www.sitedocontratosocialinteligente.com.br informando o código {pj.CodVerificador}");

            #endregion

            #region - Funcoes para automatizar o relatório
            static string VerificaQtdeDeUnderlines(int _qtdeCaracteresSocio1, int _qtdeCaracteresSocio2, string _underlineAssinatura)
            {
                int qtdeCaracteres = 0;
                if (_qtdeCaracteresSocio1 >= _qtdeCaracteresSocio2)
                {
                    qtdeCaracteres = _qtdeCaracteresSocio1;
                }
                else { qtdeCaracteres = _qtdeCaracteresSocio2; }

                for (int i = 0; i < qtdeCaracteres; i++)
                {
                    _underlineAssinatura += "__";
                }

                return _underlineAssinatura;
            };

            static int CalculaAlturaDoParagrafo(int qtdeCaracteres, double _alturaLinha)
            {
                double qtdeDeLinhas = qtdeCaracteres / 97;
                if (qtdeDeLinhas <= 0)
                {
                    qtdeDeLinhas = 1;
                    double alturaDoParagrafo = (qtdeDeLinhas) * _alturaLinha;
                    return (int)Math.Ceiling(alturaDoParagrafo);
                }
                else
                {
                    double alturaDoParagrafo = (qtdeDeLinhas + 1.5) * _alturaLinha;
                    return (int)Math.Ceiling(alturaDoParagrafo);
                }
            }

            static int CalculaQtdeDeLinhas(int _qtdeCaracteresBaseLegal, int _qtdeCaracteresNomeCondicionante, int _qtdCaracteresItemCondicionante, int _qtdCaracteresOperador, int _qtdCaracteresConteudo)
            {
                int qtdeLinhas = 1;
                if (_qtdeCaracteresBaseLegal > 83 || _qtdeCaracteresNomeCondicionante > 39 || _qtdCaracteresItemCondicionante > 39 || _qtdCaracteresOperador > 28 || _qtdCaracteresConteudo > 21)
                {

                }

                return qtdeLinhas;
            }
            #endregion

            if (GlobalFontSettings.FontResolver == null)
            {
                if (Capabilities.Build.IsCoreBuild) GlobalFontSettings.FontResolver = new FailsafeFontResolver();
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Contrato Social de {pj.Pj.Nome}";
            document.Info.Subject = "Criado pelo CSI - Contrato Social Inteligente";

            while (Clausulas.Count != 0)
            {
                PdfPage pdfPage = document.AddPage();
                pdfPage.Orientation = PageOrientation.Portrait;

                #region Criacao de variaveis
                int larguraPagina = (int)Math.Ceiling(pdfPage.Width);
                int alturaPagina = (int)Math.Ceiling(pdfPage.Height);
                int marginTop = 25;
                int marginBottom = 25;
                int margem = 20;
                int alturaDaLinha = 0;
                #endregion

                #region Formatacoes de Estilo
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;
                var tf = new XTextFormatter(graph);

                XTextFormatter paragrafoCentralizado = new XTextFormatter(graph);
                paragrafoCentralizado.Alignment = XParagraphAlignment.Center;

                XTextFormatter paragrafoJustificado = new XTextFormatter(graph);
                paragrafoJustificado.Alignment = XParagraphAlignment.Justify;

                // Gera as fontes que serão utilizadas.
                var tituloRelatorioStyle = new XFont("Times New Roman", 16, XFontStyleEx.Bold);
                var fontBold = new XFont("Times New Roman", 12, XFontStyleEx.Bold);
                var fontRegular = new XFont("Times New Roman", 12, XFontStyleEx.Regular);
                var fontParagraph = new XFont("Times New Roman", 8, XFontStyleEx.Regular);
                XSolidBrush rect_style1 = new XSolidBrush(XColors.White);
                #endregion

                #region Cabecalhos do contrato
                paragrafoCentralizado.DrawString(pj.Pj.Nome, tituloRelatorioStyle, XBrushes.Black, new XRect(margem, marginTop, pdfPage.Width, margem));
                marginTop += 30;
                paragrafoJustificado.DrawString(Clausulas[0], fontRegular, XBrushes.Black, new XRect(margem, marginTop, larguraPagina - (margem * 2), marginTop));
                #endregion

                #region Impressão das cláusulas
                try
                {
                    while (CalculaAlturaDoParagrafo(Clausulas[0].Length, fontParagraph.GetHeight()) < (alturaPagina - marginTop - marginBottom))
                    {
                        paragrafoJustificado.DrawString(Clausulas[0], fontRegular, XBrushes.Black, new XRect(margem, marginTop, larguraPagina - (margem * 2), marginTop));
                        marginTop += CalculaAlturaDoParagrafo(Clausulas[0].Length, fontRegular.GetHeight());
                        Clausulas.RemoveAt(0);
                    }
                }
                catch
                {
                    break;
                }
            }
            #endregion

            #region debug
            //Salva o relatório na pasta informada
            string regraTributariaPdf = $"c:\\temp\\ContratoSocial_{pj.Pj.Nome}.pdf";
            document.Save(regraTributariaPdf);
            #endregion

            // Converter para array de bytes
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms, false);
                return ms.ToArray();

            }
        }
    }
}