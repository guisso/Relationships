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

Um departamento de tr�nsito precisa gerenciar carteiras de motorista emitidas para cidad�os. Cada cidad�o possui exatamente uma carteira de motorista, e cada carteira est� associada a apenas um cidad�o. O sistema deve registrar e consultar informa��es como n�mero da carteira, data de validade e dados pessoais do cidad�o.

### Entidades e Relacionamento

Entidade 1: Cidad�o (atributos: CPF, nome {m�ximo de 45 caracteres}, data de nascimento {somente cidad�os com mais de 18 anos}).

Entidade 2: CarteiraMotorista (atributos: n�mero, categoria {A, B, C, D ou E}, data de emiss�o {'emissao', presente ou passada}, data de validade {'validade', qualquer data}). Deve conter o m�todo isValida():Boolean que informe, se a carteira est� v�lida (n�o vencida) ou inv�lida (vencida, ou seja, com uma data passada).

Relacionamento: Um cidad�o possui exatamente uma CarteiraMotorista e uma CarteiraMotorista pertence a apenas um Cidad�o. O relacionamento � bidirecional.

**Observa��es**

- Todos os atributos devem ser obrigat�rios;
- A data de validade, por padr�o, � de 5 anos ap�s a obten��o, mas pode ser modificada para casos especiais;
- A data de emiss�o n�o pode ser futura e a data de validade n�o pode ser anterior � data de emiss�o;
- A categoria deve ser uma enumera��o com os valores A, B, C, D ou E;
- O CPF deve ser num�rico e deve seguir o formato brasileiro (11 d�gitos);
- O nome n�o pode exceder 45 caracteres;
- A data de nascimento deve ser v�lida e o cidad�o deve ter mais de 18 anos para obter a carteira.

### Implementa��o e Testes

Codifique as classes indicadas seguindo as conven��es C# j� abordadas em sala **empregando propriedades** e aplique seus pr�prios testes para valida��o da implementa��o.

Ap�s realizar seus testes, execute o teste automatizado, que foi preparado por mim, pressionando **CTRL+R, A**. Cada teste possui um nome pr�prio para verifica��o de cada aspecto solicitado.

### Enumera��es

Valores fixos e conhecidos podem ser representados por enumera��es, cujo c�digo de exemplo � apresentado a seguir. Deve ser criado um arquivo pr�prio para conter a enumera��o.

Assim, uma propriedade que deseja ser deste tipo deve ser declarada como ```public Categoria Categoria { get; set}``` e os valores podem ser atribu�dos com ```objeto.Categoria = Categoria.A;```.

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

## 2. Gerenciamento de Contas Banc�rias

### Contexto

Um banco oferece contas correntes individuais, onde cada cliente possui exatamente uma conta principal e cada conta est� vinculada a apenas um cliente. O sistema deve gerenciar informa��es do cliente e da conta, como saldo e transa��es, para fins de auditoria e atendimento.

### Entidades e Relacionamento

Entidade 1: Cliente (atributos: CPF, nome, telefone {ex.: 5538912341234}).

Entidade 2: ContaBancaria (atributos: n�mero da conta {'numero'}, saldo {pode ser negativo at� o limite m�ximo apresentado}, limite negativo {'limite' como valor positivo}, data de abertura {'abertura'}).

Relacionamento: Um Cliente possui exatamente uma ContaBancaria e uma ContaBancaria pertence a apenas um Cliente. O relacionamento � bidirecional.

**Observa��es**

- Todos os atributos devem ser obrigat�rios, ou seja, n�o s�o permitidos nulos;
- O CPF deve ser num�rico e deve obedecer ao padr�o, mas n�o precisa ser um CPF v�lido segundo as regras;
- O nome n�o pode ser vazio e n�o pode ter mais do que 45 caracteres;
- O n�mero de telefone deve conter o DDI (00 ou 000), o DDD (00) e o n�mero propriamente dito (000000000);
- O n�mero da conta deve conter exatamente 8 d�gitos e n�o s�o permitidos zeros � esquerda;
- Saques que deixem o saldo abaixo do limite permitido n�o s�o permitidos;
- O limite n�o pode ser um valor negativo;
- A data de abertura n�o pode ser futura, mas pode ser o dia atual;
- N�o pode ocorrer dep�sito sem que haja um saldo inicial definido, ainda que seja zero;
- N�o � permitido realizar saques sem que haja um limite j� definido;
- Mesmo que haja limite definido, n�o � permitido realizar saques que deixem o saldo abaixo do limite negativo;
- Para todas as opera��es de saque e dep�sito, as exce��es a serem lan�adas devem ser do tipo InvalidOperationException.

### Implementa��o e Testes

Codifique as classes indicadas seguindo as conven��es C# j� abordadas em sala **empregando propriedades** e aplique seus pr�prios testes para valida��o da implementa��o.

Ap�s realizar seus testes, execute o teste automatizado, que foi preparado por mim, pressionando **CTRL+R, A**. Cada teste possui um nome pr�prio para verifica��o de cada aspecto solicitado.
