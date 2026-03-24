#!/usr/bin/env dotnet-script
#r "nuget: PuppeteerSharp, 19.0.2"

using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.IO;

// Verifica argumentos
if (Args.Count == 0)
{
    Console.WriteLine("Uso: dotnet script html_to_pdf.csx <arquivo.html>");
    Console.WriteLine("  ou: dotnet script html_to_pdf.csx --all  (converte todos os HTML no diretório)");
    return;
}

async Task ConverterHtmlParaPdf(string arquivoHtml)
{
    if (!File.Exists(arquivoHtml))
    {
        Console.WriteLine($"Erro: Arquivo '{arquivoHtml}' não encontrado.");
        return;
    }

    var hash = DateTime.Now.Ticks.GetHashCode().ToString("X").PadLeft(3, '0')[..3];
    var nome = Path.GetFileNameWithoutExtension(arquivoHtml);
    var dir = Path.GetDirectoryName(arquivoHtml) ?? ".";
    var arquivoPdf = Path.Combine(dir, $"{nome}-{hash}.pdf");
    Console.WriteLine($"Convertendo '{arquivoHtml}' para '{arquivoPdf}'...");

    // Baixa o Chromium automaticamente (apenas na primeira vez)
    Console.WriteLine("Verificando navegador Chromium...");
    var browserFetcher = new BrowserFetcher();
    await browserFetcher.DownloadAsync();

    // Abre o navegador headless
    await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false });
    await using var page = await browser.NewPageAsync();

    // Carrega o HTML local
    var caminhoAbsoluto = Path.GetFullPath(arquivoHtml);
    var uri = new Uri(caminhoAbsoluto).AbsoluteUri;
    await page.GoToAsync(uri, new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

    // Injeta CSS para margem superior menor na primeira página e maior nas demais
    await page.AddStyleTagAsync(new AddTagOptions
    {
        Content = @"
            @page:first { margin-top: 10px !important; }
            @page { margin-top: 50px !important; }
        "
    });

    // Gera o PDF mantendo layout idêntico
    await page.PdfAsync(arquivoPdf, new PdfOptions
    {
        Format = PuppeteerSharp.Media.PaperFormat.A4,
        PrintBackground = true,
        DisplayHeaderFooter = true,
        HeaderTemplate = "<div style='font-size:10px; text-align:center; width:100%;'></div>",
        FooterTemplate = "<div style='font-size:10px; text-align:center; width:100%;'>Página <span class='pageNumber'></span> de <span class='totalPages'></span></div>",
        MarginOptions = new PuppeteerSharp.Media.MarginOptions
        {
            Top = "0px",
            Bottom = "50px",
            Left = "0px",
            Right = "0px"
        }
    });

    Console.WriteLine($"PDF gerado com sucesso: {arquivoPdf}");
}

// Execução principal
if (Args[0] == "--all")
{
    var arquivos = Directory.GetFiles(".", "*.html");
    if (arquivos.Length == 0)
    {
        Console.WriteLine("Nenhum arquivo HTML encontrado no diretório atual.");
        return;
    }
    Console.WriteLine($"Encontrados {arquivos.Length} arquivo(s) HTML\n");
    foreach (var arquivo in arquivos)
    {
        await ConverterHtmlParaPdf(arquivo);
        Console.WriteLine();
    }
}
else
{
    await ConverterHtmlParaPdf(Args[0]);
}
