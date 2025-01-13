-- Criação da tabela Pecas
CREATE TABLE Pecas (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Identificador único da peça, auto incremento
    Nome NVARCHAR(50) NOT NULL, -- Nome da peça
    Fabricante NVARCHAR(50) NOT NULL, -- Nome do fabricante
    TipoVeiculo NVARCHAR(50) NOT NULL, -- Tipo de veículo
    Categoria NVARCHAR(50) NOT NULL, -- Categoria da peça
    PrecoCompra DECIMAL(18, 2) NOT NULL, -- Preço de compra da peça
    PrecoVenda DECIMAL(18, 2) NOT NULL, -- Preço de venda da peça
    Disponivel VARCHAR(3) NOT NULL, -- Disponibilidade (sim = disponível, não = não disponível)
    Status VARCHAR(50) NOT NULL -- Status para soft delete ("ativo" ou data de exclusão) 
);

-- Inserção de dados
INSERT INTO Pecas (Nome, Fabricante, TipoVeiculo, Categoria, PrecoCompra, PrecoVenda, Disponivel, Status)
VALUES
    ('Filtro de Óleo', 'Bosch', 'Carro', 'Motor', 20.00, 35.00, 'sim', 'ativo'),
    ('Pastilhas de Freio', 'Brembo', 'Moto', 'Freio', 80.00, 120.00, 'sim', 'ativo'),
    ('Pneus', 'Goodyear', 'Carro', 'Rodas e Pneus', 400.00, 600.00, 'não', 'ativo');

-- Criação da tabela Venda
CREATE TABLE Venda (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador único da venda, auto incremento
    IdPeca INT NOT NULL,                -- Referência à peça vendida
    ValorVenda DECIMAL(18, 2) NOT NULL, -- Valor real da venda
    DataVenda DATETIME NOT NULL DEFAULT GETDATE(), -- Data da venda
    CONSTRAINT FK_Venda_Peca FOREIGN KEY (IdPeca) REFERENCES Pecas(Id) -- Relacionamento com a tabela Pecas
);

-- Criação da trigger para atualizar a disponibilidade
CREATE TRIGGER AtualizarDisponibilidadeVenda
ON Venda
AFTER INSERT
AS
BEGIN
    -- Atualiza a disponibilidade para 'não' da peça vendida
    UPDATE Pecas
    SET Disponivel = 'não'
    FROM Pecas p
    INNER JOIN inserted i ON p.Id = i.IdPeca
END;
