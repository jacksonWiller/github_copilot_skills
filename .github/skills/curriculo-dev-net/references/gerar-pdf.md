# Como Gerar PDF do Currículo

> **Importante:** Os currículos são gerados inicialmente em **HTML** com CSS inline. O HTML é o formato primário — o PDF é gerado a partir dele.

## Métodos Disponíveis

### 1. Chrome/Edge — Imprimir como PDF (Recomendado)

O método mais simples e confiável. Como o HTML já possui todo o estilo CSS embutido, o resultado é fiel ao layout original.

1. Abrir o arquivo `.html` no Chrome ou Edge
2. `Ctrl+P` (Imprimir)
3. Destino: **"Salvar como PDF"**
4. Margens: **Nenhuma** (o CSS já define padding de 2cm)
5. Marcar **"Gráficos de plano de fundo"** se necessário
6. Salvar

---

### 2. Puppeteer via npx (Automação / CLI)

Gera PDF a partir do HTML usando o Chromium headless. Ideal para automação e pipelines.

**Comando:**
```powershell
npx puppeteer-html2pdf `
  --input curriculo.html `
  --output curriculo-jackson-willer.pdf `
  --format A4 `
  --margin-top 0 `
  --margin-bottom 0 `
  --margin-left 0 `
  --margin-right 0
```

> Margens zeradas porque o HTML já define `padding: 2cm` no `<body>`.

**Requisitos:** Node.js instalado.

---

### 3. Puppeteer via script Node.js (Controle total)

Para maior personalização, crie um script:

```javascript
// gerar-pdf.js
const puppeteer = require('puppeteer');
const path = require('path');

(async () => {
  const browser = await puppeteer.launch();
  const page = await browser.newPage();
  const filePath = path.resolve('curriculo.html');
  await page.goto(`file://${filePath}`, { waitUntil: 'networkidle0' });
  await page.pdf({
    path: 'curriculo-jackson-willer.pdf',
    format: 'A4',
    printBackground: true,
    margin: { top: 0, bottom: 0, left: 0, right: 0 }
  });
  await browser.close();
})();
```

```powershell
npm install puppeteer
node gerar-pdf.js
```

---

### 4. Pandoc (Alternativa — a partir de HTML)

```powershell
pandoc curriculo.html -o curriculo-jackson-willer.pdf --pdf-engine=xelatex
```

```powershell
# HTML → DOCX (Word)
pandoc curriculo.html -o curriculo-jackson-willer.docx
```

**Requisitos:** Pandoc + MiKTeX ou TeX Live.

---

## Comparação de Métodos

| Método | Facilidade | Qualidade | Fidelidade ao CSS | Requer Instalação |
|--------|------------|-----------|-------------------|-------------------|
| Chrome/Edge Print | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | Não |
| Puppeteer (npx) | ⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | Node.js |
| Puppeteer (script) | ⭐⭐⭐ | ⭐⭐⭐⭐⭐ | ⭐⭐⭐⭐⭐ | Node.js |
| Pandoc | ⭐⭐⭐ | ⭐⭐⭐⭐ | ⭐⭐⭐ | Pandoc + LaTeX |

## Recomendação

- **Mais fácil e fiel:** Chrome/Edge Print (abre o HTML, Ctrl+P, salva como PDF)
- **Automação:** Puppeteer via npx (ideal para CI/CD e scripts)
- **Compatibilidade Word:** Pandoc HTML → DOCX

## Dicas de Formatação

### Margens
- O template HTML já define `padding: 2cm` no `<body>`
- Ao imprimir, usar margens **"Nenhuma"** para evitar margem dupla

### Fonte
- **Corpo:** 11pt (definido no CSS)
- **Nome:** 22pt (definido no CSS)
- **Títulos de seções:** 13pt (definido no CSS)

### Quebras de Página
No HTML, usar CSS:
```css
.page-break { page-break-before: always; }
```
```html
<div class="page-break"></div>
```

### Links
LinkedIn, GitHub e email já estão como `<a href="...">` clicáveis no HTML e no PDF gerado.

### Conversão entre Formatos
```powershell
# HTML → PDF (Chrome/Edge — manual)
# Abrir .html no navegador → Ctrl+P → Salvar como PDF

# HTML → PDF (Puppeteer — automático)
npx puppeteer-html2pdf --input curriculo.html --output curriculo.pdf --format A4

# HTML → DOCX (Word)
pandoc curriculo.html -o curriculo.docx

# HTML → Markdown (referência)
pandoc curriculo.html -o curriculo.md
```
