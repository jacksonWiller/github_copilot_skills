# Como Gerar PDF do Currículo

## Métodos Disponíveis

### 1. Pandoc (Recomendado)

**Instalação:**
```powershell
# Windows (usando Chocolatey)
choco install pandoc

# Ou baixar instalador em: https://pandoc.org/installing.html
# Também instalar MiKTeX ou TeX Live para PDF via LaTeX
```

**Comando Básico:**
```powershell
pandoc curriculo.md -o curriculo-jackson-willer.pdf
```

**Comando com Layout Profissional:**
```powershell
pandoc curriculo.md -o curriculo-jackson-willer.pdf `
  --pdf-engine=xelatex `
  -V geometry:margin=2cm `
  -V fontsize=11pt `
  -V colorlinks=true
```

**Comando Avançado:**
```powershell
pandoc curriculo.md -o curriculo-jackson-willer.pdf `
  --pdf-engine=xelatex `
  -V geometry:top=2cm,bottom=2cm,left=2cm,right=2cm `
  -V fontsize=11pt `
  -V mainfont="Calibri" `
  -V colorlinks=true `
  -V linkcolor=blue
```

**Gerar DOCX (Word):**
```powershell
pandoc curriculo.md -o curriculo-jackson-willer.docx
```

**Gerar HTML:**
```powershell
pandoc curriculo.md -o curriculo-jackson-willer.html --standalone
```

---

### 2. VS Code com Extensão Markdown PDF

**Instalação:**
```powershell
code --install-extension yzane.markdown-pdf
```

**Uso:**
1. Abrir arquivo `.md` no VS Code
2. `Ctrl+Shift+P`
3. Digitar "Markdown PDF: Export (pdf)"
4. PDF será salvo na mesma pasta

**Configuração (`.vscode/settings.json`):**
```json
{
  "markdown-pdf.format": "A4",
  "markdown-pdf.margin.top": "1.5cm",
  "markdown-pdf.margin.bottom": "1.5cm",
  "markdown-pdf.margin.right": "1.5cm",
  "markdown-pdf.margin.left": "1.5cm",
  "markdown-pdf.displayHeaderFooter": false
}
```

---

### 3. Chrome/Edge (Imprimir como PDF)

1. Abrir arquivo `.md` com preview no navegador
2. `Ctrl+P` (Imprimir)
3. Destino: "Salvar como PDF"
4. Ajustar margens e layout
5. Salvar

---

## Comparação de Métodos

| Método | Facilidade | Qualidade | Personalização | Requer Instalação |
|--------|------------|-----------|----------------|-------------------|
| Pandoc | ⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐ | Sim |
| VS Code Extension | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐ | ⭐⭐⭐ | Sim (leve) |
| Chrome Print | ⭐⭐⭐⭐ | ⭐⭐⭐ | ⭐⭐ | Não |

## Recomendação

- **Melhor qualidade:** Pandoc com XeLaTeX
- **Uso rápido:** VS Code Extension (yzane.markdown-pdf)
- **Sem instalar nada:** Chrome Print

## Dicas de Formatação

### Margens
- **Ideal:** 1.5cm a 2cm em todos os lados
- Muito pequenas (<1.5cm) = apertado
- Muito grandes (>2.5cm) = desperdício

### Fonte
- **Corpo:** 10-12pt
- **Nome:** 18-24pt
- **Títulos de seções:** 14-16pt

### Quebras de Página
No Markdown:
```markdown
\newpage
```

### Links
Certifique-se de que LinkedIn, GitHub e email estão clicáveis no PDF.

### Conversão entre Formatos
```powershell
# Markdown → PDF
pandoc curriculo.md -o curriculo.pdf --pdf-engine=xelatex

# Markdown → DOCX (Word)
pandoc curriculo.md -o curriculo.docx

# Markdown → HTML
pandoc curriculo.md -o curriculo.html --standalone

# HTML → PDF
pandoc curriculo.html -o curriculo.pdf --pdf-engine=xelatex

# HTML → DOCX
pandoc curriculo.html -o curriculo.docx
```
