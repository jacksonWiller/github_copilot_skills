# HTML to PDF Converter

Ferramenta para converter arquivos HTML em PDF usando **PuppeteerSharp** e **Chromium headless** com suporte a estilos CSS avançados e headers/footers.

## 📋 Requisitos

- **.NET 6.0+** ou **.NET 7.0+**
- **dotnet-script** (ferramenta CLI)

## 🚀 Instalação

### 1. Instalar dotnet-script
```bash
dotnet tool install -g dotnet-script
```

### 2. Verificar instalação
```bash
dotnet script --version
```

## 📖 Como Usar

### Converter um arquivo HTML específico:
```bash
dotnet script html_to_pdf.csx resume-jackson-willer-2026.html
```

**Output esperado:**
```
Convertendo 'resume-jackson-willer-2026.html' para 'resume-jackson-willer-2026-ABC.pdf'...
Verificando navegador Chromium...
PDF gerado com sucesso: resume-jackson-willer-2026-ABC.pdf
```

### Converter todos os arquivos HTML do diretório:
```bash
dotnet script html_to_pdf.csx --all
```

Isso irá converter todos os arquivos `.html` encontrados no diretório atual.

## 🔧 O que o Script Faz

1. **Valida o arquivo HTML** — Verifica se o arquivo existe
2. **Baixa Chromium** — Download automático na primeira execução
3. **Abre navegador headless** — Usa Chromium em background
4. **Carrega o HTML** — Via file:// protocol
5. **Gera PDF** — Com formatação A4, headers e footers
6. **Nomeia o arquivo** — Adiciona hash ao nome para evitar conflitos

## 📝 Características

- ✅ Suporte a CSS avançado (grid, flexbox, media queries)
- ✅ Margem diferenciada na primeira página
- ✅ Header/Footer automático com número de página
- ✅ Preservação de cores de background
- ✅ Compatibilidade com print media

## 💡 Exemplo de Uso

```bash
# Converter currículo individual
dotnet script html_to_pdf.csx resume-jackson-willer-2026.html

# Converter todos os currículos
dotnet script html_to_pdf.csx --all
```

## ❌ Solução de Problemas

### "dotnet script não foi encontrado"
```bash
dotnet tool install -g dotnet-script
```

### "Arquivo não encontrado"
- Verifique se o arquivo HTML existe no diretório
- Use caminho absoluto se necessário:
```bash
dotnet script html_to_pdf.csx "C:\caminho\completo\arquivo.html"
```

### Chromium não baixa
- Verifique sua conexão com internet
- Tente novamente (o download ocorre apenas na primeira execução)

## 📦 Dependências

| Pacote | Versão |
|--------|--------|
| PuppeteerSharp | 19.0.2 |

## 🎯 Arquivos Gerados

Os PDFs são salvos no **mesmo diretório** do arquivo HTML com sufixo de hash:

```
resume-jackson-willer-2026.html  →  resume-jackson-willer-2026-A1B.pdf
curriculo-jackson-willer-2026.html  →  curriculo-jackson-willer-2026-C2D.pdf
```

## 📄 Documentação da API (PuppeteerSharp)

- **Headless Mode**: Renderiza sem abrir janela visual
- **PageFormat**: A4 (210mm × 297mm)
- **printBackground**: Inclui imagens e cores de background
- **MarginOptions**: Margens customizáveis (top, bottom, left, right)

## 🔗 Referências

- [dotnet-script Documentation](https://github.com/filipw/dotnet-script)
- [PuppeteerSharp Documentation](https://www.puppeteersharp.dev/)
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)

---

**Criado para:** Converter currículos HTML para PDF com formatação profissional
