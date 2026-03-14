# Skill: Currículo — Jackson Willer Macedo Duarte

Skill para geração de currículos profissionais personalizados para **Jackson Willer Macedo Duarte**, desenvolvedor full-stack .NET com 6+ anos de experiência. Suporte bilíngue (PT-BR / EN-US), otimização ATS e exportação para PDF/DOCX.

> **Formato primário: HTML.** Os currículos são gerados inicialmente em HTML com CSS inline, garantindo layout profissional e fidelidade na conversão para PDF.

## Como Usar

No chat do GitHub Copilot:

```
criar currículo para vaga de backend .NET
```

```
adaptar meu currículo para esta vaga: [descrição]
```

```
gerar currículo em inglês para vaga de software engineer
```

### Comandos Disponíveis

- **Criar novo currículo**: `criar currículo` / `criar novo`
- **Adaptar para vaga**: `adaptar para vaga [descrição]`
- **Traduzir**: `traduzir currículo para inglês / português`
- **Gerar PDF**: `gerar pdf do currículo`

## Estrutura da Skill

```
curriculo-dev-net/
├── SKILL.md                      # Instruções, dados e workflow completo
├── README.md                     # Este arquivo
├── assets/
│   ├── template-pt.html          # Currículo HTML em português (formato primário)
│   ├── template-en.html          # Currículo HTML em inglês (formato primário)
│   ├── template-pt.md            # Currículo Markdown em português (referência)
│   └── template-en.md            # Currículo Markdown em inglês (referência)
└── references/
    ├── dicas-ats.md              # Otimização para ATS
    ├── tecnologias-net.md        # Stack técnica com priorização por vaga
    └── gerar-pdf.md              # Guia de conversão HTML → PDF/DOCX
```

## Funcionalidades

### Templates Prontos (HTML)
- Currículo HTML completo em Português (BR) com CSS inline
- Currículo HTML completo em Inglês (US) com CSS inline
- Templates Markdown mantidos como referência
- Preenchidos com todas as experiências, habilidades e certificações de Jackson

### Adaptação Inteligente por Tipo de Vaga
- **Backend .NET**: Prioriza C#, .NET, APIs, microsserviços, cloud
- **Full-Stack**: Destaca .NET + Angular/React, integração front-back
- **Cloud/DevOps**: Enfatiza AWS Lambda, Azure, CI/CD, serverless
- **Genérica**: Balanceia todas as competências

### Otimização ATS
- Palavras-chave técnicas de alto valor
- Formatação compatível com sistemas automáticos
- Técnica de espelhamento de vagas

### Exportação Multi-formato
- HTML → PDF (Chrome/Edge Print ou Puppeteer)
- HTML → DOCX (Pandoc)
- HTML → Markdown (Pandoc, para referência)

## Perfil Resumido

**Jackson Willer Macedo Duarte**  
Desenvolvedor Full-Stack | .NET | Cloud-Native | Microsserviços  
6+ anos de experiência | Januária - MG

**Empresas:** Code n'App, Magma3, TOTVS, NTT DATA, Consórcio Magalu, RBA Digital, Value Code

**Stack Principal:** C#, .NET Core, ASP.NET, Angular, React, Node.js, AWS, Azure, SQL Server, MongoDB, Docker, CI/CD

**Diferenciais:** Modernização de legados, cloud-native, serverless, Clean Code, SOLID, DDD

## Recursos

- [Template Português (HTML)](./assets/template-pt.html)
- [Template Inglês (HTML)](./assets/template-en.html)
- [Template Português (Markdown)](./assets/template-pt.md)
- [Template Inglês (Markdown)](./assets/template-en.md)
- [Dicas ATS](./references/dicas-ats.md)
- [Stack Técnica](./references/tecnologias-net.md)
- [Guia PDF (HTML → PDF)](./references/gerar-pdf.md)
