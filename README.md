---
title: Relationships in C#
description: Practical exercises on relationships in C#
author: Luis Guisso
ms.date: ago. 17, 2025
---

# Relationships in C#

## Introduction

I present practical exercises on one-to-one bidirectional relationships in C# validated by unit tests.

Always make the UML class diagram before the implementation.

## 1. Gerenciamento de Carteiras de Motorista

### Contexto

Um departamento de trânsito precisa gerenciar carteiras de motorista emitidas para cidadãos. Cada cidadão possui exatamente uma carteira de motorista, e cada carteira está associada a apenas um cidadão. O sistema deve registrar e consultar informações como número da carteira, data de validade e dados pessoais do cidadão.

### Entidades e Relacionamento

Entidade 1: Cidadão (atributos: CPF, nome {máximo de 45 caracteres}, data de nascimento {somente cidadãos com mais de 18 anos}).

Entidade 2: CarteiraMotorista (atributos: número, categoria {A, B, C, D ou E}, data de emissão {'emissao', presente ou passada}, data de validade {'validade', qualquer data}). Deve conter o método isValida():Boolean que informe, se a carteira está válida (não vencida) ou inválida (vencida, ou seja, com uma data passada).

Relacionamento: Um cidadão possui exatamente uma CarteiraMotorista e uma CarteiraMotorista pertence a apenas um Cidadão. O relacionamento é bidirecional.

**Observações**

- Todos os atributos devem ser obrigatórios;
- A data de validade, por padrão, é de 5 anos após a obtenção, mas pode ser modificada para casos especiais;
- A data de emissão não pode ser futura e a data de validade não pode ser anterior à data de emissão;
- A categoria deve ser uma enumeração com os valores A, B, C, D ou E;
- O CPF deve ser numérico e deve seguir o formato brasileiro (11 dígitos);
- O nome não pode exceder 45 caracteres;
- A data de nascimento deve ser válida e o cidadão deve ter mais de 18 anos para obter a carteira.

### Implementação e Testes

Codifique as classes indicadas seguindo as convenções C# já abordadas em sala **empregando propriedades** e aplique seus próprios testes para validação da implementação.

Após realizar seus testes, execute o teste automatizado, que foi preparado por mim, pressionando **CTRL+R, A**. Cada teste possui um nome próprio para verificação de cada aspecto solicitado.

### Enumerações

Valores fixos e conhecidos podem ser representados por enumerações, cujo código de exemplo é apresentado a seguir. Deve ser criado um arquivo próprio para conter a enumeração.

Assim, uma propriedade que deseja ser deste tipo deve ser declarada como ```public Categoria Categoria { get; set}``` e os valores podem ser atribuídos com ```objeto.Categoria = Categoria.A;```.

```cs
using System;

namespace SeuNamespaceAqui
{
    public enum Categoria {
            A, B, C, D, E
        }
    }
}
```

## 2. Gerenciamento de Contas Bancárias

### Contexto

Um banco oferece contas correntes individuais, onde cada cliente possui exatamente uma conta principal e cada conta está vinculada a apenas um cliente. O sistema deve gerenciar informações do cliente e da conta, como saldo e transações, para fins de auditoria e atendimento.

### Entidades e Relacionamento

Entidade 1: Cliente (atributos: CPF, nome, telefone {ex.: 5538912341234}).

Entidade 2: ContaBancaria (atributos: número da conta {'numero'}, saldo {pode ser negativo até o limite máximo apresentado}, limite negativo {'limite' como valor positivo}, data de abertura {'abertura'}).

Relacionamento: Um Cliente possui exatamente uma ContaBancaria e uma ContaBancaria pertence a apenas um Cliente. O relacionamento é bidirecional.

**Observações**

- Todos os atributos devem ser obrigatórios, ou seja, não são permitidos nulos;
- O CPF deve ser numérico e deve obedecer ao padrão, mas não precisa ser um CPF válido segundo as regras;
- O nome não pode ser vazio e não pode ter mais do que 45 caracteres;
- O número de telefone deve conter o DDI (00 ou 000), o DDD (00) e o número propriamente dito (000000000);
- O número da conta deve conter exatamente 8 dígitos e não são permitidos zeros à esquerda;
- Saques que deixem o saldo abaixo do limite permitido não são permitidos;
- O limite não pode ser um valor negativo;
- A data de abertura não pode ser futura, mas pode ser o dia atual;
- Não pode ocorrer depósito sem que haja um saldo inicial definido, ainda que seja zero;
- Não é permitido realizar saques sem que haja um limite já definido;
- Mesmo que haja limite definido, não é permitido realizar saques que deixem o saldo abaixo do limite negativo;
- Para todas as operações de saque e depósito, as exceções a serem lançadas devem ser do tipo InvalidOperationException.

### Implementação e Testes

Codifique as classes indicadas seguindo as convenções C# já abordadas em sala **empregando propriedades** e aplique seus próprios testes para validação da implementação.

Após realizar seus testes, execute o teste automatizado, que foi preparado por mim, pressionando **CTRL+R, A**. Cada teste possui um nome próprio para verificação de cada aspecto solicitado.
