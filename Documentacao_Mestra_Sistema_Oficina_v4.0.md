DOCUMENTAÇÃO MESTRA

Sistema de Gestão para Oficina Mecânica

ERN v4.0 + Modelo de Dados + Arquitetura .NET + Estado Atual + Plano
para Implementação

Versão documental: 1.0 \| Setembro de 2026

Base documental: ERN v4.0 (33 páginas) e projeto
OficinaMecanica_NET_EFCore fornecido em 21/09/2026.

FINALIDADE: congelar o entendimento funcional e técnico antes da
continuação do código no Codex.

# Controle e finalidade do documento

Este documento é a fonte de referência consolidada para a continuação do
projeto. Ele não substitui o ERN v4.0: organiza o ERN, registra o que já
foi materializado no código e distingue decisões consolidadas de
pendências técnicas.

| Classificação \| Significado \|

| --- \| --- \|

| CONSOLIDADO \| Definido pelo ERN e/ou já materializado de forma
  coerente no projeto. Não alterar sem motivo técnico/documental. \|

| IMPLEMENTADO NA BASE \| Existe no código estrutural atual, mas pode
  ainda não estar funcional ponta a ponta. \|

| PENDENTE \| Previsto no ERN ou necessário tecnicamente, mas ainda não
  implementado/validado. \|

| A VALIDAR \| Há intenção no modelo, porém a implementação atual não
  garante integralmente o comportamento. \|

| FUTURO \| Fora do núcleo obrigatório inicial; não deve ampliar o
  escopo do MVP agora. \|

## Regra de governança

Qualquer agente de código deve preservar as decisões consolidadas.
Mudanças estruturais devem vir acompanhadas de justificativa, impacto no
ERN/modelo de dados, riscos, estratégia de migração e testes. Não
simplificar regras de rastreabilidade, histórico, aprovação, estoque,
financeiro, segurança ou multiunidade apenas para reduzir código.

# 1. Objetivo completo do sistema

O sistema deve centralizar o ciclo operacional de uma oficina mecânica
desde o primeiro atendimento e cadastro do veículo até orçamento,
aprovação digital, ordem de serviço, diagnóstico, execução,
peças/estoque, faturamento, pagamento, entrega, garantia e histórico de
manutenção.

-   Centralizar clientes e veículos e preservar histórico completo.

-   Digitalizar orçamento, versionamento e aprovação remota/segura.

-   Controlar integralmente ordens de serviço e seus estados.

-   Permitir operação mobile-first para mecânicos, com diagnóstico,
    fotos e evidências.

-   Controlar produtos, fornecedores, estoque, reservas, aplicações,
    devoluções e movimentações.

-   Rastrear garantias de peças e serviços.

-   Calcular comissões preservando a regra histórica aplicada.

-   Controlar contas a receber, contas a pagar, pagamentos, parcelas e
    caixa.

-   Gerar documentos, laudos, relatórios e indicadores.

-   Manter auditoria, controle de acesso, privacidade/LGPD e segurança.

-   Integrar documentos ao Google Drive sem tornar a integração
    dependência do núcleo.

-   Preparar integrações de WhatsApp, e-mail e fiscais de forma
    desacoplada.

-   Permitir crescimento futuro para múltiplas empresas/unidades sem
    reconstruir o núcleo.

Fonte: ERN v4.0, seções 1--3 e 35.

# 2. Princípios não negociáveis do ERN

| Princípio \| Aplicação no projeto \|

| --- \| --- \|

| Rastreabilidade \| Operações relevantes registram usuário, data/hora e
  contexto; históricos não são descartados. \|

| Integridade \| Financeiro, fiscal, estoque, aprovações e OS não podem
  perder histórico por exclusão indiscriminada. \|

| Parametrização \| Regras variáveis por oficina/tempo devem ser
  configuráveis, especialmente fiscal, garantias e meios de pagamento.
  \|

| Segurança \| Acesso por autenticação/autorização; interface não
  substitui validação na API. \|

| Mobile first \| Fluxos do mecânico priorizam smartphone. \|

| Desacoplamento \| Drive, WhatsApp, e-mail e fiscal ficam fora do
  núcleo e podem falhar sem derrubar a operação. \|

| Extensibilidade \| A arquitetura não deve bloquear
  multiempresa/multiunidade e crescimento futuro. \|

# 3. Escopo funcional --- ERN v4.0

| Módulo \| Regras \| Resumo \|

| --- \| --- \| --- \|

| Clientes e veículos \| RN01--RN03 \| Cadastro/inativação, múltiplos
  veículos por cliente, prevenção de duplicidade e histórico do veículo.
  \|

| Atendimento e agenda \| RN04--RN06 \| Agendamento, boxes/elevadores e
  checklist de entrada com fotos. \|

| Orçamento \| RN07--RN11 \| Pré-orçamento, versionamento, link seguro,
  aprovação total/parcial e registro da versão aprovada. \|

| Ordem de serviço \| RN12--RN15 \| Abertura, máquina de estados,
  transições controladas e itens de serviço/peça. \|

| Mecânicos e comissões \| RN16--RN18 \| Colaboradores, atribuição de
  mão de obra e comissão histórica configurável. \|

| Estoque \| RN19--RN26 \| Produtos, fornecedores, entradas,
  procedência, movimentações, reservas, aplicação e devolução. \|

| Garantias \| RN27--RN29 \| Garantias de peça/serviço e ocorrências de
  garantia. \|

| Mobile mecânico \| RN30--RN32 \| Painel mobile, registros técnicos e
  acesso por QR/link com autenticação/autorização. \|

| Fotos e laudos \| RN33--RN35 \| Evidências, laudo técnico PDF e termo
  de substituição. \|

| Fiscal \| RN36--RN37 \| Separação estrutural produto/serviço e motor
  fiscal parametrizável/desacoplado. \|

| Financeiro \| RN38--RN42 \| Formas de pagamento, parcelamento,
  receber, pagar e caixa. \|

| Relatórios \| RN43--RN46 \| Operacionais, financeiros, estoque e
  exportação contábil configurável. \|

| Dashboard \| RN47 \| Indicadores gerenciais respeitando permissões. \|

| Notificações \| RN48 \| Eventos e canais
  sistema/e-mail/WhatsApp/futuros. \|

| Usuários e permissões \| RN49--RN51 \| Usuários, perfis e permissões
  configuráveis. \|

| Auditoria \| RN52 \| Registro de operações críticas e antes/depois
  quando aplicável. \|

| LGPD e privacidade \| RN53--RN54 \| Proteção de dados e links públicos
  com tokens seguros/expiráveis/revogáveis. \|

| Google Drive \| RN55--RN57 \| Armazenamento documental, organização
  automática e sincronização desacoplada. \|

| Backup \| RN58--RN59 \| Backup independente e restauração
  documentada/testada. \|

| WhatsApp \| RN60 \| Comunicação oficial e tolerância à
  indisponibilidade. \|

# 4. Requisitos não funcionais

| RNF \| Requisito \| Diretriz \|

| --- \| --- \| --- \|

| RNF01 \| Responsividade \| Smartphone, tablet, notebook e desktop. \|

| RNF02 \| Compatibilidade \| Navegadores modernos. \|

| RNF03 \| Segurança \| HTTPS, autenticação, autorização, senha segura,
  sessão, validação e proteção contra vulnerabilidades comuns. \|

| RNF04 \| Controle de acesso \| Toda API protegida valida
  autenticação/autorização; UI não é barreira de segurança. \|

| RNF05 \| Performance \| Paginação, filtros, índices e consultas
  otimizadas. \|

| RNF06 \| Escalabilidade \| Crescer usuários, clientes, veículos, OS,
  documentos e unidades. \|

| RNF07 \| Disponibilidade \| Integrações externas não derrubam o
  núcleo. \|

| RNF08 \| Auditoria \| Operações críticas rastreáveis. \|

| RNF09 \| Acessibilidade \| Boas práticas e busca de conformidade WCAG
  aplicável. \|

| RNF10 \| PWA \| Aplicação preparada para instalação como PWA. \|

# 5. Fluxos de negócio que devem orientar a implementação

## Fluxo principal

Cliente → Veículo → Agendamento → Checklist de Entrada → Diagnóstico →
Orçamento → Versionamento → Aprovação Digital → Reserva de Estoque →
Ordem de Serviço → Execução Mobile → Fotos/Evidências → Aplicação de
Peças → Conferência → Laudo → Faturamento → Pagamento → Entrega →
Histórico do Veículo → Garantia.

## Exceções obrigatórias

-   Orçamento rejeitado: registrar rejeição/motivo e encerrar ou
    revisar.

-   Alteração solicitada: gerar nova versão e exigir nova aprovação;
    nunca reaproveitar aprovação anterior.

-   Peça indisponível: OS aguarda peça, entrada/reserva e só então
    execução.

-   Peça reservada e não utilizada: devolver e recompor disponibilidade.

-   Garantia: ocorrência → análise → aprovação/rejeição → nova execução
    quando cabível → histórico.

# 6. Arquitetura .NET consolidada

A arquitetura segue a separação recomendada pelo ERN e já está criada na
Solution. O objetivo é manter regras de negócio independentes de API,
banco e integrações externas.

| Projeto \| Responsabilidade esperada \| Estado atual \|

| --- \| --- \| --- \|

| Oficina.Domain \| Entidades, enums, regras/invariantes de domínio sem
  dependência de infraestrutura. \| Criado; 58 classes de entidade e 13
  enums. \|

| Oficina.Application \| Casos de uso, contratos/DTOs, validações de
  aplicação e orquestração. \| Criado, ainda sem casos de uso funcionais
  relevantes. \|

| Oficina.Infrastructure \| Implementações de serviços externos e
  infraestrutura não persistente. \| Criado, praticamente vazio. \|

| Oficina.Persistence \| DbContext, mapeamentos EF Core,
  repositórios/infra de persistência quando necessários. \| DbContext e
  configurações criados; migrations ausentes. \|

| Oficina.Api \| Composição, endpoints/controllers, middleware,
  autenticação, Swagger. \| Program.cs + HealthController; endpoints de
  negócio ainda ausentes. \|

## Dependências observadas

-   Application → Domain.

-   Infrastructure → Application + Domain.

-   Persistence → Application + Domain.

-   Api → Application + Infrastructure + Persistence.

-   Domain não referencia os demais projetos.

Decisão: preservar a direção de dependências. Evitar colocar regras de
negócio em controllers, DbContext, integrações ou UI.

# 7. Stack e persistência

| Item \| Decisão/estado \|

| --- \| --- \|

| .NET \| net10.0 em todos os projetos. \|

| API \| ASP.NET Core Web API. \|

| ORM \| Entity Framework Core 10.0.0. \|

| Banco \| PostgreSQL via Npgsql.EntityFrameworkCore.PostgreSQL 10.0.0.
  \|

| Schema \| oficina como schema padrão no DbContext. \|

| Chaves \| Guid como Id base; BaseEntity cria Guid e CriadoEm UTC. \|

| Datas \| Predomínio de DateTimeOffset. \|

| Swagger \| Swashbuckle.AspNetCore 10.0.0 em desenvolvimento. \|

| Conexão atual \| Configuração local no appsettings; credenciais de
  desenvolvimento não devem ser usadas em produção. \|

| Migrations \| Ainda não existem no pacote analisado. \|

## Segurança de configuração

A string atual contém usuário/senha locais de desenvolvimento. Para
ambientes reais, segredos devem sair do repositório e ser fornecidos por
configuração segura (por exemplo, variáveis de ambiente/secret store).
Isso é uma recomendação técnica decorrente do RNF03; o ERN não prescreve
o mecanismo específico.

# 8. Modelo de dados / DER lógico consolidado

O ERN define as entidades conceituais e o projeto atual materializa uma
versão mais detalhada. O DER abaixo é lógico: os campos \*Id indicam
relacionamentos pretendidos. ATENÇÃO: na base atual, esses
relacionamentos ainda precisam ser explicitamente validados/configurados
no EF Core antes da migration inicial.

| Entidade \| Referências lógicas inferidas pelos campos Id \|

| --- \| --- \|

| Agendamento \| Unidade, Cliente, Veiculo, Box \|

| Arquivo \| Unidade \|

| ArquivoIntegracao \| Arquivo \|

| Auditoria \| Usuario \|

| Box \| Unidade \|

| Caixa \| Unidade \|

| CaixaMovimentacao \| Caixa, FormaPagamento \|

| CategoriaProduto \| --- \|

| CategoriaServico \| --- \|

| ChecklistEntrada \| Veiculo, Agendamento, OrdemServico, Usuario \|

| ChecklistItem \| ChecklistEntrada \|

| Cliente \| Unidade \|

| ComissaoLancamento \| OrdemServico, Funcionario \|

| ContaPagar \| Unidade, Fornecedor \|

| ContaReceber \| Unidade, Cliente, OrdemServico \|

| Contato \| Cliente \|

| Diagnostico \| OrdemServico, Funcionario \|

| Empresa \| --- \|

| Endereco \| Cliente \|

| EntradaEstoque \| Unidade, Fornecedor, Arquivo, Arquivo \|

| EntradaEstoqueItem \| EntradaEstoque, Produto \|

| Estoque \| Unidade, Produto \|

| FormaPagamento \| Unidade \|

| Fornecedor \| Unidade \|

| Foto \| Arquivo, Veiculo, OrdemServico, Diagnostico \|

| Funcionario \| Unidade \|

| Garantia \| OrdemServico, Cliente, Veiculo \|

| GarantiaPeca \| Garantia, Produto \|

| GarantiaServico \| Garantia, Servico \|

| IntegracaoLog \| --- \|

| Laudo \| OrdemServico, Arquivo \|

| LinkAcesso \| Orcamento, OrcamentoVersao, OrdemServico \|

| MovimentacaoEstoque \| Estoque, OrdemServico, Produto, Usuario \|

| Notificacao \| Usuario \|

| OcorrenciaGarantia \| Garantia \|

| Orcamento \| Unidade, Cliente, Veiculo \|

| OrcamentoAprovacao \| OrcamentoVersao, Cliente \|

| OrcamentoAprovacaoItem \| OrcamentoAprovacao, OrcamentoItem \|

| OrcamentoItem \| OrcamentoVersao, Servico, Produto \|

| OrcamentoVersao \| Orcamento \|

| OrdemServico \| Unidade, Cliente, Veiculo, OrcamentoVersao \|

| OrdemServicoFuncionario \| OrdemServico, Funcionario \|

| OrdemServicoItem \| OrdemServico, Servico, Produto \|

| OrdemServicoStatusHistorico \| OrdemServico, Usuario \|

| Pagamento \| Parcela, FormaPagamento \|

| Parcela \| ContaReceber \|

| Perfil \| --- \|

| PerfilPermissao \| Perfil, Permissao \|

| Permissao \| --- \|

| Produto \| CategoriaProduto \|

| ProdutoFornecedor \| Produto, Fornecedor \|

| ReservaEstoque \| OrdemServico, Produto \|

| Servico \| CategoriaServico \|

| Unidade \| Empresa \|

| Usuario \| Unidade, Funcionario \|

| UsuarioPerfil \| Usuario, Perfil \|

| Veiculo \| Cliente \|

# 9. Catálogo completo das entidades atuais

Todas herdam BaseEntity, salvo a própria BaseEntity. Campos herdados:
Id: Guid, CriadoEm: DateTimeOffset, AtualizadoEm: DateTimeOffset?. A
tabela abaixo registra o estado exato das classes do pacote analisado.

| Entidade \| Campos declarados \|

| --- \| --- \|

| Agendamento \| UnidadeId: Guid; ClienteId: Guid; VeiculoId: Guid;
  BoxId: Guid?; Inicio: DateTimeOffset; Fim: DateTimeOffset; Motivo:
  string?; Status: string; Observacoes: string? \|

| Arquivo \| UnidadeId: Guid; Nome: string; Caminho: string;
  ContentType: string?; TamanhoBytes: long?; Hash: string?; Tipo:
  TipoArquivo; DriveFileId: string? \|

| ArquivoIntegracao \| ArquivoId: Guid; Provedor: string;
  IdentificadorExterno: string; Status: string; UltimaSincronizacaoEm:
  DateTimeOffset? \|

| Auditoria \| UsuarioId: Guid?; Tipo: TipoAuditoria; Entidade: string;
  EntidadeId: Guid?; DadosAntes: string?; DadosDepois: string?; Ip:
  string?; CriadaEm: DateTimeOffset \|

| Box \| UnidadeId: Guid; Nome: string; Codigo: string; Tipo: string?;
  Ativo: bool \|

| Caixa \| UnidadeId: Guid; DataAbertura: DateTimeOffset;
  DataFechamento: DateTimeOffset?; SaldoInicial: decimal; SaldoFinal:
  decimal?; Status: string \|

| CaixaMovimentacao \| CaixaId: Guid; FormaPagamentoId: Guid?; Tipo:
  string; Valor: decimal; Descricao: string?; CriadoEm: DateTimeOffset
  \|

| CategoriaProduto \| Nome: string; Descricao: string?; Ativa: bool \|

| CategoriaServico \| Nome: string; Descricao: string?; Ativa: bool \|

| ChecklistEntrada \| VeiculoId: Guid; AgendamentoId: Guid?;
  OrdemServicoId: Guid?; KmEntrada: decimal?; CombustivelPercentual:
  decimal?; Observacoes: string?; CriadoPorUsuarioId: Guid? \|

| ChecklistItem \| ChecklistEntradaId: Guid; Descricao: string;
  Conforme: bool; Observacao: string? \|

| Cliente \| UnidadeId: Guid; TipoPessoa: TipoPessoa; Nome: string;
  Documento: string?; Email: string?; Observacoes: string?; Ativo: bool
  \|

| ComissaoLancamento \| OrdemServicoId: Guid; FuncionarioId: Guid; Tipo:
  TipoComissao; BaseCalculo: decimal; Percentual: decimal; Valor:
  decimal; GeradoEm: DateTimeOffset; PagoEm: DateTimeOffset? \|

| ContaPagar \| UnidadeId: Guid; FornecedorId: Guid?; Descricao: string;
  ValorOriginal: decimal; ValorAberto: decimal; Vencimento:
  DateTimeOffset; Status: StatusParcela \|

| ContaReceber \| UnidadeId: Guid; ClienteId: Guid?; OrdemServicoId:
  Guid?; Descricao: string; ValorOriginal: decimal; ValorAberto:
  decimal; Vencimento: DateTimeOffset; Status: StatusParcela \|

| Contato \| ClienteId: Guid; Tipo: TipoContato; Valor: string;
  Principal: bool \|

| Diagnostico \| OrdemServicoId: Guid; FuncionarioId: Guid?; Descricao:
  string; Recomendacoes: string?; CriadoEm: DateTimeOffset \|

| Empresa \| RazaoSocial: string; NomeFantasia: string?; Cnpj: string?;
  InscricaoEstadual: string?; Ativa: bool \|

| Endereco \| ClienteId: Guid; Logradouro: string; Numero: string?;
  Complemento: string?; Bairro: string?; Cidade: string; Estado: string;
  Cep: string?; Principal: bool \|

| EntradaEstoque \| UnidadeId: Guid; FornecedorId: Guid?;
  NumeroDocumento: string?; ChaveNfe: string?; DataEntrada:
  DateTimeOffset; ValorTotal: decimal; XmlArquivoId: Guid?;
  PdfArquivoId: Guid? \|

| EntradaEstoqueItem \| EntradaEstoqueId: Guid; ProdutoId: Guid;
  Quantidade: decimal; CustoUnitario: decimal; Lote: string?;
  GarantiaDias: int? \|

| Estoque \| UnidadeId: Guid; ProdutoId: Guid; QuantidadeDisponivel:
  decimal; QuantidadeReservada: decimal; Localizacao: string? \|

| FormaPagamento \| UnidadeId: Guid; Nome: string; Tipo: string; Ativa:
  bool \|

| Fornecedor \| UnidadeId: Guid; RazaoSocial: string; NomeFantasia:
  string?; Cnpj: string?; Email: string?; Telefone: string?; Ativo: bool
  \|

| Foto \| ArquivoId: Guid; VeiculoId: Guid?; OrdemServicoId: Guid?;
  DiagnosticoId: Guid?; Descricao: string?; TiradaEm: DateTimeOffset \|

| Funcionario \| UnidadeId: Guid; Nome: string; Documento: string?;
  Email: string?; Telefone: string?; PercentualComissaoPadrao: decimal;
  Ativo: bool \|

| Garantia \| OrdemServicoId: Guid; ClienteId: Guid; VeiculoId: Guid;
  Tipo: TipoGarantia; Status: StatusGarantia; InicioEm: DateTimeOffset;
  FimEm: DateTimeOffset; Observacoes: string? \|

| GarantiaPeca \| GarantiaId: Guid; ProdutoId: Guid; Quantidade:
  decimal; DiasGarantia: int \|

| GarantiaServico \| GarantiaId: Guid; ServicoId: Guid; DiasGarantia:
  int \|

| IntegracaoLog \| Provedor: string; Operacao: string; Sucesso: bool;
  Mensagem: string?; ReferenciaExterna: string?; CriadoEm:
  DateTimeOffset \|

| Laudo \| OrdemServicoId: Guid; ArquivoId: Guid; Titulo: string;
  GeradoEm: DateTimeOffset \|

| LinkAcesso \| OrcamentoId: Guid?; OrcamentoVersaoId: Guid?;
  OrdemServicoId: Guid?; TokenHash: string; ExpiraEm: DateTimeOffset;
  RevogadoEm: DateTimeOffset?; UltimoAcessoEm: DateTimeOffset? \|

| MovimentacaoEstoque \| EstoqueId: Guid; OrdemServicoId: Guid?;
  ProdutoId: Guid; Tipo: TipoMovimentacaoEstoque; Quantidade: decimal;
  CustoUnitario: decimal?; DocumentoReferencia: string?; Observacao:
  string?; UsuarioId: Guid?; MovimentadaEm: DateTimeOffset \|

| Notificacao \| UsuarioId: Guid?; Tipo: TipoNotificacao; Titulo:
  string; Mensagem: string; LidaEm: DateTimeOffset?; CriadaEm:
  DateTimeOffset \|

| OcorrenciaGarantia \| GarantiaId: Guid; Descricao: string; AbertaEm:
  DateTimeOffset; EncerradaEm: DateTimeOffset?; Status: string;
  Resolucao: string? \|

| Orcamento \| UnidadeId: Guid; ClienteId: Guid; VeiculoId: Guid;
  Numero: long; Status: StatusOrcamento; ValidadeEm: DateTimeOffset?;
  VersaoAtualNumero: int; Observacoes: string? \|

| OrcamentoAprovacao \| OrcamentoVersaoId: Guid; ClienteId: Guid;
  Aprovado: bool; AprovadoEm: DateTimeOffset; Ip: string?; UserAgent:
  string?; Observacao: string? \|

| OrcamentoAprovacaoItem \| OrcamentoAprovacaoId: Guid; OrcamentoItemId:
  Guid; Aprovado: bool \|

| OrcamentoItem \| OrcamentoVersaoId: Guid; ServicoId: Guid?; ProdutoId:
  Guid?; Descricao: string; Quantidade: decimal; ValorUnitario: decimal;
  Desconto: decimal; Total: decimal; Aprovado: bool \|

| OrcamentoVersao \| OrcamentoId: Guid; Numero: int; Status:
  StatusOrcamento; Subtotal: decimal; Desconto: decimal; Total: decimal;
  Observacoes: string?; Imutavel: bool \|

| OrdemServico \| UnidadeId: Guid; ClienteId: Guid; VeiculoId: Guid;
  OrcamentoVersaoId: Guid?; Numero: long; Status: StatusOrdemServico;
  AbertaEm: DateTimeOffset; ConcluidaEm: DateTimeOffset?; EntregueEm:
  DateTimeOffset?; Observacoes: string? \|

| OrdemServicoFuncionario \| OrdemServicoId: Guid; FuncionarioId: Guid;
  PercentualComissao: decimal; Funcao: string? \|

| OrdemServicoItem \| OrdemServicoId: Guid; ServicoId: Guid?; ProdutoId:
  Guid?; Descricao: string; Quantidade: decimal; ValorUnitario: decimal;
  Desconto: decimal; Total: decimal; Tipo: string \|

| OrdemServicoStatusHistorico \| OrdemServicoId: Guid; StatusAnterior:
  StatusOrdemServico?; StatusNovo: StatusOrdemServico; AlteradoEm:
  DateTimeOffset; UsuarioId: Guid?; Observacao: string? \|

| Pagamento \| ParcelaId: Guid; FormaPagamentoId: Guid; Valor: decimal;
  PagoEm: DateTimeOffset; TransacaoReferencia: string?; Observacao:
  string? \|

| Parcela \| ContaReceberId: Guid; Numero: int; Vencimento:
  DateTimeOffset; Valor: decimal; ValorAberto: decimal; Status:
  StatusParcela \|

| Perfil \| Nome: string; Descricao: string?; Ativo: bool \|

| PerfilPermissao \| PerfilId: Guid; PermissaoId: Guid \|

| Permissao \| Codigo: string; Descricao: string? \|

| Produto \| CategoriaProdutoId: Guid?; Codigo: string; Nome: string;
  Descricao: string?; UnidadeMedida: string; PrecoVenda: decimal;
  CustoMedio: decimal; EstoqueMinimo: decimal; Ativo: bool \|

| ProdutoFornecedor \| ProdutoId: Guid; FornecedorId: Guid;
  CodigoFornecedor: string?; PrecoUltimaCompra: decimal?;
  PrazoGarantiaDias: int? \|

| ReservaEstoque \| OrdemServicoId: Guid; ProdutoId: Guid; Quantidade:
  decimal; Status: string; ReservadaEm: DateTimeOffset; LiberadaEm:
  DateTimeOffset? \|

| Servico \| CategoriaServicoId: Guid?; Codigo: string; Nome: string;
  Descricao: string?; PrecoPadrao: decimal; CustoPadrao: decimal?;
  Ativo: bool \|

| Unidade \| EmpresaId: Guid; Nome: string; Codigo: string; Cnpj:
  string?; Telefone: string?; Email: string?; Ativa: bool \|

| Usuario \| UnidadeId: Guid; FuncionarioId: Guid?; Nome: string; Email:
  string; SenhaHash: string; Ativo: bool; UltimoLoginEm: DateTimeOffset?
  \|

| UsuarioPerfil \| UsuarioId: Guid; PerfilId: Guid \|

| Veiculo \| ClienteId: Guid; Placa: string; Renavam: string?; Chassi:
  string?; Marca: string; Modelo: string; Ano: int?; Cor: string?; Tipo:
  TipoVeiculo; KmAtual: decimal?; Observacoes: string? \|

# 10. Enumerações atuais

| Enum \| Valores atuais \|

| --- \| --- \|

| StatusGarantia \| Ativa, AguardandoAnalise, Aprovada, Rejeitada,
  Concluida, Cancelada \|

| StatusOrcamento \| Rascunho, Enviado, AguardandoAprovacao, Aprovado,
  ParcialmenteAprovado, Rejeitado, Expirado, Cancelado \|

| StatusOrdemServico \| AguardandoDiagnostico, EmDiagnostico,
  AguardandoAprovacao, Aprovada, AguardandoPecas, EmExecucao,
  AguardandoConferencia, Concluida, AguardandoPagamento, Entregue,
  Cancelada, Suspensa, AguardandoCliente, AguardandoFornecedor,
  EmGarantia \|

| StatusParcela \| Aberta, ParcialmentePaga, Paga, Vencida, Cancelada \|

| TipoArquivo \| Documento, Foto, Laudo, XmlFiscal, PdfFiscal, Outro \|

| TipoAuditoria \| Criacao, Alteracao, Exclusao, Cancelamento, Reversao,
  Acesso, Login, Outro \|

| TipoComissao \| Servico, Peca, OrdemServico \|

| TipoContato \| Telefone, Celular, WhatsApp, Email, Outro \|

| TipoGarantia \| Peca, Servico, Mista \|

| TipoMovimentacaoEstoque \| Entrada, Reserva, Aplicacao, Devolucao,
  Ajuste, Saida \|

| TipoNotificacao \| Sistema, Estoque, Financeiro, Agenda, OrdemServico,
  Garantia \|

| TipoPessoa \| Fisica, Juridica \|

| TipoVeiculo \| Carro, Moto, Caminhao, Utilitario, Outro \|

Observação: alguns estados do domínio ainda estão modelados como string
(por exemplo, Agendamento.Status, ReservaEstoque.Status, Caixa.Status e
OcorrenciaGarantia.Status). Isso é estado atual do código, não uma
exigência do ERN. Deve ser avaliado antes de congelar o modelo físico.

# 11. Índices e unicidades já configurados

| Entidade \| Restrição observada \|

| --- \| --- \|

| Empresa \| Cnpj único. \|

| Fornecedor \| Cnpj único. \|

| Veiculo \| Placa única globalmente no modelo atual. \|

| Usuario \| Email único globalmente no modelo atual. \|

| Produto \| Codigo único globalmente no modelo atual. \|

| Servico \| Codigo único globalmente no modelo atual. \|

| LinkAcesso \| TokenHash único. \|

| Estoque \| (UnidadeId, ProdutoId) único. \|

| Orcamento \| (UnidadeId, Numero) único. \|

| OrdemServico \| (UnidadeId, Numero) único. \|

A validar: unicidades globais de placa, e-mail, código de
produto/serviço e CNPJ precisam ser confrontadas com o comportamento
desejado em cenário multiempresa/multiunidade. Não alterar
automaticamente: decidir antes da migration inicial.

# 12. Regras de negócio críticas a implementar no domínio/aplicação

| Regra \| Comportamento obrigatório \|

| --- \| --- \|

| Orçamento versionado \| Alteração relevante gera nova versão; versões
  anteriores nunca são sobrescritas. \|

| Aprovação vinculada à versão \| A aprovação deve referenciar
  exatamente a versão apresentada; nova versão exige nova aprovação. \|

| Aprovação parcial \| Registrar item a item quando habilitada pela
  oficina. \|

| OS como máquina de estados \| Bloquear transições incompatíveis;
  exceções exigem permissão, justificativa e auditoria. \|

| Histórico da OS \| Toda mudança relevante de status deve permanecer
  rastreável. \|

| Estoque disponível \| Reserva reduz disponível sem necessariamente
  baixar estoque físico; aplicação efetiva gera movimentação/baixa. \|

| Movimentação de estoque \| Toda movimentação gera histórico com
  produto, quantidade, data, usuário, origem/destino, OS/motivo quando
  aplicável. \|

| Financeiro \| Pagamentos/parcelas/estornos devem preservar histórico;
  não confundir cancelamento, exclusão e estorno. \|

| Comissão histórica \| Percentual aplicado deve ser preservado para
  evitar recálculo retroativo indevido. \|

| Garantia \| Separar garantia da peça e do serviço; prazos
  parametrizáveis; não presumir automaticamente menor/maior prazo. \|

| Links públicos \| Token seguro, expiração, revogação, controle de
  versão, invalidação e registro de acesso; não expor IDs internos
  desnecessários. \|

| Auditoria \| Alteração de preço, cancelamento de OS, pagamento,
  estoque, aprovação, permissão e operações administrativas são eventos
  críticos. \|

| Exclusão lógica/histórico \| Registros críticos não devem ser
  fisicamente apagados de modo indiscriminado. \|

| Produto x serviço \| Separação estrutural deve existir em orçamento,
  OS, financeiro, fiscal e relatórios. \|

| Integrações \| Falha de Drive/WhatsApp/fiscal não pode impedir
  operação básica. \|

| Permissões \| Autorização deve ser validada na API/caso de uso, não
  apenas escondendo controles na interface. \|

# 13. Estado atual do código

| Área \| Já existe \| Ainda falta \|

| --- \| --- \| --- \|

| Solution/arquitetura \| 5 projetos separados e referências coerentes.
  \| Completar Application/Infrastructure e políticas arquiteturais. \|

| Domínio \| Entidades e enums abrangentes. \| Invariantes, métodos de
  domínio, validações e políticas. \|

| Persistência \| DbContext, schema oficina e configurações de
  propriedades/índices. \| Relacionamentos/FKs explícitos ou validados,
  delete behaviors, constraints, migrations e testes do modelo. \|

| API \| Bootstrap, Swagger e HealthController com CanConnectAsync. \|
  Endpoints/casos de uso de negócio, tratamento de erros,
  autenticação/autorização, versionamento/contratos. \|

| Segurança \| HTTPS redirection. \| Identidade/login, hashing/gestão de
  credenciais, autorização, tokens, rate limits/políticas conforme
  desenho. \|

| Testes \| Nenhum projeto de testes identificado. \| Unitários,
  integração, persistência e fluxos críticos. \|

| Integrações \| Entidades de arquivo/integracao e campos Drive. \|
  Adapters/filas/retry/sincronização e provedores reais. \|

| Frontend/PWA \| Não está no ZIP analisado. \| Definir/implementar após
  contratos e casos de uso prioritários. \|

# 14. Lacunas técnicas encontradas antes da primeira migration

-   Validar e configurar os relacionamentos EF Core e chaves
    estrangeiras. Os campos ...Id demonstram intenção, mas não foram
    encontrados mapeamentos HasOne/HasMany/HasForeignKey e as entidades
    não expõem navegações.

-   Definir DeleteBehavior por agregado/relação para evitar cascatas que
    destruam histórico crítico.

-   Revisar comprimentos de campos. Muitos textos estão uniformemente em
    255 caracteres, inclusive observações, auditoria antes/depois,
    diagnóstico e mensagens, o que pode ser insuficiente.

-   Definir precisão SQL para valores decimal (dinheiro, quantidade, km,
    percentuais). O código atual não demonstra configuração explícita de
    precision.

-   Revisar unicidades no contexto multiempresa/multiunidade antes de
    criar índices definitivos.

-   Decidir quais status string devem se tornar enums/entidades
    parametrizáveis e quais realmente precisam permanecer configuráveis.

-   Definir constraints de domínio no banco quando úteis: valores não
    negativos, datas coerentes, limites de percentual etc.

-   Revisar redundâncias temporais: BaseEntity já possui CriadoEm e
    algumas entidades também declaram CriadoEm próprio.

-   Definir estratégia de concorrência/transação para estoque, aprovação
    e financeiro.

-   Criar migration InitialCreate somente depois dessas validações,
    evitando consolidar um modelo físico prematuro.

Essas lacunas são resultado da inspeção do pacote atual e não significam
erro no ERN. São itens de engenharia necessários para transformar o
modelo estrutural em banco confiável.

# 15. Decisões que NÃO devem ser alteradas sem motivo

| Decisão protegida \| Motivo \|

| --- \| --- \|

| PostgreSQL + EF Core \| Stack de persistência já adotada no projeto.
  \|

| Arquitetura modular em projetos separados \|
  Domain/Application/Infrastructure/Persistence/Api deve permanecer
  desacoplada. \|

| Guid como identidade base \| Já disseminado por todas as entidades;
  mudança exige impacto/migração justificada. \|

| Schema oficina \| Definido no DbContext. \|

| Multiempresa/multiunidade preparada desde a base \| Não remover
  Empresa/Unidade para "simplificar" o MVP. \|

| Versionamento de orçamento \| Não substituir por edição destrutiva de
  um único orçamento. \|

| Aprovação ligada à versão e itens \| Não reduzir a um único booleano
  global que perca evidência. \|

| Históricos/auditoria \| Não apagar históricos para simplificar CRUD.
  \|

| Máquina de estados da OS \| Não permitir alterações arbitrárias de
  status. \|

| Estoque com reserva e movimentação \| Não representar estoque apenas
  por um saldo mutável sem histórico. \|

| Separação produto/serviço \| Necessária inclusive para fiscal e
  relatórios. \|

| Integrações desacopladas \| Drive/WhatsApp/fiscal não devem entrar
  diretamente no domínio nem bloquear núcleo. \|

| Mobile-first para mecânico e desktop para recepção \| Diretriz de UX
  do ERN. \|

| Segurança/autorização na API \| Não confiar em ocultação de
  botões/telas. \|

| Exclusão, cancelamento, estorno, inativação e arquivamento são
  conceitos diferentes \| Não unificar em um delete genérico. \|

| Funcionalidades futuras fora do MVP \| Não ampliar escopo com OCR, IA,
  fidelidade, app nativo etc. antes do núcleo. \|

# 16. Pontos que PODEM ser alterados com validação técnica

-   Nomes físicos de tabelas/colunas e convenções, pois o ERN permite
    definição no modelo físico.

-   Tamanhos de VARCHAR e tipos SQL específicos.

-   Uso de enum versus tabela/status parametrizável onde o ERN não fixa
    a implementação.

-   Índices adicionais para performance.

-   DTOs, bibliotecas de validação, mediator/repository patterns e
    organização interna de Application, desde que não criem acoplamento
    desnecessário.

-   Estratégia de autenticação e provedor de identidade, desde que
    cumpra RNF03/RNF04.

-   Mecanismo de fila/retry para integrações, mantendo desacoplamento.

-   Estrutura do frontend, desde que preserve responsividade,
    acessibilidade, PWA e perfis de uso.

# 17. MVP e ordem recomendada de implementação

| Fase ERN \| Escopo \|

| --- \| --- \|

| 1 --- Núcleo \| Autenticação, usuários, clientes, veículos, serviços,
  produtos, fornecedores. \|

| 2 --- Operação \| Agenda, checklist, orçamento, aprovação, OS, status.
  \|

| 3 --- Oficina \| Painel mobile, diagnóstico, fotos, serviços, peças,
  estoque, reserva. \|

| 4 --- Finalização \| Laudo, garantia, faturamento, pagamentos,
  histórico. \|

| 5 --- Gestão \| Dashboard, relatórios, comissões, contas a pagar e
  receber. \|

| 6 --- Integrações \| Google Drive, WhatsApp, e-mail e fiscal. \|

## Ajuste técnico antes da Fase 1

Antes de implementar CRUDs/casos de uso no Codex, executar uma etapa 0
de consolidação do modelo físico: relacionamentos/FKs, delete behaviors,
precisões, índices multiunidade, constraints e migration inicial. Essa
etapa não muda o ERN; evita construir casos de uso sobre um banco ainda
não congelado.

# 18. Próximos passos para o Codex

-   Ler este documento e o ERN v4.0 antes de editar o código.

-   Fazer auditoria do modelo EF Core contra o catálogo de entidades e
    regras críticas; não criar migration ainda.

-   Propor apenas as correções necessárias ao modelo físico, com lista
    de impactos e sem remover entidades/regras.

-   Configurar relacionamentos/FKs, delete behaviors, precisão decimal,
    tamanhos adequados, índices e constraints acordadas.

-   Adicionar testes de modelo/persistência que provem unicidades, FKs e
    comportamentos críticos.

-   Gerar e revisar a migration InitialCreate; inspecionar o SQL antes
    de aplicar.

-   Criar banco PostgreSQL de desenvolvimento e validar health check +
    schema.

-   Implementar Fase 1 do MVP por casos de uso verticais pequenos,
    começando por autenticação/usuários e cadastros fundamentais.

-   Adicionar testes unitários e de integração junto de cada caso de
    uso, não ao final.

-   Avançar às fases seguintes somente após critérios de aceitação do
    módulo anterior.

# 19. Critérios de aceite gerais do produto

O marco funcional mínimo definido no ERN é conseguir executar, com
consistência e rastreabilidade: cadastrar cliente → cadastrar veículo →
criar orçamento → enviar link → cliente aprovar → criar OS → reservar
peças → mecânico executar → registrar fotos → finalizar serviços → gerar
laudo → registrar pagamento → entregar veículo → atualizar histórico.

Esse fluxo deve ser usado futuramente como base para testes de aceitação
ponta a ponta.

# 20. Funcionalidades futuras --- fora do núcleo inicial

-   Aplicativo nativo.

-   Integração direta com fornecedores e consulta automática de peças.

-   Leitura automatizada de documentos/OCR.

-   IA para classificação de documentos.

-   Lembretes/campanhas/fidelidade/pesquisa de satisfação.

-   Assinatura digital avançada.

-   Múltiplas unidades em operação efetiva (a arquitetura já deve estar
    preparada).

-   Integração com equipamentos de diagnóstico.

-   Indicadores avançados.

Não antecipar essas funcionalidades se isso atrasar o ciclo operacional
obrigatório.

# 21. Checklist documental antes de iniciar código funcional

| Artefato \| Status \|

| --- \| --- \|

| ERN v4.0 consolidado \| OK \|

| Objetivo e escopo \| OK \|

| Princípios e RN/RNF \| OK \|

| Arquitetura .NET \| OK \|

| Stack PostgreSQL + EF Core \| OK \|

| Catálogo de entidades \| OK \|

| DER lógico por referências \| OK --- requer validação física \|

| Decisões protegidas \| OK \|

| Estado atual do código \| OK \|

| Lacunas pré-migration \| OK \|

| Plano de implementação \| OK \|

| Modelo físico/FKs/delete behaviors \| PENDENTE --- executar no Codex
  \|

| Migration inicial revisada \| PENDENTE \|

| Contrato de API detalhado \| PENDENTE por fase/caso de uso \|

| Casos de uso detalhados/aceites por módulo \| PENDENTE por fase \|

# 22. Instrução de handoff para agente de código

Use o ERN v4.0 e esta Documentação Mestra como fontes de verdade.
Preserve as decisões marcadas como consolidadas/protegidas. Antes de
modificar arquitetura, entidades centrais, estratégia de persistência ou
regras críticas, apresente o motivo, impacto e testes necessários. Não
gere a migration inicial até validar relacionamentos, delete behaviors,
precisão decimal, comprimentos, unicidades multiunidade e constraints.
Implemente em etapas pequenas, mantendo build verde e testes junto com
cada mudança. Não amplie o escopo com funcionalidades futuras.

# Apêndice A --- Relação ERN × implementação estrutural

| Área ERN \| Entidades atuais \| Situação \|

| --- \| --- \| --- \|

| Clientes/veículos \| Cliente, Endereco, Contato, Veiculo \| Base
  estrutural criada. \|

| Agenda/checklist \| Agendamento, Box, ChecklistEntrada, ChecklistItem
  \| Base estrutural criada. \|

| Orçamento/aprovação \| Orcamento, OrcamentoVersao, OrcamentoItem,
  OrcamentoAprovacao, OrcamentoAprovacaoItem, LinkAcesso \| Base
  estrutural criada; regras ainda pendentes. \|

| OS/oficina \| OrdemServico, OrdemServicoItem,
  OrdemServicoStatusHistorico, Diagnostico, OrdemServicoFuncionario \|
  Base estrutural criada; transições pendentes. \|

| Estoque \| Produto, CategoriaProduto, Fornecedor, ProdutoFornecedor,
  Estoque, ReservaEstoque, MovimentacaoEstoque, EntradaEstoque,
  EntradaEstoqueItem \| Base estrutural criada; transações pendentes. \|

| Garantia \| Garantia, GarantiaPeca, GarantiaServico,
  OcorrenciaGarantia \| Base estrutural criada. \|

| Documentos \| Arquivo, Foto, Laudo, ArquivoIntegracao, IntegracaoLog
  \| Base estrutural criada; integrações pendentes. \|

| Financeiro \| ContaReceber, Parcela, Pagamento, ContaPagar,
  FormaPagamento, Caixa, CaixaMovimentacao \| Base estrutural criada;
  regras pendentes. \|

| Comissão \| ComissaoLancamento + percentuais em
  Funcionario/OrdemServicoFuncionario \| Base estrutural
  parcial/coerente; regras pendentes. \|

| Acesso \| Usuario, Perfil, Permissao, UsuarioPerfil, PerfilPermissao
  \| Base estrutural criada; autenticação/autorização pendentes. \|

| Auditoria/notificação \| Auditoria, Notificacao \| Base estrutural
  criada; captura automática/eventos pendentes. \|

| Multiempresa \| Empresa, Unidade \| Criado e deve ser preservado. \|

# Apêndice B --- Observações de consistência documental

-   O ERN lista "Comissao" e "ComissaoLancamento"; o código atual possui
    ComissaoLancamento, mas não uma entidade separada Comissao. Isso
    deve ser tratado como diferença de modelagem, não automaticamente
    como ausência, pois a regra pode ser representada por
    configuração/percentuais. Validar antes de criar nova entidade.

-   O ERN cita OrdemServicoStatus e OrdemServicoHistorico; o código
    atual concentra histórico em OrdemServicoStatusHistorico e o status
    corrente em OrdemServico.Status. Essa é uma modelagem possível,
    desde que preserve transições e auditoria.

-   O ERN cita Documento e Arquivo; o código atual possui
    Arquivo/Foto/Laudo e integração. Validar se Documento precisa
    existir como entidade própria ou se Arquivo + metadados cobre o
    requisito.

-   O ERN permite que nomes definitivos de tabelas sejam definidos no
    modelo físico; portanto, nomes C# atuais não são obrigação de
    nomenclatura SQL.

-   Não foi encontrado frontend no ZIP; portanto, nenhuma decisão
    concreta de framework frontend foi consolidada por esta análise. O
    ERN exige Web Responsiva/PWA, mas não define tecnologia frontend
    específica.

# Fim da documentação mestra

Próximo marco: consolidar o modelo físico no Codex e somente então
gerar/revisar a migration InitialCreate.
