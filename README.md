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

## 🤖 Integração com Claude Skill

Este projeto utiliza **Claude Skill** para geração inteligente de currículos. O Claude possui acesso completo aos seus dados profissionais (experiência, skills, educação, certificações) e utiliza esse conhecimento para:

- ✅ Manter consistência entre português e inglês
- ✅ Otimizar para ATS (Applicant Tracking Systems)

A skill armazena histórico de suas experiências, habilidades e projetos, permitindo geração rápida de múltiplas versões personalizadas.

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

## � Estrutura de Pastas

```
resume_github_copilot_skills/
│
├── resume-jackson-willer-2026.html       # Currículo em inglês (formato A4)
├── curriculo-jackson-willer-2026.html    # Currículo em português (formato A4)
├── preview.html                          # Preview básico para testes
│
├── html_to_pdf.csx                       # Script C# para conversão HTML → PDF
├── README.md                             # Este arquivo (documentação)
├── .gitignore                            # Ignora arquivos temporários e PDFs
│
└── lixo/                                 # 📌 IGNORADA PELO GIT
    └── (PDFs antigos, arquivos de teste)
```

### Descrição de cada arquivo:

| Arquivo | Descrição |
|---------|-----------|
| `resume-jackson-willer-2026.html` | Currículo profissional em inglês, otimizado para vagas internacionais e ATS |
| `curriculo-jackson-willer-2026.html` | Currículo em português, customizado para oportunidades locais |
| `preview.html` | Versão simplificada para visualização rápida |
| `html_to_pdf.csx` | Script de conversão usando PuppeteerSharp + Chromium headless |
| `.gitignore` | Configuração para ignorar `lixo/` e outros arquivos temporários |
| `lixo/` | Pasta descartável com versões antigas e testes (não sincronizada) |

## 🏗️ Como o Projeto Foi Feito

### 1. **Estratégia de Armazenamento**
   - Currículos em **HTML estruturado** (fácil de modificar e converter)
   - Dois idiomas: **Português** (pt-BR) e **Inglês** (en-US)
   - Estilos **CSS embarcados** para garantir consistência visual
   - Compatibilidade com **print media** para PDF

### 2. **Componentes Principais**

#### **HTML (Semântica + Estilo)**
   ```html
   <!-- Estrutura semântica: h1, h2, ul, li, p -->
   <h1>Jackson Willer Macedo Duarte</h1>
   <h2>Professional Summary</h2>
   <ul>
     <li>Desenvolvedor Full Stack com 6+ anos</li>
   </ul>
   
   <!-- CSS responsivo e otimizado para print -->
   <style>
     body { font-family: Segoe UI; max-width: 210mm; }
     h2 { border-bottom: 1px solid #ccc; }
     @media print { /* Ajustes para PDF */ }
   </style>
   ```

#### **Script de Conversão (C# + dotnet-script)**
   ```csharp
   // html_to_pdf.csx usa:
   1. PuppeteerSharp → Controla Chromium headless
   2. BrowserFetcher → Download automático do navegador
   3. page.PdfAsync() → Renderiza e exporta PDF
   4. Margens customizadas → Primeira página diferente
   ```

### 3. **Fluxo de Funcionamento**

```
┌─────────────────────┐
│  HTML (pt/en)       │  ← Raiz do projeto
└──────────┬──────────┘
           │
           │ dotnet script html_to_pdf.csx <arquivo>
           │
┌──────────▼──────────┐
│ PuppeteerSharp      │  ← Script C#
│ + Chromium headless │
└──────────┬──────────┘
           │
           │ Renderização + CSS
           │
┌──────────▼──────────┐
│ PDF (A4, 1 página)  │  ← Output
└─────────────────────┘
```

### 4. **Características Implementadas**

✅ **Responsividade**
   - Layout A4 (210mm × 297mm)
   - Margem diferenciada na primeira página (10px) vs demais (50px)
   - Header/Footer automático com contagem de páginas

✅ **Formatação Profissional**
   - Tipografia com Segoe UI (legível em impressão)
   - Cores harmônicas (#0d1b2a para títulos)
   - Espaçamento vertical consistente
   - Ícones SVG embarcados para contato

✅ **Otimizado para ATS**
   - Estrutura semântica clara
   - Sem imagens complexas
   - Texto estruturado em listas
   - Meta charset UTF-8

✅ **Controle de Versão**
   - Arquivos nomeados com data (2026)
   - PDFs com hash para evitar conflitos
   - Pasta `lixo/` ignorada pelo Git

### 5. **Customizações Possíveis**

Você pode editar os HTMLs diretamente:

```html
<!-- Mudar cores -->
<style>h2 { color: #1a5da6; }</style>

<!-- Adicionar seções -->
<h2>Projetos</h2>
<ul>
  <li>Projeto X — Descrição</li>
</ul>

<!-- Ajustar margens no PDF -->
<style>
  body { padding: 2cm; }
  @media print { body { padding: 1.5cm; } }
</style>
```

## �🔗 Referências

- [dotnet-script Documentation](https://github.com/filipw/dotnet-script)
- [PuppeteerSharp Documentation](https://www.puppeteersharp.dev/)
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)

---

**Criado para:** Converter currículos HTML para PDF com formatação profissional
