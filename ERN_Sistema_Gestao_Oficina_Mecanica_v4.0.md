DOCUMENTO DE ESPECIFICAÇÃO DE REQUISITOS DE NEGÓCIO --- ERN

Projeto: Sistema de Gestão para Oficina Mecânica

Versão: 4.0

Data: Setembro de 2026

Status: Especificação Consolidada para Desenvolvimento

Plataforma: Web Responsiva / PWA

Backend: .NET / C#

Banco de Dados: Relacional

Integrações previstas: Google Drive, WhatsApp, E-mail e serviços fiscais

1.  VISÃO GERAL

O presente documento define os requisitos de negócio, regras
operacionais e requisitos não funcionais para o desenvolvimento de um
sistema web de gestão destinado a oficinas mecânicas.

O sistema deverá centralizar o ciclo operacional da oficina, desde o
primeiro atendimento e cadastro do veículo até orçamento, aprovação
digital, ordem de serviço, diagnóstico, execução dos serviços, controle
de peças, faturamento, pagamento, entrega, garantia e histórico de
manutenção.

A solução deverá priorizar:

-   mobilidade;

-   redução de processos em papel;

-   rastreabilidade;

-   segurança das informações;

-   facilidade de uso;

-   automação de tarefas;

-   controle financeiro;

-   controle de estoque;

-   histórico completo dos veículos;

-   integração com serviços externos;

-   arquitetura preparada para crescimento futuro.

O sistema deverá funcionar adequadamente em computadores, tablets e
smartphones.

2.  OBJETIVOS DO SISTEMA

O sistema deverá:

1.  Centralizar os dados de clientes e veículos.

2.  Digitalizar o processo de orçamento.

3.  Permitir aprovação remota de orçamentos.

4.  Controlar integralmente as Ordens de Serviço.

5.  Permitir operação mobile para mecânicos.

6.  Registrar fotos e evidências dos serviços.

7.  Controlar estoque e peças vinculadas às OS.

8.  Rastrear fornecedores e garantias.

9.  Automatizar cálculo de comissões.

10. Controlar recebimentos e pagamentos.

11. Gerar documentos e relatórios.

12. Manter histórico completo dos veículos.

13. Permitir auditoria das operações.

14. Proteger dados pessoais e operacionais.

15. Integrar documentos ao Google Drive.

16. Preparar a aplicação para futuras integrações fiscais e de
    comunicação.

17. Permitir futura expansão para múltiplas unidades.

18. PRINCÍPIOS DE NEGÓCIO

3.1 Rastreabilidade

Operações relevantes deverão registrar usuário, data, hora e contexto da
operação.

3.2 Integridade

Registros financeiros, fiscais, estoque, aprovações e OS não deverão ser
apagados de maneira que comprometa o histórico.

3.3 Parametrização

Regras que possam variar entre oficinas ou ao longo do tempo deverão ser
configuráveis.

3.4 Segurança

O acesso às informações deverá obedecer ao perfil e às permissões do
usuário.

3.5 Mobile First para operação de oficina

As funcionalidades utilizadas diretamente pelos mecânicos deverão ser
projetadas prioritariamente para smartphones.

3.6 Desacoplamento

Integrações externas, como Google Drive, WhatsApp e serviços fiscais,
deverão ser desacopladas do núcleo do sistema.

4.  MÓDULO DE CLIENTES E VEÍCULOS

RN01 --- Cadastro de Clientes

O sistema deverá permitir o cadastro, consulta, alteração e inativação
de clientes.

Dados previstos:

-   nome/razão social;

-   CPF/CNPJ;

-   telefone;

-   WhatsApp;

-   e-mail;

-   endereço;

-   cidade;

-   estado;

-   CEP;

-   observações;

-   situação cadastral;

-   data de cadastro.

O sistema deverá permitir a associação de um ou mais veículos ao mesmo
cliente.

RN02 --- Cadastro de Veículos

Cada veículo deverá estar vinculado a um cliente.

Dados previstos:

-   placa;

-   marca;

-   modelo;

-   versão;

-   ano de fabricação;

-   ano/modelo;

-   cor;

-   combustível;

-   quilometragem;

-   chassi/VIN, quando aplicável;

-   observações;

-   data de cadastro.

O sistema deverá impedir duplicidade indevida de veículos.

RN03 --- Histórico do Veículo

O sistema deverá manter o histórico de manutenção do veículo.

O histórico deverá apresentar, quando disponível:

-   data;

-   quilometragem;

-   serviços realizados;

-   peças aplicadas;

-   valores;

-   OS relacionada;

-   garantias;

-   observações;

-   fotos;

-   laudos.

O histórico não deverá ser perdido quando uma OS for encerrada.

5.  MÓDULO DE ATENDIMENTO E AGENDAMENTO

RN04 --- Agendamento

O sistema deverá permitir o agendamento de serviços.

O agendamento poderá conter:

-   cliente;

-   veículo;

-   serviço previsto;

-   data;

-   horário;

-   duração estimada;

-   responsável;

-   box;

-   observações;

-   status.

Status sugeridos:

-   Agendado;

-   Confirmado;

-   Em atendimento;

-   Concluído;

-   Cancelado;

-   Não compareceu.

RN05 --- Controle de Boxes

A oficina poderá cadastrar seus boxes/elevadores.

Cada box deverá possuir situação:

-   Livre;

-   Reservado;

-   Em uso;

-   Em manutenção;

-   Indisponível.

O sistema deverá evitar conflitos de utilização.

RN06 --- Checklist de Entrada

No recebimento do veículo, o sistema deverá permitir o registro de
checklist.

Itens possíveis:

-   estado da lataria;

-   riscos;

-   amassados;

-   vidros;

-   pneus;

-   rodas;

-   estepe;

-   ferramentas;

-   objetos internos;

-   combustível;

-   quilometragem;

-   acessórios;

-   outras observações.

O checklist poderá conter fotografias.

6.  MÓDULO DE ORÇAMENTO

RN07 --- Pré-Orçamento

O sistema deverá permitir a criação de orçamento preliminar antes da
execução do serviço.

O orçamento poderá conter:

-   serviços;

-   peças;

-   quantidade;

-   preço unitário;

-   desconto;

-   observações;

-   diagnóstico preliminar;

-   fotografias;

-   validade do orçamento.

O orçamento deverá separar valores de produtos e serviços.

RN08 --- Versionamento do Orçamento

Toda alteração relevante após a criação do orçamento deverá gerar uma
nova versão.

Exemplo:

Orçamento 1001 --- Versão 1

R\$ 1.500,00

Orçamento 1001 --- Versão 2

R\$ 1.250,00

Cada versão deverá manter:

-   data;

-   usuário;

-   itens;

-   quantidades;

-   preços;

-   descontos;

-   observações;

-   valor total;

-   situação.

Versões anteriores não deverão ser sobrescritas.

RN09 --- Aprovação Digital

O sistema deverá gerar um link seguro para apresentação do orçamento ao
cliente.

O link poderá ser compartilhado por:

-   WhatsApp;

-   e-mail;

-   outros meios autorizados.

A página deverá ser responsiva e adequada para smartphones.

O cliente deverá visualizar:

-   identificação da oficina;

-   veículo;

-   diagnóstico;

-   serviços;

-   peças;

-   valores;

-   descontos;

-   fotos;

-   observações;

-   validade;

-   condições comerciais.

RN10 --- Aprovação Parcial

O cliente poderá aprovar individualmente determinados itens do
orçamento, quando a configuração da oficina permitir.

Exemplo:

\[APROVADO\] Troca de óleo

\[APROVADO\] Pastilhas

\[REJEITADO\] Amortecedores

\[APROVADO\] Alinhamento

O sistema deverá registrar exatamente quais itens foram aprovados.

RN11 --- Registro da Aprovação

A aprovação deverá registrar:

-   versão do orçamento;

-   itens aprovados;

-   data;

-   hora;

-   situação;

-   identificador da aprovação;

-   usuário interno responsável pelo processamento.

O sistema deverá impedir que uma alteração posterior no orçamento seja
interpretada como aprovação da versão anterior.

7.  MÓDULO DE ORDEM DE SERVIÇO

RN12 --- Abertura da OS

A OS poderá ser criada a partir de:

-   atendimento;

-   diagnóstico;

-   orçamento aprovado;

-   manutenção previamente agendada.

A OS deverá possuir identificador único.

RN13 --- Estados da OS

A OS deverá possuir estados controlados.

Estados sugeridos:

Aguardando Diagnóstico

↓

Em Diagnóstico

↓

Aguardando Aprovação

↓

Aprovada

↓

Aguardando Peças

↓

Em Execução

↓

Aguardando Conferência

↓

Concluída

↓

Aguardando Pagamento

↓

Entregue

Também deverão existir estados excepcionais, como:

-   Cancelada;

-   Suspensa;

-   Aguardando Cliente;

-   Aguardando Fornecedor;

-   Em Garantia.

RN14 --- Controle de Transição

O sistema deverá impedir transições incompatíveis.

Exemplo:

Uma OS entregue não deverá retornar diretamente para "Em Diagnóstico".

Alterações excepcionais deverão exigir:

-   permissão adequada;

-   justificativa;

-   registro em auditoria.

RN15 --- Itens da OS

A OS deverá permitir:

-   serviços;

-   peças;

-   descontos;

-   acréscimos;

-   observações;

-   mecânico responsável;

-   quantidade;

-   preço;

-   situação do item.

8.  MÓDULO DE MECÂNICOS E COMISSÕES

RN16 --- Cadastro de Colaboradores

O sistema deverá permitir cadastro de colaboradores.

Dados:

-   nome;

-   função;

-   contato;

-   situação;

-   percentual ou regra de comissão;

-   permissões relacionadas.

RN17 --- Atribuição de Mão de Obra

Cada serviço executado deverá poder ser vinculado a um ou mais
colaboradores, conforme a regra da oficina.

O sistema deverá registrar:

-   serviço;

-   executor;

-   data;

-   tempo, quando aplicável;

-   valor;

-   percentual de comissão.

RN18 --- Cálculo de Comissão

A comissão deverá ser calculada conforme regras configuráveis.

O percentual aplicável ao serviço deverá ser preservado historicamente
para impedir alterações retroativas.

A comissão poderá possuir situações:

-   Pendente;

-   Calculada;

-   Aprovada;

-   Paga;

-   Cancelada;

-   Estornada.

9.  MÓDULO DE ESTOQUE

RN19 --- Cadastro de Produtos e Peças

O sistema deverá permitir cadastro de:

-   código;

-   descrição;

-   fabricante;

-   categoria;

-   unidade;

-   preço de custo;

-   preço de venda;

-   estoque mínimo;

-   localização;

-   fornecedor;

-   garantia;

-   situação.

RN20 --- Fornecedores

O sistema deverá manter cadastro de fornecedores.

Dados:

-   razão social;

-   nome fantasia;

-   CNPJ;

-   contatos;

-   endereço;

-   condições comerciais;

-   prazo de pagamento;

-   prazo de garantia;

-   observações.

RN21 --- Entrada de Peças

A entrada poderá ocorrer por:

-   lançamento manual;

-   XML de documento fiscal;

-   documento importado;

-   processo integrado, quando disponível.

O sistema deverá registrar:

-   fornecedor;

-   documento;

-   data;

-   quantidade;

-   custo;

-   lote, quando aplicável;

-   procedência;

-   usuário responsável.

RN22 --- Procedência Fiscal

Cada entrada deverá permitir classificação de procedência conforme a
necessidade operacional e contábil da empresa.

Possíveis classificações:

-   Com documento fiscal;

-   Sem documento fiscal;

-   Outras situações parametrizadas.

O sistema deverá manter a informação para auditoria.

RN23 --- Movimentação de Estoque

Toda movimentação deverá gerar histórico.

Tipos:

-   Entrada;

-   Saída;

-   Reserva;

-   Cancelamento de reserva;

-   Aplicação;

-   Devolução;

-   Perda;

-   Ajuste;

-   Transferência;

-   Baixa.

Cada movimentação deverá registrar:

-   produto;

-   quantidade;

-   data;

-   usuário;

-   origem;

-   destino;

-   OS relacionada, quando aplicável;

-   motivo.

RN24 --- Reserva de Peças

Peças destinadas a uma OS poderão ser reservadas.

A reserva deverá reduzir a quantidade disponível sem necessariamente
representar uma saída física definitiva.

Exemplo:

Estoque físico: 10

Reservado: 3

Disponível: 7

RN25 --- Aplicação de Peças

Quando uma peça for efetivamente aplicada no veículo, o sistema deverá
registrar:

-   OS;

-   veículo;

-   produto;

-   quantidade;

-   data;

-   responsável.

A aplicação deverá atualizar o estoque.

RN26 --- Devolução de Peças

Peças não utilizadas poderão ser devolvidas ao estoque.

O sistema deverá registrar a origem da devolução e atualizar a
quantidade disponível.

10. MÓDULO DE GARANTIAS

RN27 --- Cadastro de Garantias

O sistema deverá permitir registrar garantias relacionadas a:

-   peças;

-   serviços;

-   fornecedores;

-   fabricantes;

-   OS.

Os prazos deverão ser parametrizáveis.

RN28 --- Garantia Final

O sistema deverá registrar separadamente:

-   garantia da peça;

-   garantia do serviço;

-   condições aplicáveis;

-   data inicial;

-   data final;

-   origem da garantia.

A definição da garantia comercial deverá respeitar as regras
estabelecidas pela oficina e sua orientação jurídica/contábil.

O sistema não deverá presumir automaticamente que a menor ou maior
garantia seja sempre a aplicável.

RN29 --- Atendimento em Garantia

O sistema deverá permitir abertura de ocorrência de garantia.

A ocorrência poderá conter:

-   OS original;

-   veículo;

-   cliente;

-   peça;

-   serviço;

-   motivo;

-   diagnóstico;

-   fotos;

-   fornecedor;

-   situação.

11. MÓDULO MOBILE DO MECÂNICO

RN30 --- Painel Mobile

O sistema deverá disponibilizar interface responsiva para smartphones.

O mecânico deverá visualizar principalmente as OS atribuídas a ele.

RN31 --- Registro Mobile

O mecânico poderá registrar:

-   diagnóstico;

-   observações;

-   serviços;

-   peças;

-   fotos;

-   vídeos, se posteriormente suportados;

-   conclusão de etapas.

RN32 --- QR Code

Cada OS poderá possuir QR Code ou link exclusivo.

Ao acessar:

QR Code

↓

OS específica

↓

Autenticação/autorização

↓

Painel da OS

O QR Code não deverá permitir acesso irrestrito aos dados da oficina.

12. MÓDULO DE FOTOS E LAUDOS

RN33 --- Evidências Fotográficas

O sistema deverá permitir fotografias relacionadas a:

-   entrada;

-   avarias;

-   diagnóstico;

-   peças removidas;

-   peças novas;

-   execução;

-   resultado final;

-   garantia.

As imagens deverão ser vinculadas à OS.

RN34 --- Laudo Técnico

O sistema deverá permitir geração de laudo contendo:

-   identificação do cliente;

-   veículo;

-   OS;

-   diagnóstico;

-   serviços realizados;

-   peças aplicadas;

-   peças removidas;

-   evidências;

-   garantia;

-   responsável;

-   data.

O documento deverá poder ser gerado em PDF.

RN35 --- Termo de Substituição

O sistema deverá gerar documento contendo as peças substituídas e,
quando aplicável, informações sobre a destinação dessas peças.

13. MÓDULO FISCAL

RN36 --- Separação entre Produtos e Serviços

O sistema deverá manter separação estrutural entre:

MERCADORIAS / PEÇAS

SERVIÇOS

Essa separação deverá existir no banco de dados, orçamento, OS,
financeiro e relatórios.

RN37 --- Motor Fiscal Parametrizável

As regras tributárias não deverão ficar rigidamente codificadas no
sistema.

O sistema deverá permitir parametrização conforme:

-   produto;

-   serviço;

-   operação;

-   estabelecimento;

-   classificação fiscal;

-   regras tributárias;

-   período de vigência.

A emissão fiscal deverá ser desacoplada do núcleo da OS.

14. MÓDULO FINANCEIRO

RN38 --- Formas de Pagamento

O sistema deverá permitir:

-   dinheiro;

-   PIX;

-   cartão de débito;

-   cartão de crédito;

-   boleto;

-   outros meios parametrizados.

RN39 --- Parcelamento

Pagamentos poderão ser parcelados.

Cada parcela deverá possuir:

-   valor;

-   vencimento;

-   situação;

-   data de pagamento;

-   forma de pagamento.

RN40 --- Contas a Receber

O sistema deverá permitir acompanhamento de:

-   valores em aberto;

-   vencidos;

-   pagos;

-   parcialmente pagos;

-   cancelados;

-   estornados.

RN41 --- Contas a Pagar

O sistema deverá permitir registrar despesas da oficina.

Exemplos:

-   fornecedores;

-   aluguel;

-   serviços;

-   despesas operacionais;

-   impostos;

-   outras despesas.

RN42 --- Fechamento de Caixa

O sistema deverá permitir:

-   abertura de caixa;

-   entradas;

-   saídas;

-   sangrias;

-   suprimentos;

-   fechamento;

-   conferência.

15. MÓDULO DE RELATÓRIOS

RN43 --- Relatórios Operacionais

Deverão existir relatórios de:

-   OS;

-   serviços;

-   produtividade;

-   mecânicos;

-   veículos;

-   clientes;

-   agenda.

RN44 --- Relatórios Financeiros

Deverão existir relatórios de:

-   faturamento;

-   recebimentos;

-   contas a receber;

-   contas a pagar;

-   inadimplência;

-   formas de pagamento;

-   comissões.

RN45 --- Relatórios de Estoque

Deverão existir:

-   estoque atual;

-   estoque mínimo;

-   movimentações;

-   reservas;

-   peças aplicadas;

-   devoluções;

-   perdas;

-   produtos sem movimentação.

RN46 --- Exportação Contábil

O sistema deverá permitir exportação de informações em formatos
definidos junto ao escritório contábil.

A estrutura deverá ser configurável para futuras alterações.

16. MÓDULO DE DASHBOARD

RN47 --- Dashboard Gerencial

O sistema deverá disponibilizar indicadores como:

-   OS abertas;

-   OS em execução;

-   OS aguardando aprovação;

-   OS aguardando peças;

-   veículos agendados;

-   faturamento;

-   recebimentos;

-   contas vencidas;

-   estoque baixo;

-   garantias próximas do vencimento.

Os indicadores deverão respeitar as permissões do usuário.

17. MÓDULO DE NOTIFICAÇÕES

RN48 --- Notificações

O sistema deverá permitir notificações para eventos relevantes.

Exemplos:

Orçamento criado

↓

Cliente notificado

Orçamento aprovado

↓

Oficina notificada

Peça recebida

↓

Responsável notificado

OS concluída

↓

Cliente notificado

Veículo pronto

↓

Cliente notificado

Os canais poderão incluir:

-   sistema;

-   e-mail;

-   WhatsApp, quando integrado;

-   outros canais futuros.

18. MÓDULO DE USUÁRIOS E PERMISSÕES

RN49 --- Usuários

O sistema deverá permitir cadastro de usuários.

RN50 --- Perfis

Perfis iniciais:

-   Administrador;

-   Gerente;

-   Recepção;

-   Mecânico;

-   Estoquista;

-   Financeiro;

-   Contabilidade;

-   Cliente.

RN51 --- Permissões

As permissões deverão ser configuráveis.

Exemplo:

Mecânico pode:

-   visualizar OS atribuídas;

-   adicionar diagnóstico;

-   adicionar fotos;

-   registrar serviços.

Mecânico não pode:

-   alterar pagamentos;

-   excluir clientes;

-   alterar regras fiscais.

Financeiro pode:

-   visualizar pagamentos;

-   registrar recebimentos;

-   controlar contas.

Financeiro não pode:

-   alterar diagnóstico técnico.

19. MÓDULO DE AUDITORIA

RN52 --- Auditoria

O sistema deverá registrar operações críticas.

Dados:

-   usuário;

-   data;

-   hora;

-   ação;

-   entidade;

-   identificador do registro;

-   valor anterior, quando aplicável;

-   valor posterior;

-   justificativa, quando necessária.

Eventos críticos incluem:

-   alteração de preço;

-   cancelamento de OS;

-   alteração de pagamento;

-   ajuste de estoque;

-   aprovação;

-   alteração de permissões;

-   exclusão lógica;

-   alterações administrativas.

20. LGPD E PRIVACIDADE

RN53 --- Proteção de Dados

O sistema deverá implementar controles compatíveis com a legislação de
proteção de dados aplicável.

Deverão existir mecanismos para:

-   controle de acesso;

-   proteção de dados;

-   finalidade;

-   minimização;

-   rastreabilidade;

-   retenção;

-   correção;

-   exportação quando aplicável;

-   exclusão ou anonimização quando juridicamente aplicável.

RN54 --- Links Públicos

Links enviados aos clientes deverão utilizar tokens seguros.

O sistema deverá permitir:

-   expiração;

-   revogação;

-   controle de versão;

-   invalidação;

-   registro de acesso.

O link não deverá expor diretamente IDs sequenciais ou dados internos
desnecessários.

21. INTEGRAÇÃO COM GOOGLE DRIVE

RN55 --- Armazenamento Documental

O sistema deverá permitir armazenamento de documentos no Google Drive da
oficina.

Arquivos possíveis:

-   fotos;

-   laudos;

-   PDFs;

-   documentos fiscais;

-   XML;

-   comprovantes;

-   relatórios.

RN56 --- Organização dos Arquivos

A estrutura deverá ser organizada automaticamente.

Exemplo:

OFICINA

| 

+-- Clientes

| 

+-- Veiculos

| 

+-- Ordens de Servico

|   \|

|   +-- OS-000001

|       +-- Fotos

|       +-- Laudo

|       +-- Orcamento

|       +-- Documentos

| 

+-- Relatorios

O banco deverá armazenar o identificador do arquivo externo.

RN57 --- Desacoplamento do Drive

A indisponibilidade temporária do Google Drive não deverá impedir o
funcionamento básico da oficina.

O sistema deverá poder:

1.  registrar o documento;

2.  armazenar temporariamente;

3.  tentar sincronizar posteriormente;

4.  informar o status da sincronização.

5.  BACKUP E RECUPERAÇÃO

RN58 --- Backup do Banco

O banco de dados deverá possuir rotina de backup automatizada.

O backup deverá ser armazenado de maneira independente do banco de
produção.

RN59 --- Restauração

O sistema deverá possuir procedimento documentado de recuperação.

Backups deverão ser periodicamente testados.

23. INTEGRAÇÃO COM WHATSAPP

RN60 --- Comunicação

O sistema deverá permitir preparação de mensagens relacionadas a:

-   orçamento;

-   aprovação;

-   confirmação de agendamento;

-   veículo pronto;

-   manutenção;

-   garantia.

A integração deverá utilizar mecanismo oficial quando implementada.

O sistema deverá continuar funcionando caso a integração esteja
temporariamente indisponível.

24. ARQUITETURA DO SISTEMA

A aplicação deverá ser estruturada de forma modular.

Arquitetura recomendada:

FRONTEND WEB/PWA

Desktop / Tablet / Smartphone

| 

v

ASP.NET CORE API

| 

+-----+-----+

|           \|

v v

DOMÍNIO APLICAÇÃO

Regras Casos de uso

|           \|

+-----+-----+

| 

v

INFRAESTRUTURA

|       \| \|

Banco Drive Integrações

25. ESTRUTURA DE DADOS

O banco deverá contemplar, entre outras, entidades equivalentes a:

Cliente

Endereco

Contato

Veiculo

Agendamento

Box

ChecklistEntrada

Orcamento

OrcamentoItem

OrcamentoVersao

OrcamentoAprovacao

OrdemServico

OrdemServicoItem

OrdemServicoStatus

OrdemServicoHistorico

Funcionario

Comissao

ComissaoLancamento

Produto

CategoriaProduto

Fornecedor

ProdutoFornecedor

Estoque

MovimentacaoEstoque

ReservaEstoque

Servico

CategoriaServico

Diagnostico

Foto

Laudo

Documento

Garantia

GarantiaPeca

GarantiaServico

OcorrenciaGarantia

Pagamento

Parcela

ContaReceber

ContaPagar

Caixa

Usuario

Perfil

Permissao

Notificacao

Auditoria

Arquivo

ArquivoIntegracao

Os nomes definitivos das tabelas poderão ser definidos durante a
elaboração do modelo físico.

26. REQUISITOS NÃO FUNCIONAIS

RNF01 --- Responsividade

O sistema deverá funcionar em:

-   smartphones;

-   tablets;

-   notebooks;

-   desktops.

RNF02 --- Compatibilidade

A aplicação deverá ser compatível com navegadores modernos.

RNF03 --- Segurança

Deverá implementar:

-   HTTPS;

-   autenticação;

-   autorização;

-   senhas armazenadas de forma segura;

-   controle de sessão;

-   proteção contra acesso indevido;

-   validação de entrada;

-   proteção contra vulnerabilidades comuns.

RNF04 --- Controle de Acesso

Toda API deverá validar autenticação e autorização antes de permitir
operações protegidas.

A interface não deverá ser considerada mecanismo de segurança.

RNF05 --- Performance

As telas de uso frequente deverão apresentar tempo de resposta adequado
para a operação normal da oficina.

Consultas pesadas deverão utilizar:

-   paginação;

-   filtros;

-   índices;

-   consultas otimizadas.

RNF06 --- Escalabilidade

A arquitetura deverá permitir crescimento de:

-   usuários;

-   clientes;

-   veículos;

-   OS;

-   documentos;

-   unidades.

RNF07 --- Disponibilidade

Falhas em integrações externas não deverão derrubar o núcleo da
aplicação.

RNF08 --- Auditoria

Operações críticas deverão ser rastreáveis.

RNF09 --- Acessibilidade

A interface deverá seguir boas práticas de acessibilidade e buscar
conformidade com as diretrizes WCAG aplicáveis.

RNF10 --- PWA

A aplicação deverá ser preparada para funcionamento como Progressive Web
App, permitindo instalação em dispositivos compatíveis.

27. MULTIEMPRESA E MULTIUNIDADE

A arquitetura deverá ser preparada para futura expansão.

Estrutura conceitual:

Empresa

| 

+-- Unidade

| 

+-- Usuários

| 

+-- Clientes

| 

+-- Veículos

| 

+-- Estoque

| 

+-- Ordens de Serviço

Mesmo que inicialmente exista apenas uma oficina, o modelo deverá evitar
decisões que impossibilitem essa expansão.

28. INTEGRIDADE E HISTÓRICO

Registros críticos não deverão ser fisicamente apagados de forma
indiscriminada.

Deverá ser utilizado, quando apropriado:

-   inativação;

-   cancelamento;

-   arquivamento;

-   exclusão lógica;

-   histórico.

Registros financeiros, fiscais, auditoria, estoque e aprovações deverão
preservar rastreabilidade.

29. REGRAS PARA CANCELAMENTO

O sistema deverá diferenciar:

-   Exclusão;

-   Cancelamento;

-   Estorno;

-   Inativação;

-   Arquivamento.

Esses conceitos não deverão ser tratados como uma única operação.

30. FLUXO OPERACIONAL COMPLETO

CLIENTE

↓

VEÍCULO

↓

AGENDAMENTO

↓

CHECKLIST DE ENTRADA

↓

DIAGNÓSTICO

↓

ORÇAMENTO

↓

VERSIONAMENTO

↓

APROVAÇÃO DIGITAL

↓

RESERVA DE ESTOQUE

↓

ORDEM DE SERVIÇO

↓

EXECUÇÃO MOBILE

↓

FOTOS / EVIDÊNCIAS

↓

APLICAÇÃO DE PEÇAS

↓

CONFERÊNCIA

↓

LAUDO

↓

FATURAMENTO

↓

PAGAMENTO

↓

ENTREGA

↓

HISTÓRICO DO VEÍCULO

↓

GARANTIA

31. FLUXO DE EXCEÇÃO

Cliente não aprova:

Orçamento

↓

Rejeitado

↓

Motivo

↓

Encerramento ou revisão

Cliente solicita alteração:

Orçamento

↓

Solicitação

↓

Nova versão

↓

Nova aprovação

Peça indisponível:

OS

↓

Aguardando peça

↓

Pedido fornecedor

↓

Entrada

↓

Reserva

↓

Execução

Peça devolvida:

Peça reservada

↓

Não utilizada

↓

Devolução

↓

Estoque disponível

Serviço em garantia:

Cliente

↓

Ocorrência

↓

Análise

↓

Garantia aprovada/rejeitada

↓

Nova execução

↓

Histórico

32. MVP RECOMENDADO

O primeiro ciclo de desenvolvimento deverá priorizar:

Fase 1 --- Núcleo

-   autenticação;

-   usuários;

-   clientes;

-   veículos;

-   serviços;

-   produtos;

-   fornecedores.

Fase 2 --- Operação

-   agenda;

-   checklist;

-   orçamento;

-   aprovação;

-   OS;

-   status.

Fase 3 --- Oficina

-   painel mobile;

-   diagnóstico;

-   fotos;

-   serviços;

-   peças;

-   estoque;

-   reserva.

Fase 4 --- Finalização

-   laudo;

-   garantia;

-   faturamento;

-   pagamentos;

-   histórico.

Fase 5 --- Gestão

-   dashboard;

-   relatórios;

-   comissões;

-   contas a pagar;

-   contas a receber.

Fase 6 --- Integrações

-   Google Drive;

-   WhatsApp;

-   e-mail;

-   integrações fiscais.

33. FUNCIONALIDADES FUTURAS

O sistema poderá futuramente receber:

-   aplicativo nativo;

-   integração com fornecedores;

-   consulta automática de disponibilidade de peças;

-   leitura automatizada de documentos;

-   OCR;

-   inteligência artificial para auxílio na classificação de documentos;

-   lembretes de manutenção;

-   campanhas de retorno de clientes;

-   programa de fidelidade;

-   pesquisa de satisfação;

-   assinatura digital avançada;

-   múltiplas unidades;

-   integração com equipamentos de diagnóstico;

-   indicadores avançados.

Essas funcionalidades não fazem parte do núcleo obrigatório da versão
inicial.

34. CRITÉRIOS DE ACEITAÇÃO GERAIS

O sistema será considerado funcional quando for capaz de executar o
ciclo:

Cadastrar cliente

↓

Cadastrar veículo

↓

Criar orçamento

↓

Enviar link

↓

Cliente aprovar

↓

Criar OS

↓

Reservar peças

↓

Mecânico executar

↓

Registrar fotos

↓

Finalizar serviços

↓

Gerar laudo

↓

Registrar pagamento

↓

Entregar veículo

↓

Atualizar histórico

Todas as etapas deverão manter consistência dos dados e rastreabilidade.

35. CONSIDERAÇÕES FINAIS

A versão 4.0 deste documento estabelece uma base completa para
desenvolvimento de um sistema de gestão de oficina mecânica.

A solução deverá ser construída de maneira modular, segura e extensível,
evitando acoplamento excessivo entre o núcleo da aplicação e integrações
externas.

O banco de dados deverá representar corretamente os relacionamentos
entre:

-   clientes;

-   veículos;

-   orçamentos;

-   aprovações;

-   ordens de serviço;

-   funcionários;

-   peças;

-   estoque;

-   fornecedores;

-   garantias;

-   documentos;

-   pagamentos;

-   usuários;

-   auditoria.

As regras tributárias e demais integrações que dependam de legislação ou
serviços externos deverão ser parametrizáveis e desacopladas.

O Google Drive deverá ser utilizado como mecanismo de armazenamento
documental, não como substituto do banco de dados ou como única
estratégia de backup.

A aplicação deverá priorizar a experiência de uso da recepção no desktop
e dos mecânicos no smartphone, mantendo a mesma base de dados e regras
de negócio.

A partir deste documento, o projeto estará preparado para avançar para
as próximas etapas técnicas:

ERN 4.0

↓

Casos de Uso

↓

Regras Detalhadas

↓

Modelo Conceitual do Banco

↓

Modelo Entidade-Relacionamento

↓

Modelo Físico do Banco

↓

Arquitetura .NET

↓

Contrato da API

↓

Estrutura do Frontend

↓

Implementação do MVP

↓

Testes

↓

Homologação

↓

Produção

Status recomendado: APROVADO COMO BASE PARA PROJETO TÉCNICO,
condicionado ao detalhamento dos casos de uso, modelo de dados, regras
fiscais específicas e critérios de aceitação de cada módulo.
