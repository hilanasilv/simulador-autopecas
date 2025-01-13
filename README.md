<h1 align="center">Simulator Télos Nível 8 - Object-Relational Mapping 🚀</h1>

## **1. Visão Geral**

Este projeto é um **Simulador de Gerenciamento de Autopeças**, desenvolvido em **Windows Forms** com .NET Framework 4.8. Ele permite gerenciar um estoque de peças de veículos, realizar consultas, simular vendas, e registrar informações no banco de dados utilizando o ORM **NHibernate**.

O sistema segue a **arquitetura em camadas**:

- **UI (Interface Gráfica):** Gerencia a interação do usuário.
- **Controller (Negócios):** Contém a lógica e validações.
- **Data (Dados):** Responsável pela comunicação com o banco de dados SQL Server.

---

## **2. Funcionalidades**

### 2.1 **Cadastro de Peças**

Permite incluir novas peças no sistema com informações detalhadas, como:

- Nome da peça
- Fabricante
- Tipo de veículo
- Categoria
- Preço de compra e venda

### 2.2 **Consulta de Peças**

Permite buscar peças pelo **ID** ou pelo **nome**. O sistema exibe as informações revelantes sobre a peça.

### 2.3 **Edição de Peças**

Permite atualizar as informações de uma peça cadastrada, exceto o **ID**.

### 2.4 **Exclusão de Peças**

Realiza uma exclusão lógica (**soft delete**), alterando o status da peça com a data de exclusão, sem removê-la do banco de dados.

### 2.5 **Simulação de Venda**

Permite registrar a venda de uma peça:

- Atualiza o status de disponibilidade da peça.
- Registra o **ID da peça** e o **valor real de venda** (considerando possíveis descontos) em uma tabela de vendas.

### 2.6 **Interface Gráfica**

A interface é intuitiva, com menus e botões claros para cada funcionalidade, permitindo navegação simples.

---

## **3. Tecnologias Utilizadas**

- **.NET Framework 4.8** (Windows Forms)
- **C#**
- **NHibernate** (ORM)
- **SQL Server** (banco de dados relacional)
- **LINQ** (consultas no banco de dados)

---

## **4. Estrutura do Projeto**

### 4.1 **Camada de Apresentação (UI)**

Localização: `/UI`

- Contém os formulários Windows Forms, como:
    - `MainForm`: Tela inicial do sistema, com consulta de peças.
    - `FormCadastro`: Tela de cadastro de peças.
    - `FormEditar`: Tela para editar peças.
    - `FormExcluir`: Tela para exclusão de peças.
    - `FormVender`: Tela para simulação de vendas.

### 4.2 **Camada de Negócios**

Localização: `/Controllers`

- Contém a lógica de negócios e validações, como:
    - `PecaController`: Gerencia operações de peças.
    - `VendaController`: Gerencia operações de vendas.

### 4.3 **Camada de Dados (Data)**

Localização: `/Data`

- Contém:
    - **/Models:** Representações das tabelas (`Peca.cs`, `Venda.cs`).
    - **/Repositories:** Acesso aos dados (`PecaRepository.cs`, `VendaRepository.cs`).
    - **/Mappings:** Arquivos de mapeamento (`Peca.hbm.xml`, `Venda.hbm.xml`)
    - **NHibernateHelper:**
   
* O Arquivo de configuração principal do NHibernate é `Program.cs`.

### 4.4 **Arquivos do Banco de dados**

Localização: `/Database`

- Contém: 
   - **Arquivo SQL** `autopecassqlserver.sql`

---

## **5. Requisitos do Sistema**

- **Visual Studio**
- **SQL Server** instalado e configurado
- **.NET Framework 4.8**

---

## **6. Configuração Inicial**

### 6.1 **Clonando o Repositório**

1. Clone o repositório no Visual Studio:
    
    ```bash
    git clone https://github.com/hilanasilv/simulador-autopecas.git
    
    ```
    
2. Abra o arquivo de solução (`.sln`) no Visual Studio.

#

<p align=center>Desenvolvido por Nayla Hilana</p>